using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;

namespace negras_vergas
{
    public partial class nigger : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public nigger()
        {
            InitializeComponent();
        }
        bool nigger1 = false;
        private async void Form1_LoadAsync(object help, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] {"close", "exit", "stop","fortnite", "midget", "reddit", "niger", "nigga", "nigger" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            using (var soundPlayer = new SoundPlayer(@"voice lines\sv bicas.wav"))
            {
                soundPlayer.Play();
            }
        }
        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.ToLower() == "close" || e.Result.Text.ToLower() == "stop" || e.Result.Text.ToLower() == "exit" && nigger1 == true)
            {
                using (var soundPlayer = new SoundPlayer(@"voice lines\dw.wav"))
                {
                    soundPlayer.Play();
                }
                Thread.Sleep(2000);
                Application.Exit();
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "fortnite" && nigger1 == true)
            {
                System.Diagnostics.Process.Start("https://www.twitch.tv/directory/game/Fortnite");
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "midget" && nigger1 == true)
            {
                if (pictureBox1.Size.Height == 200)
                    pictureBox1.Invoke(new Action(() => pictureBox1.Size = new Size(810, 750)));
                else
                    pictureBox1.Invoke(new Action(() => pictureBox1.Size = new Size(1200, 200)));

                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "reddit" && nigger1 == true)
            {
                Console.Beep(500, 500);
                reddit f2 = new reddit();
                f2.ShowDialog();
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "nigger" || e.Result.Text.ToLower() == "niger" || e.Result.Text.ToLower() == "nigga")
            {
                nigger1 = true;
                using (var soundPlayer = new SoundPlayer(@"voice lines\ko nori.wav"))
                {
                    soundPlayer.Play();
                }
            }
        }
        private bool mouseDown;
        private Point lastLocation;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
