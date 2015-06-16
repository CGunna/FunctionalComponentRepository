using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAgent
{
    class Program
    {
        static void Main(string[] args)
        {
            InitialisierePerformanceCounter(); // Initialisieren

            while (true)
            {
                Console.WriteLine(GetCPUusage());    // CPU Auslastung in die Konsole schreiben
                System.Threading.Thread.Sleep(5000); // 1 Sekunde warten
            }
        }

        static PerformanceCounter cpuCounter; // globaler PerformanceCounter 

        static void InitialisierePerformanceCounter() // Initialisieren
        {
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total"; // "_Total" entspricht der gesamten CPU Auslastung, Bei Computern mit mehr als 1 logischem Prozessor: "0" dem ersten Core, "1" dem zweiten...
        }

        static float GetCPUusage() // Liefert die aktuelle Auslastung zurück
        {
            return cpuCounter.NextValue();
        }
    }
}
