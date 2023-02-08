using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LearningIncreaser.Core
{
    public class DictionaryManager
    {
        Random rnd = new Random();

        /// <summary>
        /// Dictionary of words from file
        /// </summary>
        public static Dictionary<string, string> MainDictionary { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Serializing from csv file
        /// </summary>
        public static void ReadWordsFromCSVFile()
        {
            var plik = File.ReadAllLines(@"..\..\..\SlowkaDoNauki.csv");

            foreach (var line in plik)
            {
                var elements = line.Split(';');
                try
                {
                    MainDictionary.Add(elements[0].ToString(), elements[1].ToString());
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }

        public static bool IsDictionaryCountLessThan3()
        {
            if (MainDictionary.Count < 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Randomize Word Key
        /// </summary>
        public string DrawCorrectWordKey()
        {
            return MainDictionary.ElementAt(rnd.Next(0, MainDictionary.Count)).Key;
        }
    }
}
