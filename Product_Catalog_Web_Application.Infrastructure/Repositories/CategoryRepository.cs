using Microsoft.EntityFrameworkCore;
using Product_Catalog_Web_Application.Core.Entities;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Core.ViewModels;
using Product_Catalog_Web_Application.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductCatalogWebApplicationDBContext _dBContext;

        public CategoryRepository(ProductCatalogWebApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _dBContext.Categories.ToListAsync();
    }
}
