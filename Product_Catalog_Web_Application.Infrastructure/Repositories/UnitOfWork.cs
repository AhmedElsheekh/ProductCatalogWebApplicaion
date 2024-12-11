using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ProductCatalogWebApplicationDBContext _dBContext;

		public UnitOfWork(ProductCatalogWebApplicationDBContext dBContext,
			IProductRepository productRepository)
		{
			_dBContext = dBContext;
			ProductRepository = productRepository;
		}

		public IProductRepository ProductRepository { get; }

		public async Task<int> CompleteAsync()
			=> await _dBContext.SaveChangesAsync();

		public async ValueTask DisposeAsync()
			=> await _dBContext.DisposeAsync();
	}
}
