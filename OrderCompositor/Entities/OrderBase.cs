using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCompositor.Entities
{
	public class OrderBase
	{
		public string ClientName { get; set; }
		public string ClientSurname { get; set; }
		public DateTime ClientDateOfBirth { get; set; }
		public virtual List<Product> Products { get; set; }
	}
}
