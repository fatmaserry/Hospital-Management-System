using HospitalSystem.DAL.DB;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstracion;
using System.Security.Claims;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HospitalSystem.DAL.Repo.Implemintation
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppDbContext db;
        public AppointmentRepo(AppDbContext db)
        {
            this.db = db;
        }
        public List<Room> GetAllRooms()
        {
            return db.Rooms.ToList();
        }
        public RoomAvailability? BookRoom(Room room, DateTime date, TimeSpan time, string PatientId, int DoctorId)
        {

            // Check if this specific availability already exists
            var existingAvailability = db.RoomAvailabilities
                .Where(ra => ra.RoomID == room.ID && ra.Date == date && ra.Time == time)
                .OrderByDescending(ra => ra.ID)
                .FirstOrDefault();



            if (existingAvailability == null)
            {
                var roomAvailability = new RoomAvailability
                {
                    RoomID = room.ID,
                    Date = date,
                    Time = time,
                    AvailablePlaces = room.Capacity - 1,
                    PatientID = PatientId
                };
                var bill = new Bill
                {
                    Amount = 250,
                    PaymentDate = DateTime.Now,
                    PatientID = PatientId,
                    RoomAvailability = roomAvailability
                };

                var appointment = new Appointment
                {
                    PatientID = PatientId,
                    DoctorID = DoctorId,
                    RoomAvailability = roomAvailability,
                    Date = date,
                    Time = time,
                };
                db.RoomAvailabilities.Add(roomAvailability);
                db.Bills.Add(bill);
                db.Appointments.Add(appointment);
                db.SaveChanges();
                
                return roomAvailability;
            }
            else if (existingAvailability.AvailablePlaces == 0)
            {
                return null;
            }
            else
            {
                var roomAvailability = new RoomAvailability
                {
                    RoomID = room.ID,
                    Date = date,
                    Time = time,
                    AvailablePlaces = existingAvailability.AvailablePlaces - 1
                };
                var bill = new Bill
                {
                    Amount = 250,
                    PaymentDate = DateTime.Now,
                    PatientID = PatientId,
                    RoomAvailability = roomAvailability
                };
                var appointment = new Appointment
                {
                    PatientID = PatientId,
                    DoctorID = DoctorId,
                    RoomAvailability = roomAvailability,
                    Date = date,
                    Time = time,
                };
                db.RoomAvailabilities.Add(roomAvailability);
                db.Bills.Add(bill);
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return roomAvailability;
            }
        }

        public List<Bill> GetMyBills(string patientId)
        {
           return db.Bills.Where(b => b.PatientID == patientId).ToList();
        }
    }
    }

