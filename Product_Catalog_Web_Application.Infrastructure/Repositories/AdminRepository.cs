using Microsoft.AspNetCore.Identity;
using Product_Catalog_Web_Application.Core.Entities.Identity;
using Product_Catalog_Web_Application.Core.Interfaces;
using Product_Catalog_Web_Application.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ProductCatalogWebApplicationDBContext _dBContext;

        public AdminRepository(ProductCatalogWebApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Admin> GetByApplicationUserIdAsync(string applicationUserId)
        {
            var admin = _dBContext.Admins.FirstOrDefault(a => a.ApplicationUserId == applicationUserId);
            return admin;
        }
    }
}
