using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace ImageClick
{
    public partial class settingsForm : Form
    {
        string langString = "Deutsch";
        int difficultyInt = 5;
        int revealSpeedInt = 400;
        public string returnlangString { get { return langString; } }
        public int returndifficultyInt {  get { return difficultyInt; } }
        public int returnrevealSpeedInt { get { return revealSpeedInt; } }
        
        public settingsForm()
        {
            InitializeComponent();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            readSettings();
        }

        private void readSettings()
        {
            difficultyInt = Properties.Settings.Default.difficultyInt;
            revealSpeedInt = Properties.Settings.Default.speedInt;
            // Fill combobox

            // Use files in directory to fill
            // Combobox selected index from AppSettings

            // Fill difficulty from appSettings
            difficultytrackBar.Maximum = 10;
            difficultytrackBar.Minimum = 2;
            difficultytrackBar.Value = difficultyInt;
            difficultyValueLabel.Text = difficultytrackBar.Value.ToString();

            // Fill Speed from appSettings
            velocityTrackBar.Maximum = 1000;
            velocityTrackBar.Minimum = 1;
            velocityTrackBar.Value = revealSpeedInt+1;
            velocityValueLabel.Text = velocityTrackBar.Value.ToString();
        }


        private void settingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void languagecomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            langString = languagecomboBox.SelectedText;
        }

        private void difficultytrackBar_Scroll(object sender, EventArgs e)
        {
            difficultyInt = difficultytrackBar.Value;
            difficultyValueLabel.Text = difficultytrackBar.Value.ToString();
        }

        private void velocityTrackBar_Scroll(object sender, EventArgs e)
        {
            revealSpeedInt = velocityTrackBar.Value;
            velocityValueLabel.Text = velocityTrackBar.Value.ToString();
        }
    }
}
