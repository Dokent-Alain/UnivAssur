using Microsoft.EntityFrameworkCore;
using UnivAssurance.DataAccess.Models;

namespace UnivAssurance.DataAccess.Data
{
    public class SouscriptionDbContext: DbContext
    {  
      protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Person>(entite =>{
                entite.HasKey(Proprietes =>Proprietes.PersonID);
            });
            modelBuilder.Entity<Product>(entite =>{
                entite.HasKey(Proprietes =>Proprietes.ProductId);
            });

            modelBuilder.Entity<Subscription>(entite =>{
                entite.HasKey(Proprietes =>Proprietes.SubscriptionID);
            });

            modelBuilder.Entity<Commercial>(entite =>{
                entite.HasKey(Proprietes =>Proprietes.CommercialId);
            });
      }   
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if(!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer("Server=DESKTOP-3BEDEK9;Database=univAssurance;User Id=sa;Password=1234;Encrypt=false;");
            }
      }
        public SouscriptionDbContext()
        {
            
        } 
        public SouscriptionDbContext(DbContextOptions<DbContext> option):base (option)
        {
            
        }

        public virtual DbSet<Person> Person{get;set;}  
    }
}