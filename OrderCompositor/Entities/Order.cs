using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OrderCompositor.Entities
{
	public class Order : OrderBase
	{
		[XmlIgnore]
		public int Id { get; set; }		
	}
}
