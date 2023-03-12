using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class Reply
	{
		[Key]
		[DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
		public int Reply_Id { get; set; }

		//public int CommentId { get; set; }

		[Required(ErrorMessage = "Comment is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Reply is 60 characters.")]
		public string? ReplyText { get; set; }

		[ForeignKey("Comment")]
		public int Comment_Id { get; set; }
		public Comment Comment { get; set; }
	}
}
