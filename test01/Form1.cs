using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test01
{
    public partial class Form1 : Form

    {
        Point start;
        Pen pen;
        float r; 
        double sin;
        double cos;
        float paramX;
        float paramY;
        float radius; 
        int parameter; 
        int BPM = 16;
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();

        public Form1()

        {
            InitializeComponent();
            start = new Point(200, 200);
            pen = new Pen(Color.Black, 1);
            r = 15; //物体の半径
            sin = Math.Sin(parameter * (Math.PI / 180));
            cos = Math.Cos(parameter * (Math.PI / 180));
            paramX = (float)(cos * radius) + start.X;
            paramY = (float)(sin * radius) + start.Y;
            radius = 100;
            parameter = 0;

            this.DoubleBuffered = true;
            this.BackColor = SystemColors.Window;

            //Timer

            timer1.Interval = BPM;
            timer1.Tick += new EventHandler(Update1);
            timer1.Start();

            timer2.Interval = BPM;
            timer2.Tick += new EventHandler(Update2);
            timer2.Start();

        }

        private void Update1(object sender, EventArgs e)

        {
            Invalidate();
            parameter += 8;
            if (parameter == 360)
            {
                parameter = 0;
            }
            sin = Math.Sin(parameter * (Math.PI / 180));
            cos = Math.Cos(parameter * (Math.PI / 180));
            paramX = (float)(cos * radius) + start.X;
            paramY = (float)(sin * radius) + start.Y;    
        }
        private void Update2(object sender, EventArgs e)

        {
            Invalidate();
            parameter += 4;
            if (parameter == 360)
            {
                parameter = 0;
            }
            sin = Math.Sin(parameter * (Math.PI / 180));
            cos = Math.Cos(parameter * (Math.PI / 180));
            paramX = (float)(cos * radius) + start.X;
            paramY = (float)(sin * radius) + start.Y;
        }


        protected override void OnPaint(PaintEventArgs e)

        {
            Graphics graphics = e.Graphics;
            graphics.DrawEllipse(pen, paramX, paramY, r, r);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out BPM))
            {
                if(int.Parse(textBox1.Text) == 0)
                {
                    timer1.Interval = 1;
                    textBox1.Text = "";
                }
                else
                {
                    timer1.Interval = int.Parse(textBox1.Text);
                }

            }
            else
            {
                timer1.Interval = 1;
                textBox1.Text = "";
            }
        }
    }
}
