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

            var students = new Product[]
            {
                new Product{Id="1", Name="JBL Endurance", Description="Bele, Crne", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost=5.899 },
                new Product{Id="2", Name="JBL Tune 500BT", Description="Bele, Crne, Crvene", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost=6.299 },
                new Product{Id="3", Name="JBL E45BT", Description="Bele, Crne, Plave", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost= 11.999 },
                new Product{Id="4", Name="JBL QUANTUM 100", Description="Crne, Crvene", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost=4.999 },
                new Product{Id="5", Name="JBL QUANTUM 600", Description="Bele, Crne", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost= 17.999 },
                new Product{Id="6", Name="JBL QUANTUM 800", Description="Bele, Crne", Category="Bežične slušalice", Manufacturer="JBL", Supplier="Gigatron", Cost= 24.599 },
                new Product{Id="7", Name="SENNHEISER CX 350BT", Description="Bele", Category="Bežične slušalice", Manufacturer="SENNHEISER", Supplier="WinWin", Cost= 11.899 },
                new Product{Id="8", Name="SENNHEISER CX 100", Description="Crvene", Category="Bubice", Manufacturer="SENNHEISER", Supplier="Gigatron", Cost= 5.899 },
                new Product{Id="9", Name="SENNHEISER HD 450BT", Description="Crne", Category="Bežične slušalice", Manufacturer="SENNHEISER", Supplier="Gigatron", Cost= 15.999 },
                new Product{Id="10", Name="SONY WH-CH510L", Description="Bele, Crne, Crvene", Category="Bežične slušalice", Manufacturer="SONY", Supplier="WinWin", Cost= 6.999 }
            };

            foreach (Product s in students)
            {
                context.Products.Add(s);
            }

            context.SaveChanges();
        }
    }
}