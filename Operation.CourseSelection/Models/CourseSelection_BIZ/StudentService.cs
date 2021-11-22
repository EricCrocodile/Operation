using Operation.CourseSelection.Models.Repository;
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

		public StudentService()
		{
			//TOOD:加入IStudentRepository的繫結
			_studentRepo = new StudentRepository();
		}

		public List<StudentVM> GetStudents()
		{
			return _studentRepo.GetStudenList();
			//return new List<StudentVM>()
			//{
			//	new StudentVM()
			//	{
			//		ID="S1030",
			//		Name="eric",
			//		Birthday="2019-01-01",
			//		Email="a@gmail"
			//	}
			//};
		}

		public bool AddStudent(StudentModel student)
		{
			if (student == null)
			{
				SetErrorMessage("傳入資訊不得是空的！");
				return false;
			}
			if (!StudentIsVaild(student)) return false;
			if (_studentRepo.Find(student.ID) != null)
			{
				SetErrorMessage("此學號已存在，不可重複新增！");
				return false;
			}

			_studentRepo.CreatStudent(student.ID, student.Name, student.Birthday, student.Email);
			return true;
		}

		public bool ModifyStudent(StudentModel student)
		{
			if (student == null)
			{
				SetErrorMessage("傳入資訊不得是空的！");
				return false;
			}
			if (!StudentIsVaild(student)) return false;
			if (_studentRepo.Find(student.ID) == null)
			{
				SetErrorMessage("此學號不存在，不可修改！");
				return false;
			}

			_studentRepo.UpdateStudent(student.ID, student.Name, student.Birthday, student.Email);
			return true;
		}
		public bool DeleteStudent(string studentId)
		{
			if (string.IsNullOrEmpty(studentId))
			{
				SetErrorMessage("學號不可空白！");
				return false;
			}

			if (!IDIsVaild(studentId)) return false;
			if (_studentRepo.Find(studentId) == null)
			{
				SetErrorMessage("此學號不存在，無法刪除！");
				return false;
			}

			_studentRepo.DeleteStudent(studentId);
			return true;
		}

		private bool StudentIsVaild(StudentModel student)
		{
			if (!IDIsVaild(student.ID)) return false;
			if (student.Birthday > DateTime.Now)
			{
				SetErrorMessage("生日不可在今天之後！");
				return false;
			}
			return true;
		}

		private bool IDIsVaild(string id)
		{
			Regex id_regex = new Regex(@"^(S)\d{4}$");
			if (!id_regex.Match(id).Success)
			{
				SetErrorMessage("學號格式不正確!");
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