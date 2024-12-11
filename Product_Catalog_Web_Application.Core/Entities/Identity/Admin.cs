using Product_Catalog_Web_Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Entities.Identity
{
	public class Admin : BaseEntity<int>
	{
		public required string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
