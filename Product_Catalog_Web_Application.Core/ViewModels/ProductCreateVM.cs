using Product_Catalog_Web_Application.Core.Entities.Identity;
using Product_Catalog_Web_Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Product_Catalog_Web_Application.Core.ViewModels
{
	public class ProductCreateVM
	{
		public required string Name { get; set; }
		[Required(ErrorMessage = "Start Date is required")]
		public required DateOnly StartDate { get; set; }
		[Required(ErrorMessage = "Duration is required")]
		[Range(0, int.MaxValue)]
		public required int Duration { get; set; }
		[Required(ErrorMessage = "Price is required")]
		[Range(1, double.MaxValue, ErrorMessage = "Wrong price range")]
		public required decimal Price { get; set; }

		[Required(ErrorMessage = "Required field")]
		[Range(1, int.MaxValue)]
		public required int CategoryId { get; set; }
	}
}
