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
    /// Page to set the nickname and flashcard round length
    /// </summary>
    public partial class FiszkiMenuPage : Page
    {
        public FiszkiMenuPage()
        {
            InitializeComponent();
        }

        //StartFiszkiButton method
        private void StartFiszkiButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayRequirementsToStartFlashcards();
            Flashcards.GameCorrectPoints = 0;
            Flashcards.GameWrongPoints = 0;
            Flashcards.WrongAnswers.Clear();
        }

        private void ShortRoundButton_Click(object sender, RoutedEventArgs e)
        {
            MarkButtonBorder(ShortRoundButton);
        }

        private void MidRoundButton_Click(object sender, RoutedEventArgs e)
        {
            MarkButtonBorder(MidRoundButton);
        }

        private void LongRoundButton_Click(object sender, RoutedEventArgs e)
        {
            MarkButtonBorder(LongRoundButton);
        }

        //Mark what button is activated
        private void MarkButtonBorder(Button buttonClicked)
        {
            Flashcards.IsRoundTimeButtonClicked = true;
            var markButtonBorderColor = new SolidColorBrush(Color.FromRgb(238, 25, 127));
            var defaulfButtonBorderColor = new SolidColorBrush(Color.FromRgb(29, 76, 176));
            if (buttonClicked == ShortRoundButton)
            {
                ShortRoundButton.BorderBrush = markButtonBorderColor;
                MidRoundButton.BorderBrush = defaulfButtonBorderColor;
                LongRoundButton.BorderBrush = defaulfButtonBorderColor;
                Flashcards.RoundTimer = 20;
            }
            if(buttonClicked == MidRoundButton)
            {
                ShortRoundButton.BorderBrush = defaulfButtonBorderColor;
                MidRoundButton.BorderBrush = markButtonBorderColor;
                LongRoundButton.BorderBrush = defaulfButtonBorderColor;
                Flashcards.RoundTimer = 45;
            }
            if (buttonClicked == LongRoundButton)
            {
                ShortRoundButton.BorderBrush = defaulfButtonBorderColor;
                MidRoundButton.BorderBrush = defaulfButtonBorderColor;
                LongRoundButton.BorderBrush = markButtonBorderColor;
                Flashcards.RoundTimer = 90;
            }
        }

        //if requirements for nick/round timer are not correct method will display conditions
        private void DisplayRequirementsToStartFlashcards()
        {
            IsNickCorrect();
            if (Flashcards.IsRoundTimeButtonClicked &&  Flashcards.IsNickCorrect)
            {
                Flashcards.PlayerNick = NickTextBox.Text;
                NavigationService.Navigate(new FiszkiGamePage());
            }
            if (Flashcards.IsRoundTimeButtonClicked == false && Flashcards.IsNickCorrect)
            {
                NickIsIncorrect.Visibility = Visibility.Hidden;
                RoundTimeIsNotMarked.Visibility = Visibility.Visible;
            }
            if (Flashcards.IsRoundTimeButtonClicked && Flashcards.IsNickCorrect == false)
            {
                NickIsIncorrect.Visibility = Visibility.Visible;
                RoundTimeIsNotMarked.Visibility = Visibility.Hidden;
            }
            if (Flashcards.IsRoundTimeButtonClicked == false && Flashcards.IsNickCorrect == false)
            {
                NickIsIncorrect.Visibility = Visibility.Visible;
                RoundTimeIsNotMarked.Visibility = Visibility.Visible;
            }
        }

        //Checking requirements for nick
        private void IsNickCorrect()
        {
            if (NickTextBox.Text.Length >= 1 && NickTextBox.Text.Length < 16)
            {
                Flashcards.IsNickCorrect = true;
            }
            else
            {
                Flashcards.IsNickCorrect = false;
            }
        }

    }
}
