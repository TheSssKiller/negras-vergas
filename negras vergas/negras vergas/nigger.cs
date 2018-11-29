using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;
using System.IO;

namespace negras_vergas
{
    public partial class nigger : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public nigger()
        {
            InitializeComponent();
        }
        bool white = false;
        bool asian = false;
        bool female = false;
        bool midget = false;
        bool nigger1 = false;
        private async void Form1_LoadAsync(object help, EventArgs e)
        {
            string settings;
            try
            {
                settings = File.ReadAllText("settings");
            }
            catch
            {
                File.WriteAllText("settings", "white = fals\nasian = fals\nfemale = fals\nmidget = fals");
                settings = File.ReadAllText("settings");
            }
            if (settings.Substring(settings.IndexOf("white") + 8, 4) == "true")
                white = true;
            else if (settings.Substring(settings.IndexOf("asian") + 8, 4) == "true")
                asian = true;
            if (settings.Substring(settings.IndexOf("female") + 9, 4) == "true")
                female = true;
            if (settings.Substring(settings.IndexOf("midget") + 9, 4) == "true")
                midget = true;
            if (white == true && female == true)
                niggerbox.Image = Properties.Resources.whitewoman;
            else if (white == true && female == false)
                niggerbox.Image = Properties.Resources.whitenegro;
            else if (asian == true && female == true)
                niggerbox.Image = Properties.Resources.asianwoman;
            else if (asian == true && female == false)
                niggerbox.Image = Properties.Resources.asiannegro;
            else if (female == true)
                niggerbox.Image = Properties.Resources.blackwoman;
            else
                niggerbox.Image = Properties.Resources.negro;
            if(midget == true)
            {
                niggerbox.Size = new Size(1200, 200);
                ClientSize = new Size(ClientSize.Width + 390, ClientSize.Height);
            }
            Choices commands = new Choices();
            commands.Add(new string[] {"close","fortnite", "midget", "reddit", "niger", "nigga", "nigger", "upgrade", "downgrade", "calculator", "white", "black", "female", "male","woman", "man" });
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
            if (e.Result.Text.ToLower() == "close" && nigger1 == true)
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
                if (niggerbox.Size.Height == 200)
                {
                    niggerbox.Invoke(new Action(() => niggerbox.Size = new Size(810, 750)));
                    ClientSize = new Size(ClientSize.Width - 390, ClientSize.Height);
                    midget = false;
                }
                else
                {
                    niggerbox.Invoke(new Action(() => niggerbox.Size = new Size(1200, 200)));
                    ClientSize = new Size(ClientSize.Width + 390, ClientSize.Height);
                    midget = true;
                }
                string stringtowrite = "";
                if (white == true)
                    stringtowrite = stringtowrite + "white = true\n";
                else
                    stringtowrite = stringtowrite + "white = fals\n";
                if (asian == true)
                    stringtowrite = stringtowrite + "asian = true\n";
                else
                    stringtowrite = stringtowrite + "asian = false\n";
                if (female == true)
                    stringtowrite = stringtowrite + "female = true\n";
                else
                    stringtowrite = stringtowrite + "female = fals\n";
                if (midget == true)
                    stringtowrite = stringtowrite + "midget = true";
                else
                    stringtowrite = stringtowrite + "midget = false";
                File.WriteAllText("settings", stringtowrite);
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "upgrade" && nigger1 == true)
            {
                niggerbox.Image = Properties.Resources.bien;
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "white" && nigger1 == true)
            {
                if (female == false)
                    niggerbox.Image = Properties.Resources.whitenegro;
                else
                    niggerbox.Image = Properties.Resources.whitewoman;
                white = true;
                asian = false;
                string stringtowrite = "";
                if (white == true)
                    stringtowrite = stringtowrite + "white = true\n";
                else
                    stringtowrite = stringtowrite + "white = fals\n";
                if (asian == true)
                    stringtowrite = stringtowrite + "asian = true\n";
                else
                    stringtowrite = stringtowrite + "asian = false\n";
                if (female == true)
                    stringtowrite = stringtowrite + "female = true\n";
                else
                    stringtowrite = stringtowrite + "female = fals\n";
                if (midget == true)
                    stringtowrite = stringtowrite + "midget = true";
                else
                    stringtowrite = stringtowrite + "midget = false";
                File.WriteAllText("settings", stringtowrite);
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "woman" || e.Result.Text.ToLower() == "female" && nigger1 == true)
            {
                if (white == true)
                    niggerbox.Image = Properties.Resources.whitewoman;
                else if (asian == true)
                    niggerbox.Image = Properties.Resources.asianwoman;
                else
                    niggerbox.Image = Properties.Resources.blackwoman;
                female = true;
                string stringtowrite = "";
                if (white == true)
                    stringtowrite = stringtowrite + "white = true\n";
                else
                    stringtowrite = stringtowrite + "white = fals\n";
                if (asian == true)
                    stringtowrite = stringtowrite + "asian = true\n";
                else
                    stringtowrite = stringtowrite + "asian = false\n";
                if (female == true)
                    stringtowrite = stringtowrite + "female = true\n";
                else
                    stringtowrite = stringtowrite + "female = fals\n";
                if (midget == true)
                    stringtowrite = stringtowrite + "midget = true";
                else
                    stringtowrite = stringtowrite + "midget = false";
                File.WriteAllText("settings", stringtowrite);
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "man" || e.Result.Text.ToLower() == "male" && nigger1 == true)
            {
                if (white == true)
                    niggerbox.Image = Properties.Resources.whitenegro;
                else if (asian == true)
                    niggerbox.Image = Properties.Resources.asiannegro;
                else
                    niggerbox.Image = Properties.Resources.negro;
                female = false;
                string stringtowrite = "";
                if (white == true)
                    stringtowrite = stringtowrite + "white = true\n";
                else
                    stringtowrite = stringtowrite + "white = fals\n";
                if (asian == true)
                    stringtowrite = stringtowrite + "asian = true\n";
                else
                    stringtowrite = stringtowrite + "asian = false\n";
                if (female == true)
                    stringtowrite = stringtowrite + "female = true\n";
                else
                    stringtowrite = stringtowrite + "female = fals\n";
                if (midget == true)
                    stringtowrite = stringtowrite + "midget = true";
                else
                    stringtowrite = stringtowrite + "midget = false";
                File.WriteAllText("settings", stringtowrite);
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "black" && nigger1 == true)
            {
                if (female == false)
                    niggerbox.Image = Properties.Resources.negro;
                else
                    niggerbox.Image = Properties.Resources.blackwoman;
                white = false;
                asian = false;
                string stringtowrite = "";
                if (white == true)
                    stringtowrite = stringtowrite + "white = true\n";
                else
                    stringtowrite = stringtowrite + "white = fals\n";
                if (asian == true)
                    stringtowrite = stringtowrite + "asian = true\n";
                else
                    stringtowrite = stringtowrite + "asian = false\n";
                if (female == true)
                    stringtowrite = stringtowrite + "female = true\n";
                else
                    stringtowrite = stringtowrite + "female = fals\n";
                if (midget == true)
                    stringtowrite = stringtowrite + "midget = true";
                else
                    stringtowrite = stringtowrite + "midget = false";
                File.WriteAllText("settings", stringtowrite);
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "downgrade" && nigger1 == true)
            {
                if(asian == true)
                    niggerbox.Image = Properties.Resources.asiannegro;
                else if(white == true)
                    niggerbox.Image = Properties.Resources.whitenegro;
                else
                    niggerbox.Image = Properties.Resources.negro;
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "calculator" && nigger1 == true)
            {
                if (female == false)
                    niggerbox.Image = Properties.Resources.asiannegro;
                else
                    niggerbox.Image = Properties.Resources.asianwoman;
                asian = true;
                white = false;
                string stringtowrite = "";
                if (white == true)
                    stringtowrite = stringtowrite + "white = true\n";
                else
                    stringtowrite = stringtowrite + "white = fals\n";
                if (asian == true)
                    stringtowrite = stringtowrite + "asian = true\n";
                else
                    stringtowrite = stringtowrite + "asian = false\n";
                if (female == true)
                    stringtowrite = stringtowrite + "female = true\n";
                else
                    stringtowrite = stringtowrite + "female = fals\n";
                if (midget == true)
                    stringtowrite = stringtowrite + "midget = true";
                else
                    stringtowrite = stringtowrite + "midget = false";
                File.WriteAllText("settings", stringtowrite);
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

        private void niggerbox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void niggerbox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void niggerbox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
