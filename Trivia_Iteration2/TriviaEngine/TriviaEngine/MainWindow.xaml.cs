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
        Starmap starmap = new Starmap(4, 4);
        private Player player;
        private QuestionFactory qf = new QuestionFactory();

        public MainWindow()
        {
            starmap.initialize();
            player = new Player(starmap.getSpaceport(0, 0));
            InitializeComponent();
        }

        public void playerMove(Spaceport spaceport)
        {
          
            if(player.getCoordinates().Equals(spaceport.getCoordinates()))
               MessageBox.Show("You are already at this location");
            else
            ValidMove(spaceport);
       
         /*   else
            {
                TriviaWindow triviaWindow = new TriviaWindow();
                triviaWindow.Show();
                player.setCoordinates(spaceport.getCoordinates());
            }*/
        }

        public void ValidMove(Spaceport spaceport)
        {
            Coordinates destination = spaceport.getCoordinates();
            List<Trajectory> trajectories = player.getCurr().getTrajectories();
            bool valid = false;
            Trajectory traj = null;
            trajectories.ForEach(delegate(Trajectory curr)
                                 {
                                     if (curr.getCoordinates().Equals(destination) && curr.getLocked() != 2)
                                     {
                                         valid = true;
                                         traj = curr;
                                     }
                                 });
            if (valid == true)
            {
                if (traj.getLocked() == 0)
                {
                    Coordinates prev = player.getCoordinates();
                    player.setCoordinates(traj.getCoordinates());
                    player.setSpaceport(spaceport);
                    updateReturnTrajectoryOpen(prev, spaceport.getTrajectories());
                }
                else
                {
                    Question q1 = qf.CreateQuestion(1);
                    q1.displayQuestion.displayQuestion(q1);
                    if (q1.result == 1)
                    {
                        Coordinates prev = player.getCoordinates();
                        player.setCoordinates(spaceport.getCoordinates());
                        player.setSpaceport(spaceport);
                        updateReturnTrajectoryOpen(prev, spaceport.getTrajectories());
                    }
                    else
                    {
                        MessageBox.Show("In else");
                    }
                }
            }
        }

        public void updateReturnTrajectoryOpen(Coordinates coordinates, List<Trajectory> trajectories)
        {
            trajectories.ForEach(delegate(Trajectory curr)
            {
                if (curr.getCoordinates().Equals(coordinates))
                {
                   curr.setLocked(0);
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Spaceport spaceport = starmap.getSpaceport(0, 0);
            Button btn = (Button)sender;
            if (btn == PlanetButton1)
            {
                spaceport = starmap.getSpaceport(0, 0);
                playerMove(spaceport);
            }
            if (btn == PlanetButton2)
            {
                spaceport = starmap.getSpaceport(0, 1);
                playerMove(spaceport);

            }
            if (btn == PlanetButton3)
            {
                spaceport = starmap.getSpaceport(1, 0);
                playerMove(spaceport);
            }
            if (btn == PlanetButton4)
            {
                spaceport = starmap.getSpaceport(0, 2);
                playerMove(spaceport);
            }
            if (btn == PlanetButton5)
            {
                spaceport = starmap.getSpaceport(1, 1);
                playerMove(spaceport);
            }
            if (btn == PlanetButton6)
            {
                spaceport = starmap.getSpaceport(2, 0);
                playerMove(spaceport);
            }
            if (btn == PlanetButton7)
            {
                spaceport = starmap.getSpaceport(0, 3);
                playerMove(spaceport);
            }
            if (btn == PlanetButton8)
            {
                spaceport = starmap.getSpaceport(1, 2);
                playerMove(spaceport);
            }
            if (btn == PlanetButton9)
            {
                spaceport = starmap.getSpaceport(2, 1);
                playerMove(spaceport);
            }
            if (btn == PlanetButton10)
            {
                spaceport = starmap.getSpaceport(3, 0);
                playerMove(spaceport);
            }
            if (btn == PlanetButton11)
            {
                spaceport = starmap.getSpaceport(1, 3);
                playerMove(spaceport);
            }
            if (btn == PlanetButton12)
            {
                spaceport = starmap.getSpaceport(2, 2);
                playerMove(spaceport);
            }
            if (btn == PlanetButton13)
            {
                spaceport = starmap.getSpaceport(3, 1);
                playerMove(spaceport);
            }
            if (btn == PlanetButton14)
            {
                spaceport = starmap.getSpaceport(3, 2);
                playerMove(spaceport);
            }
            if (btn == PlanetButton15)
            {
                spaceport = starmap.getSpaceport(2, 3);
                playerMove(spaceport);
            }
            if (btn == PlanetButton16)
            {
                spaceport = starmap.getSpaceport(3, 3);
                playerMove(spaceport);
            }



        }


        private void mnuReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click a planet to attempt to move to the location.\n" +
                "You will be asked a space themed trivia question.\n" +
                "You must answer the question correctly to move to the new location.\n" +
                "If you answer the question wrong, the trajectory to that planet is locked forever.\n" +
                "Get to the end of the solar system to win.\n" +
                "If you have locked all trajectories from one planet, you will lose.");
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Journey To.. The Space Trivia Game!\n" +
                "Developed by: Isaac Deal, Michael Giacalone, and Brian Lollis\n" +
                "Using: .NET v1.0.0 ");
        }

        private void mnuStart_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Game_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Retrieve current mouse coordinates.
            double newX = e.GetPosition(null).X;
            double newY = e.GetPosition(null).Y;
            Point myPoint = new Point();
            myPoint.X = newX;
            myPoint.Y = newY;
            PlayerShip.Width = myPoint.X;
            //myStoryboard.Begin(); 
            MessageBox.Show("Journey To.. The Space Trivia Game!\n" +
                "Developed by: Isaac Deal, Michael Giacalone, and Brian Lollis\n" +
                "Using: .NET v1.0.0 ");
        }

        private void Game_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Retrieve current mouse coordinates.
            double newX = e.GetPosition(null).X;
            double newY = e.GetPosition(null).Y;
            Point myPoint = new Point();
            myPoint.X = newX;
            myPoint.Y = newY;
           
            Canvas.SetTop(PlayerShip, myPoint.X);
            Canvas.SetLeft(PlayerShip, myPoint.Y);
            //myStoryboard.Begin(); 
            MessageBox.Show("Journey To.. The Space Trivia Game!\n" +
                "Developed by: Isaac Deal, Michael Giacalone, and Brian Lollis\n" +
                "Using: .NET v1.0.0      " + myPoint.X);
        }
    }
}