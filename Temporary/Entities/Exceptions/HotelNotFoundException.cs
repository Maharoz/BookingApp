using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class HotelNotFoundException : NotFoundException
    {
        public HotelNotFoundException(int hotelId)
        : base($"The hotel with id: {hotelId} doesn't exist in the database.")
        {
        }
    }
}
