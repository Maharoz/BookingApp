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
	public class ReplyForManipulationDto : BaseDto
	{
		[Required(ErrorMessage = "Reply is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Reply is 60 characters.")]
		public string? ReplyText { get; init; }
		public int Comment_Id { get; init; }
    }
}
