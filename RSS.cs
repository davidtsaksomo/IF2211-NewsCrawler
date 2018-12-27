using System;
using System.Xml;

namespace News_Crawler
{
	public class RSS
	{
		public RSS (XmlDocument XML,string name)
		{
			this.XML = XML;
			this.name = name;
		}
		public XmlDocument getXml() {
			return XML;
		}
		public string getName() {
			return name;
		}

		private XmlDocument XML;
		private string name;
	}
}

