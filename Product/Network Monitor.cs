using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace NetworkMonitor
{

    class Program
    {
        #region //variable decleration
        // Declare performance counter variables
        static PerformanceCounter CPUCounter;
        static PerformanceCounter MemoryCounter;
        static PerformanceCounter DspaceCounter;
        static PerformanceCounter CspaceCounter;
        static PerformanceCounter TCPCounter;
#endregion

        static void Main(string[] args)
        {
            #region // collect infomation
            // Pulls Processor infomation
            CPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            // Pulls Memory infomation
            MemoryCounter = new PerformanceCounter("Memory", "Available MBytes");

            // Pulls Disk Space infomation
            DspaceCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "D:");

            // Pulls processor infomation
            CspaceCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "C:");

            // Pulls TCP connection infomation
            TCPCounter = new PerformanceCounter("TCPv4", "Connections Established");
#endregion

            //Infinite while loop
            while (true)
            {

                //Print out current system infomation with relevent colouring for alerting thresholds

                #region CPU alerting threshold
                if (CPUCounter.NextValue() > 80)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CPU Load: " + (int)CPUCounter.NextValue() + "%");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("CPU Load: " + (int)CPUCounter.NextValue() + "%");
                }
                #endregion

                #region Memory alerting threshold
                if (MemoryCounter.NextValue() < 500)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Avaliable Memory:" + MemoryCounter.NextValue() + "MB");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Avaliable Memory:" + MemoryCounter.NextValue() + "MB");
                }
                #endregion

                #region D: disk space alerting threshold
                if (DspaceCounter.NextValue() < 80)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Free Disk Space: " + (int)DspaceCounter.NextValue() + "%");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Free Disk Space: " + (int)DspaceCounter.NextValue() + "%");
                }
                #endregion

                #region C: alerting threshold 
                if (CspaceCounter.NextValue() < 80)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Free Disk Space: " + (int)CspaceCounter.NextValue() + "%");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Free Disk Space: " + (int)CspaceCounter.NextValue() + "%");
                }
                #endregion

                #region TCP connection alerting threshold
                if (TCPCounter.NextValue() > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("TCP connections established " + TCPCounter.NextValue());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("TCP connections established " + TCPCounter.NextValue());
                }
                #endregion 

                //Sleep for 2 seconds
                Thread.Sleep(2000);

            }
        }
    }
}
