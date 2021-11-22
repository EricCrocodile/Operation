using Operation.CourseSelection.Models.Repository;
using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.CourseSelection_BIZ
{
	public class CourseSelectionService
	{
		readonly ICourseSelectionRepository _selectionRepo;
		readonly ICourseRepository _courseRepo;
		readonly IStudentRepository _studentRepo;
		private string errorMessage;

		public string GetErrorMessage()
		{
			return errorMessage;
		}

		private void SetErrorMessage(string value)
		{
			errorMessage = value;
		}

		public CourseSelectionService()
		{
			//TODO: 加入ICourseSelectionRepository的繫結
			_selectionRepo = null;
			_studentRepo = new StudentRepository();
			_courseRepo = new CourseRepository();
		}

		public List<StudentSelecterVM> GetStudents()
		{
			var students = _studentRepo.GetStudenList().Select(p => p.ToSelecterVM());
			return students.ToList();
		}

		public List<CourseCheckVM> GetCourseCheckList(string studentId)
		{
			var CheckedList = _selectionRepo.CourseList(studentId);

			List<CourseCheckVM> courseList = _courseRepo.GetCourseList().Select(p => p.ToCheckList(CheckedList)).ToList();

			return courseList;
		}

		public List<SelectionVM> GetSelectionList()
		{
			return _selectionRepo.GetStudentCourseList();
		}
	}

	public interface ICourseSelectionRepository
	{
		List<SelectionVM> GetStudentCourseList();
		string[] CourseList(string studentId);
		void UpdateSelection(string studentId, string[] courses);
	}

	public static class CourseSelectionExc
	{
		public static StudentSelecterVM ToSelecterVM(this StudentVM student)
			=> new StudentSelecterVM()
			{
				StudentID = student.ID,
				Name = student.Name
			};

		public static CourseCheckVM ToCheckList(this CourseVM course, string[] Checked)
			=> new CourseCheckVM()
			{
				CourseId = course.ID,
				CourseName = course.Name,
				Checked = Checked.Contains(course.ID),
			};

	}
}