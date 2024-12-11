using Product_Catalog_Web_Application.Core.DTOs;
using Product_Catalog_Web_Application.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResultList<CategoryDetaailsVM>> GetAllAsync();
    }
}
