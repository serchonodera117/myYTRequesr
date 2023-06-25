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
    public partial class Form1 : Form
    {
        private string path;
        public string myUrl;
        private YouTubeService yt;
        public Form1()
        {
            InitializeComponent();
            path = loadPath();
            path_name.Text = path;
            visibleItems(url_search.Text);
            validateTextBox(path);
            clear.Visible = (url_search.Text == "") ? false : true;

            yt = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCca9kwDhBgJ8SAz1zAAuYSsv-3KIZatQk" //to get it you have to log in Google developer console 
            });
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            path_name.Text = (browser.ShowDialog() == DialogResult.OK) ? browser.SelectedPath : "Path...";
            path = path_name.Text;
            savePath(path);
            validateTextBox(path);

        }

        private async void url_search_TextChanged(object sender, EventArgs e)
        {
            clear.Visible = (url_search.Text == "") ? false : true;

            Uri uriResult;
            bool result = Uri.TryCreate(url_search.Text, UriKind.Absolute, out uriResult) //validar url 
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (result)
            {
                await urlSearch(url_search.Text);
            }
            else
            {
                btn_download.Enabled =  false;
                GroupBox1.Visible =  false;
            }


        }

        private void visibleItems(string url)
        {
            string check = url.Replace(" ", string.Empty);
            btn_download.Enabled = (string.IsNullOrEmpty(check)) ? false : true;
            GroupBox1.Visible = (string.IsNullOrEmpty(check)) ? false : true;
        }
        
    private void validateTextBox(string path)
        {
            url_search.Enabled = (path != "Path...") ? true : false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            url_search.Text = "";
        }

        private void savePath(string path)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string fileName = "download_path.txt";
            string fullPath = currentDirectory + fileName;

            File.WriteAllText(fullPath, path);
        }
        private string loadPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string fileName = "download_path.txt";
            string fullPath = currentDirectory + fileName;
            return  (File.Exists(fullPath))?File.ReadAllText(fullPath): "Path...";
        }

    
        //-----------------------------------------------------------------------------queries
        private async Task urlSearch(string url)
        {
            //buscar del buscador
            var searchListRequest = yt.Search.List("snippet");
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
                visibleItems(url_search.Text);
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

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (radioVideo.Checked){downloadVideo();}
            if (radioAudio.Checked) { downloadAudioMP3(); }
        }

        private async void downloadVideo()
        {
            try
            {
            downloading_icon.Visible = true;
            Image gifImage = Properties.Resources.downloading;
            ImageAnimator.Animate(gifImage, OnFrameChanged);
            btn_download.Enabled = false;
            string theUrl = url_search.Text;
            var youtube = YouTube.Default;
            var video = await youtube.GetVideoAsync(theUrl);

            File.WriteAllBytes(@path+'/'+video.FullName,video.GetBytes());
            string videoName = video.FullName;
            download_finished("Video", videoName);

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void download_finished(string file, string myFileName)
        {
            downloading_icon.Visible = false;
            url_search.Text = "";
            myUrl = url_search.Text = "";
            MessageBox.Show($"The {file}  '[{myFileName}]' has been succesfully saved in {path}");
            openFIleRoute(myFileName);
        }
        private void openFIleRoute(string theFileName)
        {
            string completeRoute =  Path.Combine(path,theFileName);
            ProcessStartInfo myProcess = new ProcessStartInfo{ 
                 Arguments = "/select, \"" + completeRoute + "\"",
                FileName = "explorer.exe"
            };

            Process.Start(myProcess);
        }

        private async void downloadAudioMP3()
        {
            try
            {
            downloading_icon.Visible = true;
            Image gifImage = Properties.Resources.downloading;
            ImageAnimator.Animate(gifImage, OnFrameChanged);
            btn_download.Enabled = false;
            string theUrl = url_search.Text;
            var youtube = YouTube.Default;
            var video = await youtube.GetVideoAsync(theUrl);
            File.WriteAllBytes(@path + '/' + video.FullName, video.GetBytes());

             var inputfile = new MediaToolkit.Model.MediaFile { Filename =  path + '/' + video.FullName };
             var outputfile = new MediaToolkit.Model.MediaFile { Filename = $"{ @path + '/' + video.FullName.Replace(".mp4","") }.mp3"  };
            string fileName = video.FullName.Replace("mp4", "mp3");
                    using (var enging = new Engine())
                    {
                        enging.GetMetadata(inputfile);
                        enging.Convert(inputfile, outputfile);
                    }
               File.Delete(@path + '/' + video.FullName);


            download_finished("Audio",fileName);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+" "+ ex);
            }
        }

                                    //---------------------------Actualizar Gif
         private void OnFrameChanged(object sender, EventArgs e)
        {
            // Forzar el repintado del PictureBox
            downloading_icon.Invalidate();
        }
    }
}
