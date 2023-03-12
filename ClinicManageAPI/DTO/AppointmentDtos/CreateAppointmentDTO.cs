﻿using ClinicManageAPI.DTO.ReservedScheduleDtos;
using System.Collections.Generic;

namespace ClinicManageAPI.DTO.AppointmentDtos
{
    public class CreateAppointmentDTO
    {
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public CreateScheduleDTO Schedule { get; set; }
        public List<CreateAppointmentDetailsDTO> AppointmentDetails { get; set; }
    }
}
