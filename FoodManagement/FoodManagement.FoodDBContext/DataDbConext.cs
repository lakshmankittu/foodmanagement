using FoodManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.FoodDBContext
{
    public class DataDbConext :DbContext
    {
        public DataDbConext(DbContextOptions options): base(options) {}
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users {  get; set; }
    }
}
