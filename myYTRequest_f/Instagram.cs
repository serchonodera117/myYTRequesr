using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Google.Apis;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MediaToolkit;
using VideoLibrary;
using System.Net;

using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using Xamarin.Essentials;

namespace myYTRequest_f
{
    internal class Instagram
    {
        private Form1 form1;
        private string authorFileName;

        public Instagram(Form1 form)
        {
            this.form1 = form;
        }


        public async Task urlSearch(string url, YouTubeService yt, Label title_video, Label chanel_video,
            Label description_video, Label url_video, PictureBox min_video, TextBox url_search)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var descriptionNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:description']");
                string description = descriptionNode?.Attributes["content"]?.Value;

                var authorNode = doc.DocumentNode.SelectSingleNode("//meta[@name='author']");
                string author = authorNode?.Attributes["content"]?.Value;

                var imageUrlNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:image']");
                string imageUrl = imageUrlNode?.Attributes["content"]?.Value;

                
                string decodedDescription = WebUtility.HtmlDecode(description);
                string decodedImageUrl = WebUtility.HtmlDecode(imageUrl);
                string[] splitedDescription = decodedDescription.Split(' ');
                string[] splitedDescriptionUser = decodedDescription.Split('"');
                string decodedAutor = splitedDescription[5];

                //print
                title_video.Text = "Insta media";
                chanel_video.Text =decodedAutor;
                authorFileName = decodedAutor;
                description_video.Text = splitedDescriptionUser[1];
                url_video.Text = url;


                HttpClient client = new HttpClient();
                byte[] imgByte = await client.GetByteArrayAsync(decodedImageUrl);
                using( var stream = new MemoryStream(imgByte))
                {
                    Image image = Image.FromStream(stream);
                    min_video.Image = image;
                    min_video.SizeMode = PictureBoxSizeMode.Zoom;
                }

                form1.visibleItems(url_search.Text);
            }
            catch (Exception ex)
            {
                string tempFilepath = Path.GetTempFileName();
                File.WriteAllText(tempFilepath, $"Message: \n {ex}");
                Process process = Process.Start("notepad.exe", tempFilepath);
            }
        }


        public async void downloadVideo(PictureBox downloading_icon, Button btn_download, TextBox url_search, string path)
        {
            try
            {
                string instaUrl = url_search.Text;
                WebBrowser myWebBrowser = new WebBrowser();

                myWebBrowser.Navigate(instaUrl);
                myWebBrowser.DocumentCompleted += (s, e) =>
                {
                    string html = myWebBrowser.DocumentText;
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var videoNode = doc.DocumentNode.SelectSingleNode("//meta[@property='og:video']");
                    if (videoNode != null )
                    {
                        string videolink = videoNode.GetAttributeValue("content", "");
                        string tempFilepath = Path.GetTempFileName();
                        File.WriteAllText(tempFilepath, $"Message: \n {videolink}");
                        Process process = Process.Start("notepad.exe", tempFilepath);
                    }
                };

               // InstagramDownloadMachineDemo.Program.DownloadToPathFIle(instaUrl, @path+'/'+ $"{authorFileName}.mp4"); 

                //HttpClient client = new HttpClient();
                //HttpResponseMessage response = await client.GetAsync(instaUrl);

                //if (response.IsSuccessStatusCode)
                //{
                //    Stream stream = await response.Content.ReadAsStreamAsync();
                //    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                //    string htmlContent = reader.ReadToEnd();

                //    HtmlDocument htmlDoc = new HtmlDocument();
                //    htmlDoc.LoadHtml(htmlContent);

                //   // Encuentra el nodo que contiene el enlace al video
                //   HtmlNode videoNode = htmlDoc.DocumentNode.SelectSingleNode("//tagname[@class='x1ey2m1c']");

                //        if (videoNode != null)
                //        {
                //            string videoUrl = videoNode.GetAttributeValue("content", "");
                //            string tempFilepath = Path.GetTempFileName();
                //            File.WriteAllText(tempFilepath, "Video URL: " + videoUrl);
                //            Process process = Process.Start("notepad.exe", tempFilepath);

                //        }
                //        else
                //        {
                //            string tempFilepath = Path.GetTempFileName();
                //            File.WriteAllText(tempFilepath, "Video URL: " + "No se pudo encontrar el video.");
                //            Process process = Process.Start("notepad.exe", tempFilepath);
                //    }
                //}
            }

            catch (Exception ex)
            {
                form1.just_hide_icon();
                string tempFilepath = Path.GetTempFileName();
                File.WriteAllText(tempFilepath, $"Message: \n {ex}");
                Process process = Process.Start("notepad.exe", tempFilepath);
            }
        }
    }
}
