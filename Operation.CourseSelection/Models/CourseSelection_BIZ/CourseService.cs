using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
			return _courseRepo.GetCourseList();
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