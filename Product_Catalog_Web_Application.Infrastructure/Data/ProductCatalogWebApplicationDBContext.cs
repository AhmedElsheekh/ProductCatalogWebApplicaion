using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product_Catalog_Web_Application.Core.Entities;
using Product_Catalog_Web_Application.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Infrastructure.Data
{
	public class ProductCatalogWebApplicationDBContext : IdentityDbContext<ApplicationUser>
	{
		public ProductCatalogWebApplicationDBContext(DbContextOptions<ProductCatalogWebApplicationDBContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Admin> Admins { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfigurationsFromAssembly(typeof(ProductCatalogWebApplicationDBContext).Assembly);
		}
	}
}
