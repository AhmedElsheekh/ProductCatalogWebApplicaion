using Product_Catalog_Web_Application.Core.DTOs;
using Product_Catalog_Web_Application.Core.Entities;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Product_Catalog_Web_Application.ApplicationService.Services
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork,
			IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ServiceResult<ProductDetailsVM>> AddAsync(ProductCreateVM productCreateVM,
			int userId)
		{
			if(productCreateVM is null)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = null,
					Success = false,
					Message = "Invalid product input"
				};
			}

			var product = _mapper.Map<Product>(productCreateVM);
			product.CreatedByUserId = userId;
			await _unitOfWork.ProductRepository.AddAsync(product);
			var result = await _unitOfWork.CompleteAsync();
			if (result > 0)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = _mapper.Map<ProductDetailsVM>(product),
					Success = true,
					Message = "Product has been created successfully"
				};
			}

			return new ServiceResult<ProductDetailsVM>
			{
				Data = null,
				Success = false,
				Message = "Something went wrong"
			};
		}

		public async Task<ServiceResult<ProductDetailsVM>> Delete(int id)
		{
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
			if(product is null)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = null,
					Success = false,
					Message = "Product is not found"
				};
			}

			_unitOfWork.ProductRepository.Delete(product);
			var result = await _unitOfWork.CompleteAsync();
			if(result > 0)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = null,
					Success = true,
					Message = "Product has been deleted successfully"
				};
			}

			return new ServiceResult<ProductDetailsVM>
			{
				Data = null,
				Success = false,
				Message = "Something went wrong"
			};
		}

		public async Task<ServiceResultList<ProductDetailsVM>> GetAllAsync()
		{
			var products = await _unitOfWork.ProductRepository.GetAllAsync();
			return new ServiceResultList<ProductDetailsVM>
			{
				Data = _mapper.Map<IEnumerable<ProductDetailsVM>>(products),
				Count = products.Count()
			};
		}

        public ServiceResultList<ProductDetailsVM> GetByCategory(string category)
        {
			var products = _unitOfWork.ProductRepository.GetByCategory(category).ToList();
			return new ServiceResultList<ProductDetailsVM>
			{
				Data = _mapper.Map<IEnumerable<ProductDetailsVM>>(products),
				Count = products.Count()
			};
        }

        public async Task<ServiceResult<ProductDetailsVM>> GetByIdAsync(int id)
		{
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
			if(product is null)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = null,
					Success = false,
					Message = "Product is not found"
				};
			}

			return new ServiceResult<ProductDetailsVM>
			{
				Data = _mapper.Map<ProductDetailsVM>(product),
				Success = true,
				Message = "Product is found"
			};
		}

		public async Task<ServiceResultList<ProductDetailsVM>> GetCurrentAsync()
		{
			var products = await _unitOfWork.ProductRepository.GetCurrentAsync().ToListAsync();
			return new ServiceResultList<ProductDetailsVM>
			{
				Data = _mapper.Map<IEnumerable<ProductDetailsVM>>(products),
				Count = products.Count
			};
		}

        public async Task<ServiceResult<ProductUpdateVM>> GetForUpdate(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return new ServiceResult<ProductUpdateVM>
                {
                    Data = null,
                    Success = false,
                    Message = "Product is not found"
                };
            }

            return new ServiceResult<ProductUpdateVM>
            {
                Data = _mapper.Map<ProductUpdateVM>(product),
                Success = true,
                Message = "Product is found"
            };
        }

        public async Task<ServiceResult<ProductDetailsVM>> Update(int id, ProductUpdateVM productUpdateVM)
		{
			if(id != productUpdateVM.Id)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = null,
					Success = false,
					Message = "Invalid product id"
				};
			}

			var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
			if(product is null)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = null,
					Success = false,
					Message = "Product is not found"
				};
			}

			product.StartDate = productUpdateVM.StartDate;
			product.Duration = productUpdateVM.Duration;
			product.Price = productUpdateVM.Price;
			product.CategoryId = productUpdateVM.CategoryId;
			product.Name = productUpdateVM.Name;

			_unitOfWork.ProductRepository.Update(product);
			var result = await _unitOfWork.CompleteAsync();
			if(result > 0)
			{
				return new ServiceResult<ProductDetailsVM>
				{
					Data = _mapper.Map<ProductDetailsVM>(product),
					Success = true,
					Message = "Product has been updated successfully"
				};
			}

			return new ServiceResult<ProductDetailsVM>
			{
				Data = null,
				Success = false,
				Message = "Something went wrong"
			};
		}
	}
}
