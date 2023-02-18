using BusinessObject.Entity;
using System;

namespace ClinicManageAPI.Extentions
{
    public static class UserManageExtentions
    {
        public static User CreateUser(this User user, string userCreate)
        {
            user.CreatedDate = DateTime.UtcNow;
            user.CreatedBy = userCreate;
            user.IsDelete = false;
            
            return user;
        }
        public static User EditUser(this User user, string userCreate)
        {
            user.UpdatedDate = DateTime.UtcNow;
            user.UpdatedBy = userCreate;
            user.IsDelete = false;

            return user;
        }
        public static User DeleteUser(this User user, string userCreate)
        {
            user.DeletedDate = DateTime.UtcNow;
            user.DeletedBy = userCreate;
            user.IsDelete = true;

            return user;
        }
    }
}
