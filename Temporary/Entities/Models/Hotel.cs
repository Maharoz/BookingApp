using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class Hotel
	{
		[Key]
		[DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
		public int Hotel_Id { get; set; }

		[Required(ErrorMessage = "Name is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Location is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
		public string? Location { get; set; }

		[Required(ErrorMessage = "Ratings is a required field.")]
		public int Ratings { get; set; }
		public List<Comment> Comments { get; set; }
	
	}
}
