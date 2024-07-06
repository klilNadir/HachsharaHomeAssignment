using HachsharaHomeAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace HachsharaHomeAssignment.Implementations
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = System.IO.Path.Join(path, "HachsharaHomeAssignmentKilil.db");
            optionsBuilder.UseSqlite(@$"DataSource={dbPath};");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set;}
    }
}
