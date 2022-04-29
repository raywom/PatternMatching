using System;
using System.Diagnostics;

namespace Bruteforce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string T2 = "qwertyuiopasdfghjklzxcvbnmmnbvcxzlkjhgfdsapoiuytrewq";
            string T = "NAVOIOIDsapoi";
            string P = "sapoi";
            string[] PArr = { "sapoi", "asdf", "asdf" };
            
            Stopwatch sw = Stopwatch.StartNew();

            FSM.FSMFunc(T, P);
            
            sw.Stop();
            double ticks = sw.ElapsedTicks;
            Console.WriteLine((ticks / Stopwatch.Frequency) * 1000000000); // get nanoseconds
        }
    }
}