using AutoMapper;
using Product_Catalog_Web_Application.Core.Entities;
using Product_Catalog_Web_Application.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.ApplicationService.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ProductCreateVM, Product>();
			CreateMap<Product, ProductDetailsVM>()
				.ForMember(d => d.Category, s => s.MapFrom(p => p.Category.Name))
				.ForMember(d => d.CreatedByUser, s => s.MapFrom(p => p.Admin.ApplicationUser.UserName));
			CreateMap<Product, ProductUpdateVM>();

			CreateMap<Category, CategoryDetaailsVM>();
		}
	}
}
