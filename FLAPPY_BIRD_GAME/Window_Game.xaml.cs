using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace FLAPPY_BIRD_GAME // Created by: Joshua C. Magoliman
{
    /// <summary>
    /// Interaction logic for Window_Game.xaml
    /// </summary>
    public partial class Window_Game : Window
    {
        #region Fields  
        public static bool isUserChoosen;
        private DispatcherTimer timerGameStart = new DispatcherTimer();
        private DispatcherTimer timerGameOver = new DispatcherTimer();
        private double score;
        private int gravity;
        private int countTheCollidedSoundEffectPlayed;
        private bool isBirdCollidedWithPipeBox;
        private bool isCollidedSoundEffectPlaying;
        private string dateToday;
        private Rect rectangle;
        #endregion

        #region Constructor  
        public Window_Game()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            timerGameStart.Tick += timerGameStart_Tick;
            timerGameStart.Interval = TimeSpan.FromMilliseconds(20);
            timerGameOver.Tick += timerGameOver_Tick;
            timerGameOver.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }
        #endregion

        #region Event Handler Methods
        private void timerGameStart_Tick(object sender, EventArgs e)
        {
            dateToday = DateTime.Now.ToString("MM/dd/yyyy");
            lblScore.Content = "Score: " + Top10Only.AddingCommasInScore(Convert.ToString(score));
            // Creating new object called rectangle and re assign the value of new location.
            rectangle = new Rect(Canvas.GetLeft(imgFlappyBird), Canvas.GetTop(imgFlappyBird), imgFlappyBird.Width - 5, imgFlappyBird.Height);
            // Set the top value of the bird.       
            Canvas.SetTop(imgFlappyBird, Canvas.GetTop(imgFlappyBird) + gravity);
            // If the bird is fallen down or overfly.
            if (Canvas.GetTop(imgFlappyBird) < -10 || Canvas.GetTop(imgFlappyBird) > 458)
            {
                GameOver(); // Invoke this user defined method.
            }
            // If the fields called isBirdCollidedWithPipeBox and isCollidedSoundEffectPlaying are both true.
            if (isBirdCollidedWithPipeBox == true && isCollidedSoundEffectPlaying == true)
            {
                // If the field called countTheCollidedSoundEffectPlayed is less than or equal to 2.
                if (countTheCollidedSoundEffectPlayed <= 2)
                {
                    PlayCollidedAudio(); // Invoke this user defined method.
                    isCollidedSoundEffectPlaying = false; // Re assign the value of field called isCollidedSoundEffectPlaying.
                    countTheCollidedSoundEffectPlayed++; // Increment the value of field called countTheCollidedSoundEffectPlayed by 1.
                }
            }
            // Using the foreach loop to control every image in the Canvas.
            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                // Check if there are image that have a tag name of "obs1" or "obs2" or "obs3". 
                if ((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    // Set a new location to the Canvas.
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
                    // If the image of Canvas is less than to -100.
                    if (Canvas.GetLeft(x) < -100)
                    {
                        // Set a new location to the Canvas.
                        Canvas.SetLeft(x, 800);
                        // If the value of the field called isBirdCollidedWithPipeBox is false.
                        if (isBirdCollidedWithPipeBox == false)
                        {
                            score += .5; // Re assign the value of this field called score.
                            CheckIfAudioMutedOrNot("scored.wav"); // Invoke this user defined method.
                        }
                    }
                    // Create new object called rectPipe using the structure called Rect.
                    Rect rectPipe = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    // If object called rectangle (the bird) collided of object called rectPipe. 
                    if (rectangle.IntersectsWith(rectPipe))
                    {
                        isBirdCollidedWithPipeBox = true; // Re assign the value of this field.
                        isCollidedSoundEffectPlaying = true; // Re assign the value of this field.
                        MakeBirdFallingDown(); // Invoke this user defined method.
                    }
                }
                // Check if there are image that have a tag name of "cloud".
                if ((string)x.Tag == "cloud")
                {
                    // Set a new location to the Canvas.
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 2);
                    // If the left location of a image is less than -250.
                    if (Canvas.GetLeft(x) < -250)
                    {
                        Canvas.SetLeft(x, 550); // Set a new location.
                    }
                }
            }
        }
        private void timerGameOver_Tick(object sender, EventArgs e)
        {
            if (isUserChoosen == true)
            {
                this.Visibility = Visibility.Collapsed;
                timerGameOver.Stop();
                isUserChoosen = false;
            }
        }
        // The user is keep pressing.
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // If the user press space and the value of field called isBirdCollidedWithPipeBox is equal to false.
            if (e.Key == Key.Space && isBirdCollidedWithPipeBox == false)
            {
                imgFlappyBird.RenderTransform = new RotateTransform(-20, imgFlappyBird.Width / 2, imgFlappyBird.Height / 2);
                gravity = -8;
            }
        }
        // The user releases the touch.
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            MakeBirdFallingDown();
        }
        // This window is closing.
        private void OnClosing(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region User Defined Methods
        private void StartGame()
        {
            MyCanvas.Focus();
            int tempo = 300;
            score = 0;
            gravity = 8;
            isBirdCollidedWithPipeBox = false;
            isCollidedSoundEffectPlaying = false;
            countTheCollidedSoundEffectPlayed = 0;
            // Set new location of the image called imgFlappyBird.
            Canvas.SetTop(imgFlappyBird, 190);
            // Using the foreach loop to control every image in the Canvas.
            foreach (var x in MyCanvas.Children.OfType<Image>())
            {
                // If the image have a tag name of "obs1".
                if ((string)x.Tag == "obs1")
                {
                    // Set a new location of the image.
                    Canvas.SetLeft(x, 500);
                }
                // If the image have a tag name of "obs2".
                if ((string)x.Tag == "obs2")
                {
                    // Set a new location of the image.
                    Canvas.SetLeft(x, 800);
                }
                // If the image have a tag name of "obs3".
                if ((string)x.Tag == "obs3")
                {
                    // Set a new location of the image.
                    Canvas.SetLeft(x, 1100);
                }
                // If the image have a tag name of "cloud".
                if ((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, 300 + tempo); // Set a new location of the image.
                    tempo = 800; // Re assign the value of this field called tempo.
                }
            }
            timerGameStart.Start();
            dateToday = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void GameOver()
        {
            timerGameStart.Stop();
            PlayCollidedAudio();
            timerGameOver.Start();
            PlayGameOverAudio();
            Top10Only.CheckResultInTop10Only(dateToday, Convert.ToInt32(score));
            Window_DialogBox nextWindow = new Window_DialogBox();
            nextWindow.ShowDialog();
        }
        private void CheckIfAudioMutedOrNot(string param_NameOfWavFile)
        {
            if (Window_Introduction.isAudioOn == true)
            {
                CustomAudio customAudio = new CustomAudio(param_NameOfWavFile);
                customAudio.Play(false);
            }
        }
        private void MakeBirdFallingDown()
        {
            imgFlappyBird.RenderTransform = new RotateTransform(5, imgFlappyBird.Width / 2, imgFlappyBird.Height / 2);
            if (isBirdCollidedWithPipeBox == true)
            {
                gravity = 17;
            }
            else
            {
                gravity = 8;
                CheckIfAudioMutedOrNot("moved.wav");
            }
        }
        private void PlayGameOverAudio()
        {
            CheckIfAudioMutedOrNot("gameover.wav");
        }
        private void PlayCollidedAudio()
        {
            CheckIfAudioMutedOrNot("collided.wav");
            isCollidedSoundEffectPlaying = false;
        }
        #endregion
    }
}
