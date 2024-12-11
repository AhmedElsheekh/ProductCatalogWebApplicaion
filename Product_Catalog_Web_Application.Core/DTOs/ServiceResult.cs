using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.DTOs
{
	public class ServiceResult<TEntity>
	{
		public TEntity? Data { get; set; }
		public bool Success { get; set; }
		public string? Message { get; set; }
	}
}
