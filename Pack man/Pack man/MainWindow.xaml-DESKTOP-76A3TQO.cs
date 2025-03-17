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
namespace Pack_man
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        bool goUp, goDown, goLeft, goRight;
        bool noUp, noDown, noLeft, noRight;

        int speed = 8;

        Rect pacmanHitBox;

        int ghostspeed = 7;
        int ghostspeed_orange = 10;
        int ghostspeed_pink = 10;
        int ghostspeed_red = 10;
        int ghostspeed_blue = 10;
        int ghostspeed_green = 10;
        int ghostspeed_pruple = 10;
        int ghostspeed_schwarz = 10;
        int ghostMoveStep = 200;
        int ghostMoveStep_orange = 413;
        int ghostMoveStep_pink = 235;
        int ghostMoveStep_red = 601;
        int ghostMoveStep_blue = 1030;
        int ghostMoveStep_green = 500;
        int ghostMoveStep_pruple = 400;
        int ghostMoveStep_schwarz = 600;
        int currentGhostStep;
        int currentGhostStep_orange;
        int currentGhostStep_pink;
        int currentGhostStep_red;
        int currentGhostStep_blue;
        int currentGhostStep_green;
        int currentGhostStep_pruple;
        int currentGhostStep_schwarz;
        int score = 0;



        public MainWindow()
        {
            InitializeComponent();
            GameSetUp();
        }

        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left && noLeft == false)
            {
                goRight = goUp = goDown = false;
                noRight = noUp = noDown = false;
                goLeft = true;
                pacman.RenderTransform = new RotateTransform(-180, pacman.Width / 2, pacman.Height / 2);
            }

            if (e.Key == Key.Right && noRight == false)
            {
                goLeft = goUp = goDown = false;
                noLeft = noUp = noDown = false;
                goRight = true;
                pacman.RenderTransform = new RotateTransform(0, pacman.Width / 2, pacman.Height / 2);
            }

            if (e.Key == Key.Up && noUp == false)
            {
                goLeft = goRight = goDown = false;
                noLeft = goRight = noDown = false;
                goUp = true;
                pacman.RenderTransform = new RotateTransform(-90, pacman.Width / 2, pacman.Height / 2);
            }

            if (e.Key == Key.Down && noDown == false)
            {
                goLeft = goRight = goUp = false;
                noLeft = goRight = noUp = false;
                goDown = true;
                pacman.RenderTransform = new RotateTransform(90, pacman.Width / 2, pacman.Height / 2);
            }
        }

        private void GameSetUp()
        {
            MyCanvas.Focus();
            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
            currentGhostStep = ghostMoveStep;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            txtScore.Content = "Punktestand: " + score;

            if(goRight)
            {
                Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) + speed);
            }
            if (goLeft)
            {
                Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) - speed);
            }
            if (goUp)
            {
                Canvas.SetTop(pacman, Canvas.GetTop(pacman) - speed);
            }
            if (goDown)
            {
                Canvas.SetTop(pacman, Canvas.GetTop(pacman) + speed);
            }

 

            pacmanHitBox = new Rect(Canvas.GetLeft(pacman), Canvas.GetTop(pacman), pacman.Width, pacman.Height);

            foreach(var x in MyCanvas.Children.OfType<Rectangle>())
            {
                Rect hitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                if((string)x.Tag == "wall")
                {
                    if(goLeft == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) + 10);
                        noLeft = false;
                        goLeft = false;
                    }

                    if (goRight == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) - 10);
                        noRight = false;
                        goRight = false;
                    }

                    if (goDown == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(pacman, Canvas.GetTop(pacman) - 10);
                        noDown = false;
                        goDown = false;
                    }

                    if (goUp == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(pacman, Canvas.GetTop(pacman) + 10);
                        noUp = false;
                        goUp = false;
                    }

                }


                if ((string)x.Tag == "coin")
                {
                    if(pacmanHitBox.IntersectsWith(hitBox) && x.Visibility == Visibility.Visible )
                    {
                        x.Visibility = Visibility.Hidden;
                        score++;
                    }
                }

                if ((string)x.Tag == "ghost")
                {

                    if (pacmanHitBox.IntersectsWith(hitBox))
                    {
                       GameOver("Der Geist hat dich, klick ok um nochmal zu Spielen");
                    }

                    if(x.Name.ToString()== "organgeGuy")
                    {
                        Canvas.SetTop(x, Canvas.GetTop(x) - ghostspeed_orange);
                    }
                    if (x.Name.ToString() == "pinkGuy")
                    {
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - ghostspeed_pink);
                    }
                    if (x.Name.ToString() == "redGuy")
                    {
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - ghostspeed_red);
                    }
                    if (x.Name.ToString() == "blueGuy")
                    {
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - ghostspeed_blue);
                    }
                    if (x.Name.ToString() == "greenGuy")
                    {
                        Canvas.SetTop(x, Canvas.GetTop(x) - ghostspeed_green);
                    }
                    if (x.Name.ToString() == "prupleGuy")
                    {
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - ghostspeed_pruple);
                    }
                    if (x.Name.ToString() == "schwarzGuy")
                    {
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + ghostspeed_schwarz);
                    }

                    currentGhostStep_pink--;

                    if (currentGhostStep_pink < 1)
                    {
                        currentGhostStep_pink = ghostMoveStep_pink;
                        ghostspeed_pink = -ghostspeed_pink;
                    }

                    currentGhostStep_red--;

                    if (currentGhostStep_red < 1)
                    {
                        currentGhostStep_red = ghostMoveStep_red;
                        ghostspeed_red = -ghostspeed_red;
                    }


                    currentGhostStep_orange--;

                    if (currentGhostStep_orange < 1)
                    {
                        currentGhostStep_orange = ghostMoveStep_orange;
                        ghostspeed_orange = -ghostspeed_orange;
                    }

                    currentGhostStep_blue--;

                    if (currentGhostStep_blue < 1)
                    {
                        currentGhostStep_blue = ghostMoveStep_blue;
                        ghostspeed_blue = -ghostspeed_blue;
                    }

                    currentGhostStep_green--;

                    if (currentGhostStep_green < 1)
                    {
                        currentGhostStep_green = ghostMoveStep_green;
                        ghostspeed_green = -ghostspeed_green;
                    }

                    currentGhostStep_pruple--;

                    if (currentGhostStep_pruple < 1)
                    {
                        currentGhostStep_pruple = ghostMoveStep_pruple;
                        ghostspeed_pruple = -ghostspeed_pruple;
                    }

                    currentGhostStep_schwarz--;
                    if (currentGhostStep_schwarz < 1)
                    {
                        currentGhostStep_schwarz = ghostMoveStep_schwarz;
                        ghostspeed_schwarz = -ghostspeed_schwarz;
                    }
                }

            }

        if(score == 361)
            {
                GameOver("Du hast Gewonnen, du hast alle Coins eingesammelt");
            }
        }

        private void GameOver(String message)
        {
            gameTimer.Stop();
            MessageBox.Show(message, "Pacman ");
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
                
        }
    }
}
