using System;

namespace News_Crawler
{
	public class News
	{
		public News (string url,string imgUrl,string title,string date,string content)
		{
			this.url = url;
			this.imgUrl = imgUrl;
			this.title = title;
			this.date = date;
			this.content = content;
		}
		public void setUrl(string url)
		{
			this.url = url;
		}
		public void setImgUrl(string imgUrl) {
			this.imgUrl = imgUrl;
		}
		public void setTitle(string title) 
		{
			this.title = title;
		}
		public void setDate(string date)
		{
			this.date = date;
		}
		public void setContent(string content)
		{
			this.content = content;
		}
		public string getUrl()
		{
			return url;
		}
		public string getImgUrl() {
			return imgUrl;
		}
		public string getTitle()
		{
			return title;
		}
		public string getDate()
		{
			return date;
		}
		public string getContent()
		{
			return content;
		}
		public void printInfo()
		{
			Console.WriteLine ("Title : " + title);
			Console.WriteLine ("URL : " + url);
			Console.WriteLine ("Image URL : " + imgUrl);
			Console.WriteLine ("Date : " +date);
			Console.WriteLine ("Content : ");
			Console.WriteLine (content);
		}



		private string url;
		private string imgUrl;
		private string title;
		private string date;
		private string content;
	}
}

