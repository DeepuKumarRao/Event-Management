using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventManagement1.Models
{
    public class Event_DetailsModel
    {
        public int Cust_Id { get; set; }
        public string Name { get; set; }
        public int Event_Id { get; set; }
        public string Hotel_Location { get; set; }
        public string Tent_Name { get; set; }



        public string Plate_Name { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DOF { get; set; }
        public int Day { get; set; }
    }
}