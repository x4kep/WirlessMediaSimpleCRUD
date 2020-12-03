using WirlessMediaSimpleCRUD.Models;
using System;
using System.Linq;

namespace WirlessMediaSimpleCRUD.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return; 
            }

            var products = new Product[]
            {
                new Product{Name="JBL Endurance", Description="Bele, Crne", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost=5.899 },
                new Product{Name="JBL Tune 500BT", Description="Bele, Crne, Crvene", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost=6.299 },
                new Product{Name="JBL E45BT", Description="Bele, Crne, Plave", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost= 11.999 },
                new Product{Name="JBL QUANTUM 100", Description="Crne, Crvene", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost=4.999 },
                new Product{Name="JBL QUANTUM 600", Description="Bele, Crne", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost= 17.999 },
                new Product{Name="JBL QUANTUM 800", Description="Bele, Crne", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost= 24.599 },
                new Product{Name="SENNHEISER CX 350BT", Description="Bele", Category="Bežične slušalice", Manufacturer="SENNHEISER", Supplier="WinWin", Cost= 11.899 },
                new Product{Name="SENNHEISER CX 100", Description="Crvene", Category="Bubice", Manufacturer="SENNHEISER", Supplier="Gigatron", Cost= 5.899 },
                new Product{Name="SENNHEISER HD 450BT", Description="Crne", Category="Bežične slušalice", Manufacturer="SENNHEISER", Supplier="Gigatron", Cost= 15.999 },
                new Product{Name="SONY WH-CH510L", Description="Bele, Crne, Crvene", Category="Bežične slušalice", Manufacturer="SONY", Supplier="WinWin", Cost= 6.999 }
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }

            context.SaveChanges();
        }
    }
}