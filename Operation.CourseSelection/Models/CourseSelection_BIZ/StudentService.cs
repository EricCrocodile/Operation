using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.CourseSelection_BIZ
{
	public class StudentService
	{
		IStudentRepository _studentRepo;

		public StudentService()
		{
			//todo 加入IStudentRepository的繫結
			_studentRepo = null;
		}

		public List<StudentVM> GetStudents()
		{
			return _studentRepo.GetStudenList();
		}
	}

	interface IStudentRepository
	{
		List<StudentVM> GetStudenList();
		void AddStudent(string id, string name, DateTime birth, string email);
		void UpdateStudent(string id, string name, DateTime birth, string email);
		void DeleteStudent(string id);
	}


}