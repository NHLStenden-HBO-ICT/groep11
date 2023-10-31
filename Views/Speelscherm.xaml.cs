﻿using System;
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
        private List<Rectangle> itemsToRemove = new List<Rectangle>();
        private bool gameIsOver = false;
        Random random = new Random();

        // Player1 Stats
        private int movementSpeedPlayer1 = 10;
        private int bulletSpeedPlayer1 = 20;
        private int ticksBetweenShotsPlayer1 = 30;
        private int damagePlayer1 = 50;
        private int hitpointsPlayer1 = 500;
        
        // Player1 Powerups
        private bool hasPowerUpPlayer1 = false;
        private int powerUpTimerPlayer1 = 0;
        private string currentPowerUpPlayer1 = "nothing";

        // Player2 Stats
        private int movementSpeedPlayer2 = 10;
        private int bulletSpeedPlayer2 = 20;
        private int ticksBetweenShotsPlayer2 = 30;
        private int damagePlayer2 = 50;
        private int hitpointsPlayer2 = 500;
        
        // Player2 Powerups
        private bool hasPowerUpPlayer2 = false;
        private int powerUpTimerPlayer2 = 0;
        private string currentPowerUpPlayer2 = "nothing";

        // Powerups
        private int powerUpDurationInTicks = 200; //50 ticks is 1 seconde
        private int healthPowerUp = 100;
        private int damageIncreasePowerUp = 30;
        private int ticksBetweenPowerUpSpawns = 1000; // Randomized; gemiddeld 1000 ticks
        public List<string> powerUps = new List<string>
                {
                    "HealthBoost",
                    "DamageIncrease"
                };

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

            // Schieten van de projectiles + Powerup logica (beide hier omdat er met rectangles wordt gewerkt)
            foreach (var x in GameCanvas.Children.OfType<Rectangle>())
            {

                if (x.Tag != null) // Idk waarom maar soms crashte de game omdat tag null was, dit fixte t
                {
                    // Projectile van Player 1
                    if (x.Tag.ToString() == "ProjectileRight")
                    {
                        // Laat bullet bewegen
                        Rect bulletRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        Canvas.SetLeft(x, Canvas.GetLeft(x) + bulletSpeedPlayer1);

                        // Logica om te kijken of Projectile van player 1, player 2 hit
                        Rect player2Rect = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);
                        if (bulletRect.IntersectsWith(player2Rect))
                        {
                            hitpointsPlayer2 -= damagePlayer1;
                            Player2HitPoints.Content = $"Player 2: {hitpointsPlayer2} HP";
                            itemsToRemove.Add(x);
                        }

                    }
                    // Projectile van Player 2
                    else if (x.Tag.ToString() == "ProjectileLeft")
                    {
                        // Laat bullet bewegen
                        Rect bulletRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        Canvas.SetLeft(x, Canvas.GetLeft(x) - bulletSpeedPlayer2);

                        // Logica om te kijken of Projectile van player 2, player 1 hit
                        Rect player1Rect = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
                        if (bulletRect.IntersectsWith(player1Rect))
                        {
                            hitpointsPlayer1 -= damagePlayer2;
                            Player1HitPoints.Content = $"Player 1: {hitpointsPlayer1} HP";
                            itemsToRemove.Add(x);
                        }
                    }

                    // Code voor healthboosts
                    if (x.Tag.ToString() == "HealthBoostPlayer1")
                    {
                        Rect player1Rect = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
                        Rect healthPowerUpRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        if (healthPowerUpRect.IntersectsWith(player1Rect))
                        {
                            hitpointsPlayer1 += healthPowerUp;
                            Player1HitPoints.Content = $"Player 1: {hitpointsPlayer1} HP";
                            itemsToRemove.Add(x);
                        }
                    }

                    if (x.Tag.ToString() == "HealthBoostPlayer2")
                    {
                        Rect player2Rect = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);
                        Rect healthPowerUpRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        if (healthPowerUpRect.IntersectsWith(player2Rect))
                        {
                            hitpointsPlayer2 += healthPowerUp;
                            Player2HitPoints.Content = $"Player 2: {hitpointsPlayer2} HP";
                            itemsToRemove.Add(x);
                        }
                    }

                    // Code voor DamageInscrease PowerUp
                    if (x.Tag.ToString() == "DamageIncreasePlayer1")
                    {
                        Rect player1Rect = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);
                        Rect damageIncreasePowerUpRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        if (damageIncreasePowerUpRect.IntersectsWith(player1Rect))
                        {
                            hasPowerUpPlayer1 = true;
                            currentPowerUpPlayer1 = "DamageIncrease";
                            damagePlayer1 += damageIncreasePowerUp;
                            Player1Damage.Content = $"Player 1: {damagePlayer1} damage";
                            itemsToRemove.Add(x);
                        }
                    }

                    if (x.Tag.ToString() == "DamageIncreasePlayer2")
                    {
                        Rect player2Rect = new Rect(Canvas.GetLeft(Player2), Canvas.GetTop(Player2), Player2.Width, Player2.Height);
                        Rect damageIncreasePowerUpRect = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                        if (damageIncreasePowerUpRect.IntersectsWith(player2Rect))
                        {
                            hasPowerUpPlayer2 = true;
                            currentPowerUpPlayer2 = "DamageIncrease";
                            damagePlayer2 += damageIncreasePowerUp;
                            Player2Damage.Content = $"Player 2: {damagePlayer2} damage";
                            itemsToRemove.Add(x);
                        }
                    }
                }
            }

            // Checken of een speler dood is 
            if (hitpointsPlayer1 <= 0)
            {
                EndGame("Player 2");
            }
            if (hitpointsPlayer2 <= 0)
            {
                EndGame("Player 1");
            }

            // Logica voor random PowerUp Spawn
            int goalNumber = 500;
            int randomNumber = random.Next(0, ticksBetweenPowerUpSpawns);
            if (randomNumber == goalNumber) 
            {
                SpawnPowerUp(powerUps, GameCanvas);
            }



            // Check of een speler een power up heeft, zo ja elke tick + 1 doen.
            if (hasPowerUpPlayer1) 
            {
                powerUpTimerPlayer1++;
            }
            if (hasPowerUpPlayer2)
            {
                powerUpTimerPlayer2++;
            }
           

            // Check of poweruptimer bij max tijd van powerup komt
            if (powerUpTimerPlayer1 >= powerUpDurationInTicks)
            {
                hasPowerUpPlayer1 = false;
                powerUpTimerPlayer1 = 0;
                if (currentPowerUpPlayer1 == "DamageIncrease")
                {
                    damagePlayer1 -= damageIncreasePowerUp;
                    Player1Damage.Content = $"Player 1: {damagePlayer1} damage";
                    currentPowerUpPlayer1 = "nothing";
                }
            }

            if (powerUpTimerPlayer2 >= powerUpDurationInTicks)
            {
                hasPowerUpPlayer2 = false;
                powerUpTimerPlayer2 = 0;
                if (currentPowerUpPlayer2 == "DamageIncrease")
                {
                    damagePlayer2 -= damageIncreasePowerUp;
                    Player2Damage.Content = $"Player 2: {damagePlayer2} damage";
                    currentPowerUpPlayer2 = "nothing";
                }
            }


            // Verwijderen van de bullets in de list
            foreach (var item in itemsToRemove)
            {
                GameCanvas.Children.Remove(item);
            }

            // Het schieten van de projectiles
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

            // Tijdelijk voor testen
            if (e.Key == Key.P) SpawnPowerUp(powerUps, GameCanvas);

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
                Height = 50,
                Width = 50,
            };

            
            if (playerName == "Player1")
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Image/Kettlebell4kgPl1.png", UriKind.Absolute));
                newProjectile.Fill = imageBrush;
                Canvas.SetTop(newProjectile, Canvas.GetTop(player) + player.Height - newProjectile.Height); // dit zodat het lijkt alsof er met rechts gegooid wordt
                Canvas.SetLeft(newProjectile, Canvas.GetLeft(player) + player.Width);
                newProjectile.Tag = "ProjectileRight";  // beweegt naar rechts

            }
            else if (playerName == "Player2")
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Image/Kettlebell4kgPl2.png", UriKind.Absolute));
                newProjectile.Fill = imageBrush;
                Canvas.SetTop(newProjectile, Canvas.GetTop(player));
                Canvas.SetLeft(newProjectile, Canvas.GetLeft(player) - newProjectile.Width);
                newProjectile.Tag = "ProjectileLeft";   // beweegt naar links
            }

            gameCanvas.Children.Add(newProjectile);
        }


        public void EndGame(string winnerName)
        {
            if (!gameIsOver)
            {
                gameIsOver = true;
                NavigateToPostgamescherm(winnerName);
            }
        }


        private void NavigateToPostgamescherm(string winnerName)
        {
            // Postgamescherm postGameScherm = new Postgamescherm(winnerName);
            // postGameScherm.Show();
            this.Close();
        }


        private void SpawnPowerUp(List<string> powerUps, Canvas gameCanvas)
        {
            string powerUpPlayer1 = powerUps[random.Next(0, powerUps.Count)]; 
            string powerUpPlayer2 = powerUps[random.Next(0, powerUps.Count)];

            // HealthBoost Powerup
            if (powerUpPlayer1 == "HealthBoost")
            {
                Rectangle newPowerUp = new Rectangle
                {
                    Height = 30,
                    Width = 30,
                    Fill = Brushes.Red,
                    Stroke = Brushes.White,
                    Tag = "HealthBoostPlayer1"
                };
                Canvas.SetTop(newPowerUp, random.Next(0, 880));
                Canvas.SetLeft(newPowerUp, random.Next(0, 930));
                gameCanvas.Children.Add(newPowerUp);

            }

            if (powerUpPlayer2 == "HealthBoost")
            {
                Rectangle newPowerUp = new Rectangle
                {
                    Height = 30,
                    Width = 30,
                    Fill = Brushes.Red,
                    Stroke = Brushes.White,
                    Tag = "HealthBoostPlayer2"
                };
                Canvas.SetTop(newPowerUp, random.Next(0, 880));
                Canvas.SetLeft(newPowerUp, random.Next(960, 1890));
                gameCanvas.Children.Add(newPowerUp);

            }

            // DamageIncrease Powerup
            if (powerUpPlayer1 == "DamageIncrease")
            {
                Rectangle newPowerUp = new Rectangle
                {
                    Height = 30,
                    Width = 30,
                    Fill = Brushes.Gold,
                    Stroke = Brushes.White,
                    Tag = "DamageIncreasePlayer1"
                };
                Canvas.SetTop(newPowerUp, random.Next(0, 880));
                Canvas.SetLeft(newPowerUp, random.Next(0, 930));
                gameCanvas.Children.Add(newPowerUp);
            }

            if (powerUpPlayer2 == "DamageIncrease")
            {
                Rectangle newPowerUp = new Rectangle
                {
                    Height = 30,
                    Width = 30,
                    Fill = Brushes.Gold,
                    Stroke = Brushes.White,
                    Tag = "DamageIncreasePlayer2"
                };
                Canvas.SetTop(newPowerUp, random.Next(0, 880));
                Canvas.SetLeft(newPowerUp, random.Next(960, 1890));
                gameCanvas.Children.Add(newPowerUp);
            }
        }
    }
}
