using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPage11.Models;
using System.Data.Entity;

namespace WebPage11.Controllers
{
    public class MobileController : Controller
    {

        DBaseEntities1 dBaseEntities1 = new DBaseEntities1();

        // GET: Mobile
        
        public ActionResult showmobile()
        {

           var mobilelist =  dBaseEntities1.mobiles.ToList();
            return View(mobilelist);
        }
        
        public ActionResult Addmobile()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Addmobile(mobile mobiledata)
        {

            dBaseEntities1.Entry(mobiledata).State = EntityState.Added;
            dBaseEntities1.SaveChanges();
            return RedirectToAction("showmobile");
        }

        public ActionResult editmobile(int id)
        {
            var mobiledata = dBaseEntities1.mobiles.Find(id);
            return View(mobiledata);
        }

        [HttpPost]
        public ActionResult editmobile(mobile mobiledata)
        {
            dBaseEntities1.Entry(mobiledata).State = EntityState.Modified;
            dBaseEntities1.SaveChanges();
            return RedirectToAction("showmobile");
        }
       
        public ActionResult deletemobile(int id)
        {

            var mobiledata = dBaseEntities1.mobiles.Find(id);
            dBaseEntities1.Entry(mobiledata).State = EntityState.Deleted;
            dBaseEntities1.SaveChanges();
            return RedirectToAction("showmobile");
        }
    }
}