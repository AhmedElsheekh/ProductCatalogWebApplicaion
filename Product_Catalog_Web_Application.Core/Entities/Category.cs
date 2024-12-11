using Product_Catalog_Web_Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Entities
{
	public class Category : BaseEntity<int>
	{
		public required string Name { get; set; }
		public string? Description { get; set; }
		public ICollection<Product>? Products { get; set; }

	}
}
