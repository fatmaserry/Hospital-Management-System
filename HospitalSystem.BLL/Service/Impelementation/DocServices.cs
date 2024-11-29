using AutoMapper;
using HospitalSystem.BLL.Helper;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using SH.BLL.ModelVm;
using SH.BLL.Services.Abstraction;
using SH.DAL.Repo.Abstracion;



namespace SH.BLL.Services.implemintation
{
    public class DocServices : IDocServices
    {
        private readonly IDoctorRepo dectorRepo;
        private readonly IMapper mapper;

        public DocServices(IDoctorRepo dectorRepo , IMapper mapper)
        {
            this.dectorRepo = dectorRepo;
            this.mapper = mapper;
        }

        bool IDocServices.Create(CreateDocVM createDocVM)
        {
           createDocVM.Image= UploadImage.UploadFile("DProfile",createDocVM.ImageName );
            var data=mapper.Map<Doctor>(createDocVM);
            return dectorRepo.Create(data);
        }

        bool IDocServices.Delete(DeleteDocVM deleteDocVM)
        {
            var data = mapper.Map<Doctor>(deleteDocVM);
            return dectorRepo.Delete(data);
        }

        bool IDocServices.Edit(EditDocVM editDocVM)
        {
            var data = mapper.Map<Doctor>(editDocVM);
            return dectorRepo.Edit(data);
        }

        List<GetAllDoctorsVM> IDocServices.GetAllDoctors()
        {
           var data= dectorRepo.GetDoctors();
            var newData = mapper.Map<List<GetAllDoctorsVM>>(data);
            return newData;

        }

        GetByIdDocVM IDocServices.GetByIdDocVM(int id)
        {
           var data=dectorRepo.GetById(id);
            var newdata = mapper.Map<GetByIdDocVM>(data);
            return newdata; 
        }

        public async Task<string> GetDoctorRoleIdAsync(RoleManager<IdentityRole> roleManager)
        {
            var doctorRole = await roleManager.FindByNameAsync("Doctor");
            return doctorRole?.Id;
        }
    }
}
