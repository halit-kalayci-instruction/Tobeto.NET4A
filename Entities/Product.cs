using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id, string name, double unitPrice, int stock, int categoryId)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            Stock = stock;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }
    }
}
// Proje Referansları ve Paketleri
// PMC Default Project DataAccess
// Connection String
// 2:20