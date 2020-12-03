using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WirlessMediaSimpleCRUD.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Manufacturer { get; set; }

        public string Supplier { get; set; }

        public double Cost { get; set; }

    }
}
