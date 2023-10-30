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
using System.Windows.Threading;

namespace Game_Interaction.Views
{
    /// <summary>
    /// Interaction logic for Speelscherm.xaml
    /// </summary>
    public partial class Speelscherm : Window
    {
        private bool moveLeft1, moveRight1, moveUp1, moveDown1;
        private bool moveLeft2, moveRight2, moveUp2, moveDown2;
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private ImageBrush playerBrush = new ImageBrush();
        private List<Rectangle> bulletsToRemove = new List<Rectangle>();

        // Player1 Stats
        private int movementSpeedPlayer1 = 10;
        private int bulletSpeedPlayer1 = 20;
        private int ticksBetweenShotsPlayer1 = 30;
        private int damagePlayer1 = 1;
        private int hitpointsPlayer1 = 500;

        // Player2 Stats
        private int movementSpeedPlayer2 = 10;
        private int bulletSpeedPlayer2 = 20;
        private int ticksBetweenShotsPlayer2 = 30;
        private int damagePlayer2 = 1;
        private int hitpointsPlayer2 = 500;


        // Logica om ticksBetweenShots te laten werken
        private int shootCounter1 = 0;
        private int shootCounter2 = 0;



        public Speelscherm()
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameEngine;
            gameTimer.Start();

            GameCanvas.Focus();
        }

        private void GameEngine(object? sender, EventArgs e)
        {
            double newLeft1, newTop1, newLeft2, newTop2;

            // Schieten van de projectiles
            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {

                if (x.Tag != null) // Idk waarom maar soms crashte de game omdat tag null was, dit fixte t
                {
                    Rect bulletRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    // Player 1
                    if (x.Tag.ToString() == "ProjectileRight")
                    {
                        // Laat bullet bewegen
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + bulletSpeedPlayer1);
                        
                        // Logica om te kijken of bullet van player 1, player 2 hit
                        Rect player2Rect = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);
                        if (bulletRect.IntersectsWith(player2Rect))
                        {
                            hitpointsPlayer2 -= damagePlayer1;
                            bulletsToRemove.Add(x); 
                        }

                    }
                    // Player 2
                    else if (x.Tag.ToString() == "ProjectileLeft")
                    {
                        // Laat bullet bewegen
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - bulletSpeedPlayer2);

                        // Logica om te kijken of bullet van player 2, player 1 hit
                        Rect player1Rect = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
                        if (bulletRect.IntersectsWith(player1Rect))
                        {
                            hitpointsPlayer1 -= damagePlayer2;
                            Player1HitPoints.Content = $"Player 1: {hitpointsPlayer1} HP";
                            bulletsToRemove.Add(x);
                        }
                    }
                }
            }

            foreach (var bullet in bulletsToRemove)
            {
                GameCanvas.Children.Remove(bullet);
            }

            shootCounter1++;
            shootCounter2++;

            if (shootCounter1 >= ticksBetweenShotsPlayer1)
            {
                ShootProjectileFromPlayer(Player1, GameCanvas, "Player1");
                shootCounter1 = 0;
            }

            if (shootCounter2 >= ticksBetweenShotsPlayer2)
            {
                ShootProjectileFromPlayer(Player2, GameCanvas, "Player2");
                shootCounter2 = 0;
            }

            // Beweging voor Player1
            if (moveRight1)
            {
                newLeft1 = Canvas.GetLeft(Player1) + movementSpeedPlayer1;
                if (newLeft1 <= 960 - Player1.Width) // Zorg ervoor dat Player1 niet verder gaat dan de middenlijn
                    Canvas.SetLeft(Player1, newLeft1);
            }
            if (moveLeft1)
            {
                newLeft1 = Canvas.GetLeft(Player1) - movementSpeedPlayer1;
                if (newLeft1 >= 0)
                    Canvas.SetLeft(Player1, newLeft1);
            }
            if (moveUp1)
            {
                newTop1 = Canvas.GetTop(Player1) - movementSpeedPlayer1;
                if (newTop1 >= 0)
                    Canvas.SetTop(Player1, newTop1);
            }
            if (moveDown1)
            {
                newTop1 = Canvas.GetTop(Player1) + movementSpeedPlayer1;
                if (newTop1 <= GameCanvas.ActualHeight - Player1.Height)
                    Canvas.SetTop(Player1, newTop1);
            }

            // Beweging voor Player2
            if (moveRight2)
            {
                newLeft2 = Canvas.GetLeft(Player2) + movementSpeedPlayer2;
                if (newLeft2 <= GameCanvas.ActualWidth - Player2.Width)
                    Canvas.SetLeft(Player2, newLeft2);
            }
            if (moveLeft2)
            {
                newLeft2 = Canvas.GetLeft(Player2) - movementSpeedPlayer2;
                if (newLeft2 >= 960) // Zorg ervoor dat Player2 niet verder gaat dan de middenlijn aan de linkerkant
                    Canvas.SetLeft(Player2, newLeft2);
            }
            if (moveUp2)
            {
                newTop2 = Canvas.GetTop(Player2) - movementSpeedPlayer2;
                if (newTop2 >= 0)
                    Canvas.SetTop(Player2, newTop2);
            }
            if (moveDown2)
            {
                newTop2 = Canvas.GetTop(Player2) + movementSpeedPlayer2;
                if (newTop2 <= GameCanvas.ActualHeight - Player2.Height)
                    Canvas.SetTop(Player2, newTop2);
            }

        }


        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // Controls voor Player1
            if (e.Key == Key.D) moveRight1 = true;
            if (e.Key == Key.A) moveLeft1 = true;
            if (e.Key == Key.W) moveUp1 = true;
            if (e.Key == Key.S) moveDown1 = true;

            // Controls voor Player2
            if (e.Key == Key.Right) moveRight2 = true;
            if (e.Key == Key.Left) moveLeft2 = true;
            if (e.Key == Key.Up) moveUp2 = true;
            if (e.Key == Key.Down) moveDown2 = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            // Controls voor Player1
            if (e.Key == Key.D) moveRight1 = false;
            if (e.Key == Key.A) moveLeft1 = false;
            if (e.Key == Key.W) moveUp1 = false;
            if (e.Key == Key.S) moveDown1 = false;

            // Controls voor Player2
            if (e.Key == Key.Right) moveRight2 = false;
            if (e.Key == Key.Left) moveLeft2 = false;
            if (e.Key == Key.Up) moveUp2 = false;
            if (e.Key == Key.Down) moveDown2 = false;
        }

        public void ShootProjectileFromPlayer(Rectangle player, Canvas gameCanvas, string playerName)
        {
            Rectangle newProjectile = new Rectangle
            {
                Height = 20,
                Width = 20,
                Fill = Brushes.White,
                Stroke = Brushes.Red
            };

            if (playerName == "Player1")
            {
                Canvas.SetTop(newProjectile, Canvas.GetTop(player));
                Canvas.SetLeft(newProjectile, Canvas.GetLeft(player) + player.Width);
                newProjectile.Tag = "ProjectileRight";  // beweegt naar rechts
            }
            else if (playerName == "Player2")
            {
                Canvas.SetTop(newProjectile, Canvas.GetTop(player));
                Canvas.SetLeft(newProjectile, Canvas.GetLeft(player) - newProjectile.Width);
                newProjectile.Tag = "ProjectileLeft";   // beweegt naar links
            }

            gameCanvas.Children.Add(newProjectile);
        }
    }
}
