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


namespace myYTRequest_f
{
    internal class Instagram
    {
        private Form form1;

        public Instagram(Form form)
        {
            this.form1 = form;
        }


        public async Task urlSearch(string url, YouTubeService yt, Label title_video, Label chanel_video,
            Label description_video, Label url_video, PictureBox min_video, TextBox url_search)
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        string html_decoded = responseBody;

                        //print
                        string responseJson = $"metaPost {url} \n {html_decoded}";
                        string tempFilepath = Path.GetTempFileName();
                        File.WriteAllText(tempFilepath, responseJson);
                        Process process = Process.Start("notepad.exe", tempFilepath);
                    }
                }
            }catch (Exception ex)
            {
                string tempFilepath = Path.GetTempFileName();
                File.WriteAllText(tempFilepath, $"Message: \n {ex}");
                Process process = Process.Start("notepad.exe", tempFilepath);
            }
        }
    }
}
