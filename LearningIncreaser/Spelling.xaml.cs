using LearningIncreaser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningIncreaser
{
    /// <summary>
    /// Spelling page. "Game" consists in drawing a word and providing a translation by the user.
    /// There are 3 prompts: enter the first letter, the length of the word and the whole word
    /// </summary>
    public partial class Pisownia : Page
    {
        DictionaryManager DictionaryManager = new DictionaryManager();
        private string drawnWorld;
        public Pisownia()
        {
            InitializeComponent();
            SpellingGame();
            if (!FiszkiGamePage.IsGameBreak)
            {
                FiszkiGamePage.IsGameBreak = true;
            }
            
        }
       
        public void SpellingGame()
        {
            drawnWorld = DictionaryManager.DrawCorrectWordKey();
            DrawnWordBlock.Text = drawnWorld;
        }

        //Checking if answer is correct, if is - next "round" of SpellingGame is activate, if not - field change color on red
        private void CheckAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (UserAnswer.Text == DictionaryManager.MainDictionary[DrawnWordBlock.Text])
            {
                UserAnswer.Background = new SolidColorBrush(Colors.Beige);
                UserAnswer.Text = string.Empty;

                SpellingGame();
            }
            else
            {
                UserAnswer.Background = new SolidColorBrush(Color.FromRgb(255, 204, 203));
            }
        }

        //Display translation 
        private void SurrenderButton_Click(object sender, RoutedEventArgs e)
        {
            UserAnswer.Text = DictionaryManager.MainDictionary[drawnWorld];
        }

        //Display translation's length
        private void LengthButton_Click(object sender, RoutedEventArgs e)
        {
            var worldLength = DictionaryManager.MainDictionary[drawnWorld].Length;
            UserAnswer.Text = $"{worldLength} liter/y";
        }

        //Display translation's first letter
        private void LetterButton_Click(object sender, RoutedEventArgs e)
        {
            var world = DictionaryManager.MainDictionary[drawnWorld];
            UserAnswer.Text = world[0].ToString();
        }
    }
}
