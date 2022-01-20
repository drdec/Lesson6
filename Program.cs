using System;
using System.Diagnostics;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] process = Process.GetProcesses();

            for (int i = 0; i < process.Length; i++)
            {
                Process process1 = process[i];
                Console.WriteLine(process1.ProcessName);
            }

            Console.WriteLine(process.Length);
        }
    }
}