using AutoMapper;
using Product_Catalog_Web_Application.Core.DTOs;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.ApplicationService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResultList<CategoryDetaailsVM>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return new ServiceResultList<CategoryDetaailsVM>
            {
                Data = _mapper.Map<IEnumerable<CategoryDetaailsVM>>(categories),
                Count = categories.Count()
            };
        }
    }
}
