using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AngleSharp.Dom;
using Google.Apis;
using MediaToolkit;
using VideoLibrary;
using HtmlAgilityPack;
using System.Net.Http;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using MediaToolkit.Util;
using Newtonsoft.Json;
using System.Web;

namespace myYTRequest_f
{
    internal class XTwitterRequest
    {
        private Form1 form1;
        //Twitter Api tokens
        private string apiKey = "";
        private string apiSecretKey = "";
        private string accessToken = "";
        private string accessTokenSecret = "";
        public XTwitterRequest(Form1 form1)
        {
            this.form1 = form1;
        }

        public async Task urlSearch(string url, Label title_video, Label chanel_video,
            Label description_video, Label url_video, PictureBox min_video, TextBox url_search)
        {
            try
            {
                HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer ");

                    HttpResponseMessage response = await client.GetAsync($"https://api.twitter.com/2/tweets?ids={url}&tweet.fields=attachments");
                    string responseJson = await response.Content.ReadAsStringAsync();
                    //deserializa json object
                    TwitterVideoResponse twitterVideo = JsonConvert.DeserializeObject<TwitterVideoResponse>(responseJson);

                    title_video.Text = $"[X]Twitter video {twitterVideo.id}";
                    //chanel_video.Text = twitterVideo.user.screen_name;
                    description_video.Text = twitterVideo.text;
                    url_video.Text = url;

                    form1.visibleItems(url_search.Text);


                string tempFilepath = Path.GetTempFileName();
                File.WriteAllText(tempFilepath, responseJson);
                Process process = Process.Start("notepad.exe", tempFilepath);

            }
            catch (Exception ex)
            {
                MessageBox.Show("message: " + ex);

            }

        }
    }


    public class TwitterVideoResponse
    {
        public string id { get; set; }
        public string text { get; set; }
        public TwitterUser user { get; set; }
        public ExtendedEntities extended_entities { get; set; }
    }

    public class TwitterUser
    {
        public string screen_name { get; set; }
    }

    public class ExtendedEntities
    {
        public Media[] media { get; set; }
    }

    public class Media
    {
        public string media_url_https { get; set; }
        public string type { get; set; }
    }
}
