using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Operation.CourseSelection.Models.ViewModel
{
	public class StudentModel
	{
		[Display(Name = "學號")]
		[Required(ErrorMessage = "{0}不得為空！")]
		[MaxLength(5, ErrorMessage = "{0}不得大於5碼字串！")]
		[MinLength(5, ErrorMessage = "{0}不得小於5碼字串！")]
		public string ID { get; set; }

		[Display(Name = "姓名")]
		[Required(ErrorMessage = "{0}不得為空！")]
		public string Name { get; set; }

		[Display(Name = "生日")]
		[Required(ErrorMessage = "{0}不得為空！")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime Birthday { get; set; }

		[Display(Name = "E-Mail")]
		[Required(ErrorMessage = "{0}不得為空！")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "{0} 格不正確")]
		public string Email { get; set; }

	}
}