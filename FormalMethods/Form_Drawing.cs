using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormalMethods
{
    public partial class Form_Drawing : Form
    {
        public Form_Drawing()
        {
            InitializeComponent();
        }

        public void drawCircles()
        {
            Console.WriteLine("Drawing DFA");
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(50, 50, 150, 150);
            
            graphics.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.Blue), rectangle);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);

            graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
        }
       
    }
}
