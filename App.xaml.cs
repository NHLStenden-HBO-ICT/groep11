using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;



namespace Game_interaction
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// /// test 2
    public partial class App : Application
    {
        private readonly MediaPlayer mediaPlayer = new MediaPlayer();

        public App()
        {
            StartBackgroundMusic();
        }

        private void StartBackgroundMusic()
        {
            mediaPlayer.Open(new Uri(@"pack://siteoforigin:,,,/Audio/TitleTheme.mp3"));
            mediaPlayer.MediaOpened += (s, e) => Debug.WriteLine("Media opened successfully");
            mediaPlayer.MediaFailed += (s, e) => Debug.WriteLine($"Media failed: {e.ErrorException.Message}");
            mediaPlayer.Volume = 1.0;
            mediaPlayer.MediaEnded += (s, e) =>
            {
                mediaPlayer.Position = TimeSpan.Zero;
                mediaPlayer.Play();
            };
            mediaPlayer.Play();
        }
    }
}
