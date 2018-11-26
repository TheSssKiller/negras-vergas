using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using RedditSharp;
using RedditSharp.Things;
using NAudio.CoreAudioApi;
using System.Threading;

namespace negras_vergas
{
    public partial class reddit : Form
    {
        BackgroundWorker worker;
        bool dab = false;
        Image maymay = null;
        List<Post> posts1 = new List<Post>() { };
        string currentsub = null;
        string box2text = "Hot";
        string box3text = "Of all time";
        public reddit()
        {
            InitializeComponent();
            comboBox2.Items.Add("Hot");
            comboBox2.Items.Add("New");
            comboBox2.Items.Add("Controversial");
            comboBox2.Items.Add("Rising");
            comboBox2.Items.Add("Top");
            comboBox3.Items.Add("Of all time");
            comboBox3.Items.Add("Past hour");
            comboBox3.Items.Add("Past day");
            comboBox3.Items.Add("Past week");
            comboBox3.Items.Add("Past month");
            comboBox3.Items.Add("Past year");
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, NAudio.CoreAudioApi.DeviceState.Active);
            comboBox1.Items.AddRange(devices.ToArray());
            comboBox1.Text = devices[0].ToString();
            worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }
        int audio = 0;
        int x = 1;
        int upvotes = 0;
        int downvotes = 0;
        bool first = true;
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker.ReportProgress(1);
            dab = true;
            if (textBox1.Text != currentsub || first == true)
            {
                first = false;
                posts1.Clear();
                x = 1;
                var reddit = new Reddit();
                var subreddit = reddit.GetSubreddit("dankmemes");
                if (textBox1.Text.Length > 0)
                {
                    try
                    {
                        subreddit = reddit.GetSubreddit(textBox1.Text);
                    }
                    catch
                    {
                    }
                }
                var vnice = new Post();
                if (box2text.ToLower() == "hot")
                    vnice = subreddit.Hot.ElementAt(x - 1);
                else if (box2text.ToLower() == "new")
                    vnice = subreddit.New.ElementAt(x - 1);
                else if (box2text.ToLower() == "controversial")
                    vnice = subreddit.Controversial.ElementAt(x - 1);
                else if (box2text.ToLower() == "rising")
                    vnice = subreddit.Rising.ElementAt(x - 1);
                else if (box2text.ToLower() == "top")
                {
                    if (box3text.ToLower() == "of all time")
                        vnice = subreddit.GetTop(FromTime.All).ElementAt(x - 1);
                    else if (box3text.ToLower() == "past hour")
                        vnice = subreddit.GetTop(FromTime.Hour).ElementAt(x - 1);
                    else if (box3text.ToLower() == "past day")
                        vnice = subreddit.GetTop(FromTime.Day).ElementAt(x - 1);
                    else if (box3text.ToLower() == "past week")
                        vnice = subreddit.GetTop(FromTime.Week).ElementAt(x - 1);
                    else if (box3text.ToLower() == "past month")
                        vnice = subreddit.GetTop(FromTime.Month).ElementAt(x - 1);
                    else if (box3text.ToLower() == "past year")
                        vnice = subreddit.GetTop(FromTime.Year).ElementAt(x - 1);
                    else
                        vnice = subreddit.GetTop(FromTime.All).ElementAt(x - 1);
                }
                else
                    vnice = subreddit.Hot.ElementAt(x - 1);
                posts1.Add(vnice);
                upvotes = posts1[x - 1].Upvotes;
                downvotes = posts1[x - 1].Downvotes;
            }
            worker.ReportProgress(2);
            WebClient webclient1 = new WebClient();
            byte[] data1 = webclient1.DownloadData(posts1[x - 1].Url);
            try
            {
                MemoryStream mem = new MemoryStream(data1);
                maymay = Image.FromStream(mem);
            }
            catch
            {
                maymay = null;
            }
            worker.ReportProgress(3);
            x++;
            currentsub = textBox1.Text;
            var reddit2 = new Reddit();
            var subreddit2 = reddit2.GetSubreddit("dankmemes");
            if (textBox1.Text.Length > 0)
            {
                try
                {
                    subreddit2 = reddit2.GetSubreddit(textBox1.Text);
                }
                catch
                {
                }
            }
            var vnice2 = new Post();
            if (box2text.ToLower() == "hot")
                vnice2 = subreddit2.Hot.ElementAt(x - 1);
            else if (box2text.ToLower() == "new")
                vnice2 = subreddit2.New.ElementAt(x - 1);
            else if (box2text.ToLower() == "controversial")
                vnice2 = subreddit2.Controversial.ElementAt(x - 1);
            else if (box2text.ToLower() == "rising")
                vnice2 = subreddit2.Rising.ElementAt(x - 1);
            else if (box2text.ToLower() == "top")
            {
                if (box3text.ToLower() == "of all time")
                    vnice2 = subreddit2.GetTop(FromTime.All).ElementAt(x - 1);
                else if (box3text.ToLower() == "past hour")
                    vnice2 = subreddit2.GetTop(FromTime.Hour).ElementAt(x - 1);
                else if (box3text.ToLower() == "past day")
                    vnice2 = subreddit2.GetTop(FromTime.Day).ElementAt(x - 1);
                else if (box3text.ToLower() == "past week")
                    vnice2 = subreddit2.GetTop(FromTime.Week).ElementAt(x - 1);
                else if (box3text.ToLower() == "past month")
                    vnice2 = subreddit2.GetTop(FromTime.Month).ElementAt(x - 1);
                else if (box3text.ToLower() == "past year")
                    vnice2 = subreddit2.GetTop(FromTime.Year).ElementAt(x - 1);
                else
                    vnice2 = subreddit2.GetTop(FromTime.All).ElementAt(x - 1);
            }
            else
                vnice2 = subreddit2.Hot.ElementAt(x - 1);
            posts1.Add(vnice2);
            upvotes = posts1[x - 1].Upvotes;
            downvotes = posts1[x - 1].Downvotes;
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
                label3.Visible = true;
            else if (e.ProgressPercentage == 2)
            {
                label1.Text = posts1[x - 1].Title;
                label6.Text = (upvotes - downvotes).ToString();
            }
            else if (e.ProgressPercentage == 3)
            {
                pictureBox1.Image = maymay;
                pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
                label3.Text = "Loading next post...";
            }
            else
                label3.Visible = false;
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label3.Visible = false;
            label3.Text = "Loading...";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dab == true)
            {
                Thread.Sleep(1000);
                dab = false;
            }
            if (comboBox1.SelectedItem != null)
            {
                var device = (MMDevice)comboBox1.SelectedItem;
                audio = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
                if (audio >= numericUpDown1.Value && checkBox1.Checked)
                {
                    try
                    {
                        label3.Visible = true;
                        worker.RunWorkerAsync();
                    }
                    catch { }
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Cursor == System.Windows.Forms.Cursors.Hand)
            {
                try
                {
                    System.Diagnostics.Process.Start(posts1[x - 2].Url.ToString());
                }
                catch { }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            x = 1;
            posts1.Clear();
            first = true;
        }
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Top")
                comboBox3.Visible = true;
            else
                comboBox3.Visible = false;
            box2text = comboBox2.Text;
        }
        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            box3text = comboBox3.Text;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.reddit.com" + posts1[x - 2].Permalink.ToString());
            }
            catch { }
        }
        private void Form1_SizeChanged_1(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(ClientSize.Width - 20, ClientSize.Height - 81);
        }
    }
}
