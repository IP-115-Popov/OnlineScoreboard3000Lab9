using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineScoreboard3000.Models
{
    public class ReisDataBaseContext : DbContext
    {
        public DbSet<Reis> Reises => Set<Reis>();
        public ReisDataBaseContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=reisdata1.db");
        }
    }
}
