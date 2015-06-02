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

        public void drawDFA(FMCollection[] collection)
        {
            Console.WriteLine("Drawing DFA");
            for (int idx = 0; idx < collection.Length; idx++) {
                string character = collection[idx].getStartCharacter();
                drawCircle(character, 50 + (idx * 80), 50);
            }
        }


        public void drawCircle(string character, float x, float y)
        {            
            var fontFamily = new FontFamily("Verdana");
            var font = new Font(fontFamily, 32, FontStyle.Regular, GraphicsUnit.Pixel);

            System.Drawing.Graphics graphics = this.CreateGraphics();            
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)x, (int)y, 50, 50);
            
            graphics.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.GhostWhite), rectangle);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);

            //graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);


            graphics.DrawString(character, font, Brushes.Black, x, y);
        }
       
    }
}
