using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entity;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product{Id = 1 , Name = "Kurşun Kalem" , Price =100 , Stock =100 , CategoryId = 1 , CreatedDate = DateTime.Now},
                new Product{Id = 2 , Name = "Tükenmez Kalem" , Price =200 , Stock =200 , CategoryId = 1 , CreatedDate = DateTime.Now},
                new Product{Id = 3 , Name = "Dolma Kalem" , Price =300 , Stock =300 , CategoryId = 1 , CreatedDate = DateTime.Now},
                new Product{Id = 4 , Name = "Çizgili Defter" , Price =100 , Stock =100 , CategoryId = 3 , CreatedDate = DateTime.Now},
                new Product{Id = 5 , Name = "Kareli Defter" , Price =200 , Stock =200 , CategoryId = 3 , CreatedDate = DateTime.Now},
                new Product{Id = 6 , Name = "Resim Defteri" , Price =300 , Stock =300 , CategoryId = 3 , CreatedDate = DateTime.Now},
                new Product{Id = 7 , Name = "Tarih Kitabı" , Price =100 , Stock =100 , CategoryId = 2 , CreatedDate = DateTime.Now},
                new Product{Id = 8 , Name = "Ders Kitabı" , Price =200 , Stock =200 , CategoryId = 2 , CreatedDate = DateTime.Now});
        }
    }
}
