using LearningIncreaser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Summary of flashcard results and display of the 3 most problematic words(if exists)
    /// </summary>
    public partial class SummaryFlashcardsPage : Page
    {
        public SummaryFlashcardsPage()
        {
            InitializeComponent();
            PlayerNick.Text = Flashcards.PlayerNick;
            PlayerScore.Text = (Flashcards.GameCorrectPoints - 2*Flashcards.GameWrongPoints).ToString();
            PlayerRound.Text = Flashcards.RoundTimer.ToString() + " sec";
            DisplayWrongAnswers();
        }

        private void DisplayWrongAnswers()
        {
            var ordered = Flashcards.WrongAnswers.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            if (ordered.Count == 0)
            {
                LabelOfRankingBadWords.Visibility = Visibility.Hidden;
            }
            if (ordered.Count >= 1)
            {
                FirstWrongWord.Text = $"{ordered.First().Key} - {ordered.First().Value}";
            }
            if (ordered.Count >= 2)
            {
                SecondWrongWord.Text = $"{ordered.ElementAt(1).Key} - {ordered.ElementAt(1).Value}";
            }
            if (ordered.Count >= 3)
            {
                ThirdWrongWord.Text = $"{ordered.ElementAt(2).Key} - {ordered.ElementAt(2).Value}";
            }
        }
    }
}
