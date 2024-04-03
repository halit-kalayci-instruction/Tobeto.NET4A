using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Product.Responses
{
    public class ListProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }
}
