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
    public record ReplyDto
	{
		public int Reply_Id { get; set; }
		public int Comment_Id { get; set; }
		public string? ReplyText { get; set; }
	}
}
