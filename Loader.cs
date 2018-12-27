using System;
using System.Collections;
using System.Xml;
using System.Text;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace News_Crawler
{
	class MainClass
	{
		public static void Main (string[] args) {
			Load ();
			Console.WriteLine ("Keyword : ");
			string key = Console.ReadLine ();	
			Console.WriteLine ();
			searchNews (key,1);
			foreach (News N in searchResult) {
				N.printInfo ();
				Console.WriteLine ();
			}
			searchResult.Clear ();
		}
		public static void Load() {
			XmlDocument tempo = new XmlDocument ();
			XmlDocument viva = new XmlDocument ();

			tempo.Load ("https://www.tempo.co/rss/terkini");
			viva.Load ("http://rss.vivanews.com/get/all");

			rssPool.Add (new RSS (tempo, nameof (tempo)));
			rssPool.Add (new RSS (viva, nameof (viva)));

			foreach (RSS rss in rssPool) {
				XmlNodeList rssNodes = rss.getXml ().SelectNodes ("rss/channel/item");
				foreach (XmlNode rssNode in rssNodes) {
					try {
						XmlNode rssSubNode = rssNode.SelectSingleNode ("title");
						string title = rssSubNode != null ? rssSubNode.InnerText : "";

						rssSubNode = rssNode.SelectSingleNode ("link");
						string link = rssSubNode != null ? rssSubNode.InnerText : ""; 

						if (rss.getName () == "viva") {
							rssSubNode = rssNode.SelectSingleNode ("enclosure/@url");
						} else if (rss.getName () == "tempo") {
							rssSubNode = rssNode.SelectSingleNode ("image");
						}
						string imgUrl = rssSubNode != null ? rssSubNode.InnerText : "";
						//Console.WriteLine(imgUrl);

						rssSubNode = rssNode.SelectSingleNode ("pubDate");
						string date = rssSubNode != null ? rssSubNode.InnerText : "";

						HtmlWeb web = new HtmlWeb ();
					
						HtmlDocument doc;
						try {
							doc = web.Load (link);
						} catch (WebException Ex) {
							Console.WriteLine(Ex);
							continue;
						}
						string text = null;
						var root = doc.DocumentNode;

						foreach (HtmlNode node in root.SelectNodes("//p")) {						
							text += node.InnerHtml; 
						}
						doc.LoadHtml (text);
						string content = doc.DocumentNode.InnerText;
						newsPool.Add (new News (link, imgUrl, title, date, content));
					} catch (DirectoryNotFoundException E) {
						continue;
					}
					Console.Clear ();
					Console.WriteLine ("Loading");
				}
			}
		}
		public static void searchNews(string pattern,int opt) {
			foreach (News N in newsPool) {
				if (opt == 1) {
					if (KMP.Match (N.getContent (), pattern) != -1) {
						searchResult.Add (N);
					}
				} else if (opt == 2) {
					if (BooyerMoore.bmMatch (N.getContent (), pattern) != -1) {
						searchResult.Add (N);
					}
				} else if (opt == 3) {
					if (RegexMatching.RegexMatcher (N.getContent (), pattern) != -1) {
						searchResult.Add (N);
					}
				}
			}
		}

		public static ArrayList rssPool = new ArrayList ();
		public static ArrayList newsPool = new ArrayList();
		public static ArrayList searchResult = new ArrayList ();
	}
} 