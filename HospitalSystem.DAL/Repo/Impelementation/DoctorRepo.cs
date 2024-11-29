using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using SH.DAL.Repo.Abstracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.DAL.Repo.Implemintation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly AppDbContext entitiy;

        public DoctorRepo(AppDbContext entitiy)
		{
			this.entitiy = entitiy;
        }
		bool IDoctorRepo.Create(Doctor doc)
		{
			try
			{
                entitiy.Doctors.Add(doc);
				entitiy.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		bool IDoctorRepo.Delete(Doctor doc)
		{
			try
			{
				var data = entitiy.Doctors.Where(e => e.Id == doc.Id).FirstOrDefault();
				data.IsDelete = !data.IsDelete;
				entitiy.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		bool IDoctorRepo.Edit(Doctor doc)
		{
			try
			{
				var data = entitiy.Doctors.Where(d => d.Id == doc.Id).FirstOrDefault();
				data.FullName = doc.FullName;
				data.Address = doc.Address;
				data.PhoneNumber = doc.PhoneNumber;
				data.Email = doc.Email;
				data.Gender = data.Gender;
				data.Specialization = data.Specialization;
				entitiy.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		Doctor IDoctorRepo.GetById(int id)
		{
			return entitiy.Doctors.Where(e => e.Id == id).FirstOrDefault();
		}

		List<Doctor> IDoctorRepo.GetDoctors()
		{
			return entitiy.Doctors.ToList();
		}
    }

}
