using System;
using System.Collections.Generic;

namespace Test3
{
    /*
     * a list of sentences, where each sentence is a list 
     * of one or more words in lowercase
     */
    class Program
    {
        static void Main(string[] args)
        {
            var list = ParseSentences(@"1. THE BOY. the GirL");
        }

        /// <summary>
        /// Find all words in the sentence
        /// </summary>
        /// <param name="text">The sentence</param>
        public static List<string> GetWords(string text)
        {
            var wordsList = new List<string>();
            string word = "";
            for (int letterCount = 0; letterCount < text.Length; letterCount++)
            {
                char letter = text[letterCount];
                if (char.IsLetter(letter) || letter == '\'')
                {
                    word += letter;
                }
                else
                {
                    if (word != "")
                    {
                        Console.WriteLine(word.ToLower());
                        wordsList.Add(word.ToLower());
                        word = "";
                    }
                }
            }
            //check the last word
            if (word != "")
            {
                Console.WriteLine(word.ToLower());
                wordsList.Add(word.ToLower());
                word = "";
                Console.WriteLine("-----");
            }
            return wordsList;
        }

        /// <summary>
        /// Creating a list of sentences
        /// </summary>
        /// <param name="text">The whole text</param>
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            //find all sentences
            var separators = new string[] { ".", "!", "?", ";", ":", "(", ")" };
            var sentences = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int sentence = 0;
            //find all words in sentence
            while (sentence < sentences.Length)
            {
                var wordsList = GetWords(sentences[sentence]);
                if (wordsList.Count > 0)
                {
                    sentencesList.Add(wordsList);
                }
                sentence++;
            }
            return sentencesList;
        }
    }
}
