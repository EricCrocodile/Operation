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

		[HttpPost]
		public JsonResult AddStudent(StudentModel student)
		{
			if (!ModelState.IsValid)
			{
				return Json(new
				{
					SysCode = 400,
					SysMsg = ModelState.Values.FirstOrDefault(p => p.Errors.Count > 0)?.Errors.FirstOrDefault()?.ErrorMessage
				}, JsonRequestBehavior.DenyGet);
			}

			var service = new StudentService();
			if (!service.AddStudent(student))
			{
				return Json(new
				{
					SysCode = 408,
					SysMsg = service.GetErrorMessage()
				}, JsonRequestBehavior.DenyGet);
			}

			return Json(new
			{
				SysCode = 200,
				SysMsg = "OK"
			}, JsonRequestBehavior.DenyGet);
		}

		[HttpPost]
		public JsonResult ModifyStudent(StudentModel student)
		{
			if (!ModelState.IsValid)
			{
				return Json(new
				{
					SysCode = 400,
					SysMsg = ModelState.Values.FirstOrDefault(p => p.Errors.Count > 0)?.Errors.FirstOrDefault()?.ErrorMessage
				}, JsonRequestBehavior.DenyGet);
			}

			var service = new StudentService();
			if (!service.ModifyStudent(student))
			{
				return Json(new
				{
					SysCode = 408,
					SysMsg = service.GetErrorMessage()
				}, JsonRequestBehavior.DenyGet);
			}

			return Json(new
			{
				SysCode = 200,
				SysMsg = "OK"
			}, JsonRequestBehavior.DenyGet);
		}

		[HttpPost]
		public JsonResult DeleteStudent(string studentId)
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

			var service = new StudentService();
			if (!service.DeleteStudent(studentId))
			{
				return Json(new
				{
					SysCode = 408,
					SysMsg = service.GetErrorMessage()
				}, JsonRequestBehavior.DenyGet);
			}

			return Json(new
			{
				SysCode = 200,
				SysMsg = "OK"
			}, JsonRequestBehavior.DenyGet);
		}

		public ActionResult CourseInformation()
		{
			return View();
		}

		public JsonResult GetCourseList()
		{
			var courselist = new CourseService().GetCourses();
			return Json(courselist, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult AddCourse(CourseModel course)
		{
			if (!ModelState.IsValid)
			{
				return Json(new
				{
					SysCode = 400,
					SysMsg = ModelState.Values.FirstOrDefault(p => p.Errors.Count > 0)?.Errors.FirstOrDefault()?.ErrorMessage
				}, JsonRequestBehavior.DenyGet);
			}

			var service = new CourseService();
			if (!service.AddCourse(course))
			{
				return Json(new
				{
					SysCode = 408,
					SysMsg = service.GetErrorMessage()
				}, JsonRequestBehavior.DenyGet);
			}

			return Json(new
			{
				SysCode = 200,
				SysMsg = "OK"
			}, JsonRequestBehavior.DenyGet);
		}

		[HttpPost]
		public JsonResult ModifyCourse(CourseModel course)
		{
			if (!ModelState.IsValid)
			{
				return Json(new
				{
					SysCode = 400,
					SysMsg = ModelState.Values.FirstOrDefault(p => p.Errors.Count > 0)?.Errors.FirstOrDefault()?.ErrorMessage
				}, JsonRequestBehavior.DenyGet);
			}

			var service = new CourseService();
			if (!service.ModifyCourse(course))
			{
				return Json(new
				{
					SysCode = 408,
					SysMsg = service.GetErrorMessage()
				}, JsonRequestBehavior.DenyGet);
			}

			return Json(new
			{
				SysCode = 200,
				SysMsg = "OK"
			}, JsonRequestBehavior.DenyGet);
		}

		[HttpPost]
		public JsonResult DeleteCourse(string CourseId)
		{
			if (string.IsNullOrEmpty(CourseId))
			{
				ModelState.AddModelError("課號", "課號不可空白！");
				return Json(new
				{
					SysCode = 400,
					SysMsg = ModelState.Values.FirstOrDefault(p => p.Errors.Count > 0)?.Errors.FirstOrDefault()?.ErrorMessage
				}, JsonRequestBehavior.DenyGet);
			}

			var service = new CourseService();
			if (!service.DeleteCourse(CourseId))
			{
				return Json(new
				{
					SysCode = 408,
					SysMsg = service.GetErrorMessage()
				}, JsonRequestBehavior.DenyGet);
			}

			return Json(new
			{
				SysCode = 200,
				SysMsg = "OK"
			}, JsonRequestBehavior.DenyGet);
		}
	}
}