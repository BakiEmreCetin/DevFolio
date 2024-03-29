﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio.Models;

namespace DevFolio.Controllers
{
    public class ProjectController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Project
        public ActionResult ProjectList()
        {
            var value = db.TblProject.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> category = (from x in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            var category = db.TblCategory.Where(m => m.CategoryId == p.TblCategory.CategoryId).FirstOrDefault();
            p.TblCategory = category;
            p.CreatedDate = DateTime.Now;
            db.TblProject.Add(p);
            db.SaveChanges();

            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProject.Find(id);
            db.TblProject.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var values = db.TblProject.Find(id);
            List<SelectListItem> category = (from i in db.TblCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProject.Find(p.ProjectID);
            values.Title = p.Title;
            values.ProjectCategory = p.TblCategory.CategoryId;
            values.CoverImageUrl = p.CoverImageUrl;
            values.CreatedDate = p.CreatedDate;
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}

 