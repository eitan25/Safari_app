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
        Lion l;
        Rabbit r;

        public Form1()
        {
            InitializeComponent();
            l = new Lion(500, 250);
            r = new Rabbit(300, 300);
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
            l.Hunt(checkBox1.Checked);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            l = new Lion(coordinates.X, coordinates.Y);*/
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            which_animel = 1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            l.Draw(g);
            if(r != null)   /////////////////////addad for test
                r.Draw(g);
        }

        //moves all the objects on screen according to timer.
        private void moveTimerEvent(object sender, EventArgs e)
        {
            l.Move(r);
            if (r != null) ///////////////////////added for test
            {
                r.Move();
                if (r.IS_HUNTED == true)
                {
                    checkBox1.Checked = false;
                    r = null;
                }
            }
            this.Refresh();

        }
    }
}
