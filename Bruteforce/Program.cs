using System;
using System.Diagnostics;

namespace Bruteforce
{
    internal class Program
    {
        static void Initialize()
        {
            Bruteforce.BruteforceFunc("123", "123");
            Sunday.SundayFunc("123", "123");
            KMP.KMPFunc("123", "123");
            FSM.FSMFunc("123", "123");
            RabinKarp.RabinCarpOptimized("123", "123");

        }
        static void Main(string[] args)
        {
            string P = "rewq";
            string T, TCopy;
            string pathToWrite = "Algos.csv";
            int times = 5000;
            
            
            using (StreamReader reader = new StreamReader("file1.txt"))
            {
                T = reader.ReadToEnd();
            }

            TCopy = T;
            int textLength = TCopy.Length;
            
            Initialize();

            List<double> timesBruteforce = new List<double>();
            List<double> timesFSM = new List<double>();
            List<double> timesKMP = new List<double>();
            List<double> timesRabinCarp = new List<double>();
            List<double> timesSunday = new List<double>();
            
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < times; i++)
            {
                sw = Stopwatch.StartNew();
                sw.Start();
                Bruteforce.BruteforceFunc(T, P);
                sw.Stop();
                timesBruteforce.Add((int)sw.ElapsedTicks * 100);
                sw = Stopwatch.StartNew();
                sw.Start();
                FSM.FSMFunc(T, P);
                sw.Stop();
                timesFSM.Add((int)sw.ElapsedTicks * 100);
                sw = Stopwatch.StartNew();
                sw.Start();
                KMP.KMPFunc(T, P);
                sw.Stop();
                timesKMP.Add((int)sw.ElapsedTicks * 100);
                sw = Stopwatch.StartNew(); 
                sw.Start();
                RabinKarp.RabinCarpOptimized(T, P);
                sw.Stop();
                timesRabinCarp.Add((int)sw.ElapsedTicks * 100);
                sw = Stopwatch.StartNew();
                sw.Start();
                Sunday.SundayFunc(T, P);
                sw.Stop();
                timesSunday.Add((int)sw.ElapsedTicks * 100);
                T += TCopy;
            }

            using StreamWriter writer = new StreamWriter(pathToWrite, false);
            writer.WriteLine("textSize, RT BruteForce, RT FSM, \tRT KMP, \tRT RabinKarp, RT Sunday");
            for (var index = 0; index < times; index++)
            {
                writer.WriteLine(textLength + ",\t   " + timesBruteforce[index] + ",\t   " + timesFSM[index] + ",\t   " + timesKMP[index] + ",\t   " + timesRabinCarp[index] + ",\t   " + timesSunday[index]);
                textLength += TCopy.Length;
            }
        }
    }
}