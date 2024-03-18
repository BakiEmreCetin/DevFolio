using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFolio.Controllers
{
    public class DownloadCVController : Controller
    {
        // GET: DownloadCV
        public FilePathResult DownloadCV()
        {
            string dosyayolu = Server.MapPath("~/CV/Cv.pdf");
             string dosyaTuru = "application/pdf";
            return File(dosyayolu, dosyaTuru, "Cv.pdf");
        }
    }
}