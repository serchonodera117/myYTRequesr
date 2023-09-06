
namespace myYTRequest_f
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.path_name = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.url_search = new System.Windows.Forms.TextBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.title_video = new System.Windows.Forms.Label();
            this.chanel_video = new System.Windows.Forms.Label();
            this.description_video = new System.Windows.Forms.Label();
            this.url_video = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sign = new System.Windows.Forms.Label();
            this.downloading_icon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.button1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.min_video = new Guna.UI2.WinForms.Guna2PictureBox();
            this.radio_contianer = new System.Windows.Forms.GroupBox();
            this.radioAudio = new System.Windows.Forms.RadioButton();
            this.radioVideo = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloading_icon)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.min_video)).BeginInit();
            this.radio_contianer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // path_name
            // 
            this.path_name.AutoSize = true;
            this.path_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path_name.Location = new System.Drawing.Point(139, 25);
            this.path_name.Name = "path_name";
            this.path_name.Size = new System.Drawing.Size(0, 25);
            this.path_name.TabIndex = 1;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // url_search
            // 
            this.url_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.url_search.Location = new System.Drawing.Point(29, 175);
            this.url_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.url_search.Name = "url_search";
            this.url_search.Size = new System.Drawing.Size(623, 30);
            this.url_search.TabIndex = 2;
            this.url_search.TextChanged += new System.EventHandler(this.url_search_TextChanged);
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(649, 175);
            this.btn_download.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(127, 31);
            this.btn_download.TabIndex = 3;
            this.btn_download.Text = "download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // title_video
            // 
            this.title_video.AutoSize = true;
            this.title_video.BackColor = System.Drawing.Color.Transparent;
            this.title_video.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_video.Location = new System.Drawing.Point(225, 10);
            this.title_video.Name = "title_video";
            this.title_video.Size = new System.Drawing.Size(66, 25);
            this.title_video.TabIndex = 6;
            this.title_video.Text = "Titulo";
            // 
            // chanel_video
            // 
            this.chanel_video.AutoSize = true;
            this.chanel_video.BackColor = System.Drawing.Color.Transparent;
            this.chanel_video.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chanel_video.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chanel_video.Location = new System.Drawing.Point(230, 50);
            this.chanel_video.Name = "chanel_video";
            this.chanel_video.Size = new System.Drawing.Size(60, 26);
            this.chanel_video.TabIndex = 7;
            this.chanel_video.Text = "Canal";
            // 
            // description_video
            // 
            this.description_video.AutoSize = true;
            this.description_video.BackColor = System.Drawing.Color.Transparent;
            this.description_video.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description_video.Location = new System.Drawing.Point(227, 85);
            this.description_video.Name = "description_video";
            this.description_video.Size = new System.Drawing.Size(69, 15);
            this.description_video.TabIndex = 8;
            this.description_video.Text = "Description";
            // 
            // url_video
            // 
            this.url_video.AutoSize = true;
            this.url_video.BackColor = System.Drawing.Color.Transparent;
            this.url_video.Location = new System.Drawing.Point(226, 127);
            this.url_video.Name = "url_video";
            this.url_video.Size = new System.Drawing.Size(26, 20);
            this.url_video.TabIndex = 9;
            this.url_video.Text = "url";
            // 
            // clear
            // 
            this.clear.BackColor = System.Drawing.SystemColors.Window;
            this.clear.Location = new System.Drawing.Point(627, 175);
            this.clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(27, 30);
            this.clear.TabIndex = 11;
            this.clear.Text = "X";
            this.clear.UseVisualStyleBackColor = false;
            this.clear.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Paste your url here:";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.sign);
            this.groupBox2.Controls.Add(this.downloading_icon);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.GroupBox1);
            this.groupBox2.Controls.Add(this.radio_contianer);
            this.groupBox2.Controls.Add(this.clear);
            this.groupBox2.Controls.Add(this.btn_download);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.path_name);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.url_search);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(947, 723);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // sign
            // 
            this.sign.AutoSize = true;
            this.sign.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.sign.Location = new System.Drawing.Point(-3, 413);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(345, 16);
            this.sign.TabIndex = 17;
            this.sign.Text = "Developed by Serch Onodera. ©2023. All rights reserved.";
            // 
            // downloading_icon
            // 
            this.downloading_icon.Image = global::myYTRequest_f.Properties.Resources.downloading;
            this.downloading_icon.ImageRotate = 0F;
            this.downloading_icon.Location = new System.Drawing.Point(649, 295);
            this.downloading_icon.Name = "downloading_icon";
            this.downloading_icon.Size = new System.Drawing.Size(130, 131);
            this.downloading_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.downloading_icon.TabIndex = 16;
            this.downloading_icon.TabStop = false;
            this.downloading_icon.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.button1.HoverState.ImageSize = new System.Drawing.Size(34, 34);
            this.button1.Image = global::myYTRequest_f.Properties.Resources.carpeta;
            this.button1.ImageOffset = new System.Drawing.Point(0, 0);
            this.button1.ImageRotate = 0F;
            this.button1.ImageSize = new System.Drawing.Size(32, 32);
            this.button1.Location = new System.Drawing.Point(67, 13);
            this.button1.Name = "button1";
            this.button1.PressedState.ImageSize = new System.Drawing.Size(33, 33);
            this.button1.Size = new System.Drawing.Size(46, 33);
            this.button1.TabIndex = 15;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.BorderRadius = 15;
            this.GroupBox1.Controls.Add(this.min_video);
            this.GroupBox1.Controls.Add(this.title_video);
            this.GroupBox1.Controls.Add(this.url_video);
            this.GroupBox1.Controls.Add(this.chanel_video);
            this.GroupBox1.Controls.Add(this.description_video);
            this.GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GroupBox1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.GroupBox1.Location = new System.Drawing.Point(29, 210);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(595, 166);
            this.GroupBox1.TabIndex = 10;
            // 
            // min_video
            // 
            this.min_video.BorderRadius = 15;
            this.min_video.ImageRotate = 0F;
            this.min_video.Location = new System.Drawing.Point(-1, 0);
            this.min_video.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.min_video.Name = "min_video";
            this.min_video.Size = new System.Drawing.Size(214, 164);
            this.min_video.TabIndex = 10;
            this.min_video.TabStop = false;
            // 
            // radio_contianer
            // 
            this.radio_contianer.Controls.Add(this.radioAudio);
            this.radio_contianer.Controls.Add(this.radioVideo);
            this.radio_contianer.Location = new System.Drawing.Point(649, 210);
            this.radio_contianer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radio_contianer.Name = "radio_contianer";
            this.radio_contianer.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radio_contianer.Size = new System.Drawing.Size(130, 76);
            this.radio_contianer.TabIndex = 14;
            this.radio_contianer.TabStop = false;
            // 
            // radioAudio
            // 
            this.radioAudio.AutoSize = true;
            this.radioAudio.Location = new System.Drawing.Point(0, 44);
            this.radioAudio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioAudio.Name = "radioAudio";
            this.radioAudio.Size = new System.Drawing.Size(92, 20);
            this.radioAudio.TabIndex = 3;
            this.radioAudio.Text = "Audio.mp3";
            this.radioAudio.UseVisualStyleBackColor = true;
            // 
            // radioVideo
            // 
            this.radioVideo.AutoSize = true;
            this.radioVideo.BackColor = System.Drawing.Color.Transparent;
            this.radioVideo.Checked = true;
            this.radioVideo.Location = new System.Drawing.Point(0, 19);
            this.radioVideo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioVideo.Name = "radioVideo";
            this.radioVideo.Size = new System.Drawing.Size(93, 20);
            this.radioVideo.TabIndex = 2;
            this.radioVideo.TabStop = true;
            this.radioVideo.Text = "Video.mp4";
            this.radioVideo.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(41, 52);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "myYTRequest";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloading_icon)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.min_video)).EndInit();
            this.radio_contianer.ResumeLayout(false);
            this.radio_contianer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label path_name;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.TextBox url_search;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Label title_video;
        private System.Windows.Forms.Label chanel_video;
        private System.Windows.Forms.Label description_video;
        private System.Windows.Forms.Label url_video;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox radio_contianer;
        private System.Windows.Forms.RadioButton radioAudio;
        private System.Windows.Forms.RadioButton radioVideo;
        private Guna.UI2.WinForms.Guna2GroupBox GroupBox1;
        private Guna.UI2.WinForms.Guna2PictureBox min_video;
        private Guna.UI2.WinForms.Guna2ImageButton button1;
        private Guna.UI2.WinForms.Guna2PictureBox downloading_icon;
        private System.Windows.Forms.Label sign;
    }
}

