using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement1.Models
{
    public class Event_Details
    {
        public int Event_Id { get; set; }
        public int Event_Loc_Id { get; set; }
        public int Tent_Id { get; set; }
        public System.DateTime DOF { get; set; }
        public int Day { get; set; }
    }
}