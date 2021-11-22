using Operation.CourseSelection.Models.CourseSelection_BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Operation.CourseSelection.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult GetStudentList()
		{
			var studens = new CourseSelectionService().GetStudents();
			return Json(studens, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult GetCourseCheckList(string studentId)
		{
			if (string.IsNullOrEmpty(studentId))
			{
				ModelState.AddModelError("學號", "學號不可空白！");
				return Json(new
				{
					SysCode = 400,
					SysMsg = ModelState.Values.FirstOrDefault(p => p.Errors.Count > 0)?.Errors.FirstOrDefault()?.ErrorMessage
				}, JsonRequestBehavior.DenyGet);
			}

			var service = new CourseSelectionService();
			var checkList = service.GetCourseCheckList(studentId);
			return Json(checkList, JsonRequestBehavior.DenyGet);
		}

		public JsonResult GetSelectionList()
		{
			var studens = new CourseSelectionService().GetSelectionList();
			return Json(studens, JsonRequestBehavior.AllowGet);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}