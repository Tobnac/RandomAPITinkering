﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TumblrImgShow
{
    public partial class Form1 : Form
    {
        private List<string> linkList;
        private int index = -1;
        private int offset = 0;
        private APIRequest.TumblrAPI api;
        private List<PictureBox> picBoxList = new List<PictureBox>();
        private int currentPicBox = 0;
        private bool gifsOnly = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.api = new APIRequest.TumblrAPI();

            this.picBoxList.Add(PictureBox1);
            this.picBoxList.Add(PictureBox2);
        }

        private void StartSearch(object sender, EventArgs e)
        {
            // start search, get new links, reset all counters, load first pic
            this.linkList = this.api.Run(SearchInput.Text);
            this.index = 0;
            this.offset = 0;
            this.UpdatePicBox();
        }

        private void UpdateLabel()
        {
            this.label1.Text = this.index + " / " + this.linkList.Count + " -- offset: " + this.offset;
        }

        private void StartDiaShow()
        {
            void LoadNextImg(object sender, EventArgs a) => this.NextPic();
            void InfoPrint(object sender, EventArgs a) => Console.WriteLine("now");

            var aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(LoadNextImg);
            aTimer.Elapsed += new ElapsedEventHandler(InfoPrint);
            aTimer.Interval = 1500;
            aTimer.Enabled = true;

            //while (true) ;
        }

        private void SearchInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // enter key press
            {
                this.StartSearch(SearchBtn, EventArgs.Empty);
            }
        }

        private void CopyLinkBtn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.linkList[this.index]);
        }

        private void UpdatePicBox()
        {
            UpdateLabel();
            var link = this.linkList[this.index];
            PictureBox1.Load(link);
        }

        private void NextPic(object sender, EventArgs e) => this.NextPic();
        private void NextPic()
        {
            do
            {
                this.IncreaseIndex();
            }
            while (this.gifsOnly && !this.linkList[this.index].Contains("gif"));


            this.UpdatePicBox();
        }

        private void PrevPic(object sender, EventArgs e) => this.PrevPic();
        private void PrevPic()
        {
            this.index--;
            if (index < 0)
            {
                this.index = this.linkList.Count - 1;
                this.offset -= 1;
                this.linkList = this.api.Run(SearchInput.Text);
            }

            this.UpdatePicBox();
        }

        private void StartDiashowBtn_Click(object sender, EventArgs e)
        {
            this.StartDiaShow();
        }

        private string GetNextLink()
        {
            this.IncreaseIndex();
            return this.linkList[this.index];
        }

        private void IncreaseIndex()
        {
            this.index++;

            if (index >= this.linkList.Count)
            {
                this.index = 0;
                this.offset += 1;
                this.linkList = this.api.Run(SearchInput.Text);
            }
        }
    }
}
