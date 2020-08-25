using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Oppgave04_Ordgaater
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = GetWords(); // Får ut liste med ord
            var randomWordIndex = new Random().Next(words.Length); //Velger ett random ord, og nummeret dens i lista
            var selectedWord = words[randomWordIndex]; 
            Console.WriteLine("Valgt ord: " + selectedWord);

            for (var i = 0; i < words.Length; i++)
            {
                if (i % 1000 == 0) Console.Write(".");

                if (LastPartIsSameAsFirstPartSecondWord(selectedWord, words[i]))
                {
                    Console.WriteLine("\n" + words[i]);
                    return;
                }
            }
        }

        private static bool LastPartIsSameAsFirstPartSecondWord(string word1, string word2)
        {
            return LastPartIsSameAsFirstPartSecondWord(2, word1, word2)
        }
        private static bool LastPartIsSameAsFirstPartSecondWord(int commonLength, string word2)
        {
            var lastPartOfFirstWord = word1.Substring(word1.length - commonLength, commonLength);
            var firstPartOfSecondWord = word2.Substring(0, commonLength);

            return lastPartOfFirstWord == firstPartOfSecondWord;
        }
        static string[] GetWords()
        {
            var lastWord = string.Empty;
            var path = @"E:\Work\_Modul3\Oppgave04_Ordgaater\Oppgave04_Ordgaater\ordliste.txt";
            var wordList = new List<string>();
            foreach (var line in File.ReadLines(path, Encoding.UTF8))
            {
                var parts = line.Split('\t'); //fjerner tab mellomrom og separerer string, hvert ord til plass i en array. 1 array pr linje.
                var word = parts[1]; //henter ut ord på plassering 1 i "linje-arrayet"
                if (word != lastWord && word.Length > 7 && !word.Contains("-")) wordList.Add(word); //hvis ordet ikke er det samme som forrige valgt, er større en 7 tegn, uten bindestrek, da addes den til lista.
                lastWord = word; 
            }

            return wordList.ToArray();
        }
    }
}
