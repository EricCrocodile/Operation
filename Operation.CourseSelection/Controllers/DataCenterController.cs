using Operation.CourseSelection.Models.CourseSelection_BIZ;
using Operation.CourseSelection.Models.ViewModel;
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

		public JsonResult GetStudentList()
		{
			var studentlist = new StudentService().GetStudents();
			return Json(studentlist, JsonRequestBehavior.AllowGet);
		}

		public JsonResult AddStudent(StudentModel student)
		{
			if (!ModelState.IsValid)
			{
				return Json(new
				{
					SysCode = 400,
					SysMsg = ModelState.Values.FirstOrDefault(p => p.Errors.Count > 0)?.Errors.FirstOrDefault()?.ErrorMessage
				});
			}

			var service = new StudentService();
			if (!service.AddStudent(student))
			{
				return Json(new
				{
					SysCode = 408,
					SysMsg = service.ErrorMessage
				});
			}

			return Json(new
			{
				SysCode = 200,
				SysMsg = "OK"
			});
		}

		public ActionResult CourseInformation()
		{
			return View();
		}
	}
}