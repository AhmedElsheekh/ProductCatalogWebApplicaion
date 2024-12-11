using Product_Catalog_Web_Application.Core.Abstractions;
using Product_Catalog_Web_Application.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Entities
{
	public class Product : BaseEntity<int>
	{
		public required string Name { get; set; }
		public required DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public required DateOnly StartDate { get; set; }
		public required int Duration { get; set; }
		public required decimal Price { get; set; }

		//Navigation properties
		[ForeignKey("Admin")]
		public required int CreatedByUserId { get; set; }
		public required Admin Admin { get; set; }
		public required int CategoryId { get; set; }
		public required Category Category { get; set; }
	}
}
