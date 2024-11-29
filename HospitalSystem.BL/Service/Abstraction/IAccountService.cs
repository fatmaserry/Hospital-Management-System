using HospitalSystem.BLL.ModelVM.Account;
using HospitalSystem.BLL.ModelVM.Patient;
using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace HospitalSystem.BLL.Service.Abstraction
{
    public interface IAccountService
    {
        Task<PatientProfileVM> GetProfile(ClaimsPrincipal user);
        Task<EditePatientVM> GetPatientForEdit(ClaimsPrincipal user);
        Task<PatientVM> GetPatientForMoreInfo(ClaimsPrincipal user);
        Task<IdentityResult> UpdatePatient(ClaimsPrincipal user, EditePatientVM model);
        Task<Patient> GetCurrentPatient(ClaimsPrincipal user);
        Task<IdentityResult> DeletePatientAccount(ClaimsPrincipal user);
        Task<IdentityResult> ChangePassword(ChangePasswordVM model);
        Task<IdentityResult> UpdatePatient(Patient patient);
        Task<SignInResult> Login(LoginVM loginVM);
        Task<IdentityResult> RegisterUserAsync(RegistrationVM registerVM);
        Task Logout();
    }
}
