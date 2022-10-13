using EventManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement1.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Index(LoginModel Lm)
        {
            Event_ManagementEntities em = new Event_ManagementEntities();
            var data = em.Customer_Entry.FirstOrDefault(x => x.Email == Lm.Email && x.Password == Lm.Password);
            if (data != null)
            {
                return RedirectToAction("EventTables", new { id = data.Cust_Id });
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult SignUP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(SignupModel su)

        {
            Event_ManagementEntities ee = new Event_ManagementEntities();
            Customer_Entry cs = new Customer_Entry();
            cs.Cust_Id = su.Cust_Id;
            cs.Name = su.Name;
            cs.Mobile_No = su.Mobile_No;
            cs.Address = su.Address;
            cs.Id_Proof = su.Id_Proof;
            cs.Email = su.Email;
            cs.Password = su.Password;
            ee.Customer_Entry.Add(cs);
            ee.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EventTables(int id)
        {
            Event_ManagementEntities ee = new Event_ManagementEntities();
            EventTables et = new EventTables();
            et.Cust_Id = id;
            var data = ee.Customer_Entry.FirstOrDefault(x => x.Cust_Id == id);
            et.Name = data.Name;
            et.DOB = DateTime.Now.Date;



            List<string> list = new List<string>();
            list.Add("Marraige");
            list.Add("Anniversary");



            ViewBag.eventype = list;



            return View(et);
        }



        [HttpPost]
        public ActionResult EventTables(EventTables ed)
        {
            Event_ManagementEntities ee = new Event_ManagementEntities();
            Event_Table ede = new Event_Table();
            ede.Event_Id = ed.Event_Id;
            ede.Cust_Id = ed.Cust_Id;
            ede.DOB = (DateTime)ed.DOB;
            ede.DOF = (DateTime)ed.DOF;
            ede.Event = ed.Event;
            ee.Event_Table.Add(ede);
            ee.SaveChanges();



            return RedirectToAction("EventDetails", new {id= ed.Event_Id });
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }





        [HttpPost]
        public ActionResult Admin(AdminModel ad)
        {
            Event_ManagementEntities ee = new Event_ManagementEntities();
            var data = ee.Admins.FirstOrDefault(x => x.Admin1 == ad.Admin1 && x.Password == ad.Password);
            if (data != null)
            {
                return RedirectToAction("NewPage");



            }
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public ActionResult NewPage()
        {
            return View();
        }


        [HttpGet]
        public ActionResult TentEntry()
        {
            return View();
        }



        [HttpPost]
        public ActionResult TentEntry(TentModel tm)
        {

            Event_ManagementEntities ee = new Event_ManagementEntities();
            Tent_Name tn = new Tent_Name();

            tn.Tent_Id = tm.Tent_Id;
            tn.Tent_Name1 = tm.Tent_Name1;
            tn.Tent_Size = tm.Tent_Size;
            tn.Tent_Price = tm.Tent_Price;



            ee.Tent_Name.Add(tn);
            ee.SaveChanges();
            return RedirectToAction("Admin");



        }

        [HttpGet]
        public ActionResult HotelEntry()
        {
            return View();
        }


        [HttpPost]
        public ActionResult HotelEntry(HotelModel hm)
        {

            Event_ManagementEntities ee = new Event_ManagementEntities();
            Hotel_Event he = new Hotel_Event();
            he.Hotel_Id = hm.Hotel_Id;
            he.Hotel_Name = hm.Hotel_Name;
            he.Hotel_Price = hm.Hotel_Price;
            he.Size = hm.Size;

            ee.Hotel_Event.Add(he);
            ee.SaveChanges();

            return RedirectToAction("Admin");

        }


        [HttpGet]
        public ActionResult PlateEntry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlateEntry(PlateModel hm)
        {

            Event_ManagementEntities ee = new Event_ManagementEntities();
            Plate_Table he = new Plate_Table();
            he.Plate_Id = hm.Plate_Id;
            he.Plate_Name = hm.Plate_Name;
            he.Price = hm.Price;

            ee.Plate_Table.Add(he);
            ee.SaveChanges();

            return RedirectToAction("Admin");

        }

        [HttpGet]
        public ActionResult EventDetails(int id)
        {
            Event_DetailsModel ed = new Event_DetailsModel();
            ed.Event_Id = id;

            Event_ManagementEntities ee = new Event_ManagementEntities();



            var data = ee.Event_Table.SingleOrDefault(x => x.Event_Id == id);


            ed.Cust_Id = data.Cust_Id;
            ed.DOF = (DateTime)data.DOF;



            List<string> hotel = ee.Hotel_Event.Select(x => x.Hotel_Name).ToList();
            List<string> tent = ee.Tent_Name.Select(x => x.Tent_Name1).ToList();
            List<string> plate = ee.Plate_Table.Select(x => x.Plate_Name).ToList();



            ViewBag.hotel = hotel;
            ViewBag.tent = tent;
            ViewBag.plate = plate;



            return View(ed);
        }

        [HttpPost]
        public ActionResult EventDetails(Event_DetailsModel ed)
        {
            Event_ManagementEntities ee = new Event_ManagementEntities();
            Event_Details_Entry ede = new Event_Details_Entry();
            ede.Event_Id = ed.Event_Id;
            //ede.Event_Loc_Id = ed;
            //ede.Tent_Id = ed.Tent_Id;
            var data1 = ee.Hotel_Event.SingleOrDefault(x => x.Hotel_Name == ed.Hotel_Location);
            ede.Event_Loc_Id = data1.Hotel_Id;



            var data2 = ee.Tent_Name.SingleOrDefault(x => x.Tent_Name1 == ed.Tent_Name);
            ede.Tent_Id = data2.Tent_Id;

            var data3 = ee.Plate_Table.SingleOrDefault(x => x.Plate_Name == ed.Plate_Name);
            ede.Plate_Id = data3.Plate_Id;

            var data = ee.Event_Table.SingleOrDefault(x => x.Event_Id == ed.Event_Id);

            ede.DOF = (DateTime)data.DOF;
            ede.Day = ed.Day;
            ee.Event_Details_Entry.Add(ede);
            ee.SaveChanges();
            return RedirectToAction("Cost",new {id=data.Event_Id});

        }
        [HttpGet]
        public ActionResult Cost(int id)
        {
            CostModel cm = new CostModel();
            Event_ManagementEntities ee = new Event_ManagementEntities();

            var data0 = ee.Event_Details_Entry.FirstOrDefault(x => x.Event_Id == id);

            var data1 = ee.Hotel_Event.SingleOrDefault(x => x.Hotel_Id == data0.Event_Loc_Id);
            int hotel=data1.Hotel_Price*data0.Day;



            var data2 = ee.Tent_Name.SingleOrDefault(x => x.Tent_Id == data0.Tent_Id);
            int  tent  = data2.Tent_Price*data0.Day;

            var data3 = ee.Plate_Table.SingleOrDefault(x => x.Plate_Id == data0.Plate_Id);
            int plate = data3.Price*data0.Day;

            cm.Tent_Price = tent;
            cm.Plate_Price = plate;
            cm.Hotel_Price = hotel;
            cm.Event_Id=data0.Event_Id;
            cm.Total=tent+plate+hotel;

            return View(cm);
        }

        [HttpPost]
        public ActionResult Cost(CostModel c)
        {
            Cost_Table cm = new Cost_Table();
            Event_ManagementEntities ee = new Event_ManagementEntities();

            

            cm.Tent_Price = c.Tent_Price;
            cm.Plate_Price =c.Plate_Price ;
            cm.Hotel_Price = c.Hotel_Price;
            cm.Event_Id = c.Event_Id;
            ee.Cost_Table.Add(cm);
            ee.SaveChanges();

            return RedirectToAction("index");


            
        }


    }
}
