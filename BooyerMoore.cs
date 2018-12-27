using System;

namespace News_Crawler
{
	public class BooyerMoore
	{
		public static int[] buildLast(String pattern)
		{
			int[] last = new int[128];
			for (int i = 0; i < 128; i++)
			{
				last[i] = -1;
			}
			for (int i = 0; i < pattern.Length; i++)
			{
				if ((pattern[i] >= 97 && pattern[i] <= 122))
				{
					last[pattern[i]] = i;
					last[pattern[i] - 32] = i;
				}
				else if (pattern[i] >= 65 && pattern[i] <= 90)
				{
					last[pattern[i]] = i;
					last[pattern[i] + 32] = i;
				}
				else
				{
					last[pattern[i]] = i;
				}
			}
			return last;
		}
		public static int bmMatch(String text, String pattern)
		{
			int[] last = buildLast(pattern);
			int n = text.Length;
			int m = pattern.Length;
			int i = m - 1;
			if (i > n - 1)
			{
				return -1; //pattern lebih panjang dr text
			}
			int j = m - 1;
			do
			{
				if (pattern[j] >= 65 && pattern[j] <= 90)
				{
					if ((pattern[j] == text[i]) || pattern[j] + 32 == text[i])
					{
						if (j == 0)
						{
							return i;
						}
						else
						{
							i--;
							j--;
						}
					}
					else
					{
						int lastoccur = last[text[i]]; //last occurence dr huruf
						i = i + m - Math.Min(j, 1 + lastoccur);
						j = m - 1;
					}
				}
				else if (pattern[j] >= 97 && pattern[j] <= 122)
				{
					if ((pattern[j] == text[i]) || pattern[j] - 32 == text[i])
					{
						if (j == 0)
						{
							return i;
						}
						else
						{
							i--;
							j--;
						}
					}
					else
					{
						int lastoccur = last[text[i]]; //last occurence dr huruf
						i = i + m - Math.Min(j, 1 + lastoccur);
						j = m - 1;
					}
				}
				else
				{
					if (pattern[j] == text[i])
					{
						if (j == 0)
						{
							return i;
						}
						else
						{
							i--;
							j--;
						}
					}
					else
					{
						int lastoccur = last[text[i]]; //last occurence dr huruf
						i = i + m - Math.Min(j, 1 + lastoccur);
						j = m - 1;
					}

				}
			} while (i <= n - 1);
			return -1; //no match
		}
	}
}

