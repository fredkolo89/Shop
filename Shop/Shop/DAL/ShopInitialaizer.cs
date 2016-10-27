using System;
using System.Collections.Generic;
using System.Data.Entity;
using Shop.Models;

namespace Shop.DAL
{
    public class ShopInitialaizer : DropCreateDatabaseAlways<ShopContext>
    {

        protected override void Seed(ShopContext context)
        {
            SeedData(context);
            base.Seed(context);
        }

        private void SeedData(ShopContext context)
        {
            var categories = new List<Category>();
            categories.Add(new Category() { Description = "Kategoria z komputerami oraz laptopami", Name = "Komputery" });
            categories.Add(new Category() { Description = "Kategoria z telefonami i smartfonami", Name = "Telefony" });
            categories.Add(new Category() { Description = "Kategoria z telewizorami", Name = "Telewizory" });

            categories.ForEach(c => context.Category.Add(c));
            context.SaveChanges();

            var products = new List<Product>();
            products.Add(new Product()
            {
                Name = "Laptop Asus 15 cali, i7 2.0 GHz",
                Brand = "Asus",
                CategoryId = 1,
                ImagePath = "asus1.jpg",
                Description = "Mocny laptop Asus'a z wydajnym procesorem i kartą grafiki",
                Avaliability = true,
                Price = 2099,
                DateAdded = new DateTime(2016, 08, 23)
            });
            products.Add(new Product()
            {
                Name = "Lenovo 13 cali, i3 1.5 GHz",
                Brand = "Lenovo",
                CategoryId = 1,
                ImagePath = "lenovo1.jpg",
                Description = "Laptop Lenovo, ze zintegrowaną grafiką i pojemnym ukumulatorem",
                Avaliability = true,
                Price = 1699,
                DateAdded = new DateTime(2016, 07, 23)

            });
            products.Add(new Product()
            {
                Name = "Telefon Sony Xperia S 5 cali",
                Brand = "Sony",
                CategoryId = 2,
                ImagePath = "sony1.jpg",
                Description = "Ciekawy telefon SOny Xperia z perfekcyjnym ekranem",
                Avaliability = true,
                Price = 1122,
                DateAdded = new DateTime(2016, 03, 23)
            });
            products.Add(new Product()
            {
                Name = "Samsung Galaxy S6 edge ",
                Brand = "Samsung",
                CategoryId = 2,
                ImagePath = "samsung1.jpg",
                Description = "Doskonały smartfon Samsung Galaxy s6 edge z zakrzywionym ekranem",
                Avaliability = true,
                Price = 2355,
                DateAdded = new DateTime(2016, 01, 23)

            });

            products.ForEach(c => context.Product.Add(c));
            context.SaveChanges();

            var accounts = new List<Account>();

            accounts.Add(new Account() { AcessLevel = 0, Name = "Darek", Surname = "Kowlaski", Adress = "Kielce", TelephoneNumber = "542365854", Mail = "darek@gmail.com" });
            accounts.Add(new Account() { AcessLevel = 1, Name = "Marek", Surname = "Nowak", Adress = "Warszawa", TelephoneNumber = "599965854", Mail = "marek@gmail.com" });

            accounts.ForEach(a => context.Account.Add(a));
            context.SaveChanges();

        }


    }
}