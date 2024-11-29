using Microsoft.AspNetCore.Http;


namespace HospitalSystem.BLL.ModelVM.Account
{
    public class ProfileVM
    {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string NationalId { get; set; }
        public string ProfileImage { get; set; }
        public IFormFile NewProfileImage { get; set; }
    }
}
