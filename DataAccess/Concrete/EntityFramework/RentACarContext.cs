using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class RentACarContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Database = RentACar;Trusted_Connection = true");
		}
        public RentACarContext()
        {
        }
        public RentACarContext(DbContextOptions<RentACarContext> options)
        : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
