﻿using AutoMapper;
using BusinessObject.Entity;
using ClinicManageAPI.DTO.AppointmentDtos;
using ClinicManageAPI.DTO.AuthenticationDtos;
using ClinicManageAPI.DTO.DoctorDtos;
using ClinicManageAPI.DTO.MedicineDtos;
using ClinicManageAPI.DTO.NurseDtos;
using ClinicManageAPI.DTO.PatientDtos;
using ClinicManageAPI.DTO.QueueDtos;
using ClinicManageAPI.DTO.ReservedScheduleDtos;
using ClinicManageAPI.DTO.ServiceDtos;
using ClinicManageAPI.DTO.UserDtos;

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
            CreateMap<Nurse, NurseInfoDTO>().ReverseMap();
            CreateMap<Doctor, DoctorInfoDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Medicine, MedicineDTO>().ReverseMap();
            CreateMap<Medicine, CreateMedicineDTO>().ReverseMap();
            CreateMap<Medicine, EditMedicineDTO>().ReverseMap();
            CreateMap<Queue, QueueDTO>().ReverseMap();
            CreateMap<Queue, GetQueueDTO>().ReverseMap();
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<CreateDoctorDTO, User>().ReverseMap();
            CreateMap<CreateDoctorInfoDTO, Doctor>().ReverseMap();
            CreateMap<CreateNurseDTO, User>().ReverseMap();
            CreateMap<CreateNurseInfoDTO, Nurse>().ReverseMap();
            CreateMap<AppointmentDTO, Appointment>().ReverseMap();
            CreateMap<ReservedScheduleInfoDTO, ReservedSchedule>().ReverseMap();
        }
    }
}
