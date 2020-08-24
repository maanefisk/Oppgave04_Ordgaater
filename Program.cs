using System;
using System.IO;

namespace Oppgave04_Ordgaater
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"E:\Work\_Modul3\Oppgave04_Ordgaater\Oppgave04_Ordgaater\ordliste.txt";
            var lines = File.ReadLines(path);
            foreach (var line in lines)
            {
                var parts = line.Split('\t');
                var word = parts[1];
                Console.WriteLine(word);
            }
        }
    }
}
