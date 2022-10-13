using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement1.Models
{
    public class SignupModel
    {
        public int Cust_Id { get; set; }
        public string Name { get; set; }
        public string Mobile_No { get; set; }
        public string Address { get; set; }
        public string Id_Proof { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}