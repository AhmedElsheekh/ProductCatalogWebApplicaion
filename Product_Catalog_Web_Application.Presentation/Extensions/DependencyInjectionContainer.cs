using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Product_Catalog_Web_Application.ApplicationService.Mapper;
using Product_Catalog_Web_Application.ApplicationService.Services;
using Product_Catalog_Web_Application.Core.Entities.Identity;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Infrastructure.Data;
using Product_Catalog_Web_Application.Infrastructure.Repositories;

namespace Product_Catalog_Web_Application.Presentation.Extensions
{
	public static class DependencyInjectionContainer
	{
		public static IServiceCollection AddDIServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<ProductCatalogWebApplicationDBContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(20);
			})
				.AddEntityFrameworkStores<ProductCatalogWebApplicationDBContext>()
				.AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IAdminRepository, AdminRepository>();
			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
	}
}
