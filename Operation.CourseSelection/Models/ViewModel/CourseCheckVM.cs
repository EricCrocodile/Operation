using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.ViewModel
{
	public class CourseCheckVM
	{
		public string CourseId { get; set; }
		public string CourseName { get; set; }
		public bool Checked { get; set; }
	}
}