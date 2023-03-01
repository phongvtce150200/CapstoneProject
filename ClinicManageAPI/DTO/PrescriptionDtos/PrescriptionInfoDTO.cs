using BusinessObject.Entity;
using System;
using System.Collections.Generic;

namespace ClinicManageAPI.DTO.PrescriptionDtos
{
    public class PrescriptionInfoDTO
    {
        public int? IdDoctor { get; set; }
        public int? IdPatient { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<PrescriptionDetails> PrescriptionDetails { get; set; }

    }
}
