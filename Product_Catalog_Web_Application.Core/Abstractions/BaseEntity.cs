using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Web_Application.Core.Abstractions
{
	public abstract class BaseEntity<T> where T : struct
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public T Id { get; set; }
	}
}
