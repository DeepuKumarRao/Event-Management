using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement1.Models
{
    public class CostModel
    {
        public int Event_Id { get; set; }
        public int Hotel_Price { get; set; }
        public int Tent_Price { get; set; }
        public int Plate_Price { get; set; }
        public int Total { get; set; }



    }
}