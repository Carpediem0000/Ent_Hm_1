using Ent_Hm_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ent_Hm_1
{
    internal class AppDbContext: DbContext
    {
        private readonly IConfiguration Configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
    }
}
