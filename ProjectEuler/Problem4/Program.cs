using System;
using System.Diagnostics;

namespace Problem4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var maxPalindrome = 0;
            for (int i = 999; i > 99; i--)
            {
                //decrement by 11 because result palindrome must be devisible by 11. Details here https://projecteuler.net/thread=4#1211
                for (int j = 990; j > 99; j -= 11)
                {
                    int k = i * j;
                    if (isPalindrome(k))
                    {
                        if (maxPalindrome < k)
                        {
                            maxPalindrome = k;
                        }
                    }
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"{maxPalindrome}, elapse {stopWatch.Elapsed.TotalMilliseconds} ms.");
        }

        public static bool isPalindrome(int d)
        {
            var dString = d.ToString();
            var l = dString.Length;
            for (int i = 0; i < l / 2; i++)
            {
                if (dString[i] != dString[l - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}