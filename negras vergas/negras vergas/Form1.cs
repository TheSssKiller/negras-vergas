using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Speech.V1;
using NAudio;

namespace negras_vergas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static async Task<object> StreamingMicRecognizeAsync(int seconds)
        {
            bool nigger = false;
            while (true)
            {
                if (NAudio.Wave.WaveIn.DeviceCount < 1)
                {
                    //Console.WriteLine("No microphone!");
                    return -1;
                }
                var speech = SpeechClient.Create();
                var streamingCall = speech.StreamingRecognize();
                // Write the initial request with the config.
                await streamingCall.WriteAsync(
                    new StreamingRecognizeRequest()
                    {
                        StreamingConfig = new StreamingRecognitionConfig()
                        {
                            Config = new RecognitionConfig()
                            {
                                Encoding =
                                RecognitionConfig.Types.AudioEncoding.Linear16,
                                SampleRateHertz = 16000,
                                LanguageCode = "en",
                            },
                            InterimResults = true,
                        }
                    });
                // Print responses as they arrive.
                Task printResponses = Task.Run(async () =>
                {
                    while (await streamingCall.ResponseStream.MoveNext(
                        default(CancellationToken)))
                    {
                        foreach (var result in streamingCall.ResponseStream.Current.Results)
                        {
                            foreach (var alternative in result.Alternatives)
                            {
                                int indexof = streamingCall.ResponseStream.Current.Results[0].ToString().IndexOf("\"", 37);
                                if (streamingCall.ResponseStream.Current.Results[0].IsFinal)
                                {
                                    if (nigger == true && streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).IndexOf("type") >= 0)
                                    {
                                        SendKeys.SendWait(streamingCall.ResponseStream.Current.Results[0].ToString().Substring(streamingCall.ResponseStream.Current.Results[0].ToString().IndexOf("type") + 5, indexof - (streamingCall.ResponseStream.Current.Results[0].ToString().IndexOf("type")+5)).TrimStart(' '));
                                        Console.WriteLine(streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).TrimStart(' '));
                                        using (var soundPlayer = new SoundPlayer(@"voice lines\what.wav"))
                                        {
                                            soundPlayer.Play();
                                        }
                                        nigger = false;
                                    }
                                    else if (nigger == true && streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).IndexOf("close") >= 0 || streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).ToLower().IndexOf("exit") >= 0 || streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).ToLower().IndexOf("stop") >= 0)
                                    {
                                        using (var soundPlayer = new SoundPlayer(@"voice lines\dw.wav"))
                                        {
                                            soundPlayer.Play();
                                        }
                                        Application.Exit();
                                        nigger = false;
                                    }
                                    else if (nigger == true && streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).IndexOf("fortnite") >= 0)
                                    {
                                        System.Diagnostics.Process.Start("https://www.twitch.tv/directory/game/Fortnite");
                                        using (var soundPlayer = new SoundPlayer(@"voice lines\fortnite.wav"))
                                        {
                                            soundPlayer.Play();
                                        }
                                    }
                                    else if (streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).IndexOf("nigger") >= 0 || streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).ToLower().IndexOf("niger") >= 0 || streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).ToLower().IndexOf("nigga") >= 0)
                                    {
                                        nigger = true;
                                        using (var soundPlayer = new SoundPlayer(@"voice lines\ko nori.wav"))
                                        {
                                            soundPlayer.Play();
                                        }
                                        Console.WriteLine(streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).TrimStart(' '));
                                    }
                                }
                                else
                                    Console.WriteLine(streamingCall.ResponseStream.Current.Results[0].ToString().Substring(37, indexof - 37).TrimStart(' '));
                            }
                        }
                    }
                });
                // Read from the microphone and stream to API.
                object writeLock = new object();
                bool writeMore = true;
                var waveIn = new NAudio.Wave.WaveInEvent();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
                waveIn.DataAvailable +=
                    (object sender, NAudio.Wave.WaveInEventArgs args) =>
                    {
                        lock (writeLock)
                        {
                            if (!writeMore) return;
                            try
                            {
                                streamingCall.WriteAsync(
                                    new StreamingRecognizeRequest()
                                    {
                                        AudioContent = Google.Protobuf.ByteString
                                            .CopyFrom(args.Buffer, 0, args.BytesRecorded)
                                    }).Wait();
                            }
                            catch { }
                        }
                    };
                waveIn.StartRecording();
                Console.WriteLine("Speak now.");
                await Task.Delay(TimeSpan.FromSeconds(seconds));
                // Stop recording and shut down.
                using (var soundPlayer = new SoundPlayer(@"voice lines\oogabooga.wav"))
                {
                    soundPlayer.Play();
                }
                waveIn.StopRecording();
                lock (writeLock) writeMore = false;
                await streamingCall.WriteCompleteAsync();
                await printResponses;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamingMicRecognizeAsync(60);
            using (var soundPlayer = new SoundPlayer(@"voice lines\sv bicas.wav"))
            {
                soundPlayer.Play();
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
