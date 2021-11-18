using Operation.CourseSelection.Models.CourseSelection_BIZ;
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

		public JsonResult GetStudentList()
		{
			var studentlist = new StudentService().GetStudents();
			return Json(studentlist, JsonRequestBehavior.AllowGet);
		}
	}
}