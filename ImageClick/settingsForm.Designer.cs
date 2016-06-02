namespace ImageClick
{
    partial class settingsForm
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
            this.languagecomboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.revealAllSpeedLabel = new System.Windows.Forms.Label();
            this.difficultytrackBar = new System.Windows.Forms.TrackBar();
            this.velocityTrackBar = new System.Windows.Forms.TrackBar();
            this.difficultyValueLabel = new System.Windows.Forms.Label();
            this.velocityValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.difficultytrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // languagecomboBox
            // 
            this.languagecomboBox.FormattingEnabled = true;
            this.languagecomboBox.Location = new System.Drawing.Point(12, 32);
            this.languagecomboBox.Name = "languagecomboBox";
            this.languagecomboBox.Size = new System.Drawing.Size(205, 21);
            this.languagecomboBox.TabIndex = 0;
            this.languagecomboBox.SelectedValueChanged += new System.EventHandler(this.languagecomboBox_SelectedValueChanged);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(12, 16);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(47, 13);
            this.languageLabel.TabIndex = 1;
            this.languageLabel.Text = "Sprache";
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Location = new System.Drawing.Point(12, 76);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(70, 13);
            this.difficultyLabel.TabIndex = 3;
            this.difficultyLabel.Text = "Schwierigkeit";
            // 
            // revealAllSpeedLabel
            // 
            this.revealAllSpeedLabel.AutoSize = true;
            this.revealAllSpeedLabel.Location = new System.Drawing.Point(9, 156);
            this.revealAllSpeedLabel.Name = "revealAllSpeedLabel";
            this.revealAllSpeedLabel.Size = new System.Drawing.Size(170, 13);
            this.revealAllSpeedLabel.TabIndex = 4;
            this.revealAllSpeedLabel.Text = "Alles aufdecken - Geschwindigkeit";
            // 
            // difficultytrackBar
            // 
            this.difficultytrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.difficultytrackBar.BackColor = System.Drawing.Color.White;
            this.difficultytrackBar.Location = new System.Drawing.Point(12, 92);
            this.difficultytrackBar.Name = "difficultytrackBar";
            this.difficultytrackBar.Size = new System.Drawing.Size(273, 45);
            this.difficultytrackBar.TabIndex = 5;
            this.difficultytrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.difficultytrackBar.Scroll += new System.EventHandler(this.difficultytrackBar_Scroll);
            // 
            // velocityTrackBar
            // 
            this.velocityTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.velocityTrackBar.BackColor = System.Drawing.Color.White;
            this.velocityTrackBar.Location = new System.Drawing.Point(12, 188);
            this.velocityTrackBar.Name = "velocityTrackBar";
            this.velocityTrackBar.Size = new System.Drawing.Size(273, 45);
            this.velocityTrackBar.TabIndex = 6;
            this.velocityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.velocityTrackBar.Scroll += new System.EventHandler(this.velocityTrackBar_Scroll);
            // 
            // difficultyValueLabel
            // 
            this.difficultyValueLabel.AutoSize = true;
            this.difficultyValueLabel.Location = new System.Drawing.Point(291, 92);
            this.difficultyValueLabel.Name = "difficultyValueLabel";
            this.difficultyValueLabel.Size = new System.Drawing.Size(35, 13);
            this.difficultyValueLabel.TabIndex = 7;
            this.difficultyValueLabel.Text = "label1";
            // 
            // velocityValueLabel
            // 
            this.velocityValueLabel.AutoSize = true;
            this.velocityValueLabel.Location = new System.Drawing.Point(291, 188);
            this.velocityValueLabel.Name = "velocityValueLabel";
            this.velocityValueLabel.Size = new System.Drawing.Size(35, 13);
            this.velocityValueLabel.TabIndex = 8;
            this.velocityValueLabel.Text = "label1";
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(317, 245);
            this.Controls.Add(this.velocityValueLabel);
            this.Controls.Add(this.difficultyValueLabel);
            this.Controls.Add(this.velocityTrackBar);
            this.Controls.Add(this.difficultytrackBar);
            this.Controls.Add(this.revealAllSpeedLabel);
            this.Controls.Add(this.difficultyLabel);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.languagecomboBox);
            this.Name = "settingsForm";
            this.Text = "Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settingsForm_FormClosing);
            this.Load += new System.EventHandler(this.settingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.difficultytrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.velocityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox languagecomboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label difficultyLabel;
        private System.Windows.Forms.Label revealAllSpeedLabel;
        private System.Windows.Forms.TrackBar difficultytrackBar;
        private System.Windows.Forms.TrackBar velocityTrackBar;
        private System.Windows.Forms.Label difficultyValueLabel;
        private System.Windows.Forms.Label velocityValueLabel;
    }
}