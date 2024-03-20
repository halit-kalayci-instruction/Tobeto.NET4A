using ConsoleUI;

Console.WriteLine("Hello, World!");

int number = 0;
string text = "Merhaba";

// OOP => Gerçek hayattaki nesneyi bilgisayara tanıtmak.

// Kalıptan üretilen bir örnek 
// instance
// C# 8.0
Product product = new(1, "Kazak"); // Constructor, ctor -> Yapıcı blok


Product product2 = new();
product2.Name = "Klavye";
product2.Id = 2;

// Min. User'in gereksinimleri karşılayacak bir obje.
User user = new Admin();

User user2 = new Customer();

// İşçi sınıflara da nesne olarak bakar. Manager,DaL

// Veritabanı nesnesi -> MssqlNesnesi, PostgreSqlNesnesi

// OOP Concepts ->  Access Modifiers, Constructor, Inheritance, Polymorphism
// Abstraction, Interface