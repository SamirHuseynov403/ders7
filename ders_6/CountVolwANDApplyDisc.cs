using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ders_6
{
    public static class CountVolwANDApplyDisc
    {
        public static int CountVowels(string text)
        {
            char[] Vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U', };
            int countVowels = 0;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < Vowels.Length; j++)
                {
                    if (text[i] == Vowels[j])
                    {
                        countVowels++;
                    }
                }
            }
            return countVowels;
        }

        public static decimal ApplyDiscount(this decimal price, decimal discount)
        {
            return price - (price * discount / 100);
        }
    }
}
