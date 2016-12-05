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
            var categories = new List<Category>
            {
                new Category() {Description = "Kategoria z komputerami oraz laptopami", Name = "Komputery"},
                new Category() {Description = "Kategoria z telefonami i smartfonami", Name = "Telefony"},
                new Category() {Description = "Kategoria z telewizorami", Name = "Telewizory"}
            };

            categories.ForEach(c => context.Category.Add(c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product()
                {
                    Name = "Laptop Asus 15 cali, i7 2.0 GHz",
                    Brand = "Asus",
                    CategoryId = 1,
                    ImagePath = "asus1.jpg",
                    Description = "Mocny laptop Asus'a z wydajnym procesorem i kartą grafiki",
                    Avaliability = true,
                    IsHidden = false,
                    Price = 2099,
                    DateAdded = new DateTime(2016, 08, 23)

                },
                new Product()
                {
                    Name = "Lenovo 13 cali, i3 1.5 GHz",
                    Brand = "Lenovo",
                    CategoryId = 1,
                    ImagePath = "lenovo1.jpg",
                    Description = "Laptop Lenovo, ze zintegrowaną grafiką i pojemnym ukumulatorem",
                    Avaliability = true,
                    IsHidden = false,
                    Price = 1699,
                    DateAdded = new DateTime(2016, 07, 23)

                },
                new Product()
                {
                    Name = "Telefon Sony Xperia S 5 cali",
                    Brand = "Sony",
                    CategoryId = 2,
                    ImagePath = "sony1.jpg",
                    Description = "Ciekawy telefon SOny Xperia z perfekcyjnym ekranem",
                    Avaliability = true,
                    IsHidden = false,
                    Price = 1122,
                    DateAdded = new DateTime(2016, 03, 28)
                },
                new Product()
                {
                    Name = "Samsung Galaxy S6 edge ",
                    Brand = "Samsung",
                    CategoryId = 2,
                    ImagePath = "samsung1.jpg",
                    Description = "Doskonały smartfon Samsung Galaxy s6 edge z zakrzywionym ekranem",
                    Avaliability = true,
                    Price = 2355,
                    IsHidden = false,
                    DateAdded = new DateTime(2016, 01, 23)

                },
                 new Product()
                {
                    Name = "Telewizor LED Samsung Smart TV 50 cali",
                    Brand = "Samsung",
                    CategoryId = 3,
                    ImagePath = "samsungtv1.jpg",
                    Description = "Duzy telewizor Samsung, smart tv oferuje ciekawe możliwości, a technologia LED ogranicza zużycie prądu",
                    Avaliability = true,
                    IsHidden = false,
                    Price = 4586,
                    DateAdded = new DateTime(2016, 04, 15)
                },
                new Product()
                {
                    Name = "Toshiba 32 cale, Wifi, USB, 3 x Hdmi ",
                    Brand = "Toshiba",
                    CategoryId = 3,
                    ImagePath = "toshiba1.jpg",
                    Description = "Tani telewizor, świetna jakość obrazu, wysoki kontrast, do tego można sie z nim komunikować za pomocą Wifi",
                    Avaliability = true,
                    Price = 999,
                    IsHidden = false,
                    DateAdded = new DateTime(2016, 02, 07)

                }
            };

            products.ForEach(c => context.Product.Add(c));
            context.SaveChanges();

            //var accounts = new List<Account>();

            //accounts.Add(new Account() { AcessLevel = 0, Name = "Darek", Surname = "Kowlaski", Adress = "Kielce", TelephoneNumber = "542365854", Mail = "darek@gmail.com" });
            //accounts.Add(new Account() { AcessLevel = 1, Name = "Marek", Surname = "Nowak", Adress = "Warszawa", TelephoneNumber = "599965854", Mail = "marek@gmail.com" });

            //accounts.ForEach(a => context.Account.Add(a));
            //context.SaveChanges();

        }


    }
}