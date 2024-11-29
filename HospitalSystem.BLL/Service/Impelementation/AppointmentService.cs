using HospitalSystem.BLL.Service.Abstraction;
using HospitalSystem.DAL.Entity;
using HospitalSystem.DAL.Repo.Abstracion;

namespace HospitalSystem.BLL.Service.Implemintation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo AppointmentRepo;
        public AppointmentService(IAppointmentRepo AppointmentRepo)
        { this.AppointmentRepo = AppointmentRepo; }

        public List<Room> GetAllRooms()
        { return AppointmentRepo.GetAllRooms(); }
        public RoomAvailability? BookRoom(Room room, DateTime date, TimeSpan time, string PatientId, int DoctorId)
        {
            var result = AppointmentRepo.BookRoom(room, date, time, PatientId, DoctorId);
            return result;
        }
        public List<Bill> GetMyBills(string PatientId)
        {
            return AppointmentRepo.GetMyBills(PatientId);
        }
    }
}