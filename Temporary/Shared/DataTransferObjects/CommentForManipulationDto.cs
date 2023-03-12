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
	public class CommentForManipulationDto : BaseDto
	{
		[Required(ErrorMessage = "Comment is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Comment is 60 characters.")]
		public string? CommentText { get; init; }
		public int Hotel_Id { get; init; }
    }
}
