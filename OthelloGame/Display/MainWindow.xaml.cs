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
using System.Threading;

namespace Display
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //GameLogic game = new();

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
                }
            }

            if (turns == 9)
            {
                //game over
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
            if (Zero.Content.ToString() == CurrentPlayer.ToString() 
                && One.Content.ToString() == CurrentPlayer.ToString()
                && Two.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (Three.Content.ToString() == CurrentPlayer.ToString()
                && Four.Content.ToString() == CurrentPlayer.ToString()
                && Five.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (Six.Content.ToString() == CurrentPlayer.ToString()
                && Seven.Content.ToString() == CurrentPlayer.ToString()
               && Eight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            return false;
        }

        public bool CheckColumnWin()
        {
            if (Zero.Content.ToString() == CurrentPlayer.ToString()
                && Three.Content.ToString() == CurrentPlayer.ToString()
                && Six.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (One.Content.ToString() == CurrentPlayer.ToString()
                && Four.Content.ToString() == CurrentPlayer.ToString()
                && Seven.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (Two.Content.ToString() == CurrentPlayer.ToString()
                && Five.Content.ToString() == CurrentPlayer.ToString()
                && Eight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            return false;
        }

        public bool CheckDiagonalWin()
        {
            if (Four.Content.ToString() != CurrentPlayer.ToString())
            {
                return false;
            }

            if (Zero.Content.ToString() == CurrentPlayer.ToString()
                && Eight.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            if (Two.Content.ToString() == CurrentPlayer.ToString()
                && Six.Content.ToString() == CurrentPlayer.ToString())
            {
                return true;
            }

            return false;
        }

        public void Victory()
        {
            foreach (Button button in Board.Children)
            {
                button.IsHitTestVisible = false;
            }

            Win.Content = "Player " + CurrentPlayer.ToString() + " won the game!!";
            Win.Background = Brushes.AliceBlue;
            Win.Foreground = Brushes.Coral;
            Win.HorizontalAlignment = HorizontalAlignment.Center;
            Win.VerticalAlignment = VerticalAlignment.Center;
            Win.HorizontalContentAlignment = HorizontalAlignment.Center;
            Win.VerticalContentAlignment = VerticalAlignment.Center;

            
        }

        public void ResetBoard()
        {
            
            foreach(Button button in Board.Children)
            {
                button.Content = "";
                button.IsHitTestVisible = true;
            }
            turns = 0;
        }
    }

    //public class GameLogic
    //{
    //    public enum Player
    //    {
    //        X = 1,
    //        O
    //    }

    //    public Player CurrentPlayer { get; set; } 

    //    public int turns { get; set; }

    //    public GameLogic()
    //    {
    //        CurrentPlayer = Player.X;
    //        turns = 0;
    //    }
    //    public void UpdateGame()
    //    {
    //        if(turns == 9)
    //        {

    //        }


    //        if (CurrentPlayer == Player.X)
    //        {
    //            CurrentPlayer = Player.O;
    //        }
    //        else
    //        {
    //            CurrentPlayer = Player.X;
    //        }

    //        ++turns;
    //    }
    //}    
}
