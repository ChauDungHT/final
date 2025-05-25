using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using final.Areas.Admin.Models;

namespace final.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Users> Userss { get; set; }
        public DbSet<Categories> category { get; set; }
        public DbSet<Assignments> assignment { get; set; }
        public DbSet<Submissions> submission { get; set; }
        public DbSet<PlagiarismResults> plagiarismResult { get; set; }
        public DbSet<AIInteractions> AIInteraction { get; set; }
    }
}