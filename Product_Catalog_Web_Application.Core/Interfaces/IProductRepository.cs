using Product_Catalog_Web_Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Interfaces
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllAsync();
		IQueryable<Product> GetCurrentAsync();
		IQueryable<Product> GetByCategory(string category);
		Task<Product?> GetByIdAsync(int id);
		Task AddAsync(Product product);
		void Update(Product product);
		void Delete(Product product);
	}
}
