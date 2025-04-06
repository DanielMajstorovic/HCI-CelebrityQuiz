using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrityQuiz.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Leaderboard> Leaderboards { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

    }
}
