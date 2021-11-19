using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Operation.CourseSelection.Models.CourseSelection_BIZ
{
	public class StudentService
	{
		IStudentRepository _studentRepo;
		public string ErrorMessage { get; set; }
		public StudentService()
		{
			//todo 加入IStudentRepository的繫結
			_studentRepo = null;
		}

		public List<StudentVM> GetStudents()
		{
			return _studentRepo.GetStudenList();
		}

		public bool AddStudent(StudentModel student)
		{
			if (student == null)
			{
				ErrorMessage = "傳入資訊不得是空的！";
				return false;
			}
			if (!StudentIsVaild(student)) return false;
			if (_studentRepo.Find(student.ID) != null)
			{
				ErrorMessage = "此學號已存在，不可重複新增！";
				return false;
			}

			_studentRepo.CreatStudent(student.ID, student.Name, student.Birthday, student.Email);
			return true;
		}

		private bool StudentIsVaild(StudentModel student)
		{
			if (!IDIsVaild(student.ID)) return false;
			if (student.Birthday > DateTime.Now)
			{
				ErrorMessage = "生日不可在今天之後！";
				return false;
			}
			return true;
		}

		private bool IDIsVaild(string id)
		{
			Regex id_regex = new Regex(@"^(S)\d{4}$");
			if (!id_regex.Match(id).Success)
			{
				ErrorMessage = "學號格式不正確!";
				return false;
			}
			return true;
		}
	}

	interface IStudentRepository
	{
		List<StudentVM> GetStudenList();
		StudentVM Find(string id);
		void CreatStudent(string id, string name, DateTime birth, string email);
		void UpdateStudent(string id, string name, DateTime birth, string email);
		void DeleteStudent(string id);
	}


}