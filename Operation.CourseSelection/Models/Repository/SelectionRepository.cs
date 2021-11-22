using Operation.CourseSelection.Models.CourseSelection_BIZ;
using Operation.CourseSelection.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.Repository
{
	public class SelectionRepository : ICourseSelectionRepository
	{
		public string[] CourseList(string studentId)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var entity = DB.Students.Where(p => p.StudentID == studentId)
					.Join(DB.Student_CourseSelection,
					p => p.ID,
					e => e.Student_ID,
					(p, e) => e.Course_ID)
					.Join(DB.Courses,
					p => p,
					e => e.ID,
					(p, e) => e.CourseID);

				return entity.ToArray();
			}
		}

		public List<SelectionVM> GetStudentCourseList()
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				List<SelectionVM> selections = new List<SelectionVM>();

				var entityList = DB.Students
					.Join(DB.Student_CourseSelection,
					p => p.ID,
					e => e.Student_ID,
					(p, e) => new
					{
						courseId = e.Course_ID,
						studentId = p.StudentID
					})
					.Join(DB.Courses,
					p => p.courseId,
					e => e.ID,
					(p, e) => new
					{
						studentId = p.studentId,
						courseName = e.Name
					});

				var students = entityList.Select(p => p.studentId).Distinct().ToList();

				students.ForEach(stu =>
				{
					selections.Add(new SelectionVM()
					{
						StudentID = stu,
						SelectCourses = entityList
										.Where(e => e.studentId == stu)
										.Select(c => c.courseName)
										.ToArray(),
					});
				});

				return selections;
			}
		}

		public void UpdateSelection(string studentId, string[] courses)
		{
			using (CurriculumDBEntities DB = new CurriculumDBEntities())
			{
				var student = DB.Students.Where(p => p.StudentID == studentId)
					.FirstOrDefault();

				ClearSelection(DB, student.ID);
				AddSelection(DB, student.ID, courses);
			}
		}

		private void AddSelection(CurriculumDBEntities DB, int id, string[] courses)
		{
			var Addlist = DB.Courses.Where(p => courses.Contains(p.CourseID)).ToList();

			Addlist.ForEach(p =>
			{
				DB.Student_CourseSelection.Add(new Student_CourseSelection()
				{
					Course_ID = p.ID,
					Student_ID = id
				});
			});
			DB.SaveChanges();
		}

		private void ClearSelection(CurriculumDBEntities DB, int id)
		{
			var clearlist = DB.Student_CourseSelection.Where(p => p.Student_ID == id).ToList();
			clearlist.ForEach(p =>
			{
				DB.Student_CourseSelection.Remove(p);
			});
			DB.SaveChanges();
		}
	}
}