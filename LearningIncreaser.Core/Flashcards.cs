using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningIncreaser.Core
{
    public class Flashcards : DictionaryManager
    {
        Random rnd = new Random();

        /// <summary>
        /// Dictionary that collects wrong answers
        /// </summary>
        public static Dictionary<string, int> WrongAnswers { get; set; } = new Dictionary<string, int>();

        /// <summary>
        /// Flag to check round timer correctness
        /// </summary>
        public static bool IsRoundTimeButtonClicked { get; set; }

        /// <summary>
        /// Flag to check nick correctness
        /// </summary>
        public static bool IsNickCorrect { get; set; }

        public static int GameCorrectPoints { get; set; }
        public static int GameWrongPoints { get; set; }
        public static int RoundTimer { get; set; }
        public static string PlayerNick { get; set; }

        /// <summary>
        /// Randomizing witch button will display correct answer
        /// </summary>
        /// <returns></returns>
        public string DrawButtonToCorrectAnswer()
        {
            var listOfButtons = new List<string>
            {
                "LeftAnswerButton",
                "MidAnswerButton",
                "RightAnswerButton"

            };

            return listOfButtons[rnd.Next(listOfButtons.Count)];
        }

        /// <summary>
        /// Randomize wrong translation
        /// </summary>
        /// <param name="correctAnswerKey"></param>
        /// <returns></returns>
        public string DrawWrongAnswer(string correctAnswerKey)
        {
            var keyList = new List<string>(MainDictionary.Keys);
            var KeysWithoutCorrectKey = (keyList.Where(x => x != correctAnswerKey).ToList());
            return KeysWithoutCorrectKey[rnd.Next(KeysWithoutCorrectKey.Count)];
        }


    }
}
