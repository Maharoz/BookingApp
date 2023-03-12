using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures;

namespace Entities.LinkModels;

public record LinkParameters(HotelSearchParameters hotelparameters, HttpContext Context);
