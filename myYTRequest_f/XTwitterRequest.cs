using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AngleSharp.Dom;
using Google.Apis;
using MediaToolkit;
using VideoLibrary;
using System.Net.Http;
using MediaToolkit.Util;
using Newtonsoft.Json;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System.Web;
using AngleSharp.Io;
using OpenQA.Selenium;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using OpenQA.Selenium.Chrome;
using Google.Apis.Auth.OAuth2;
using System.Reflection;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Core.Models;
using Tweetinvi.Parameters;
using Tweetinvi.Models.Entities;

namespace myYTRequest_f
{
    internal class XTwitterRequest
    {
        private Form1 form1;
        //Twitter Api tokens
        private string apiKey = "";
        private string apiSecretKey = "YDMDlvmmyY4upNdK579X4l3QlsGlWh0z8MV6ortsqpk4XEQyYU";
        private string accessToken = "701251154437664768-PWrIG3Tqms5F1EJ21SbkgVR43LwrWeU";
        private string accessTokenSecret = "abFCQyjRL7E6V0016vQaPZEKQoprpKlrK4ywcHNlzZ36t";
        private string baererToken = "AAAAAAAAAAAAAAAAAAAAAEg9pQEAAAAASmtaj2hfs3sCXpNoYYcBJuE14Po%3DnmksYoqZfldzwYR43x7l4LLiFzgjd8Ie38VUyLvPdtvWdB3zTk";

        public XTwitterRequest(Form1 form1)
        {
            this.form1 = form1;
        }

        public async Task urlSearch(string url, Label title_video, Label chanel_video,
            Label description_video, Label url_video, PictureBox min_video, TextBox url_search)
        {
            try
            {
                string html_decoded;
                title_video.Text = "Tweet Video";
                url_video.Text = url;
                chanel_video.Text = "From X (twiter)";
                description_video.Text = "For the momment the video data can't be loaded in \n this previewer I apologize about it";
              
                min_video.Image = Properties.Resources.xtwitter_logo; 
                min_video.SizeMode = PictureBoxSizeMode.Zoom;
                form1.visibleItems(url_search.Text);
                //using (HttpClient client = new HttpClient())
                //{

                //    HttpResponseMessage resonse = client.GetAsync(url).Result;

                //    if(resonse.IsSuccessStatusCode)
                //    {
                //        var responseBody = await resonse.Content.ReadAsStringAsync();
                //        HtmlDocument document = new HtmlDocument();
                //        document.LoadHtml(responseBody);

                //        string description = document.DocumentNode.SelectSingleNode("//span[@class='css-901oao css-16my406 r-poiln3 r-bcqeeo r-qvutc0']").InnerText;
                //        // string imageUrl = document.DocumentNode.SelectSingleNode("//img[@class='tweet-image']/@src").Value;


                //        html_decoded = description;

                //        //print
                //        string responseJson = $"tweet {url} \n {html_decoded}";
                //        string tempFilepath = Path.GetTempFileName();
                //        File.WriteAllText(tempFilepath, responseJson);
                //        Process process = Process.Start("notepad.exe", tempFilepath);
                //    }
                //}

            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Message: {ex}");
                string tempFilepath = Path.GetTempFileName();
                File.WriteAllText(tempFilepath, $"Message: \n {ex}");
                Process process = Process.Start("notepad.exe", tempFilepath);
            }

        }

        public async void downloadVideo(PictureBox downloading_icon, Button btn_download, TextBox url_search, string path) 
        {
            try
            {

                var userCredentials = new TwitterCredentials(apiKey, apiSecretKey, accessToken, accessTokenSecret);
                var appClient = new TwitterClient(userCredentials);

                downloading_icon.Visible = true;
                Image gifImage = Properties.Resources.downloading;
                ImageAnimator.Animate(gifImage, form1.OnFrameChanged);
                btn_download.Enabled = false;
                
                string theUrl = url_search.Text;
                
                using (HttpClient client = new HttpClient())
                {
                    string html = await client.GetStringAsync(theUrl);
                    HtmlDocument doc = new HtmlDocument();  
                    doc.LoadHtml(html);

                    HtmlNode videoNode = doc.DocumentNode.SelectSingleNode("//video[@src]");
                    if (videoNode != null)
                    {
                        string videoUrl = videoNode.GetAttributeValue("src", "");
                        string videoName = Path.Combine(path,"tweetVideo.mp4");
                        using (WebClient webClient = new WebClient())
                        {

                            webClient.DownloadFile(videoUrl, videoName);
                        }
                          form1.download_finished("Video", "tweetVideo.mp4");
                    }
                    else
                    {
                        MessageBox.Show($"counln't download video");

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Message: \n {ex}");
                form1.just_hide_icon();
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
