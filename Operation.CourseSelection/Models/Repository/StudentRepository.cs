using Operation.CourseSelection.Models.CourseSelection_BIZ;
using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.Repository
{
	public class StudentRepository : IStudentRepository
	{
		public void CreatStudent(string id, string name, DateTime birth, string email)
		{
			throw new NotImplementedException();
		}

		public void DeleteStudent(string id)
		{
			throw new NotImplementedException();
		}

		public StudentVM Find(string id)
		{
			throw new NotImplementedException();
		}

		public List<StudentVM> GetStudenList()
		{
			throw new NotImplementedException();
		}

		public void UpdateStudent(string id, string name, DateTime birth, string email)
		{
			throw new NotImplementedException();
		}
	}

	public static class StudentRepoExc
	{
		public static StudentVM ToViewModel(this Student student)
			=> new StudentVM()
			{
				ID = student.StudentID,
				Name = student .Name,
				Birthday = student.Birthday.ToString("yyyy-MM-dd"),
				Email = student.Email
			};
	}
}