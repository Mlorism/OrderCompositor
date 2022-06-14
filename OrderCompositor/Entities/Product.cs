using System.Xml.Serialization;

namespace OrderCompositor.Entities
{
	public class Product : ProductBase
	{
		[XmlIgnore]
		public int Id { get; set; }
		[XmlIgnore]
		public int OrderId { get; set; }
		[XmlIgnore]
		public virtual Order Order { get; set; }
	}
}
