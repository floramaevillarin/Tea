using System;
using System.Collections.Generic;

namespace Fiftea.Model
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public int CreatedBy { get; set; }
		public DateTime DateCreated { get; set; }
		public ICollection<Product> Products { get; set; }

	}
}
