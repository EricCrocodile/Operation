using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operation.CourseSelection.Controllers
{
    public class DataCenterController : Controller
    {
        
        public ActionResult StudentInfo()
        {
            return View();
        }

        public ActionResult CourseInformation()
        {
            return View();
        }
    }
}