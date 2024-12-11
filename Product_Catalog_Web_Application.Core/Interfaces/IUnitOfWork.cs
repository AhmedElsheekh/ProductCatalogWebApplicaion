using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Interfaces
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IProductRepository ProductRepository { get; }
		Task<int> CompleteAsync();
	}
}
