using Microsoft.EntityFrameworkCore;
using Rankings.EntityFramework.Entities;
using System;

namespace Rankings.EntityFramework
{
    public class RankingsContext : DbContext
    {
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<Item> Items { get; set; }

        public RankingsContext(DbContextOptions options)
            : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //for migrations
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=rankings.db");
            }
        }
            
    }
}
