using lab210.DAL.Configurations;
using lab210.DAL.Entitati;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL
{
    public class AppDbContext : IdentityDbContext<
        Utilizatori,
        Roluri,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
        public DbSet<Oras> Orase { get; set; }
        public DbSet<Producator> Producatori { get; set; }
        public DbSet<Model> Modele { get; set; }
        public DbSet<ListaMotoare> ListaMotoare { get; set; }
        public DbSet<Motor> Motoare { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(options => options.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   

            modelBuilder.ApplyConfiguration(new OrasConfiguration());
            modelBuilder.ApplyConfiguration(new ProducatorConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new ListaMotoareConfiguration());
            modelBuilder.ApplyConfiguration(new MotorConfiguration());

        }
    }
}
