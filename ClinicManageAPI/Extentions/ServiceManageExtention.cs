using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.Extentions
{
    public static class ServiceManageExtention
    {
        public static Service PostService(this Service service, string user)
        {
            service.CreatedDate = DateTime.UtcNow;
            service.IsDelete = false;
            service.CreatedBy = user;
            return service;
        }
        public static Service UpdateService(this Service service, string user)
        {
            service.UpdatedBy = user;
            service.UpdatedDate = DateTime.UtcNow;
            return service;
        }
        public static Service DeleteService(this Service service, string user)
        {
            service.IsDelete = true;
            service.DeletedDate = DateTime.UtcNow;
            return service;
        }
        public static Service RestoreDeleteService(this Service service, string user)
        {
            service.IsDelete = false;
            service.DeletedDate = null;
            service.UpdatedDate = DateTime.UtcNow;
            return service;
        }
    }
}
