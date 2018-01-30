/**
 * @license
 * Copyright 2017 Nicolai Schmid All rights reserved.
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *     http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml;
using System.Net;
using System.IO.Compression;

namespace ImageClick
{
    public partial class ImageClickForm : Form
    {

        static string versionString = "0.1.1";
        string[] picturesStringArray;
        int difficultyInt = 4;
        int paddingInt = 5;
        int imageCountInt = 0;
        bool revealButtonBool = true;
        bool inGameBool = false;
        int count = 0;

        //string[] textStringArray = { "Keine Bilder im Ordner gespeichert", "Nächstes Bild", "Aufdecken", "Zuende!", "Spiel starten", "Alles aufdecken", "Einstellungen" };
        string[] textStringArray = new string[12];
        
        int[] used;
        Random random = new Random();

        public static AutoResetEvent arEvent = new AutoResetEvent(false);

        // true means not guessed
        bool[,] fieldBool;
        Image image;

        public ImageClickForm()
        {
            InitializeComponent();
        }

        private void languageSet()
        {
            // Spiel starten
            startButton.Text = textStringArray[4];
            //Aufdecken
            revealButton.Text = textStringArray[2];
            // Alles aufdecken
            revealEverythingButton.Text = textStringArray[5];
            // Einstellungen
            settingsButton.Text = textStringArray[6];
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            string pathString = folderBrowserDialog1.SelectedPath;

            // MessageBox.Show(pathString);
            if (dialogResult == DialogResult.OK)
            {

                if (pathString != "")
                {
                    if (Directory.Exists(pathString))
                    {
                        picturesStringArray = Directory.GetFiles(pathString, "*.jpg");
                        if (picturesStringArray.Length == 0)
                        {
                            //              Keine bilder im Ordner gespeichert
                            MessageBox.Show(textStringArray[0]);
                        }
                        else
                        {
                            Array.Sort(picturesStringArray);
                            //Array.Sort(picturesStringArray, new AlphanumComparatorFast());
                            fieldBool = new bool[difficultyInt, difficultyInt];
                            used = new int[difficultyInt];
                            imageCountInt = 0;
                            revealButton.Enabled = true;
                            revealEverythingButton.Enabled = true;
                            resetArray();
                            inGameBool = true;
                            image = Image.FromFile(picturesStringArray[0]);
                            //                  Nächstes Bild
                            startButton.Text = textStringArray[1];
                            startButton.Enabled = false;
                            revealButton.Visible = true;
                            revealEverythingButton.Visible = true;

                            // Configuring Reveal Label
                            revealLabel.Visible = true;

                            gameVoid(picturesStringArray[imageCountInt]);
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            difficultyInt = Properties.Settings.Default.difficultyInt;
            timer1.Interval = Properties.Settings.Default.speedInt;
            readXml();
            languageSet();
            //checkUpdate();
        }

        private void gameVoid(string fileString)
        {
            image.Dispose();
            image = Image.FromFile(fileString);
            drawGrid(image.Width, image.Height, difficultyInt, paddingInt);
            pictureBox1.Image = image;
            // Configuring Reveal Label
            revealLabel.Text = count.ToString() + " / " + (difficultyInt * difficultyInt).ToString();
            this.Text = "ImageClick [" + (imageCountInt + 1).ToString() + " / " + picturesStringArray.Length.ToString() + "]";
            if (imageCountInt == 0)
            {
                previousButton.Visible = false;
                nextButton.Visible = true;
            }
            else
            { previousButton.Visible = true; }
            if (imageCountInt == picturesStringArray.Length - 1)
            { nextButton.Visible = false; }
            else
            { nextButton.Visible = true; }
        }

        private void readXml()
        {
            bool rightLangBool = false;
            int countInt = 0;
            string[] lines = new string[5000];
            string buffer;
            XmlTextReader xmlReader = new XmlTextReader("language.xml");
            while (xmlReader.Read())
            {
                if (rightLangBool)
                {
                    buffer = xmlReader.Value;
                    buffer = buffer.Trim();
                    if (buffer != "" && buffer != "\r\n")
                    {
                        if (countInt == 12)
                        { break; }
                        textStringArray[countInt] = xmlReader.Value;
                        countInt++;
                    }
                }
                string buffer2 = Properties.Settings.Default.lang;
                if (xmlReader.Name == buffer2)
                { rightLangBool = true; }
            }
            //System.IO.File.WriteAllLines(@"C:\Users\Nicolai\Desktop\WriteLines2.txt", lines);
        }

        private void drawGrid(int width, int height, int diffi, int padding)
        {
            // number of lines (excluding spare)
            int lineHeightInt = height / diffi;
            int collumnWidthInt = width / diffi;

            for (int spalten = 0; spalten < diffi; spalten++)
            {
                for (int zeilen = 0; zeilen < diffi; zeilen++)
                {
                    if (fieldBool[spalten, zeilen])
                    {
                        int x1 = zeilen * collumnWidthInt;
                        int y1 = spalten * lineHeightInt;
                        int x2 = (zeilen + 1) * collumnWidthInt;
                        int y2 = (spalten + 1) * lineHeightInt;
                        drawRect(x1, y1, x2, y2);
                    }
                }
            }
            
            
        }

        private void drawLine(int x1, int y1, int x2, int y2, Pen pen)
        {
            
            using (var graphic = Graphics.FromImage(image))
            {
                graphic.DrawLine(pen, x1, y1, x2, y2);
            }

                //graphics.DrawLine(blackPen, x1, y1, x2, y2);

        }

        private void drawRect(int x1, int y1, int x2, int y2)
        {
            int width = (x2 - x1);
            int height = (y2 - y1);

            Pen blackPen = new Pen(Color.Black, paddingInt);
            Pen whitePen = new Pen(Color.White, paddingInt);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            Rectangle rect = new Rectangle(x1, y1, width, height);
            using (var graphic = Graphics.FromImage(image))
            {
                graphic.FillRectangle(whiteBrush, rect);
                graphic.DrawLine(blackPen, x1, y1, x1, y2);
                graphic.DrawLine(blackPen, x1, y1, x2, y1);
                graphic.DrawLine(blackPen, x2, y1, x2, y2);
                graphic.DrawLine(blackPen, x1, y2, x2, y2);
            }
        }

        private void revealButton_Click(object sender, EventArgs e)
        {
            if (revealButtonBool)
            {
                reveal();
            }
            else
            {
                imageCountInt++;
                count = 0;
                revealButtonBool = true;
                //                  Aufdecken
                revealButton.Text = textStringArray[2];
                revealEverythingButton.Enabled = true;
                resetArray();
                if (imageCountInt == picturesStringArray.Length)
                {
                    finished();
                }
                else
                {
                    gameVoid(picturesStringArray[imageCountInt]);
                }

            }
        }
           
        private void resetArray()
        {
            for (int i = 0; i < difficultyInt; i++)
            {
                for (int i2 = 0; i2 < difficultyInt; i2++)
                {
                    fieldBool[i, i2] = true;
                }
            }
        }

        private void revealEverythingButton_Click(object sender, EventArgs e)
        {
            if (revealButtonBool)
            {
                revealEverything();
            }
            else
            {
                imageCountInt++;
                count = 0;
                revealButtonBool = true;
                //                  Aufdecken
                revealButton.Text = textStringArray[2];
                resetArray();
                if (imageCountInt == picturesStringArray.Length)
                {
                    finished();
                }
                else
                { gameVoid(picturesStringArray[imageCountInt]); }

            }

        }

        private void revealEverything()
        {
            timer1.Enabled = true;
        }

        private void reveal()
        {
            int collumnInt = random.Next(0, difficultyInt - 1);
            int lineInt = random.Next(0, difficultyInt - 1);

            if (fieldBool[collumnInt, lineInt] == false)
            {
                if (count != difficultyInt * difficultyInt)
                {
                    while (true)
                    {
                        collumnInt = random.Next(0, difficultyInt);
                        lineInt = random.Next(0, difficultyInt);
                        if (fieldBool[collumnInt, lineInt] == true)
                        {
                            break;
                        }
                    }
                    if (count == (difficultyInt * difficultyInt)-1)
                    {
                        //                  Nächsten Bild
                        revealButton.Text = textStringArray[1];
                        revealButtonBool = false;
                        revealEverythingButton.Enabled = false;
                    }
                }
                else
                {
                    
                }
                fieldBool[collumnInt, lineInt] = false;
                count++;
            }
            else
            {
                fieldBool[collumnInt, lineInt] = false;
                used[lineInt] = collumnInt;
                count++;
            }
            gameVoid(picturesStringArray[imageCountInt]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count != difficultyInt * difficultyInt)
            {
                reveal();
            }
            else
            {
                timer1.Enabled = false;
                revealButtonBool = false;
                //                  Nächsten Bild
                revealButton.Text = textStringArray[1];
                revealEverythingButton.Enabled = false;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settingsForm settingsform = new settingsForm();
            if (settingsform.ShowDialog() == DialogResult.Yes)
            {
                Properties.Settings.Default.speedInt = settingsform.returnrevealSpeedInt;
                Properties.Settings.Default.difficultyInt = settingsform.returndifficultyInt;
                Properties.Settings.Default.lang = settingsform.returnlangString;
                Properties.Settings.Default.Save();

                difficultyInt = Properties.Settings.Default.difficultyInt;
                timer1.Interval = Properties.Settings.Default.speedInt;
                readXml();
                if (inGameBool)
                {
                    fieldBool = new bool[difficultyInt, difficultyInt];
                    used = new int[difficultyInt];
                    count = 0;
                    revealButtonBool = true;
                    //                  Aufdecken
                    revealButton.Text = textStringArray[2];
                    revealEverythingButton.Enabled = true;
                    resetArray();
                    if (imageCountInt == picturesStringArray.Length)
                    {
                        finished();
                    }
                    else
                    { gameVoid(picturesStringArray[imageCountInt]); }
                }

                startButton.Text = textStringArray[4];
                revealEverythingButton.Text = textStringArray[5];
                settingsButton.Text = textStringArray[6];
                revealButton.Text = textStringArray[2];
                //Application.Restart();
            }
        }

        private void finished()
        {
            //               Zuende
            MessageBox.Show(textStringArray[3]);
            startButton.Enabled = true;
            //               Spiel starten
            startButton.Text = textStringArray[4];
            revealButton.Enabled = false;
            revealEverythingButton.Enabled = false;
            inGameBool = false;
        }

        private void checkUpdate()
        {
            try
            { 
                using (var client = new WebClient())
                { client.DownloadFile("https://raw.githubusercontent.com/nicolaiimmanuelschmid/ImageClick/master/README.md", "README.md"); }
                string[] readMeString = File.ReadAllLines("README.md");
                if (readMeString[1] != versionString)
                {
                    DialogResult dialogResult = MessageBox.Show(textStringArray[10], textStringArray[11], MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Yes)
                    { update(); }
                }
            }
            catch (Exception e)
            { }
        }

        private void update()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile("https://github.com/nicolaiimmanuelschmid/ImageClick/archive/update.zip", "update.zip");
                    string zipPath = "update.zip";
                    string path = Directory.GetCurrentDirectory();
                    Directory.Delete("ImageClick-update\\", true);
                    
                    ZipFile.ExtractToDirectory("update.zip", path);
                    File.Delete("update.zip");
                    System.Diagnostics.Process.Start("ImageClick-update\\update.bat");
                    Application.Exit();
                }
                catch (Exception e) { }
             }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            imageCountInt++;
            resetArray();
            gameVoid(picturesStringArray[imageCountInt]);
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            imageCountInt--;
            resetArray();
            gameVoid(picturesStringArray[imageCountInt]);
        }
    }
}
