using System.ComponentModel.DataAnnotations;
using System;

namespace ClinicManageAPI.DTO.ReservedScheduleDtos
{
    public class ReservedScheduleInfoDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
