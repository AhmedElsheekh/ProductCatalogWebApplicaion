using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.ViewModels
{
	public class ProductDetailsVM
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required DateOnly StartDate { get; set; }
		public required int Duration { get; set; }
		public required decimal Price { get; set; }
		public required string CreatedByUser { get; set; }
		public required string Category { get; set; }
	}
}
