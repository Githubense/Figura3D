using System;
using System.Windows.Forms;

namespace Figuras3D
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        bool x, y, z = false;
        int clickX, clickY, clickZ;

        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(PCT_CANVAS);
            //canvas.Cubo();
            //canvas.Icosahedro();
            canvas.Esfera();
            //canvas.Cono();
            //canvas.Cilindro();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RotarX_Click(object sender, EventArgs e)
        {
            if (clickX == 0)
            {
                timer1.Enabled = true;
                x = true;
                y = z = false;
                clickX= 1;
            }
            else{ 
                timer1.Enabled = false;
                x = false;
                y = z = false;
                clickX = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x)
            {
                y = z = false;
                canvas.RotacionX();
            }
            else if (y)
            {
                x = z = false;
                canvas.RotacionY();
            }
            else if (z)
            {
                x = y = false;
                canvas.RotacionZ();
            }

        }

        private void RotarY_Click(object sender, EventArgs e)
        {
            if (clickY == 0)
            {
                timer1.Enabled = true;
                y = true;
                x = z = false;
                clickY = 1;
            }
            else
            {
                timer1.Enabled = false;
                y = false;
                x = z = false;
                clickY = 0;
            }
        }

        private void RotarZ_Click(object sender, EventArgs e)
        {
            if (clickZ == 0)
            {
                timer1.Enabled = true;
                z = true;
                x = y = false;
                clickZ = 1;
            }
            else
            {
                timer1.Enabled = false;
                z = false;
                x = y = false;

                clickZ = 0;
            }
        }
    }
}
