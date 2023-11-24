using System;
using Microsoft.EntityFrameworkCore;

namespace exam_azure.Entities
{
	public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }
}

