using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.ViewModel
{
	public class StudentVM
	{		
		public string ID { get; set; }		
		public string Name { get; set; }		
		public string Birthday { get; set; }		
		public string Email { get; set; }

	}
}