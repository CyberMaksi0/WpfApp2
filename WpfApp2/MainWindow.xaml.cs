using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace AnagramChecker
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool isFirstWordValid = true;
        private bool isSecondWordValid = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsFirstWordValid
        {
            get { return isFirstWordValid; }
            set
            {
                isFirstWordValid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFirstWordValid"));
            }
        }

        public bool IsSecondWordValid
        {
            get { return isSecondWordValid; }
            set
            {
                isSecondWordValid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSecondWordValid"));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CheckAnagrams_Click(object sender, RoutedEventArgs e)
        {
            string firstWord = firstWordTextBox.Text;
            string secondWord = secondWordTextBox.Text;

            IsFirstWordValid = !string.IsNullOrWhiteSpace(firstWord);
            IsSecondWordValid = !string.IsNullOrWhiteSpace(secondWord);

        private void CheckAnagrams_Click(object sender, RoutedEventArgs e)
        {
            string firstWord = firstWordTextBox.Text;
            string secondWord = secondWordTextBox.Text;

            IsFirstWordValid = !string.IsNullOrWhiteSpace(firstWord);
            IsSecondWordValid = !string.IsNullOrWhiteSpace(secondWord);

            if (IsFirstWordValid && IsSecondWordValid)
            {
                string sortedFirstWord = new string(firstWord.ToLower().ToCharArray().OrderBy(c => c).ToArray());
                string sortedSecondWord = new string(secondWord.ToLower().ToCharArray().OrderBy(c => c).ToArray());

                if (sortedFirstWord.Equals(sortedSecondWord, StringComparison.Ordinal))
                {
                    resultTextBlock.Text = "Słowa są anagramami!";
                }
                else
                {
                    resultTextBlock.Text = "Słowa nie są anagramami.";
                }
            }
            else
            {
                resultTextBlock.Text = "Wprowadź oba słowa, aby sprawdzić, czy są anagramami.";
            }
        }
    }
}
