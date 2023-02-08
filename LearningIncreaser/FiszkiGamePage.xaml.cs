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
using System.Windows.Threading;

namespace LearningIncreaser
{
    /// <summary>
    /// Flashcards page. "Game" lasts a previously selected time, draws a word from the dictionary and 3 answers, one of which is correct. 
    /// After selecting an answer, a point is awarded and the next question is displayed
    /// </summary>
    public partial class FiszkiGamePage : Page
    {
        Flashcards Flashcards = new Flashcards();
        private string drawnWorld { get; set; }
        DispatcherTimer timer;
        TimeSpan time;

        /// <summary>
        /// Flag to avoid changing scene error when timer counting 
        /// </summary>
        public static bool IsGameBreak { get; set; }

        public FiszkiGamePage()
        {
            InitializeComponent();
            if (IsGameBreak)
            {
                IsGameBreak = false;
            }
            CorrectAnswersPointsCounter.Text = 0.ToString();
            WrongAnswersPointsCounter.Text = 0.ToString();
            Timerek();
            FlashcardsGame();
        }

        /// <summary>
        /// "Round" of flashcards, drawing world and answers and displaying them
        /// </summary>
        private void FlashcardsGame()
        {
            var correctAnswerButton = Flashcards.DrawButtonToCorrectAnswer();
            drawnWorld = Flashcards.DrawCorrectWordKey();
            WordTextBlock.Text = drawnWorld;

            switch (correctAnswerButton)
            {
                case "LeftAnswerButton":
                    LeftAnswerButton.Content = DictionaryManager.MainDictionary[drawnWorld];
                    MidAnswerButton.Content = DictionaryManager.MainDictionary[Flashcards.DrawWrongAnswer(drawnWorld)];
                    RightAnswerButton.Content = DictionaryManager.MainDictionary[Flashcards.DrawWrongAnswer(drawnWorld)];
                    break;
                case "MidAnswerButton":
                    LeftAnswerButton.Content = DictionaryManager.MainDictionary[Flashcards.DrawWrongAnswer(drawnWorld)];
                    MidAnswerButton.Content = DictionaryManager.MainDictionary[drawnWorld];
                    RightAnswerButton.Content = DictionaryManager.MainDictionary[Flashcards.DrawWrongAnswer(drawnWorld)];
                    break;
                case "RightAnswerButton":
                    LeftAnswerButton.Content = DictionaryManager.MainDictionary[Flashcards.DrawWrongAnswer(drawnWorld)];
                    MidAnswerButton.Content = DictionaryManager.MainDictionary[Flashcards.DrawWrongAnswer(drawnWorld)];
                    RightAnswerButton.Content = DictionaryManager.MainDictionary[drawnWorld];
                    break;

                default:
                    break;
            }
        }

        private void LeftAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            AddPointAfterAnswer(LeftAnswerButton);
            FlashcardsGame();
        }

        private void MidAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            AddPointAfterAnswer(MidAnswerButton);
            FlashcardsGame();
        }

        private void RightAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            AddPointAfterAnswer(RightAnswerButton);
            FlashcardsGame();
        }

        /// <summary>
        /// Adding points depending on answer correctness 
        /// </summary>
        /// <param name="selectedAnswerButton"></param>
        private void AddPointAfterAnswer(Button selectedAnswerButton)
        {
            if (selectedAnswerButton.Content.ToString() == DictionaryManager.MainDictionary[drawnWorld])
            {
                Flashcards.GameCorrectPoints += 1;
                CorrectAnswersPointsCounter.Text = Flashcards.GameCorrectPoints.ToString();
            }
            else
            {
                Flashcards.GameWrongPoints += 1;
                WrongAnswersPointsCounter.Text = Flashcards.GameWrongPoints.ToString();

                if (!Flashcards.WrongAnswers.ContainsKey(drawnWorld))
                {
                    Flashcards.WrongAnswers.Add(drawnWorld, 1);
                }
                else
                {
                    Flashcards.WrongAnswers[drawnWorld] += 1;
                }
            }
        }

        /// <summary>
        /// Round timer that counting from set value to 0
        /// </summary>
        private void Timerek()
        {
            time = TimeSpan.FromSeconds(Flashcards.RoundTimer);

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TimerBlock.Text = time.ToString("c");
                if (time == TimeSpan.Zero && IsGameBreak == false) 
                {
                    timer.Stop();
                    NavigateToSummaryFlashcardsPage();
                } 
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
        }

        //Method that navigate to Flashcards summary 
        private void NavigateToSummaryFlashcardsPage()
        {
            NavigationService.Navigate(new SummaryFlashcardsPage());
        }
    }
}
