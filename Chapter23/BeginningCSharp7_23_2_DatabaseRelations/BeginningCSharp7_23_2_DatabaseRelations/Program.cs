using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using static System.Console;

namespace BeginningCSharp7_23_2_DatabaseRelations
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [Key]
        public int Code { get; set; }
    }

    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Stock> Inventory { get; set; }
    }
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public int OnHand { get; set; }
        public int OnOrder { get; set; }
        public virtual Book Item { get; set; }
    }
    public class BookContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookContext())
            {
                Book book1 = new Book
                {
                    Title = "Beginning Visual C# 2015",
                    Author = "Perkins, Reid, and Hammer"
                };
                db.Books.Add(book1);

                Book book2 = new Book
                {
                    Title = "Beginning XML",
                    Author = "Fawcett, Quin, and Ayers"
                };
                db.Books.Add(book2);

                var store1 = new Store
                {
                    Name = "Main St Books",
                    Address = "123 Main St",
                    Inventory = new List<Stock>()
                };
                db.Stores.Add(store1);

                Stock store1book1 = new Stock
                { Item = book1, OnHand = 4, OnOrder = 6 };
                store1.Inventory.Add(store1book1);

                Stock store1book2 = new Stock
                { Item = book2, OnHand = 1, OnOrder = 9 };
                store1.Inventory.Add(store1book2);

                var store2 = new Store
                {
                    Name = "Campus Books",
                    Address = "321 College Ave",
                    Inventory = new List<Stock>()
                };

                db.Stores.Add(store2);

                Stock store2book1 = new Stock
                { Item = book1, OnHand = 7, OnOrder = 23 };
                store2.Inventory.Add(store2book1);

                Stock store2book2 = new Stock
                { Item = book2, OnHand = 2, OnOrder = 8 };
                store2.Inventory.Add(store2book2);

                db.SaveChanges();

                var query = from store in db.Stores
                            orderby store.Name
                            select store;

                WriteLine("Bookstore Inventory Report:");
                WriteLine();
                foreach (var store in query)
                {

                    WriteLine($"{store.Name} located at {store.Address}");

                    foreach (Stock stock in store.Inventory)
                    {
                        WriteLine($"- Title: {stock.Item.Title}");
                        WriteLine($"-- Copies in Store: {stock.OnHand}");
                        WriteLine($"-- Copies on Order: {stock.OnOrder}");
                    }
                    WriteLine();
                }

                WriteLine("Press a key to exit...");
                ReadKey();
            }
        }
    }
}
