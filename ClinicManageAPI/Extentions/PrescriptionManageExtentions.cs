using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.Extentions
{
    public static class PrescriptionManageExtentions
    {
        public static Prescription PostPrescription(this Prescription prescription, string user)
        {
            prescription.CreatedDate = DateTime.UtcNow;
            prescription.IsDelete = false;
            prescription.CreatedBy = user;
            return prescription;
        }

        public static Prescription UpdatePrescription(this Prescription prescription, string user)
        {
            prescription.UpdatedBy = user;
            prescription.UpdatedDate = DateTime.UtcNow;
            return prescription;
        }

        public static Prescription DeletePrescription(this Prescription prescription, string user)
        {
            prescription.IsDelete = true;
            prescription.DeletedDate = DateTime.UtcNow;
            prescription.DeletedBy = user;
            return prescription;
        }
    }
}
