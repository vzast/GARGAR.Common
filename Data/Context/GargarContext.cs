using Data.Context.Configurations;
using Data.Models.Public;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class GargarContext : IdentityDbContext<User>
    {
        private readonly string _conectionString;

        #region CTOR
        public GargarContext(string conectionString)
        {
            _conectionString = conectionString;
        }
        public GargarContext(DbContextOptions<GargarContext> options) : base(options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new UserConfigurations());


            base.OnModelCreating(modelBuilder);


            var hasher = new PasswordHasher<User>();
            #region Data Seeding
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                 Name = "Admin",
                 NormalizedName = "Administrator"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Firstname = "Sigma",
                Lastname = "Dev",
                Email = "TechnoGargar@outlook.com",
                NormalizedEmail = "technogargar@outlook.com",
                UserName = "GarGar",
                NormalizedUserName = "gargar",
                PasswordHash = hasher.HashPassword(null, "Administrator"),
            });
            #endregion
        }

    }
}
