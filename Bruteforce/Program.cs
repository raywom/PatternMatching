using System;
using System.Diagnostics;

namespace Bruteforce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string P = "rewq";
            string T, T1;
            string P1 = "vel";
            using (StreamReader reader = new StreamReader("file1.txt"))
            {
                T = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader("file2.txt"))
            {
                T1 = reader.ReadToEnd();
            }
            string path = "FSM.csv";
            Stopwatch sw = new Stopwatch();
            FSM.FSMFunc(T, P);
            List<double> times = new List<double>();
            for (int i = 0; i < 50; i++)
            {
                sw = Stopwatch.StartNew();
                sw.Start();
                FSM.FSMFunc(T, P);
                sw.Stop();
                times.Add(sw.ElapsedTicks);
            }
            List<double> times2 = new List<double>();
            for (int i = 0; i < 50; i++)
            {
                sw = Stopwatch.StartNew();
                sw.Start();
                FSM.FSMFunc(T1, P1);
                sw.Stop();
                times2.Add(sw.ElapsedTicks);
            }

            using StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine("Execution Time, FileName");
            for (var index = 0; index < times.Count; index++)
            {
                var time = times[index];
                var time2 = times2[index];
                writer.WriteLine((int) ((time / Stopwatch.Frequency) * 1000000000) + ", file1.txt");
                writer.WriteLine((int) ((time2 / Stopwatch.Frequency) * 1000000000) + ", file2.txt");
            }

            // Bruteforce.BruteforceFunc(T, P);
            //
            // Console.WriteLine((ticks / Stopwatch.Frequency) * 1000000000); // get nanoseconds
        }
    }
}