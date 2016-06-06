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
using System.Xml;

namespace ImageClick
{
    public partial class settingsForm : Form
    {
        string langString = "Deutsch";
        int difficultyInt = 5;
        int revealSpeedInt = 400;
        string[] textStringArray = new string[10];
        string[] bufferArray;
        public string returnlangString { get { return langString; } }
        public int returndifficultyInt {  get { return difficultyInt; } }
        public int returnrevealSpeedInt { get { return revealSpeedInt; } }
        
        public settingsForm()
        {
            InitializeComponent();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            setLanguage();
            readSettings();
        }

        private void setLanguage()
        {
            readXml();
            // Einstellungen
            this.Text = textStringArray[6];
            // Sprache
            languageLabel.Text = textStringArray[7];
            // Schwierigkeit
            difficultyLabel.Text = textStringArray[8];
            // Alles aufdecken - Geschwindigkeit
            revealAllSpeedLabel.Text = textStringArray[9];
        }

        private void readXml()
        {
            bool rightLangBool = false;
            int countInt = 0;
            string[] lines = new string[5000];
            string buffer;
            XmlTextReader xmlReader = new XmlTextReader("language.xml");

            // Set language based on comboboxes content
            string buffer2 = "";
            if (languagecomboBox.SelectedIndex == -1)
            { buffer2 = Properties.Settings.Default.lang; }
            else
            { buffer2 = bufferArray[languagecomboBox.SelectedIndex]; }

            // Read loop
            while (xmlReader.Read())
            {
                if (rightLangBool)
                {
                    buffer = xmlReader.Value;
                    buffer = buffer.Trim();
                    if (buffer != "" && buffer != "\r\n")
                    {
                        if (countInt == 10)
                        { break; }
                        textStringArray[countInt] = xmlReader.Value;
                        countInt++;
                    }
                }
                
                if (xmlReader.Name == buffer2)
                { rightLangBool = true; }
            }
            //System.IO.File.WriteAllLines(@"C:\Users\Nicolai\Desktop\WriteLines2.txt", lines);
        }

        private void readSettings()
        {
            difficultyInt = Properties.Settings.Default.difficultyInt;
            revealSpeedInt = Properties.Settings.Default.speedInt;
            // Fill combobox
            readXmlCombo();

            // De and reattach event handler and write to combobox
            languagecomboBox.SelectedValueChanged -= languagecomboBox_SelectedValueChanged;
            languagecomboBox.SelectedIndex = Array.IndexOf(bufferArray, Properties.Settings.Default.lang);
            languagecomboBox.SelectedValueChanged += languagecomboBox_SelectedValueChanged;

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
            langString = languagecomboBox.Text;
            setLanguage();
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

        private void readXmlCombo()
        {
            bool rightLangBool = false;
            int countInt = 0;
            string[] languages = new string[5000];
            string buffer;
            XmlTextReader xmlReader = new XmlTextReader("language.xml");
            while (xmlReader.Read())
            {
                if (xmlReader.Depth == 1)
                {
                    buffer = xmlReader.Name;
                    buffer = buffer.Trim();
                    if (buffer != "" && buffer != "\r\n")
                    {
                        languages[countInt] = xmlReader.Name;
                        countInt++;
                    }
                }
            }
            bufferArray = new string[countInt / 2];
            int countInt2 = 0;
            for (int i = 0; i < countInt; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    bufferArray[countInt2] = languages[i];
                    countInt2++;
                }
            }
            languagecomboBox.Items.AddRange(bufferArray);
            //System.IO.File.WriteAllLines(@"C:\Users\Nicolai\Desktop\debug_depth.txt", lines);
        }
    }
}
