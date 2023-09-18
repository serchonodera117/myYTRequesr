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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Google.Apis;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MediaToolkit;
using VideoLibrary;
using HtmlAgilityPack;
using System.Net;

namespace myYTRequest_f
{
    internal class Instagram
    {
        private Form1 form1;

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
                description_video.Text = splitedDescriptionUser[1];
                url_video.Text = url;


                HttpClient client = new HttpClient();
                byte[] imgByte = await client.GetByteArrayAsync(decodedImageUrl);
                using( var stream = new MemoryStream(imgByte))
                {
                    Image image = Image.FromStream(stream);
                    min_video.Image = image;
                }

                form1.visibleItems(url_search.Text);


                string tempFilepath = Path.GetTempFileName();
                File.WriteAllText(tempFilepath, $"Message: \n {decodedDescription}");
                Process process = Process.Start("notepad.exe", tempFilepath);

            }
            catch (Exception ex)
            {
                string tempFilepath = Path.GetTempFileName();
                File.WriteAllText(tempFilepath, $"Message: \n {ex}");
                Process process = Process.Start("notepad.exe", tempFilepath);
            }
        }
    }
}
