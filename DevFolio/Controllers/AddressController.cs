using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    
    public class AddressController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Address
        public ActionResult AddressList()
        {
            
            var values = db.TblAddress.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAddress()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(TblAddress p)
        {

            db.TblAddress.Add(p);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

        public ActionResult DeleteAddress(int id)
        {
            var values = db.TblAddress.Find(id);
            db.TblAddress.Remove(values);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var values = db.TblAddress.Find(id);

            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAddress(TblAddress p)
        {
            var values = db.TblAddress.Find(p.AddressId);
            values.Description = p.Description;
            values.Location = p.Location;
            values.Email = p.Email;
            values.PhoneNumber = p.PhoneNumber;
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}