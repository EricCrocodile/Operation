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
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var student = new Student()
				{
					StudentID = id,
					Name = name,
					Birthday = birth,
					Email = email
				};

				DB.Students.Add(student);
				DB.SaveChanges();
			}
		}

		public void DeleteStudent(string id)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var entity = DB.Students.Where(p => p.StudentID == id).FirstOrDefault();
				DB.Students.Remove(entity);
				DB.SaveChanges();
			}
		}

		public StudentVM Find(string id)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var entity = DB.Students.Where(p => p.StudentID == id).FirstOrDefault();
				return entity?.ToViewModel();
			}
		}

		public List<StudentVM> GetStudenList()
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var viewModels = new List<StudentVM>();
				DB.Students.OrderBy(p => p.StudentID).ToList().ForEach(p =>
				{
					viewModels.Add(p.ToViewModel());
				});

				return viewModels;
			}
		}

		public void UpdateStudent(string id, string name, DateTime birth, string email)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var entity = DB.Students.Where(p => p.StudentID == id).FirstOrDefault();
				entity.Name = name;
				entity.Birthday = birth;
				entity.Email = email;
				DB.SaveChanges();
			}
		}
	}

	public static class StudentRepoExc
	{
		public static StudentVM ToViewModel(this Student student)
			=> new StudentVM()
			{
				ID = student.StudentID,
				Name = student.Name,
				Birthday = student.Birthday.ToString("yyyy-MM-dd"),
				Email = student.Email
			};
	}
}