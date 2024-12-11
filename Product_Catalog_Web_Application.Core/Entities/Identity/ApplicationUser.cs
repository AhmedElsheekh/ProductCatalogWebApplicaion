using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Entities.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string? FullName { get; set; }
	}
}
