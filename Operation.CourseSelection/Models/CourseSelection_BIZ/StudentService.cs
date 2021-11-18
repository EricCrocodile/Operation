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
			_studentRepo = new FakeStudentRepo();
		}

		public List<StudentVM> GetStudents()
		{
			return _studentRepo.GetStudenList();
		}
	}

	interface IStudentRepository
	{
		List<StudentVM> GetStudenList();
	}

	class FakeStudentRepo : IStudentRepository
	{
		public List<StudentVM> GetStudenList()
		{
			return new List<StudentVM>()
			{
				new StudentVM()
				{
					ID = "S0001",
					Name = "Eric",
					Birthday = new DateTime(2021,01,01),
					Email = "a@gmail.com"
				},
				new StudentVM()
				{
					ID = "S0002",
					Name = "Andy",
					Birthday = new DateTime(2021,01,01),
					Email = "b@gmail.com"
				},
				new StudentVM()
				{
					ID = "S0003",
					Name = "Emily",
					Birthday = new DateTime(2021,01,01),
					Email = "c@gmail.com"
				},
				new StudentVM()
				{
					ID = "S0004",
					Name = "Tracy",
					Birthday = new DateTime(2021,01,01),
					Email = "d@gmail.com"
				},
			};
		}
	}
}