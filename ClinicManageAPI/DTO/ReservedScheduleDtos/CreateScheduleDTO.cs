using ClinicManageAPI.DTO.AppointmentDtos;
using System;

namespace ClinicManageAPI.DTO.ReservedScheduleDtos
{
    public class CreateScheduleDTO
    {
        public int DocId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
