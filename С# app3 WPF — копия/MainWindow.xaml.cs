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

namespace С__app3_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShuffleButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            isShuffleMode = !isShuffleMode;
            await UpdateShuffleButtonAsync();
        }

        private void SelectFolderButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Audio files (*.mp3;*.wav;*.m4a)|*.mp3;*.wav;*.m4a|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                playlist.Clear();
                foreach (string fileName in openFileDialog.FileNames)
                {
                    playlist.Add(fileName);
                }
                await PlayTrackAsync(playlist.First());
            }
        }

        private void RepeatButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            isRepeatMode = !isRepeatMode;
            await UpdateRepeatButtonAsync();
        }

        private void PreviousTrackButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            await PlayPreviousTrackAsync();
        }

        private void NextTrackButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            await PlayNextTrackAsync();
        }

        private void PlayPauseButton_Click(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            if (isPlaying)
            {
                mediaPlayer.Pause();
                isPlaying = false;
            }
            else
            {
                mediaPlayer.Play();
                isPlaying = true;
            }
            await UpdatePlayPauseButtonAsync();
        }

        public partial class MainWindow : Window
        {
            private MediaPlayer mediaPlayer = new MediaPlayer();
            private List<string> playlist = new List<string>();
            private int currentTrackIndex = 0;
            private bool isPlaying = false;
            private bool isShuffleMode = false;
            private bool isRepeatMode = false;
            private CancellationTokenSource cancellationTokenSource;
            private DispatcherTimer positionTimer = new DispatcherTimer();
            private DispatcherTimer timeRemainingTimer = new DispatcherTimer();

            public MainWindow()
            {
                InitializeComponent();
                mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
                positionTimer.Tick += PositionTimer_Tick;
                timeRemainingTimer.Tick += TimeRemainingTimer_Tick;
                timeRemainingTimer.Interval = TimeSpan.FromSeconds(1);
                positionTimer.Interval = TimeSpan.FromSeconds(1);
            }

            private async Task PlayTrackAsync(string fileName)
            {
                mediaPlayer.Open(new Uri(fileName));
                mediaPlayer.Play();
                isPlaying = true;
                await UpdatePlayPauseButtonAsync();
                UpdateTrackInfo();
                StartPositionTimer();
                AddToHistory(fileName);
            }

            private void MediaPlayer_MediaEnded(object sender, EventArgs e)
            {
                StopPositionTimer();
                if (isRepeatMode)
                {
                    mediaPlayer.Position = TimeSpan.Zero;
                    mediaPlayer.Play();
                    StartPositionTimer();
                }
                else
                {
                    PlayNextTrack();
                }
            }

            private async Task PlayNextTrackAsync()
            {
                StopPositionTimer();
                if (isShuffleMode)
                {
                    Random random = new Random();
                    currentTrackIndex = random.Next(playlist.Count);
                }
                else
                {
                    currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
                }
                await PlayTrackAsync(playlist[currentTrackIndex]);
            }

            private async Task PlayPreviousTrackAsync()
            {
                StopPositionTimer();
                currentTrackIndex = currentTrackIndex == 0 ? playlist.Count - 1 : currentTrackIndex - 1;
                await PlayTrackAsync(playlist[currentTrackIndex]);
            }

            private void StartPositionTimer()
            {
                positionTimer.Start();
            }

            private void StopPositionTimer()
            {
                positionTimer.Stop();
            }

            private void PositionTimer_Tick(object sender, EventArgs e)
            {
                positionSlider.Value = mediaPlayer.Position.TotalSeconds;
            }

            private void TimeRemainingTimer_Tick(object sender, EventArgs e)
            {
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    timeRemainingTextBlock.Text = $"{mediaPlayer.NaturalDuration.TimeSpan.Subtract(mediaPlayer.Position)}";
                }
            }

            private async Task UpdatePlayPauseButtonAsync()
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    if (isPlaying)
                        playPauseButton.Content = "Pause";
                    else
                        playPauseButton.Content = "Play";
                });
            }

            private async Task UpdateRepeatButtonAsync()
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    if (isRepeatMode)
                        repeatButton.Background = Brushes.LightBlue;
                    else
                        repeatButton.Background = Brushes.Transparent;
                });
            }

            private async Task UpdateShuffleButtonAsync()
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    if (isShuffleMode)
                        shuffleButton.Background = Brushes.LightBlue;
                    else
                        shuffleButton.Background = Brushes.Transparent;
                });
            }

            private void UpdateTrackInfo()
            {
                trackInfoTextBlock.Text = $"Playing: {Path.GetFileName(playlist[currentTrackIndex])}";
                positionSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                positionSlider.Value = 0;
                timeRemainingTextBlock.Text = $"{mediaPlayer.NaturalDuration.TimeSpan}";
            }

            private void AddToHistory(string fileName)
            {
                historyListBox.Items.Insert(0, fileName);
            }

            private void PlayNextTrack()
            {
                currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
                mediaPlayer.Open(new Uri(playlist[currentTrackIndex]));
                mediaPlayer.Play();
                UpdateTrackInfo();
                AddToHistory(playlist[currentTrackIndex]);
                StartPositionTimer();
            }
        }
    }
}
