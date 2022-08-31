using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NLayer.Repository.Seeds
{
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature{Id = 1 , Color = "Kırmızı" , Height = 10 , Width = 10 ,ProductId = 1},
                new ProductFeature{Id = 2 , Color = "Mavi" , Height = 20 , Width = 20 ,ProductId = 2},
                new ProductFeature{Id = 3 , Color = "Yeşil" , Height = 30 , Width = 30 ,ProductId = 3}
            );
        }
    }
}
