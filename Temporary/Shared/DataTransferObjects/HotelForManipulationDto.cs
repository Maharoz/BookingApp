using API.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
	public class HotelForManipulationDto : BaseDto
	{
		[Required(ErrorMessage = "Name is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Location is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
		public string? Location { get; set; }

		[Required(ErrorMessage = "Ratings is a required field.")]
		public int Ratings { get; set; }
	}
}
