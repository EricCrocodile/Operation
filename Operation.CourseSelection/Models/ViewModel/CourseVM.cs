using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.ViewModel
{
	public class CourseVM
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public int Units { get; set; }
		public string Locations { get; set; }
		public string Teacher { get; set; }
	}
}