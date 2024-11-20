using System;
using System.Linq;

namespace WordReversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputSentence = "C# is not C++ and PHP is not Delphi";
            string reversedSentence = ReverseWords(inputSentence);
            Console.WriteLine(reversedSentence);
        }

        static string ReverseWords(string sentence)
        {
            // Split the sentence into words
            string[] words = sentence.Split(' ');

            // Reverse the order of words
            Array.Reverse(words);

            // Reconstruct the modified sentence
            string reversedSentence = string.Join(" ", words);

            return reversedSentence;
        }
    }
}

