using Microsoft.EntityFrameworkCore;
using Product_Catalog_Web_Application.Core.Entities;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ProductCatalogWebApplicationDBContext _dBContext;

		public ProductRepository(ProductCatalogWebApplicationDBContext dBContext)
		{
			_dBContext = dBContext;
		}

		public async Task AddAsync(Product product)
			=> await _dBContext.Products.AddAsync(product);

		public void Delete(Product product)
			=> _dBContext.Products.Remove(product);

		public async Task<IEnumerable<Product>> GetAllAsync()
			=> await _dBContext.Products
			.Include(p => p.Category)
			.Include(p => p.Admin)
			.ThenInclude(a => a.ApplicationUser)
			.ToListAsync();

		public IQueryable<Product> GetByCategory(string category)
			=> _dBContext.Products
			.Include(p => p.Category)
			.Where(p => p.Category.Name.ToLower() == category.ToLower());

        public async Task<Product?> GetByIdAsync(int id)
			=> await _dBContext.Products.FindAsync(id);

		public IQueryable<Product> GetCurrentAsync()
			=> _dBContext.Products.Where(p => 
			p.StartDate <= DateOnly.FromDateTime(DateTime.Now)
			&& DateOnly.FromDateTime(DateTime.Now) <= p.StartDate.AddDays(p.Duration))
			.Include(p => p.Category)
			.Include(p => p.Admin)
			.ThenInclude(a => a.ApplicationUser);

		public void Update(Product product)
			=> _dBContext.Update(product);
	}
}
