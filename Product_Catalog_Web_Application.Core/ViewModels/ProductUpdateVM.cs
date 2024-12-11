using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.ViewModels
{
	public class ProductUpdateVM
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
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
