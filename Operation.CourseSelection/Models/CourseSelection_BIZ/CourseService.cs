using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Operation.CourseSelection.Models.CourseSelection_BIZ
{
	public class CourseService
	{
		readonly ICourseRepository _courseRepo;
		private string errorMessage;

		public string GetErrorMessage()
		{
			return errorMessage;
		}

		private void SetErrorMessage(string value)
		{
			errorMessage = value;
		}

		public CourseService()
		{
			//TODO:加入ICourseRepository的繫結
			_courseRepo = null;
		}

		public List<CourseVM> GetCourses()
		{
			//return _courseRepo.GetCourseList();
			return new List<CourseVM>()
			{
				new CourseVM()
				{
					ID = "C001",
					Name = "國文課",
					Units = 1,
					Locations = "A棟1樓",
					Teacher = "Mark"
				}
			};
		}

		public bool AddCourse(CourseModel course)
		{
			if (course == null)
			{
				SetErrorMessage("傳入課程資訊不可以是空的！");
				return false;
			}
			if (!CourseIsValid(course)) return false;
			if (_courseRepo.Find(course.ID) != null)
			{
				SetErrorMessage("此課程已存在，不可重複新增！");
				return false;
			}

			_courseRepo.CreatCourse(course.ID, course.Name, course.Units, course.Locations, course.Teacher);
			return true;
		}

		public bool ModifyCourse(CourseModel course)
		{
			if (course == null)
			{
				SetErrorMessage("傳入課程資訊不可以是空的！");
				return false;
			}
			if (!CourseIsValid(course)) return false;
			if (_courseRepo.Find(course.ID) == null)
			{
				SetErrorMessage("此課程不存在，不可修改！");
				return false;
			}

			_courseRepo.UpdateCourse(course.ID, course.Name, course.Units, course.Locations, course.Teacher);
			return true;
		}

		public bool DeleteCourse(string courseId)
		{
			if (string.IsNullOrEmpty(courseId))
			{
				SetErrorMessage("課號不可空白！");
				return false;
			}

			if (!IDIsVaild(courseId)) return false;
			if (_courseRepo.Find(courseId) == null)
			{
				SetErrorMessage("此課號不存在，無法刪除！");
				return false;
			}

			_courseRepo.DeleteCourse(courseId);
			return true;
		}

		private bool CourseIsValid(CourseModel course)
		{
			if (!IDIsVaild(course.ID)) return false;
			if (course.Units < 0)
			{
				SetErrorMessage("學分不可以為負數！");
				return false;
			}
			return true;
		}

		private bool IDIsVaild(string id)
		{
			Regex id_regex = new Regex(@"^(C)\d{3}$");
			if (!id_regex.Match(id).Success)
			{
				SetErrorMessage("課號格式不正確!");
				return false;
			}
			return true;
		}
	}

	public interface ICourseRepository
	{
		List<CourseVM> GetCourseList();
		CourseVM Find(string id);
		void CreatCourse(string id, string name, int units, string Locations, string Teacher);
		void UpdateCourse(string id, string name, int units, string Locations, string Teacher);
		void DeleteCourse(string id);
	}
}