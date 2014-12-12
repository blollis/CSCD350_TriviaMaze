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
using System.Windows.Shapes;

namespace TriviaEngine
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        private bool gameStart,gameLoad;
        int difficulty = 6;
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            gameStart = true;
            this.Close();
        }

       private void easy_mode(object sender, RoutedEventArgs e)
        {
            this.difficulty = 6;
            easy.Background = Brushes.Aquamarine;
            normal.Background = Brushes.White;
            hard.Background = Brushes.White;

        }
       private void normal_mode(object sender, RoutedEventArgs e)
       {
           this.difficulty = 10;
           easy.Background = Brushes.White;
           normal.Background = Brushes.Aquamarine;
           hard.Background = Brushes.White;
           
       }
       private void hard_mode(object sender, RoutedEventArgs e)
       {
           this.difficulty = 15;
           easy.Background = Brushes.White;
           normal.Background = Brushes.White;
           hard.Background = Brushes.Aquamarine;  
       }


        private void btnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            gameStart = false;
            gameLoad = true;
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            gameStart = false;
            this.Close();
        }

        public int getDifficulty()
        {
            return difficulty;
        }

        public bool getGameStart()
        {
            return gameStart;
        }
        public bool getLoadGame()
        {
            return gameLoad;
        }
    }
}
