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
        private YoutubeRequest myYouTubeObject;
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
                ApiKey = "" //to get it you have to log in Google developer console 
            });

            myYouTubeObject = new YoutubeRequest(this);
        }

        //-----------------------------------------------select the path
        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            path_name.Text = (browser.ShowDialog() == DialogResult.OK) ? browser.SelectedPath : "Path...";
            path = path_name.Text;
            savePath(path);
            validateTextBox(path);
           

        }
        //------------------------------------url search

        private async void url_search_TextChanged(object sender, EventArgs e)
        {
            clear.Visible = (url_search.Text == "") ? false : true;

            Uri uriResult;
            bool result = Uri.TryCreate(url_search.Text, UriKind.Absolute, out uriResult) //validar url 
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (result)
            {
                // await urlSearch(url_search.Text);
                await myYouTubeObject.urlSearch(
                    url_search.Text, yt, title_video, chanel_video, description_video,
                    url_video, min_video, url_search);

               //await myTwiterOnject.urlSearch(parameters) 

               //await myInatagramOnject.urlSearch(parameters) 

            }
            else
            {
                btn_download.Enabled =  false;
                GroupBox1.Visible =  false;
            }


        }

        public void visibleItems(string url)
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

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (radioVideo.Checked){
                //downloadVideo();
                myYouTubeObject.downloadVideo(downloading_icon, btn_download, url_search, path);
            }
            if (radioAudio.Checked) {
                myYouTubeObject.downloadAudioMP3(downloading_icon, btn_download, url_search, path);
                //downloadAudioMP3(); 
            }
        }

     
        public void download_finished(string file, string myFileName)
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

                                    //---------------------------Actualizar Gif
         public void OnFrameChanged(object sender, EventArgs e)
        {
            // Forzar el repintado del PictureBox
            downloading_icon.Invalidate();
        }
    }
}
