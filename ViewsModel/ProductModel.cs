using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WirlessMediaSimpleCRUD.Models;

namespace WirlessMediaSimpleCRUD.ViewsModel
{
    public class ProductModel
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public string Store { get; set; }
    }
}
