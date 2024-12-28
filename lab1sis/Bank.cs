using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1sis
{
    public class Bank
    {
        private int money;
        private string name;
        private int percent;
        private readonly object locker = new object(); // Для синхронизации потоков
        private readonly string logFilePath = "BankLog.txt";

        public Bank(int money, string name, int percent)
        {
            this.money = money;
            this.name = name;
            this.percent = percent;
            WriteLog($"Initial values - Money: {money}, Name: {name}, Percent: {percent}");
        }

        public int Money
        {
            get { return money; }
            set
            {
                if (money != value)
                {
                    money = value;
                    StartLoggingThread($"Money changed to: {money}");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    StartLoggingThread($"Name changed to: {name}");
                }
            }
        }

        public int Percent
        {
            get { return percent; }
            set
            {
                if (percent != value)
                {
                    percent = value;
                    StartLoggingThread($"Percent changed to: {percent}");
                }
            }
        }

        private void StartLoggingThread(string logMessage)
        {
            new Thread(() =>
            {
                lock (locker)
                {
                    WriteLog(logMessage);
                }
            }).Start();
        }

        private void WriteLog(string message)
        {
            try
            {
                using (var writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
    }
}
