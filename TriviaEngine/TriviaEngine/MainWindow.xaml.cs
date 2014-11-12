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
using TriviaEngine;
using System.Collections;
using System.Data.SQLite;

namespace TriviaEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuestionAndAnswer qa;
        Starmap starmap = new Starmap(4, 4);
        Player player = new Player();
        public MainWindow()
        {
           
            starmap.initialize(); 
            InitializeComponent();
            getQuestion();
        }

        private void getQuestion()
        {
            ArrayList questionList = new ArrayList();
            questionList = DBQuestion.QueryQuestion();

            qa = new QuestionAndAnswer(questionList[1].ToString(), questionList[2].ToString(), questionList[3].ToString(), questionList[4].ToString(), questionList[5].ToString(), questionList[6].ToString());
        }// This method will need to get question form array or database. 
        //probably need to set it up as public with the array being sent in.

     

        private void PlanetButton1_Click(object sender, RoutedEventArgs e)
        {
            Spaceport spaceport = starmap.getSpaceport(0, 0);
            if(player.getCoordinates().getX() == spaceport.getCoordinates().getX() && player.getCoordinates().getY() == spaceport.getCoordinates().getY())
            MessageBox.Show("You are already at this location");
            
            else
            {
            TriviaWindow triviaWindow = new TriviaWindow();
            triviaWindow.Show();
            player.setCoordinates(spaceport.getCoordinates());
            }
        }

        private void PlanetButton2_Click(object sender, RoutedEventArgs e)
        {
            Spaceport spaceport = starmap.getSpaceport(1, 0);
            if (player.getCoordinates().getX() == spaceport.getCoordinates().getX() && player.getCoordinates().getY() == spaceport.getCoordinates().getY())
                MessageBox.Show("You are already at this location");
            
            else
            {
                TriviaWindow triviaWindow = new TriviaWindow();
                triviaWindow.Show();
                player.setCoordinates(spaceport.getCoordinates());
            }
        }

        private void PlanetButton3_Click(object sender, RoutedEventArgs e)
        {
            Spaceport spaceport = starmap.getSpaceport(0, 1);
            if (player.getCoordinates().getX() == spaceport.getCoordinates().getX() && player.getCoordinates().getY() == spaceport.getCoordinates().getY())
                MessageBox.Show("You are already at this location");

            else
            {
                TriviaWindow triviaWindow = new TriviaWindow();
                triviaWindow.Show();
                player.setCoordinates(spaceport.getCoordinates());
            }
        }

        /*public bool DoorUnlocked(bool value)
        {
            return value;
        }*/
    }
}
