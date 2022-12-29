using AutoMapper;
using BusinessObject.Entity;
using ClinicManageAPI.DTO;

namespace ClinicManageAPI.MapperConfig
{
    public class ClinicManageProfile : Profile
    {
        public ClinicManageProfile()
        {
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, UserInfoDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, DoctorInfoDTO>().ReverseMap();
            CreateMap<User, NurseInfoDTO>().ReverseMap();
            CreateMap<Doctor, DoctorInfoDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Medicine, MedicineDTO>().ReverseMap();
        }
    }
}
