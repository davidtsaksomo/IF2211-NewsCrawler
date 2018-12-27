using System;

namespace News_Crawler
{
	public class KMP
	{
		public static int Match(string text,string pattern)
		{
			int n = text.Length;
			int m = pattern.Length;

			int[] fail = computeFail(pattern);

			int i=0;
			int j=0;
			while (i < n) {
				if (Char.ToLower(pattern[j]) == Char.ToLower(text[i])) {
					if (j == m - 1) {
						return i - m + 1; // match
					}
					i++;
					j++;
				}
				else if (j > 0) {
					j = fail[j-1];
				}
				else {
					i++;
				}
			}
			return -1; // no match
		}
		public static int[] computeFail(string pattern)
		{
			int[] fail = new int[pattern.Length];

			fail[0] = 0;

			int m = pattern.Length;
			int j = 0;
			int i = 1;
			while (i < m) {
				if  (Char.ToLower(pattern[j]) == Char.ToLower(pattern[i])) {   //j+1 chars match
					fail[i] = j + 1;
					i++;
					j++;
				}
				else if (j > 0) {// j follows matching prefix
					j = fail[j-1];
				}
				else {     // no match
					fail[i] = 0;
					i++;
				}
			}
			return fail;
		}
	}
}


/*string Text = Console.ReadLine();
			string Pattern = Console.ReadLine();
			Console.WriteLine("Text: " +Text);
			Console.WriteLine("Pattern: "+Pattern);

			int pos = KMP.Match(Text, Pattern);
			if (pos == -1) {
				Console.WriteLine("Pattern not found");
			}
			else {
				Console.WriteLine("Pattern starts at pos :" + pos);
			}*/