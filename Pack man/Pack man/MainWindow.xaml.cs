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
using System.Timers;


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

        bool OgoUp, OgoDown, OgoLeft, OgoRight;
        bool OnoUp, OnoDown, OnoLeft, OnoRight;

        bool RgoUp, RgoDown, RgoLeft, RgoRight;
        bool RnoUp, RnoDown, RnoLeft, RnoRight;

        bool PgoUp, PgoDown, PgoLeft, PgoRight;
        bool PnoUp, PnoDown, PnoLeft, PnoRight;

        bool BgoUp, BgoDown, BgoLeft, BgoRight;
        bool BnoUp, BnoDown, BnoLeft, BnoRight;

        bool GgoUp, GgoDown, GgoLeft, GgoRight;
        bool GnoUp, GnoDown, GnoLeft, GnoRight;


        int speed = 5;

        Rect pacmanHitBox;
        Rect oHitBox;
        Rect rHitBox;
        Rect pHitBox;
        Rect bHitBox;
        Rect gHitBox;

        int ghostspeed = 5;
        int schnell_ghostspeed = 10;



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
            Timer gMove = new Timer();
        private void GameSetUp()
        {
            MyCanvas.Focus();
            
            gMove.Interval = 750;
            gMove.AutoReset = true;


            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(5);
            gameTimer.Start();
            gMove.Start();
   
        }

        int BotDirection;

        void botO(object sender, ElapsedEventArgs e)
        {
            Random Rnd = new Random();
            BotDirection = Rnd.Next(1, 5);

            if (BotDirection == 1 && OnoUp == false)
            {
                OgoUp = true;

                OgoDown = false;
                OgoLeft = false;
                OgoRight = false;

            }

            if (BotDirection == 2 && OnoDown == false)
            {
                OgoDown = true;

                OgoUp = false;
                OgoLeft = false;
                OgoRight = false;
            }

            if (BotDirection == 3 && OnoLeft == false)
            {
                OgoLeft = true;

                OgoUp = false;
                OgoDown = false;
                OgoRight = false;
            }

            if (BotDirection == 4 && OnoRight == false)
            {
                OgoRight = true;

                OgoUp = false;
                OgoDown = false;
                OgoLeft = false;
            }
        }

        void botR(object sender, ElapsedEventArgs e)
        {
            Random Rnd = new Random();
            BotDirection = Rnd.Next(1, 5);

            if (BotDirection == 4 && RnoUp == false)
            {
                RgoUp = true;

                RgoDown = false;
                RgoLeft = false;
                RgoRight = false;
            }

            if (BotDirection == 3 && RnoDown == false)
            {
                RgoDown = true;

                RgoUp = false;
                RgoLeft = false;
                RgoRight = false;
            }

            if (BotDirection == 2 && RnoLeft == false)
            {
                RgoLeft = true;

                RgoUp = false;
                RgoDown = false;
                RgoRight = false;
            }

            if (BotDirection == 1 && RnoRight == false)
            {
                RgoRight = true;

                RgoUp = false;
                RgoDown = false;
                RgoLeft = false;
            }
        }

        void botP(object sender, ElapsedEventArgs e)
        {
            Random Rnd = new Random();
            BotDirection = Rnd.Next(1, 5);

            if (BotDirection == 3 && PnoUp == false)
            {
                PgoUp = true;

                PgoDown = false;
                PgoLeft = false;
                PgoRight = false;
            }

            if (BotDirection == 2 && PnoDown == false)
            {
                PgoDown = true;

                PgoUp = false;
                PgoLeft = false;
                PgoRight = false;
            }

            if (BotDirection == 1 && PnoLeft == false)
            {
                PgoLeft = true;

                PgoUp = false;
                PgoDown = false;
                PgoRight = false;
            }

            if (BotDirection == 4 && PnoRight == false)
            {
                PgoRight = true;

                PgoUp = false;
                PgoDown = false;
                PgoLeft = false;
            }
        }

        void botB(object sender, ElapsedEventArgs e)
        {
            Random Rnd = new Random();
            BotDirection = Rnd.Next(1, 5);

            if (BotDirection == 4 && BnoUp == false)
            {
                BgoUp = true;

                BgoDown = false;
                BgoLeft = false;
                BgoRight = false;

            }

            if (BotDirection == 3 && BnoDown == false)
            {
                BgoDown = true;

                BgoUp = false;
                BgoLeft = false;
                BgoRight = false;
            }

            if (BotDirection == 2 && BnoLeft == false)
            {
                BgoLeft = true;

                BgoUp = false;
                BgoDown = false;
                BgoRight = false;
            }

            if (BotDirection == 1 && BnoRight == false)
            {
                BgoRight = true;

                BgoUp = false;
                BgoDown = false;
                BgoLeft = false;
            }

        }

        void botG(object sender, ElapsedEventArgs e)
        {
            Random Rnd = new Random();
            BotDirection = Rnd.Next(1, 5);

            if (BotDirection == 4 && GnoUp == false)
            {
                GgoUp = true;

                GgoDown = false;
                GgoLeft = false;
                GgoRight = false;

            }

            if (BotDirection == 2 && GnoDown == false)
            {
                GgoDown = true;

                GgoUp = false;
                GgoLeft = false;
                GgoRight = false;
            }

            if (BotDirection == 1 && GnoLeft == false)
            {
                GgoLeft = true;

                GgoUp = false;
                GgoDown = false;
                GgoRight = false;
            }

            if (BotDirection == 3 && GnoRight == false)
            {
                GgoRight = true;

                GgoUp = false;
                GgoDown = false;
                GgoLeft = false;
            }

        }

        private void GameLoop(object sender, EventArgs e)
        {

            gMove.Elapsed += new System.Timers.ElapsedEventHandler(botO);
            gMove.Elapsed += new System.Timers.ElapsedEventHandler(botR);
            gMove.Elapsed += new System.Timers.ElapsedEventHandler(botP);
            gMove.Elapsed += new System.Timers.ElapsedEventHandler(botB);
            gMove.Elapsed += new System.Timers.ElapsedEventHandler(botG);

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
            
            if (OgoRight)
            {
                Canvas.SetLeft(organgeGuy, Canvas.GetLeft(organgeGuy) + ghostspeed);

            }
            if (OgoLeft)
            {
                Canvas.SetLeft(organgeGuy, Canvas.GetLeft(organgeGuy) - ghostspeed);
            }
            if (OgoUp)
            {
                Canvas.SetTop(organgeGuy, Canvas.GetTop(organgeGuy) + ghostspeed);
            }
            if (OgoDown)
            {
                Canvas.SetTop(organgeGuy, Canvas.GetTop(organgeGuy) - ghostspeed);
            }

            if (RgoRight)
            {
                Canvas.SetLeft(redGuy, Canvas.GetLeft(redGuy) + ghostspeed);

            }
            if (RgoLeft)
            {
                Canvas.SetLeft(redGuy, Canvas.GetLeft(redGuy) - ghostspeed);
            }
            if (RgoUp)
            {
                Canvas.SetTop(redGuy, Canvas.GetTop(redGuy) + ghostspeed);
            }
            if (RgoDown)
            {
                Canvas.SetTop(redGuy, Canvas.GetTop(redGuy) - ghostspeed);
            }

            if (PgoRight)
            {
                Canvas.SetLeft(pinkGuy, Canvas.GetLeft(pinkGuy) + ghostspeed);

            }
            if (PgoLeft)
            {
                Canvas.SetLeft(pinkGuy, Canvas.GetLeft(pinkGuy) - ghostspeed);
            }
            if (PgoUp)
            {
                Canvas.SetTop(pinkGuy, Canvas.GetTop(pinkGuy) + ghostspeed);
            }
            if (PgoDown)
            {
                Canvas.SetTop(pinkGuy, Canvas.GetTop(pinkGuy) - ghostspeed);
            }

            if (BgoRight)
            {
                Canvas.SetLeft(blueGuy, Canvas.GetLeft(blueGuy) + ghostspeed);

            }
            if (BgoLeft)
            {
                Canvas.SetLeft(blueGuy, Canvas.GetLeft(blueGuy) - ghostspeed);
            }
            if (BgoUp)
            {
                Canvas.SetTop(blueGuy, Canvas.GetTop(blueGuy) + ghostspeed);
            }
            if (BgoDown)
            {
                Canvas.SetTop(blueGuy, Canvas.GetTop(blueGuy) - ghostspeed);
            }

            if (GgoRight)
            {
                Canvas.SetLeft(greenGuy, Canvas.GetLeft(greenGuy) + schnell_ghostspeed);

            }
            if (GgoLeft)
            {
                Canvas.SetLeft(greenGuy, Canvas.GetLeft(greenGuy) - schnell_ghostspeed);
            }
            if (GgoUp)
            {
                Canvas.SetTop(greenGuy, Canvas.GetTop(greenGuy) + schnell_ghostspeed);
            }
            if (GgoDown)
            {
                Canvas.SetTop(greenGuy, Canvas.GetTop(greenGuy) - schnell_ghostspeed);
            }

            pacmanHitBox = new Rect(Canvas.GetLeft(pacman), Canvas.GetTop(pacman), pacman.Width, pacman.Height);
            oHitBox = new Rect(Canvas.GetLeft(organgeGuy), Canvas.GetTop(organgeGuy), organgeGuy.Width, organgeGuy.Height);
            rHitBox = new Rect(Canvas.GetLeft(redGuy), Canvas.GetTop(redGuy), redGuy.Width, redGuy.Height);
            pHitBox = new Rect(Canvas.GetLeft(pinkGuy), Canvas.GetTop(pinkGuy), pinkGuy.Width, pinkGuy.Height);
            bHitBox = new Rect(Canvas.GetLeft(blueGuy), Canvas.GetTop(blueGuy), blueGuy.Width, blueGuy.Height);
            gHitBox = new Rect(Canvas.GetLeft(greenGuy), Canvas.GetTop(greenGuy), greenGuy.Width, greenGuy.Height);

            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                Rect hitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                if((string)x.Tag == "wall")
                {
                    if(goLeft == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) + 5);
                        noLeft = false;
                        goLeft = false;
                    }

                    if (goRight == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(pacman, Canvas.GetLeft(pacman) - 5);
                        noRight = false;
                        goRight = false;
                    }

                    if (goDown == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(pacman, Canvas.GetTop(pacman) - 5);
                        noDown = false;
                        goDown = false;
                    }

                    if (goUp == true && pacmanHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(pacman, Canvas.GetTop(pacman) + 5);
                        noUp = false;
                        goUp = false;
                    }

                    if (OgoLeft == true && oHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(organgeGuy, Canvas.GetLeft(organgeGuy) + 5);
                        OnoLeft = false;
                        OgoLeft = false;
                    }

                    if (OgoRight == true && oHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(organgeGuy, Canvas.GetLeft(organgeGuy) - 5);
                        OnoRight = false;
                        OgoRight = false;
                    }

                    if (OgoDown == true && oHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(organgeGuy, Canvas.GetTop(organgeGuy) + 5);
                        OnoDown = false;
                        OgoDown = false;
                    }

                    if (OgoUp == true && oHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(organgeGuy, Canvas.GetTop(organgeGuy) - 5);
                        OnoUp = false;
                        OgoUp = false;
                    }

                    if (RgoLeft == true && rHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(redGuy, Canvas.GetLeft(redGuy) + 5);
                        RnoLeft = false;
                        RgoLeft = false;
                    }

                    if (RgoRight == true && rHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(redGuy, Canvas.GetLeft(redGuy) - 5);
                        RnoRight = false;
                        RgoRight = false;
                    }

                    if (RgoDown == true && rHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(redGuy, Canvas.GetTop(redGuy) + 5);
                        RnoDown = false;
                        RgoDown = false;
                    }

                    if (RgoUp == true && rHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(redGuy, Canvas.GetTop(redGuy) - 5);
                        RnoUp = false;
                        RgoUp = false;
                    }

                    if (PgoLeft == true && pHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(pinkGuy, Canvas.GetLeft(pinkGuy) + 5);
                        PnoLeft = false;
                        PgoLeft = false;
                    }

                    if (PgoRight == true && pHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(pinkGuy, Canvas.GetLeft(pinkGuy) - 5);
                        PnoRight = false;
                        PgoRight = false;
                    }

                    if (PgoDown == true && pHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(pinkGuy, Canvas.GetTop(pinkGuy) + 5);
                        PnoDown = false;
                        PgoDown = false;
                    }

                    if (PgoUp == true && pHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(pinkGuy, Canvas.GetTop(pinkGuy) - 5);
                        PnoUp = false;
                        PgoUp = false;
                    }

                    if (BgoLeft == true && bHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(blueGuy, Canvas.GetLeft(blueGuy) + 5);
                        BnoLeft = false;
                        BgoLeft = false;
                    }

                    if (BgoRight == true && bHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(blueGuy, Canvas.GetLeft(blueGuy) - 5);
                        BnoRight = false;
                        BgoRight = false;
                    }

                    if (BgoDown == true && bHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(blueGuy, Canvas.GetTop(blueGuy) + 5);
                        BnoDown = false;
                        BgoDown = false;
                    }

                    if (BgoUp == true && bHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(blueGuy, Canvas.GetTop(blueGuy) - 5);
                        BnoUp = false;
                        BgoUp = false;
                    }

                    if (GgoLeft == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(greenGuy, Canvas.GetLeft(greenGuy) + 10);
                        GnoLeft = false;
                        GgoLeft = false;
                    }

                    if (GgoRight == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(greenGuy, Canvas.GetLeft(greenGuy) - 10);
                        GnoRight = false;
                        GgoRight = false;
                    }

                    if (GgoDown == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(greenGuy, Canvas.GetTop(greenGuy) + 10);
                        GnoDown = false;
                        GgoDown = false;
                    }

                    if (GgoUp == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(greenGuy, Canvas.GetTop(greenGuy) - 10);
                        GnoUp = false;
                        GgoUp = false;
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
                }
            }

            if(score == 418)
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
