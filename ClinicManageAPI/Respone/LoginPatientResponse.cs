﻿namespace ClinicManageAPI.Respone
{
    public class LoginPatientResponse
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public int PatientId { get; set; }
    }
}
