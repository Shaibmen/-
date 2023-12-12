using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dispetcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowZadachi();
        }


        static void ShowZadachi()
        {
                while (true)
                {
                    Process[] GetProcess = Process.GetProcesses();
                    Console.Clear();
                    Console.SetCursorPosition(2, Console.CursorTop);
                    Console.Write("Название");
                    Console.SetCursorPosition(40, Console.CursorTop);
                    Console.Write("Опер. память");
                    Console.SetCursorPosition(60, Console.CursorTop);
                    Console.Write("ID");
                    Console.WriteLine("");

                    foreach (Process process in GetProcess)
                    {
                        Console.SetCursorPosition(2, Console.CursorTop);
                        Console.WriteLine("" + process.ProcessName);
                        Console.SetCursorPosition(40, Console.CursorTop);
                        Console.Write("" + process.PagedMemorySize64 / 1024 / 1024 + " МБ");
                        Console.SetCursorPosition(60, Console.CursorTop);
                        Console.Write("" + process.Id);
                    }
                    
                    int pos = Menu.Show(1, GetProcess.Length) - 1;
                    if (pos == -1)
                    {
                        return;
                    }
                    else
                    {
                        ShowZadacha(GetProcess[pos].Id);
                    }

                }
        }

        static void ShowZadacha(int p) 
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Process Choiseprocess = Process.GetProcessById(p);
                    string nameTask = Choiseprocess.ProcessName;
                    Process[] ProcessToKill = Process.GetProcessesByName(nameTask);
                    Console.WriteLine("  Имя процесса: " + Choiseprocess.ProcessName);
                    Console.WriteLine("----------------------------------------------");

                    Console.WriteLine("  Опер. Память: " + Choiseprocess.PagedMemorySize64 / 1024 / 1024 + " МБ");
                    Console.WriteLine("  Виртуал. Память: " + Choiseprocess.PeakVirtualMemorySize64 / 1024 / 1024 + " МБ");
                    Console.WriteLine("  Приоритет: " + Choiseprocess.BasePriority);
                    Console.WriteLine("  Время запуска: " + Choiseprocess.StartTime);
                    Console.WriteLine("  Дескриптор процесса: " + Choiseprocess.Handle);
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Статус: Запущен");
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("D - завершить процесс");
                    Console.WriteLine("Del - завершить все процессы с таким названием");
                    Console.WriteLine("BackSpace - вернуться назад");
                    int pos = Menu.Show(2, 6);
                    if (pos == -2)
                    {
                        return;
                    }
                    if (pos == -300)
                    {
                        Choiseprocess.Kill();
                        ShowZadachi();
                    }
                    if (pos == -301)
                    {
                        
                        foreach (Process Killall in ProcessToKill)
                        {
                            Killall.Kill();
                        }
                        ShowZadachi();

                        
                    }
                    else
                    {
                        ShowZadachi();
                    }
                }
            }
            catch(System.ComponentModel.Win32Exception)
            {
                ErrorPrikol(p);
            }
            finally
            {
                ShowZadachi();
            }
        }
        static void ErrorPrikol(int p)
        {
            Console.Clear();
            Process Choiseprocess = Process.GetProcessById(p);
            Console.WriteLine("Процесс: " + Choiseprocess.ProcessName);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("  Ошибка в отображении процесса!");
            Console.WriteLine("  Причина: Отказанно в доступе");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Нажмите BackSpace для того чтобы вернуться назад");
            int pos = Menu.Show(2, 3);
            if (pos == -2)
            {
                return;
            }
        }
    }
}
