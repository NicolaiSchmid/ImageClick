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

namespace ImageClick
{
    public partial class ImageClickForm : Form
    {

        string[] picturesStringArray;
        int difficultyInt = 4;
        int paddingInt = 5;
        bool clickBool = false;
        int imageCountInt = 0;
        bool runButtonBool = true;
        bool revealButtonBool = true;
        bool inGameBool = false;
        int count = 0;

        // used[lines];
        int[] used;
        Random random = new Random();

        public static AutoResetEvent arEvent = new AutoResetEvent(false);

        // true means not guessed
        bool[,] fieldBool;
        Image image;
        Graphics graphics;



        public ImageClickForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string pathString = folderBrowserDialog1.SelectedPath;
            // MessageBox.Show(pathString);
            if (pathString != "")
            {
                if (Directory.Exists(pathString))
                {
                    picturesStringArray = Directory.GetFiles(pathString, "*.jpg");
                    if (picturesStringArray.Length == 0)
                    {
                        MessageBox.Show("Keine JPG Dateien im Verzeichnis vorhanden");
                    }
                    else
                    {
                        fieldBool = new bool[difficultyInt, difficultyInt];
                        used = new int[difficultyInt];
                        imageCountInt = 0;
                        revealButton.Enabled = true;
                        revealEverythingButton.Enabled = true;
                        resetArray();
                        inGameBool = true;
                        image = Image.FromFile(picturesStringArray[0]);
                        runButtonBool = false;
                        startButton.Text = "Nächstes Bild";
                        startButton.Enabled = false;
                        revealButton.Visible = true;
                        revealEverythingButton.Visible = true;
                        gameVoid(picturesStringArray[imageCountInt]);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //graphics = CreateGraphics();
        }

        private void gameVoid(string fileString)
        {
            image.Dispose();
            image = Image.FromFile(fileString);
            drawGrid(image.Width, image.Height, difficultyInt, paddingInt);
            pictureBox1.Image = image;
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
                revealButton.Text = "Aufdecken";
                revealEverythingButton.Enabled = true;
                resetArray();
                if (imageCountInt == picturesStringArray.Length)
                {
                    finished();
                }
                else
                { gameVoid(picturesStringArray[imageCountInt]); }

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
                revealButton.Text = "Aufdecken";
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
            bool buffer = true;
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
                        revealButton.Text = "Nächsten Bild";
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
                //Thread.Sleep(500);
                //revealEverything();
            }
            else
            {
                timer1.Enabled = false;
                revealButtonBool = false;
                revealButton.Text = "Nächstes Bild";
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

                if (inGameBool)
                {
                    fieldBool = new bool[difficultyInt, difficultyInt];
                    used = new int[difficultyInt];
                    count = 0;
                    revealButtonBool = true;
                    revealButton.Text = "Aufdecken";
                    revealEverythingButton.Enabled = true;
                    resetArray();
                    if (imageCountInt == picturesStringArray.Length)
                    {
                        finished();
                    }
                    else
                    { gameVoid(picturesStringArray[imageCountInt]); }
                }
                //Application.Restart();
            }
        }

        private void finished()
        {
            MessageBox.Show("Zuende");
            startButton.Enabled = true;
            startButton.Text = "Spiel starten";
            revealButton.Enabled = false;
            revealEverythingButton.Enabled = false;
            inGameBool = false;
        }

    }
}
