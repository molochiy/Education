using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animation
{
    public partial class Animation : Form
    {
        public Animation()
        {
            InitializeComponent();
            snowmans.BackColor = Color.Transparent;
            snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/0.gif");
            eyes.Image = Image.FromFile(@"../../../pictures/eyes.jpg");
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
        }

        int step = 0;

        private void timer_Tick(object sender, EventArgs e)
        {
            int d = 16;

            if (step % d == 0)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/1.gif");
            }

            if (step % d == 1)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/2.gif");
            }

            if (step % d == 2)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/3.gif");
            }

            if (step % d == 3)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/4.gif");
            }

            if (step % d == 4)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/5.gif");
            }

            if (step % d == 5)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/6.gif");
            }

            if (step % d == 6)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/7.gif");
            }

            if (step % d == 7)
            {
                snowmans.Image = Image.FromFile(@"../../../pictures/snowmans/0.gif");
            }

            if (step % 10 == 0)
            {
                eyes.Visible = true;
            }
            else
            {
                eyes.Visible = false;
            }

            if (step % 2 == 0)
            {
                star.Visible = true;
            }
            else
            {
                star.Visible = false;
            }

            int k = 30;

            if (step == k)
            {
                pictureBox1.Visible = true;
            }

            if (step == k + 5)
            {
                pictureBox2.Visible = true;
            }

            if (step == k + 10)
            {
                pictureBox3.Visible = true;
            }

            if (step == k + 15)
            {
                pictureBox4.Visible = true;
            }

            if (step == k + 20)
            {
                pictureBox5.Visible = true;
            }

            if (step == k + 25)
            {
                pictureBox6.Visible = true;
            }

            if (step == k + 30)
            {
                pictureBox7.Visible = true;
            }

            if (step == k + 35)
            {
                pictureBox8.Visible = true;
            }

            if (step == k + 40)
            {
                pictureBox9.Visible = true;
            }

            if (step == k + 45)
            {
                pictureBox10.Visible = true;
            }

            if (step == k + 50)
            {
                pictureBox11.Visible = true;
            }

            if (step == k + 55)
            {
                pictureBox12.Visible = true;
            }

            step++;
        }

        private void Animation_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }
    }
}
