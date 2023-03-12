using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Utility;
using System.Diagnostics.Metrics;

namespace Shared.DataTransferObjects
{
    public record CommentDto
	{
		public int Comment_Id { get; set; }
		public int Hotel_Id { get; set; }
		public string? CommentText { get; set; }
		public List<ReplyDto> Reply { get; set; }
	}
}
