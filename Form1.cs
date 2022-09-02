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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Classes;

namespace Safari_app
{
    public partial class Form1 : Form
    {
        //check which animel will created
        //can be changed with checking the radio box accordingly
        //0 for rabbit    1 for giraffe
        int which_animel = -1;
        AnimelList animels = new AnimelList();
        int hunger_counter = 0;

        public Form1()
        {
            InitializeComponent();
            animels.Add(new Lion(500, 250));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //hunt enabler
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            animels.Hunt(hunt_check_box.Checked);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            switch (which_animel)
            {
                case 0 :    //create rabbit
                    animels.Add(new Rabbit(coordinates.X, coordinates.Y));
                    break;
                case 1:     //create giraffe
                    animels.Add(new Giraffe(coordinates.X, coordinates.Y));
                    break;
                case 2:
                    animels.Add(new Deer(coordinates.X, coordinates.Y));
                    break;
                case 3:
                    animels.Add(new Zebra(coordinates.X, coordinates.Y));
                    break;
                default:
                    break;
            }
            
        }

        //Rabbit selector
        private void Rabbit_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 0;
        }

        //Giraffe selector
        private void Giraffe_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 1;
        }

        private void Deer_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 2;
        }

        private void Zebra_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 3;
        }

        //draw all objects to the screen
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            animels.DrawAll(g);
        }

        //moves all the objects on screen according to timer.
        private void moveTimerEvent(object sender, EventArgs e)
        {
            hunger_counter++;
            if (hunger_counter % 3 == 0)        //hold the decrement of lion progress bar.
            {
                lion_progress_bar.Increment(-1);
                hunger_counter = 0;
            }

            if (lion_progress_bar.Value == lion_progress_bar.Maximum)
                hunt_check_box.Checked = false;
            lion_progress_bar.Increment(animels.MoveAll() * 10);        //move lion progress bar according to eaten animal.
            this.Refresh();
        }

        //save button
        private void save_button_Click(object sender, EventArgs e)
        {
            timer1.Stop();              //stop moving the items when trynig to save.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "safary file (*.sff)|*.sff|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, animels);
                }
            }
            timer1.Start();             //continue items movment after the save try.
        }

        private void open_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "safary file (*.sff)|*.sff|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                animels = (AnimelList)binaryFormatter.Deserialize(stream);
                pictureBox1.Invalidate();
                lion_progress_bar.Increment(-100);           //reset lion hunger
                hunt_check_box.Checked = false;              //reset hunt check box
            }
        }

        private void performBarProgress(object sender, EventArgs e)
        {

        }
    }
}
