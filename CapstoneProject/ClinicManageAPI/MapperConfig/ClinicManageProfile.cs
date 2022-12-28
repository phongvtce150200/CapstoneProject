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
        }
    }
}
