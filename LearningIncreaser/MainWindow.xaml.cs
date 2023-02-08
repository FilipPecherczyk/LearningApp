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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Zrobić event który po kliknięciu jakiegoś przyciusku chowa rzeczy z Frame-u początkowego
        public MainWindow()
        {
            InitializeComponent();
            DictionaryManager.ReadWordsFromCSVFile(); //Reading from csv file, which is in app folder
            HideAllElementsIfDictionaryIsWrong();
        }

        //Navigate to FlashcardsMenu page
        private void FiszkiButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new FiszkiMenuPage();
            HideAllElementsFromStartFrame();
            Flashcards.IsRoundTimeButtonClicked = false;
        }

        //Navigate to Spelling page
        private void PisowniaButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pisownia();
            HideAllElementsFromStartFrame();
        }

        // Close app
        private void WyjscieButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        //private void MenuPageButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Main.Content = new MainWindow();
        //}

        //Hiding start scene buttons
        private void HideAllElementsFromStartFrame()
        {
            MenuTextBlock.Visibility = Visibility.Hidden;
            FiszkiButtonFrame.Visibility = Visibility.Hidden;
            PisowniaButtonFrame.Visibility = Visibility.Hidden;
            WyjscieButtonFrame.Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///Hide button that navigate to Flashcards and SpellingGame and display mistake comunicat
        /// </summary>
        private void HideAllElementsIfDictionaryIsWrong()
        {
            if (DictionaryManager.IsDictionaryCountLessThan3())
            {
                FiszkiButtonFrame.Visibility = Visibility.Hidden;
                PisowniaButtonFrame.Visibility = Visibility.Hidden;
                FiszkiButton.Visibility = Visibility.Hidden;
                PisowniaButton.Visibility = Visibility.Hidden;
                ErrorTextBlock.Visibility = Visibility.Visible;
                MenuTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                MenuTextBlock.Text = "Błąd";
            }
        }
    }
}
