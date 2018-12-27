using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace News_Crawler
{
	class RegexMatching
	{
		public static int RegexMatcher(string text, string pattern)
		{
			char[] splitter = { ' ', ',', '.', ':', '\t' };
			string[] words = pattern.Split(splitter);
			string splitted = words[0];
			string temp = "";
			for (int i = 0; i < words.Length - 1; i++)
			{
				temp += words[i];
				temp += ".*";
			}
			temp += words[words.Length - 1];
			Console.WriteLine("The Expression: " + temp);
			Regex r = new Regex(temp, RegexOptions.IgnoreCase);
			Match match = r.Match(text);
			if (match.Success)
			{
				return 1;
			}
			else
			{
				return -1;;
			}
		}
	}
}

