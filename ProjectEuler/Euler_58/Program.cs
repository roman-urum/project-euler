using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler_58
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
           
            stopwatch.Restart();
            Console.WriteLine("Calculating...");

            int m = 3;
            //int n = 40003;
            //int n = int.MaxValue;
            int n = 7;
            long step = 2;
            int totalAmout = 1;
            int primesAmount = 0;

            long k = 1;
            for (int i = m; i <= n; i+=2)
            {
                k += step;                
                primesAmount += ferma(k) ? 1 : 0;

                k += step;
                primesAmount += ferma(k) ? 1 : 0;

                k += step;
                primesAmount += ferma(k) ? 1 : 0;

                k += step;
                primesAmount += ferma(k) ? 1 : 0;

                totalAmout += 4;

                if (Math.Round((double)primesAmount / totalAmout * 100) < 10)
                {
                    Console.WriteLine("less than 10% when length = {0}", i);
                    break;
                }


                step += 2;                
            }

            stopwatch.Stop();
            Console.WriteLine("Calculating is ready in {0} s.", stopwatch.Elapsed.Seconds);

            Console.WriteLine("last {0}", k);

            Console.WriteLine("{0}/{1} = {2} ~ {3}", primesAmount, totalAmout , (double)primesAmount / totalAmout * 100, Math.Round((double)primesAmount / totalAmout * 100));
        }

        static bool ferma(long x)
        {
            if (x == 2) return true;

            var rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                long a = (rand.Next() % (x - 2)) + 2;

                if (gcd(a, x) != 1) return false;

                if (pows(a, x - 1, x) != 1) return false;
            }

            return true;
        }

        static long gcd(long a, long b)
        {
            if (b == 0) return a;

            return gcd(b, a % b);
        }

        static long mul(long a, long b, long m)
        {
            if (b == 1) return a;

            if (b % 2 == 0)
            {
                long t = mul(a, b / 2, m);
                return (2 * t) % m;
            }

            return (mul(a, b - 1, m) + a) % m;
        }
        static long pows(long a, long b, long m)
        {
            if (b == 0) return 1;

            if (b % 2 == 0)
            {
                long t = pows(a, b / 2, m);
                return mul(t, t, m) % m;
            }

            return mul(pows(a, b - 1, m), a, m) % m;
        }

    }
}
