using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BI_CM_C1_2020.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasData(
                new { id = 1, title = "Meeting", text = "Conference on the sales results for the previous year. Monica please examine sales trends in marketing and products. Below please find the current status of the sale.", date = DateTime.Now },
                new { id = 2, title = "Send documents to Mike", text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since.", date = DateTime.Now },
                new { id = 3, title = "Coffee Break", text = "Go to shop and find some products. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's.", date = DateTime.Now },
                new { id = 4, title = "Phone with Jeronimo", text = "Lorem Ipsum has been the industry's standard dummy text ever since.", date = DateTime.Now }
                );
    }


    public static implicit operator DBContext(HostingApplication.Context v)
        {
            throw new NotImplementedException();
        }
    }
}
