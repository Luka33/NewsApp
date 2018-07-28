using Microsoft.EntityFrameworkCore;
using NewsApp.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.Data.SqlServer
{
    public class NewsAppDbContext : DbContext
    {
        public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options) : base(options) { }

        public DbSet<News> News { get; set; }
    }
}
