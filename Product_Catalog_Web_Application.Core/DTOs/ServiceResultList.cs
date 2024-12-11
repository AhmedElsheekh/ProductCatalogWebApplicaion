using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.DTOs
{
	public class ServiceResultList<TEntity>
	{
		public IEnumerable<TEntity> Data { get; set; } = new List<TEntity>();
		public int Count { get; set; }
	}
}
