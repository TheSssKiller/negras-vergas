using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;
using System.IO;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Reflection;

namespace negras_vergas
{
    public partial class nigger : Form
    {
        private CommandService _commands;
        private DiscordSocketClient _client;
        private IServiceProvider _services;
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
            if (midget == true)
            {
                niggerbox.Size = new Size(1200, 200);
                ClientSize = new Size(ClientSize.Width + 390, ClientSize.Height);
            }
            Choices commands = new Choices();
            commands.Add(new string[] { "close", "fortnite", "midget", "reddit", "niger", "nigga", "nigger", "upgrade", "downgrade", "calculator", "white", "black", "female", "male", "woman", "man", "bot" });
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
        async void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text.ToLower() == "close" && nigger1 == true)
            {
                AudioService _service = AudioModule.service1;
                using (var soundPlayer = new SoundPlayer(@"voice lines\dw.wav"))
                {
                    soundPlayer.Play();
                }
                if (AudioModule.discordbot == true)
                {
                    _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/dw.wav");
                }
                await _service.LeaveAudio(AudioModule.contextguild);
                Thread.Sleep(2000);
                Application.Exit();
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "fortnite" && nigger1 == true)
            {
                System.Diagnostics.Process.Start("https://www.twitch.tv/directory/game/Fortnite");
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnyt.wav"))
                {
                    soundPlayer.Play();
                }
                using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/fortnyt.wav");
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/fortnite.wav");
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
                save(white, asian, female, midget);
                using (var soundPlayer = new SoundPlayer(@"voice lines\midget.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/midget.wav");
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "upgrade" && nigger1 == true)
            {
                niggerbox.Image = Properties.Resources.bien;
                using (var soundPlayer = new SoundPlayer(@"voice lines\didelis bienis.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/didelis bienis.wav");
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
                save(white, asian, female, midget);
                using (var soundPlayer = new SoundPlayer(@"voice lines\white power.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/white power.wav");
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "woman" && nigger1 == true || e.Result.Text.ToLower() == "female" && nigger1 == true)
            {
                if (white == true)
                    niggerbox.Image = Properties.Resources.whitewoman;
                else if (asian == true)
                    niggerbox.Image = Properties.Resources.asianwoman;
                else
                    niggerbox.Image = Properties.Resources.blackwoman;
                female = true;
                save(white, asian, female, midget);
                using (var soundPlayer = new SoundPlayer(@"voice lines\as buoteris.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/as buoteris.wav");
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "man" && nigger1 == true || e.Result.Text.ToLower() == "male" && nigger1 == true)
            {
                if (white == true)
                    niggerbox.Image = Properties.Resources.whitenegro;
                else if (asian == true)
                    niggerbox.Image = Properties.Resources.asiannegro;
                else
                    niggerbox.Image = Properties.Resources.negro;
                female = false;
                save(white, asian, female, midget);
                using (var soundPlayer = new SoundPlayer(@"voice lines\as vyras.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/as vyras.wav");
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
                save(white, asian, female, midget);
                using (var soundPlayer = new SoundPlayer(@"voice lines\bepis.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/bepis.wav");
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "downgrade" && nigger1 == true)
            {
                if (asian == true)
                    niggerbox.Image = Properties.Resources.asiannegro;
                else if (white == true)
                    niggerbox.Image = Properties.Resources.whitenegro;
                else
                    niggerbox.Image = Properties.Resources.negro;
                using (var soundPlayer = new SoundPlayer(@"voice lines\blet.wav"))
                {
                    soundPlayer.Play();
                }
                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/blet.wav");
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
                save(white, asian, female, midget);
                using (var soundPlayer = new SoundPlayer(@"voice lines\ching chong.wav"))
                {
                    soundPlayer.Play();
                }

                if (AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/ching chong.wav");
                }
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "reddit" && nigger1 == true)
            {
                using (var soundPlayer = new SoundPlayer(@"voice lines\reddit.wav"))
                {
                    soundPlayer.Play();
                }
                reddit f2 = new reddit();
                f2.ShowDialog();
                nigger1 = false;
            }
            else if (e.Result.Text.ToLower() == "bot" && nigger1 == true)
            {
                nigger1 = false;
                string token;
                _client = new DiscordSocketClient();
                _commands = new CommandService();
                token = "NTE5MDQyODEzNDU2MDIzNTUy.DurzoA.FDLCHjVjsWY0LEJIpq6lArv6C0U";
                _services = new ServiceCollection()
                    .AddSingleton(_client)
                    .AddSingleton(_commands)
                    .AddSingleton(new AudioService())
                    .BuildServiceProvider();
                await InstallCommandsAsync();

                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();

                _client.Log += Log;
                _commands.Log += Log;

                await Task.Delay(-1);
            }
            else if (e.Result.Text.ToLower() == "nigger" || e.Result.Text.ToLower() == "niger" || e.Result.Text.ToLower() == "nigga")
            {
                nigger1 = true;
                using (var soundPlayer = new SoundPlayer(@"voice lines\ko nori.wav"))
                {
                    soundPlayer.Play();
                }
                if(AudioModule.discordbot == true)
                {
                    AudioService _service = AudioModule.service1;
                    await _service.SendAudioAsync(AudioModule.contextguild, AudioModule.contextchannel, "voice lines/ko nori.wav");
                }
            }
        }
        public async Task InstallCommandsAsync()
        {

            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {

            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            int argPos = 0;

            if (!(message.HasCharPrefix('~', ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;

            var context = new SocketCommandContext(_client, message);

            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
                await context.Channel.SendMessageAsync(result.ErrorReason);
        }
        private Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
        private bool mouseDown;
        private Point lastLocation;
        static void save(bool white, bool asian, bool female, bool midget)
        {
            string stringtowrite = "";
            if (white == true)
                stringtowrite = stringtowrite + "white = true\n";
            else
                stringtowrite = stringtowrite + "white = fals\n";
            if (asian == true)
                stringtowrite = stringtowrite + "asian = true\n";
            else
                stringtowrite = stringtowrite + "asian = fals\n";
            if (female == true)
                stringtowrite = stringtowrite + "female = true\n";
            else
                stringtowrite = stringtowrite + "female = fals\n";
            if (midget == true)
                stringtowrite = stringtowrite + "midget = true";
            else
                stringtowrite = stringtowrite + "midget = fals";
            File.WriteAllText("settings", stringtowrite);
        }
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
