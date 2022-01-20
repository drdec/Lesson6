using System;
using System.Diagnostics;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTheRunningProgram = true;
            Process[] processes = Process.GetProcesses();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Добрый день. Вы попали в мой Task Manager в консольном приложении.");

            Console.ForegroundColor = ConsoleColor.White;

            while (isTheRunningProgram)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Выберите действие :\n" +
                "1. Вывод всех процессов на экран\n" +
                "2. Завершение процесса по его ID\n" +
                "3. Завершение процесса по его имени\n" +
                "4. Завершение программы.");

                    Console.ForegroundColor = ConsoleColor.White;

                    int number = Convert.ToInt32(Console.ReadLine());

                    switch (number)
                    {
                        case 1:
                            {
                                OutputAllProcesses(processes);
                            }
                            break;

                        case 2:
                            {
                                KillProcessById(processes);
                                Console.Clear();
                            }
                            break;

                        case 3:
                            {
                                KillProcessByName(processes);
                                Console.Clear();
                            }
                            break;

                        case 4:
                            {
                                isTheRunningProgram = false;
                            }
                            break;

                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine("Извините, но я не знаю такого действия :(");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Чтобы продолжить, нажмите любую клавишу.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Оу, что-то пошло не так, попробууйте еще раз.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.WriteLine("Чтобы продолжить, нажмите любую клавишу.");
                    Console.Clear();
                }
            }
        }

        private static void KillProcessByName(Process[] processes)
        {
            Console.WriteLine("Введите имя процесса, который хотите завершить.");
            string processName = Console.ReadLine();

            if (string.IsNullOrEmpty(processName))
            {
                throw new Exception();
            }

            for (int i = 0; i < processes.Length; i++)
            {
                if (processName == processes[i].ProcessName)
                {
                    Process tempProcess = processes[i];
                    tempProcess.Kill();
                    return;
                }
            }

            Console.ReadKey();
        }

        private static void KillProcessById(Process[] processes)
        {
            Console.WriteLine("Введите Id процесса, который хотите завершить.");
            int processId = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].Id == processId)
                {
                    Process tempProcess = processes[i];
                    tempProcess.Kill();
                    return;
                }
            }
        }

        static void OutputAllProcesses(Process[] processes)
        {
            for (int i = 0; i< processes.Length; i++)
            {
                Process tempProcess = processes[i];
                Console.WriteLine($"Название процесса - {tempProcess.ProcessName}, " +
                    $"Id процесса - {tempProcess.Id}");
            }
        }
    }
}