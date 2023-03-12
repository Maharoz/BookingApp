using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    //internal class MedicineDetailsConfiguration : IEntityTypeConfiguration<MedicineDetails>
    //{
    //    public void Configure(EntityTypeBuilder<MedicineDetails> builder)
    //    {
    //        builder.HasData
    //        (
    //            new MedicineDetails
    //            {
    //                Id = 1,
    //                MedicineTypeEnum = API.Utility.MedicineTypeEnum.Tablet,
    //                ManufacturerName = "Beximco",
    //                MedicineManufacturerCountry = "Bangladesh",
    //                UsedFor = "Fever,Headache",
    //                SideEffects="None",
    //                isSafeForChilds=true,
    //                MedicineId=1

    //            },
    //            new MedicineDetails
    //            {

    //                Id = 2,
    //                MedicineTypeEnum = API.Utility.MedicineTypeEnum.Tablet,
    //                ManufacturerName = "Sanofi",
    //                MedicineManufacturerCountry = "Bangladesh",
    //                UsedFor = "Acid Reflax",
    //                SideEffects = "None",
    //                isSafeForChilds = true,
    //                MedicineId = 2
    //            }
    //        );
    //    }
    //}
}
