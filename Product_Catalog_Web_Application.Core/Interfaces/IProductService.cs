using Product_Catalog_Web_Application.Core.DTOs;
using Product_Catalog_Web_Application.Core.Entities;
using Product_Catalog_Web_Application.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Interfaces
{
	public interface IProductService
	{
		Task<ServiceResultList<ProductDetailsVM>> GetAllAsync();
		Task<ServiceResultList<ProductDetailsVM>> GetCurrentAsync();
		Task<ServiceResult<ProductDetailsVM>> GetByIdAsync(int id);
		Task<ServiceResult<ProductDetailsVM>> AddAsync(ProductCreateVM productCreateVM, int userId);
		Task<ServiceResult<ProductDetailsVM>> Update(int id, ProductUpdateVM productUpdateVM);
		Task<ServiceResult<ProductUpdateVM>> GetForUpdate(int id);
		Task<ServiceResult<ProductDetailsVM>> Delete(int id);
		ServiceResultList<ProductDetailsVM> GetByCategory(string category);
	}
}
