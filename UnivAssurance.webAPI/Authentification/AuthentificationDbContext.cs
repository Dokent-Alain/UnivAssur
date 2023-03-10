using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UnivAssurance.webAPI.Authentification;

public class AuthentificationDbConext : IdentityDbContext<ApplicationUser>
{
    public AuthentificationDbConext()
    {

    }
    public AuthentificationDbConext(DbContextOptions<IdentityDbContext> dbContext) : base(dbContext)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Server=DESKTOP-3BEDEK9;Database=univAssurance;User Id=sa;Password=1234;Encrypt=false;");
            }
      }

}