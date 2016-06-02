namespace ImageClick
{
    partial class ImageClickForm
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
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.startButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.revealButton = new System.Windows.Forms.Button();
            this.revealEverythingButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(99, 31);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Spiel starten";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(841, 447);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // revealButton
            // 
            this.revealButton.Location = new System.Drawing.Point(117, 12);
            this.revealButton.Name = "revealButton";
            this.revealButton.Size = new System.Drawing.Size(117, 31);
            this.revealButton.TabIndex = 2;
            this.revealButton.Text = "Einzeln aufdecken";
            this.revealButton.UseVisualStyleBackColor = true;
            this.revealButton.Visible = false;
            this.revealButton.Click += new System.EventHandler(this.revealButton_Click);
            // 
            // revealEverythingButton
            // 
            this.revealEverythingButton.Location = new System.Drawing.Point(240, 12);
            this.revealEverythingButton.Name = "revealEverythingButton";
            this.revealEverythingButton.Size = new System.Drawing.Size(111, 31);
            this.revealEverythingButton.TabIndex = 3;
            this.revealEverythingButton.Text = "Alles aufdecken";
            this.revealEverythingButton.UseVisualStyleBackColor = true;
            this.revealEverythingButton.Visible = false;
            this.revealEverythingButton.Click += new System.EventHandler(this.revealEverythingButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ImageClickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 508);
            this.Controls.Add(this.revealEverythingButton);
            this.Controls.Add(this.revealButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.startButton);
            this.Name = "ImageClickForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button revealButton;
        private System.Windows.Forms.Button revealEverythingButton;
        private System.Windows.Forms.Timer timer1;
    }
}

