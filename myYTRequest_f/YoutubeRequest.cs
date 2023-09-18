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
using Google.Apis;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MediaToolkit;
using VideoLibrary;

namespace myYTRequest_f
{
    internal class YoutubeRequest
    {
        private Form1 form1;
        public YoutubeRequest(Form1 form)
        {
            this.form1 = form;
        }
        public async Task urlSearch(string url, YouTubeService yt, Label title_video, Label chanel_video,
            Label description_video, Label url_video, PictureBox min_video, TextBox url_search)
        {
            //buscar del buscador
            var searchListRequest = yt.Search.List("snippet");
            url =  form1.checkAmpersonURL(url);
            searchListRequest.Q = url;
            searchListRequest.MaxResults = 1;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            //obtener id del primer video 
            var videoId = searchListResponse.Items.FirstOrDefault()?.Id.VideoId;
            var title = searchListResponse.Items.FirstOrDefault()?.Snippet.Title;
            var author = searchListResponse.Items.FirstOrDefault()?.Snippet.ChannelTitle;
            var description = searchListResponse.Items.FirstOrDefault()?.Snippet.ChannelTitle;
            if (videoId != null)
            {
                title_video.Text = title.ToString();
                chanel_video.Text = author.ToString();
                description_video.Text = description.ToString();
                url_video.Text = url;
                var minUrl = $"https://img.youtube.com/vi/{videoId}/default.jpg";
                //cargar miniatura
                var min = await LoadMin(minUrl);
                min_video.Image = min;
                min_video.SizeMode = PictureBoxSizeMode.Zoom;

                form1.visibleItems(url_search.Text);
            }
        }

        private async Task<Image> LoadMin(string url) //cargar la imagen del video 
        {
            using (var webClient = new System.Net.WebClient())
            {
                var data = await webClient.DownloadDataTaskAsync(url);
                using (var stream = new System.IO.MemoryStream(data))
                {
                    return Image.FromStream(stream);
                }
            }
        }


        public async void downloadVideo(PictureBox downloading_icon, Button btn_download, TextBox url_search, string path)
        {
            try
            {
                downloading_icon.Visible = true;
                Image gifImage = Properties.Resources.downloading;
                ImageAnimator.Animate(gifImage, form1.OnFrameChanged);
                btn_download.Enabled = false;
                string theUrl = url_search.Text;
                theUrl = form1.checkAmpersonURL(theUrl);
                var youtube = YouTube.Default;
                var video = await youtube.GetVideoAsync(theUrl);

                File.WriteAllBytes(@path + '/' + video.FullName, video.GetBytes());
                string videoName = video.FullName;
                form1.download_finished("Video", videoName);
            }
            catch (Exception e)
            {
                form1.just_hide_icon();
                MessageBox.Show($"Error: probably the video has a restriction \nDescription:  {e.Message}");
            }
        }
        public async void downloadAudioMP3(PictureBox downloading_icon, Button btn_download, TextBox url_search, string path)
        {
            try
            {
                downloading_icon.Visible = true;
                Image gifImage = Properties.Resources.downloading;
                ImageAnimator.Animate(gifImage, form1.OnFrameChanged);
                btn_download.Enabled = false;
                string theUrl = url_search.Text;
                theUrl = form1.checkAmpersonURL(theUrl);
                var youtube = YouTube.Default;
                var video = await youtube.GetVideoAsync(theUrl);
                File.WriteAllBytes(@path + '/' + video.FullName, video.GetBytes());

                var inputfile = new MediaToolkit.Model.MediaFile { Filename = path + '/' + video.FullName };
                var outputfile = new MediaToolkit.Model.MediaFile { Filename = $"{@path + '/' + video.FullName.Replace(".mp4", "")}.mp3" };
                string fileName = video.FullName.Replace("mp4", "mp3");
                using (var enging = new Engine())
                {
                    enging.GetMetadata(inputfile);
                    enging.Convert(inputfile, outputfile);
                }
                File.Delete(@path + '/' + video.FullName);


                form1.download_finished("Audio", fileName);

            }
            catch (Exception ex)
            {
                form1.just_hide_icon();
                MessageBox.Show("Error: " + "Probably a video has a restriction, my deepest apologies\n Description: " + ex);

            }
        }

    }
}
