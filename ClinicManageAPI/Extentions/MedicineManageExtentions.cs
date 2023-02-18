using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.Extentions
{
    public static class MedicineManageExtentions
    {
        public static Medicine PostMedicine(this Medicine medicine, string user)
        {
            medicine.CreatedDate = DateTime.UtcNow;
            medicine.IsDelete = false;
            medicine.CreatedBy = user;
            return medicine;
        }
        public static Medicine UpdateMedicine(this Medicine medicine, string user)
        {
            medicine.UpdatedBy = user;
            medicine.UpdatedDate = DateTime.UtcNow;
            return medicine;
        }
        public static Medicine DeleteMedicine(this Medicine medicine, string user)
        {
            medicine.IsDelete = true;
            medicine.DeletedDate = DateTime.UtcNow;
            medicine.DeletedBy = user;
            return medicine;
        }
        public static Medicine RestoreDeleteMedicine(this Medicine medicine, string user)
        {
            medicine.IsDelete = false;
            medicine.DeletedDate = null;
            medicine.DeletedBy = null;
            medicine.UpdatedDate = DateTime.UtcNow;
            return medicine;
        }
    }
}
