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

namespace Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Player
        {
            X = 1,
            O
        }

        public Player CurrentPlayer { get; set; }
        public int turns { get; set; }

        public bool hasWon { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            CurrentPlayer = Player.X;
            turns = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button clickedButton = sender as Button;

            if (CurrentPlayer == Player.X)
            {
                clickedButton.Foreground = Brushes.Red;
                clickedButton.Content = Player.X;
            }
            else
            {
                clickedButton.Foreground = Brushes.Blue;
                clickedButton.Content = Player.O;
            }

            clickedButton.FontSize = 50;
            clickedButton.IsHitTestVisible = false;
            UpdateGame();
        }

        public void UpdateGame()
        {
            ++turns;

            if (turns >= 5)
            {
                if (CheckWin())
                {
                    Victory();
                    return;
                }
            }

            if (turns == 9)
            {
                CatsGame();
                return;
            }


            if (CurrentPlayer == Player.X)
            {
                CurrentPlayer = Player.O;
            }
            else
            {
                CurrentPlayer = Player.X;
            }
        }

        public bool CheckWin()
        {
            return CheckRowWin() || CheckColumnWin() || CheckDiagonalWin();
        }

        public bool CheckRowWin()
        {
            if (TopLeft.Content.ToString() == CurrentPlayer.ToString()
                && TopCenter.Content.ToString() == CurrentPlayer.ToString()
                && TopRight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (MiddleLeft.Content.ToString() == CurrentPlayer.ToString()
                && MiddleCenter.Content.ToString() == CurrentPlayer.ToString()
                && MiddleRight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (BottomLeft.Content.ToString() == CurrentPlayer.ToString()
                && BottomCenter.Content.ToString() == CurrentPlayer.ToString()
               && BottomRight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            return false;
        }

        public bool CheckColumnWin()
        {
            if (TopLeft.Content.ToString() == CurrentPlayer.ToString()
                && MiddleLeft.Content.ToString() == CurrentPlayer.ToString()
                && BottomLeft.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (TopCenter.Content.ToString() == CurrentPlayer.ToString()
                && MiddleCenter.Content.ToString() == CurrentPlayer.ToString()
                && BottomCenter.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (TopRight.Content.ToString() == CurrentPlayer.ToString()
                && MiddleRight.Content.ToString() == CurrentPlayer.ToString()
                && BottomRight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            return false;
        }

        public bool CheckDiagonalWin()
        {
            if (MiddleCenter.Content.ToString() != CurrentPlayer.ToString())
            {
                return false;
            }

            if (TopLeft.Content.ToString() == CurrentPlayer.ToString()
                && BottomRight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (TopRight.Content.ToString() == CurrentPlayer.ToString()
                && BottomLeft.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            return false;
        }

        public void Victory()
        {
            foreach (Border border in Board.Children)
            {
                Button button = (Button)border.Child;
                button.IsHitTestVisible = false;
            }

            WinnerBox.Content = "Player " + CurrentPlayer.ToString() + " won the game!!";
            WinnerBox.Width = 170;
            WinnerBox.FontSize = 15;
            WinnerBox.Background = Brushes.AliceBlue;
            WinnerBox.Foreground = Brushes.Coral;
            WinnerBox.HorizontalAlignment = HorizontalAlignment.Center;
            WinnerBox.VerticalAlignment = VerticalAlignment.Center;
            WinnerBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            WinnerBox.VerticalContentAlignment = VerticalAlignment.Center;
            WinnerBox.Visibility = Visibility.Visible;
        }

        public void CatsGame()
        {
            WinnerBox.Content = "Oh well, its a cats game";
            WinnerBox.Width = 170;
            WinnerBox.FontSize = 15;
            WinnerBox.Background = Brushes.Azure;
            WinnerBox.Foreground = Brushes.DarkOrchid;
            WinnerBox.HorizontalAlignment = HorizontalAlignment.Center;
            WinnerBox.VerticalAlignment = VerticalAlignment.Center;
            WinnerBox.HorizontalContentAlignment = HorizontalAlignment.Center;
            WinnerBox.VerticalContentAlignment = VerticalAlignment.Center;
            WinnerBox.Visibility = Visibility.Visible;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Border border in Board.Children)
            {
                Button button = (Button)border.Child;
                button.Content = "";
                button.IsHitTestVisible = true;
            }
            turns = 0;

            WinnerBox.Visibility = Visibility.Hidden;
            WinnerBox.Width = 0;

            CurrentPlayer = Player.X;  
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            WinnerBox.Content = "the AI feature is not supported yet";
            WinnerBox.Width = 195;
            WinnerBox.FontSize = 10;
            WinnerBox.Background = Brushes.Black;
            WinnerBox.Foreground = Brushes.White;
            WinnerBox.Visibility = Visibility.Visible;
        }
    }
}

