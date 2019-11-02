using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetSync_Click(object sender, EventArgs e)
        {
            long ticksThisTime = 0;
            textBox1.Text += ($",Ruuning Synchronously, {ticksThisTime}, { Environment.NewLine}");

            foreach (string url in MakeList())
            {
                var sw = new Stopwatch();
                // // From synchronous code
                sw.Start();
                var a = Get(url);
                 ticksThisTime = sw.ElapsedTicks;
                var ms = sw.ElapsedMilliseconds;
                sw.Stop();
                textBox1.Text += ($"{ms}:MS { Environment.NewLine}");
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
           
        }

        private async void GetAsyncAwait_Click(object sender, EventArgs e)
        {
            // Start a new stopwatch timer.
            long ticksThisTime = 0  ;
            textBox1.Text += ($",Ruuning Async{ticksThisTime}, { Environment.NewLine}");
            foreach (string url in MakeList())
            {
                var sw = new Stopwatch();
                sw.Start();
                var s =await GetAsync(url).ConfigureAwait(true);
                var ms = sw.ElapsedMilliseconds;
                sw.Stop();
                textBox1.Text += ($"{ms}:MS { Environment.NewLine}");
                textBox1.SelectionStart = textBox1.TextLength;
                textBox1.ScrollToCaret();
            }
           
        }

        private async void GetAsyncParralel_Click(object sender, EventArgs e)
        {
            Progress<ProgressReportModel> P = new Progress<ProgressReportModel>();
          

            var sw = new Stopwatch();
            sw.Start();
            _ = await RunDownload(P).ConfigureAwait(true);


        }

        private void ReportProg(ProgressReportModel e)
        {
            progressBar1.Value = e.PercentComplete;
        }

        public async Task<List<string>> RunDownload( IProgress<ProgressReportModel> progress)
        {
            var tlist = new List<Task>();
            ProgressReportModel P = new ProgressReportModel();
            var urlList = MakeList();
            for (int i = 0; i < urlList.Count; i++)
            {
                tlist.Add(GetAsync(urlList[i]));
                P.Downloaded.Add(urlList[i]);
                P.PercentComplete=(P.Downloaded.Count * 100) / urlList.Count;
                if (progress != null)
                {
                    progress.Report(P);
                }
                ReportProg(P);
            }
            var sw = new Stopwatch();
            sw.Start();
            await Task.WhenAll(tlist).ConfigureAwait(true);
            var ms = sw.ElapsedMilliseconds;
            sw.Stop();
            textBox1.Text += ($"{ms}:MS { Environment.NewLine}");
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
            return urlList;
        }


        static  string Get(string url)
        {
            Uri uri = new UriBuilder(url).Uri;
            string content = "";
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            request.Method = "GET"; // or "POST", "PUT", "PATCH", "DELETE", etc.
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using Stream responseStream = response.GetResponseStream();
                // Get a reader capable of reading the response stream
                using StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8);
                // Read stream content as string
                 content = myStreamReader.ReadToEnd();
              
            }
            return content;


        }
        static async Task<string> GetAsync(string url)
        {
            Uri uri = new UriBuilder(url).Uri;
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return content;


        }

        static List<string> MakeList()
        {
            var l = new List<string>
            {
                "https://docs.microsoft.com/en-us/visualstudio/install/update-visual-studio?view=vs-2019",
                "https://github.com/JosefPihrt/Roslynator#extensions-for-visual-studio",
                "https://www.dotnetperls.com/async",
                "https://andrewlock.net/running-async-tasks-on-app-startup-in-asp-net-core-part-1/",
                "https://stackoverflow.com/questions/20530152/deciding-between-httpclient-and-webclient",
                "https://news.google.com/?tab=rn1&hl=en-GB&gl=GB&ceid=GB:en",
                "https://www.youtube.com/feed/trending"
            };
            return l;
        }

    
    }
}
