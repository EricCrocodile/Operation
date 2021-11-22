using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.ViewModel
{
	public class SelectionModel
	{
		[Display(Name = "學號")]
		[Required(ErrorMessage = "{0}不得為空！")]
		[MaxLength(5, ErrorMessage = "{0}不得大於5碼字串！")]
		[MinLength(5, ErrorMessage = "{0}不得小於5碼字串！")]
		public string StudentID { get; set; }		
		public string[] SelectCourseID { get; set; }
	}
}