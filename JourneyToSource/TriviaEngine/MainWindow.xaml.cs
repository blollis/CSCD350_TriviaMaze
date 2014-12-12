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
using System.Media;
using System.Windows.Threading;
using System.IO;//
using System.Runtime.Serialization;//
using System.Runtime.Serialization.Formatters.Binary;

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
        SoundPlayer sp = new SoundPlayer("Stickerbrush_Symphony.wav");
        int difficulty;
  

        public MainWindow()
        {
           
            sp.LoadAsync();
            sp.PlayLooping();
            MainMenuWindow mnuWindow = new MainMenuWindow();
            mnuWindow.ShowDialog();
            bool gameStart = mnuWindow.getGameStart();
            difficulty = mnuWindow.getDifficulty();
            bool loadSave = mnuWindow.getLoadGame();
            if (gameStart)
            {
                 InitializeComponent();
                initializeGame();
            }    
            else if(loadSave)
            {
                InitializeComponent();
                loadGame();
            }

            else
                Environment.Exit(0);


            

        }

        public void initializeGame()
        {  
            
            starmap.initialize(createLineList());
            Line1And2.Opacity = 1;
            Line1And3.Opacity = 1;
            player = new Player(starmap.getSpaceport(0, 0));
            FuelCount.Text = player.getFuel().ToString() + " / " + this.difficulty;
        }

        public List<Line>[,] createLineList()
        {
            List<Line>[,] lines = new List<Line>[4, 4];
            lines[0, 0] = new List<Line> {Line1And2, Line1And3};
            lines[0, 1] = new List<Line> { Line2And3, Line2And4, Line2And5};
            lines[0, 2] = new List<Line> { Line4And5, Line4And7, Line4And8};
            lines[0, 3] = new List<Line> { Line7And8, Line7And11};
            lines[1, 0] = new List<Line> { Line2And3, Line3And5, Line3And6};
            lines[1, 1] = new List<Line> { Line4And5, Line5And6, Line5And8, Line5And9};
            lines[1, 2] = new List<Line> { Line7And8, Line8And9, Line8And11, Line8And12};
            lines[1, 3] = new List<Line> { Line11And12, Line11And14};
            lines[2, 0] = new List<Line> { Line5And6, Line6And9, Line6And10};
            lines[2, 1] = new List<Line> { Line8And9, Line9And10, Line9And12, Line9And13};
            lines[2, 2] = new List<Line> { Line11And12, Line12And13, Line12And14, Line12And15};
            lines[2, 3] = new List<Line> { Line14And15, Line14And16};
            lines[3, 0] = new List<Line> { Line9And10, Line10And13 };
            lines[3, 1] = new List<Line> { Line12And13, Line12And15 };
            lines[3, 2] = new List<Line> { Line14And15, Line15And16 };
            return lines;
        }

        public void hideLines()
        {
            
            Line1And2.Opacity = 0;
            Line1And3.Opacity = 0;
            Line2And3.Opacity = 0;
            Line2And4.Opacity = 0;
            Line2And5.Opacity = 0;
            Line3And5.Opacity = 0;
            Line3And6.Opacity = 0;
            Line4And5.Opacity = 0;
            Line4And7.Opacity = 0;
            Line4And8.Opacity = 0;
            Line5And6.Opacity = 0;
            Line5And8.Opacity = 0;
            Line5And9.Opacity = 0;
            Line6And9.Opacity = 0;
            Line6And10.Opacity = 0;
            Line7And11.Opacity = 0;
            Line7And8.Opacity = 0;
            Line8And9.Opacity = 0;
            Line8And11.Opacity = 0;
            Line8And12.Opacity = 0;
            Line9And10.Opacity = 0;
            Line9And12.Opacity = 0;
            Line9And13.Opacity = 0;
            Line10And13.Opacity = 0;
            Line11And12.Opacity = 0;
            Line11And14.Opacity = 0;
            Line12And13.Opacity = 0;
            Line12And14.Opacity = 0;
            Line12And15.Opacity = 0;
            Line13And15.Opacity = 0;
            Line14And15.Opacity = 0;
            Line14And16.Opacity = 0;
            Line15And16.Opacity = 0;
            
        }
        public int playerMove(Spaceport spaceport)
        {
            int moved = 0;
            if(player.getCoordinates().Equals(spaceport.getCoordinates()))
               MessageBox.Show("You are already at this location");
            else
            {
            moved = ValidMove(spaceport);
            }
            return moved;

            /*   else
            {
                TriviaWindow triviaWindow = new TriviaWindow();
                triviaWindow.Show();
                player.setCoordinates(spaceport.getCoordinates());
            }*/
        }

        public int ValidMove(Spaceport spaceport)
        {
            Random r = new Random();
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
                    Canvas.SetTop(PlayerShip, spaceport.getCanvasY());
                    Canvas.SetLeft(PlayerShip, spaceport.getCanvasX());
                    updateReturnTrajectoryOpen(prev, spaceport.getTrajectories());
                    return 1;
                }
                else if(traj.getLocked()==1)
                {
                    int x = r.Next(1, 101);
                    Question q1 = qf.CreateQuestion(x);
                    q1.displayQuestion.displayQuestion(q1);
                    if (q1.result == 1)
                    {
                        if(player.getFuel()<difficulty)
                        player.setFuel();
                        FuelCount.Text = player.getFuel().ToString() + " / " +difficulty;
                        Coordinates prev = player.getCoordinates();
                        player.setCoordinates(spaceport.getCoordinates());
                        player.setSpaceport(spaceport);
                        Canvas.SetTop(PlayerShip, spaceport.getCanvasY());
                        Canvas.SetLeft(PlayerShip, spaceport.getCanvasX());
                        updateReturnTrajectoryOpen(prev, spaceport.getTrajectories());
                        return 1;
                    }
                    else
                    {
                        lockTrajectory(spaceport.getCoordinates(), player.getCurr().getTrajectories(), player.getCurr().getLines());
                        return 0;
                    }
                }
                else
                {
                    MessageBox.Show("aisdjfasdf");
                    return 0;
                }
                
            }
            return 0;
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

        public void lockTrajectory(Coordinates coordinates, List<Trajectory> trajectories, List<Line> lines)
        {
            int index;
            trajectories.ForEach(delegate(Trajectory curr)
                                 {
                                     if (curr.getCoordinates().Equals(coordinates))
                                     {
                                         curr.setLocked(2);
                                         index = trajectories.IndexOf(curr);
                                         lines[index].Opacity = 0;
                                         lines[index].Height = 1111;
                                     }
                                 });
        }

        public void showLines(Line x, Line y, Line z, Line w)
        {
            if(!(x.Height==1111))
            x.Opacity = 1;
            if (!(y.Height == 1111))
            y.Opacity = 1;
            if(z!=null && z.Opacity==0)
            z.Opacity = 1;
            if (w != null && w.Opacity == 0)
            w.Opacity = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Spaceport spaceport = starmap.getSpaceport(0, 0);
            Button btn = (Button)sender;
            int moved = 0;
            if (btn == PlanetButton1)
            {
                spaceport = starmap.getSpaceport(0, 0);
                spaceport.setCanvasXY(200, 50);
                playerMove(spaceport);
            }
            if (btn == PlanetButton2)
            {              
                spaceport = starmap.getSpaceport(0, 1);
                spaceport.setCanvasXY(150, 150);
                moved =playerMove(spaceport);
                if(moved==1)
                {
                    hideLines();
                    showLines(Line2And3, Line2And4, Line2And5, null);
                }
            }

            if (btn == PlanetButton3)
            {
                spaceport = starmap.getSpaceport(1, 0);
                spaceport.setCanvasXY(150, 250);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line2And3, Line3And5, Line3And6, null);
                }
            }
            if (btn == PlanetButton4)
            {
                spaceport = starmap.getSpaceport(0, 2);
                spaceport.setCanvasXY(240, 100);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line4And7, Line4And8, Line4And5, null);
                }
            }
            if (btn == PlanetButton5)
            {
                spaceport = starmap.getSpaceport(1, 1);
                spaceport.setCanvasXY(240, 200);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line4And5, Line5And8, Line5And9, Line5And6);
                }
            }
            if (btn == PlanetButton6)
            {
                spaceport = starmap.getSpaceport(2, 0);
                spaceport.setCanvasXY(240, 300);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line5And6, Line6And9, Line6And10, null);
                }
            }
            if (btn == PlanetButton7)
            {
                spaceport = starmap.getSpaceport(0, 3);
                spaceport.setCanvasXY(330, 50);
                moved = playerMove(spaceport);
                if (moved == 1)
                { 
                    hideLines();
                    showLines(Line7And11, Line7And8, null, null);
                }
            }
            if (btn == PlanetButton8)
            {
                spaceport = starmap.getSpaceport(1, 2);
                spaceport.setCanvasXY(330, 150);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line7And8, Line8And11, Line8And12, Line8And9);
                }
            }
            if (btn == PlanetButton9)
            {
                spaceport = starmap.getSpaceport(2, 1);
                spaceport.setCanvasXY(330, 250);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line8And9, Line9And12, Line9And13, Line9And10);
                }
            }
            if (btn == PlanetButton10)
            {
                spaceport = starmap.getSpaceport(3, 0);
                spaceport.setCanvasXY(330, 350);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line9And10, Line10And13, null, null);
                }
            }
            if (btn == PlanetButton11)
            {
                spaceport = starmap.getSpaceport(1, 3);
                spaceport.setCanvasXY(420, 100);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line11And14, Line11And12, null, null);
                }
            }
            if (btn == PlanetButton12)
            {
                spaceport = starmap.getSpaceport(2, 2);
                spaceport.setCanvasXY(420, 200);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line11And12, Line12And14, Line12And15, Line12And13);
                }
            }
            if (btn == PlanetButton13)
            {
                spaceport = starmap.getSpaceport(3, 1);
                spaceport.setCanvasXY(420, 300);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line12And13, Line13And15, null, null);
                }
            }
            if (btn == PlanetButton14)
            {
                spaceport = starmap.getSpaceport(2, 3);
                spaceport.setCanvasXY(510, 150);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line14And15, Line14And16, null, null);
                }
            }
            if (btn == PlanetButton15)
            {
                spaceport = starmap.getSpaceport(3, 2);
                spaceport.setCanvasXY(510, 250);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                    showLines(Line14And15, Line15And16, null, null);
                }
            }
            if (btn == PlanetButton16)
            {
                spaceport = starmap.getSpaceport(3, 3);
                spaceport.setCanvasXY(600, 200);
                moved = playerMove(spaceport);
                if (moved == 1)
                {
                    hideLines();
                }
            }

            gameOverCheck();
        }

        public bool trapped()
        {
            int lockedCount = 0;
            int sealedCount= 0;
            int openCount = 0;
            Trajectory traj = null;
            List<Trajectory> trajectories = player.getCurr().getTrajectories();

            if (player.getCoordinates().getX() == 3 && player.getCoordinates().getY() == 3)
            {
                if (player.getFuel() < difficulty)
                {
                    return true;
                }
                else
                    return false;
            }

           foreach(Trajectory curr in trajectories)
            {
                if (curr.getLocked()==2)
                {
                    sealedCount++;
                }
               if(curr.getLocked()==0)
               {
                   traj = curr;
                   openCount++;
               }
               if(curr.getLocked()==1)
               {
                   lockedCount++;
               }
            }

            if(sealedCount==player.getCurr().getNumtrajectories())
            {
                return true;
            }

          
            if (openCount == 1 && lockedCount==0)
            {
                trajectories = starmap.getSpaceport(traj.getCoordinates().getX(), traj.getCoordinates().getY()).getTrajectories();
                openCount = 0;
                lockedCount=0;
                foreach (Trajectory curr in trajectories)
                {
                    if (curr.getLocked() == 0)
                    { 
                        openCount++;
                    }
                    if (curr.getLocked() == 1)
                    { 
                        lockedCount++;
                    }
                }

                if (openCount == 1 && lockedCount ==0)
                {
                    return true;
                }
            }

            
            return false;
        }
        public void gameOverCheck()
        {
            if(trapped())
            {
                disablePlanetButtons();
                TextBlock message = new TextBlock();
                message.Text = "GAME    OVER";
                message.Foreground = Brushes.White;
                message.FontSize = 60;
                message.FontFamily = new FontFamily("Comic Sans MS");
                Canvas.SetLeft(message, 150);
                Canvas.SetTop(message, 120);
                Game.Children.Add(message);
                Button message2 = new Button();
                message2.Content = "Reset";
                message2.Foreground = Brushes.White;
                message2.Background = Brushes.Black;
                message2.FontSize = 60;
                message2.FontFamily = new FontFamily("Comic Sans MS");
                Canvas.SetLeft(message2, 180);
                Canvas.SetTop(message2, 220);
                message2.Click += mnuReset_Click;
                Game.Children.Add(message2);
                Button message3 = new Button();
                message3.Content = "Quit";
                message3.Foreground = Brushes.White;
                message3.Background = Brushes.Black;
                message3.FontSize = 60;
                message3.FontFamily = new FontFamily("Comic Sans MS");
                Canvas.SetLeft(message3, 400);
                Canvas.SetTop(message3, 220);
                message3.Click += mnuExit_Click;
                Game.Children.Add(message3);
            }

            if(player.getFuel() >= difficulty)
            {
                //SoundPlayer warp = new SoundPlayer("warponline.wav");
               // warp.Play();
                WarpText.Text = "Online";
                Warp.Background = Brushes.Aquamarine;
            }

        }

        private void mnuReset_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click a planet to attempt to move to the location.\n" +
                "You will be asked a space themed trivia question.\n" +
                "You must answer the question correctly to move to the new location and gain a fuel!\n" +
                "If you answer the question wrong, the trajectory to that planet is locked forever.\n" +
                "Get to the end of the solar system to win and hit WARP.\n" +
                "If you have locked all trajectories from one planet, you will lose.");
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Journey To.. The Space Trivia Game!\n" +
                "Developed by: Michael Giacalone and Brian Lollis, Isaac Deal\n" +
                "Using: .NET v1.0.0 ");
        }

        private void mnuStart_Click(object sender, RoutedEventArgs e)
        {
        
                IFormatter format = new BinaryFormatter();
                Stream stream = new FileStream("SaveGame.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                format.Serialize(stream, player);
                format.Serialize(stream, starmap);
                stream.Close();
        }

        private void loadGame()
        {
            starmap.initialize(createLineList());
           // Line1And2.Opacity = 1;
            //Line1And3.Opacity = 1;
            //player = new Player(starmap.getSpaceport(0, 0));
            //FuelCount.Text = player.getFuel().ToString();
            try
            {
                IFormatter format = new BinaryFormatter();
                Stream stream = new FileStream("SaveGame.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
              // starmap = (Starmap)format.Deserialize(stream);
                player = (Player)format.Deserialize(stream);
                
                stream.Close();
                FuelCount.Text = player.getFuel().ToString();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No file Exists");
            }

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

        private void mnuAddMC_Click(object sender, RoutedEventArgs e)
        {
            AddWuestionWindow addMultipleChoiceWindow = new AddWuestionWindow();
            addMultipleChoiceWindow.ShowDialog();
        }

        private void mnuAddTF_Click(object sender, RoutedEventArgs e)
        {

            AddTrueFalse addTrueFalseWindow = new AddTrueFalse();
            addTrueFalseWindow.ShowDialog();
        }

        private void mnuAddSA_Click(object sender, RoutedEventArgs e)
        {
            AddShortAnswer addShortAnswerWindow = new AddShortAnswer();
            addShortAnswerWindow.ShowDialog();
        }

        private void Warp_Click(object sender, RoutedEventArgs e)
        {
            
            if (player.getFuel() >= difficulty && player.getCoordinates().getX() == 3 && player.getCoordinates().getY() == 3)
            {
                disablePlanetButtons();
                SoundPlayer warp = new SoundPlayer("zoom.wav");
                warp.Play();
                TextBlock message = new TextBlock();
                message.Text = "WINNER";
                message.Foreground = Brushes.White;
                message.FontSize = 60;
                message.FontFamily = new FontFamily("Comic Sans MS");
                Canvas.SetLeft(message, 150);
                Canvas.SetTop(message, 120);
                Game.Children.Add(message);
                Button message2 = new Button();
                message2.Content = "Reset";
                message2.Foreground = Brushes.White;
                message2.Background = Brushes.Black;
                message2.FontSize = 60;
                message2.FontFamily = new FontFamily("Comic Sans MS");
                Canvas.SetLeft(message2, 180);
                Canvas.SetTop(message2, 220);
                message2.Click += mnuReset_Click;
                Game.Children.Add(message2);
                Button message3 = new Button();
                message3.Content = "Quit";
                message3.Foreground = Brushes.White;
                message3.Background = Brushes.Black;
                message3.FontSize = 60;
                message3.FontFamily = new FontFamily("Comic Sans MS");
                Canvas.SetLeft(message3, 400);
                Canvas.SetTop(message3, 220);
                message3.Click += mnuExit_Click;
                Game.Children.Add(message3);
            }
            else if (player.getFuel() < difficulty)
                MessageBox.Show("Insufficient fuel");
            else
                MessageBox.Show("Must reach end of starmap");
        }
       private void disablePlanetButtons()
        {
            PlanetButton1.IsEnabled = false;
            PlanetButton2.IsEnabled = false;
            PlanetButton3.IsEnabled = false;
            PlanetButton4.IsEnabled = false;
            PlanetButton5.IsEnabled = false;
            PlanetButton6.IsEnabled = false;
            PlanetButton7.IsEnabled = false;
            PlanetButton8.IsEnabled = false;
            PlanetButton9.IsEnabled = false;
            PlanetButton10.IsEnabled = false;
            PlanetButton11.IsEnabled = false;
            PlanetButton12.IsEnabled = false;
            PlanetButton13.IsEnabled = false;
            PlanetButton14.IsEnabled = false;
            PlanetButton15.IsEnabled = false;
            PlanetButton16.IsEnabled = false;
        }

    }
}