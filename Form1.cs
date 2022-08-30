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
            animels.Hunt(checkBox1.Checked);
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
                default:
                    break;
            }
            
        }

        //Rabbit selector
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 0;
        }

        //Giraffe selector
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 1;
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
            if(animels.Count() != 1)
                if (animels.Get().IS_HUNTED)
                    checkBox1.Checked = false;
            animels.MoveAll();
            this.Refresh();
        }
    }
}
