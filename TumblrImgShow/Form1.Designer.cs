namespace TumblrImgShow
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.copyLinkBtn = new System.Windows.Forms.Button();
            this.PrevImgBtn = new System.Windows.Forms.Button();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.StartDiashowBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.PictureBox1.Location = new System.Drawing.Point(45, 65);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(1217, 630);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Click += new System.EventHandler(this.NextPic);
            // 
            // SearchInput
            // 
            this.SearchInput.Location = new System.Drawing.Point(322, 29);
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(100, 20);
            this.SearchInput.TabIndex = 1;
            this.SearchInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchInput_KeyPress);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(440, 25);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.StartSearch);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(590, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // copyLinkBtn
            // 
            this.copyLinkBtn.Location = new System.Drawing.Point(724, 15);
            this.copyLinkBtn.Name = "copyLinkBtn";
            this.copyLinkBtn.Size = new System.Drawing.Size(88, 23);
            this.copyLinkBtn.TabIndex = 4;
            this.copyLinkBtn.Text = "copy link to img";
            this.copyLinkBtn.UseVisualStyleBackColor = true;
            this.copyLinkBtn.Click += new System.EventHandler(this.CopyLinkBtn_Click);
            // 
            // PrevImgBtn
            // 
            this.PrevImgBtn.Location = new System.Drawing.Point(45, 20);
            this.PrevImgBtn.Name = "PrevImgBtn";
            this.PrevImgBtn.Size = new System.Drawing.Size(75, 23);
            this.PrevImgBtn.TabIndex = 5;
            this.PrevImgBtn.Text = "prev";
            this.PrevImgBtn.UseVisualStyleBackColor = true;
            this.PrevImgBtn.Click += new System.EventHandler(this.PrevPic);
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.SystemColors.Desktop;
            this.PictureBox2.Location = new System.Drawing.Point(45, 65);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(1217, 630);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox2.TabIndex = 6;
            this.PictureBox2.TabStop = false;
            this.PictureBox2.Click += new System.EventHandler(this.NextPic);
            // 
            // StartDiashowBtn
            // 
            this.StartDiashowBtn.Location = new System.Drawing.Point(1100, 13);
            this.StartDiashowBtn.Name = "StartDiashowBtn";
            this.StartDiashowBtn.Size = new System.Drawing.Size(100, 23);
            this.StartDiashowBtn.TabIndex = 7;
            this.StartDiashowBtn.Text = "start diashow";
            this.StartDiashowBtn.UseVisualStyleBackColor = true;
            this.StartDiashowBtn.Click += new System.EventHandler(this.StartDiashowBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1340, 707);
            this.Controls.Add(this.StartDiashowBtn);
            this.Controls.Add(this.PrevImgBtn);
            this.Controls.Add(this.copyLinkBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.PictureBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.TextBox SearchInput;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button copyLinkBtn;
        private System.Windows.Forms.Button PrevImgBtn;
        private System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.Button StartDiashowBtn;
    }
}

