using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.Entities;

namespace WebApiApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<ShopItem> ShopItems { get; set; }
    }
}
