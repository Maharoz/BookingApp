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
    public record HotelDto
	{
		public int Hotel_Id { get; set; }
		public string? Name { get; set; }

		public string? Location { get; set; }

		public int Ratings { get; set; }
		public List<CommentDto> Comment { get; set; }
	}
}
