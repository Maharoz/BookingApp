using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class Comment
	{
		[Key]
		[DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.Identity)]
		public int Comment_Id { get; set; }

		[Required(ErrorMessage = "Comment is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Comment is 60 characters.")]
		public string? CommentText { get; set; }

		public List<Reply> Replys { get; set; }

		[ForeignKey("Hotel")]
		public int Hotel_Id { get; set; }
		public Hotel Hotel { get; set; }
	}
}
