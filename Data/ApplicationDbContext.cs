using FlowerShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FlowerShop.Models.Brunsh> Brunsh { get; set; }

        public DbSet<FlowerShop.Models.BrunshFlower> BrunshFlower { get; set; }
        public DbSet<FlowerShop.Models.User> User { get; set; }


        public DbSet<FlowerShop.Models.FlowerBou> FlowerBou { get; set; }

        public DbSet<FlowerShop.Models.Occasion> Occasion { get; set; }

        public DbSet<FlowerShop.Models.Order> Order { get; set; }

        public DbSet<FlowerShop.Models.OrderProd> OrderProd { get; set; }
    }
}
