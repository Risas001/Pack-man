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

        bool BgoUp, BgoDown, BgoLeft, BgoRight;
        bool BnoUp, BnoDown, BnoLeft, BnoRight;

        int speed = 8;

        Rect pacmanHitBox;
        Rect gHitBox;

        int ghostspeed = 10;



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
            
            gMove.Interval = 900;
            gMove.AutoReset = true;





            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
            gMove.Start();
   
        }

        int BotDirection;

        void botM(object sender, ElapsedEventArgs e)
        {
            Random Rnd = new Random();
            BotDirection = Rnd.Next(1, 5);

            if (BotDirection == 1 && BnoUp == false)
            {
                BgoUp = true;

                BgoDown = false;
                BgoLeft = false;
                BgoRight = false;

            }

            if (BotDirection == 2 && BnoDown == false)
            {
                BgoDown = true;

                BgoUp = false;
                BgoLeft = false;
                BgoRight = false;
            }

            if (BotDirection == 3 && BnoLeft == false)
            {
                BgoLeft = true;

                BgoUp = false;
                BgoDown = false;
                BgoRight = false;
            }

            if (BotDirection == 4 && BnoRight == false)
            {
                BgoRight = true;

                BgoUp = false;
                BgoDown = false;
                BgoLeft = false;
            }

        }

        private void GameLoop(object sender, EventArgs e)
        {

            gMove.Elapsed += new System.Timers.ElapsedEventHandler(botM);

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

            if (BgoRight)
            {
                Canvas.SetLeft(orangeGuy, Canvas.GetLeft(orangeGuy) + ghostspeed);

            }
            if (BgoLeft)
            {
                Canvas.SetLeft(orangeGuy, Canvas.GetLeft(orangeGuy) - ghostspeed);
            }
            if (BgoUp)
            {
                Canvas.SetTop(orangeGuy, Canvas.GetTop(orangeGuy) + ghostspeed);
            }
            if (BgoDown)
            {
                Canvas.SetTop(orangeGuy, Canvas.GetTop(orangeGuy) - ghostspeed);
            }

            pacmanHitBox = new Rect(Canvas.GetLeft(pacman), Canvas.GetTop(pacman), pacman.Width, pacman.Height);
            gHitBox = new Rect(Canvas.GetLeft(orangeGuy), Canvas.GetTop(orangeGuy), orangeGuy.Width, orangeGuy.Height);

            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
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



                    if (BgoLeft == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(orangeGuy, Canvas.GetLeft(orangeGuy) + 10);
                        BnoLeft = false;
                        BgoLeft = false;
                    }

                    if (BgoRight == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetLeft(orangeGuy, Canvas.GetLeft(orangeGuy) - 10);
                        BnoRight = false;
                        BgoRight = false;
                    }

                    if (BgoDown == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(orangeGuy, Canvas.GetTop(orangeGuy) + 10);
                        BnoDown = false;
                        BgoDown = false;
                    }

                    if (BgoUp == true && gHitBox.IntersectsWith(hitBox))
                    {
                        Canvas.SetTop(orangeGuy, Canvas.GetTop(orangeGuy) - 10);
                        BnoUp = false;
                        BgoUp = false;
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
                      // GameOver("Der Geist hat dich, klick ok um nochmal zu Spielen");
                    }

                  
                }

            }

        if(score == 347)
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
