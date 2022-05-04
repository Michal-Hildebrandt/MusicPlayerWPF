
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace MusicPlayerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MediaPlayer startTrack = new MediaPlayer();
        private ImageSource _GifImage;
        public ImageSource GifImage
        {
            get
            {
                return _GifImage;
            }
            set
            {
                _GifImage = value;
                OnPropertyChanged("GifImage");
            }
        }
        public MainWindow()
        {
            InitializeComponent();

        }
      

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
            file.DefaultExt = ".mp3";
            file.Filter = "MP3 Files (*.mp3)|*.mp3|WAV files (*.wav)|.wav|FLAC files(*.flac)|*.flac";
            var result = file.ShowDialog();

            if (result == true)
            {
                startTrack.Open(new Uri(file.FileName));
                startTrack.Play();
                WelcomeText.Text = String.Empty;
                About.Text = String.Empty;
                Description.Text = String.Empty;

                GifImage = ShowAnimation("pepedance.gif");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public static BitmapImage ShowAnimation(string location)
        {
          
            BitmapImage gif = null;
            try
            {
                Uri gifUri = new Uri($"pack://application:,,,/MusicPlayerWPF/Icons/" + location, UriKind.RelativeOrAbsolute);
                gif = new BitmapImage(gifUri);
            }
            catch (Exception ex)
            {

            }
            return gif;
        }

    private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {

        }

  
    private void LibraryButton_Click(object sender, RoutedEventArgs e)
    {

    }
    }
}
