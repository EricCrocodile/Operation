using Operation.CourseSelection.Models.CourseSelection_BIZ;
using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.Repository
{
	public class CourseRepository : ICourseRepository
	{
		public void CreatCourse(string id, string name, int units, string locations, string teacher)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var course = new Course()
				{
					CourseID = id,
					Name = name,
					Units = units,
					Locations = locations,
					Teacher = teacher,
				};

				DB.Courses.Add(course);
				DB.SaveChanges();
			}
		}

		public void DeleteCourse(string id)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var entity = DB.Courses.Where(p => p.CourseID == id).FirstOrDefault();
				DB.Courses.Remove(entity);
				DB.SaveChanges();
			}
		}

		public CourseVM Find(string id)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var entity = DB.Courses.Where(p => p.CourseID == id).FirstOrDefault();
				return entity?.ToViewModel();
			}
		}

		public List<CourseVM> GetCourseList()
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var ViewModels = new List<CourseVM>();
				DB.Courses.OrderBy(p => p.CourseID).ToList().ForEach(p =>
				{
					ViewModels.Add(p.ToViewModel());
				});
				return ViewModels.ToList();
			}
		}

		public void UpdateCourse(string id, string name, int units, string Locations, string Teacher)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var entity = DB.Courses.Where(p => p.CourseID == id).FirstOrDefault();
				entity.Name = name;
				entity.Units = units;
				entity.Locations = Locations;
				entity.Teacher = Teacher;
				DB.SaveChanges();
			}
		}
	}

	public static class CourseRepoExc
	{
		public static CourseVM ToViewModel(this Course course)
			=> new CourseVM()
			{
				ID = course.CourseID,
				Name = course.Name,
				Units = course.Units,
				Teacher = course.Teacher,
				Locations = course.Locations
			};

	}
}