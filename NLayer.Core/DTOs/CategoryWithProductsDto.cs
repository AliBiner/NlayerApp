using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core.Entity;

namespace NLayer.Core.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
