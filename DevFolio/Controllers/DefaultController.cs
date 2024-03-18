using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class DefaultController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialServices()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialProject()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            ViewBag.show = false;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialContact(TblContact p)
        {
            p.IsRead = false;
            p.SendMessageDate = DateTime.Now;
            db.TblContact.Add(p);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.show = true;
            return PartialView("PartialContact");
        }

            public PartialViewResult PartialAdress()
        {
            var values = db.TblAddress.ToList();
            return PartialView(values);
        }

         public PartialViewResult PartialSocialMedia()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projeCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.servicesCount = db.TblService.Count();
            return PartialView();
        }

    }
}