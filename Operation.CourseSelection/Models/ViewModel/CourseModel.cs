using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.ViewModel
{
	public class CourseModel
	{
		[Display(Name = "課號")]
		[Required(ErrorMessage = "{0}不得為空！")]
		[MaxLength(4, ErrorMessage = "{0}不得大於4碼字串！")]
		[MinLength(4, ErrorMessage = "{0}不得小於4碼字串！")]
		public string ID { get; set; }
		[Display(Name = "課名")]
		[Required(ErrorMessage = "{0}不得為空！")]
		public string Name { get; set; }

		[Display(Name = "學分數")]
		[Required(ErrorMessage = "{0}不得為空！")]		
		public int Units { get; set; }

		[Display(Name = "上課地點")]
		[Required(ErrorMessage = "{0}不得為空！")]
		public string Locations { get; set; }

		[Display(Name = "講師名字")]
		[Required(ErrorMessage = "{0}不得為空！")]
		public string Teacher { get; set; }
	}
}