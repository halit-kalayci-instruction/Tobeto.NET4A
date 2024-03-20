using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    // Erişim Belirteci -> public -> Tüm dış dünyaya açık
    // Private => ilgili nesneye özel
    public class Product
    {
        // geri dönüş tipi olmayan, nesne ismiyle aynı olan.
        // Eğer ilgili class hiç bir ctor tanımı içermiyor ise
        // boş parametreli ctor default olarak eklenir.

        // All Args Ctor
        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
        // No Args Ctor
        public Product()
        {

        }
        public int Id { get; set; } // Field
        public string Name { get; set; }
    }
}
