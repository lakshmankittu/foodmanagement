using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Models
{
    public class Food
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string[] Tags { get; set; }
        public bool Favorite { get; set; }
        public int Stars { get; set; }
        public string ImageUrl { get; set; }
        public string[] Origins { get; set; }
        public string CookTime { get; set; }
    }
}
