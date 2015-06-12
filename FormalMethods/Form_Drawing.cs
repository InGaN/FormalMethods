using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphVizWrapper;
using GraphVizWrapper.Queries;
using GraphVizWrapper.Commands;
using System.IO;

namespace FormalMethods
{
    public partial class Form_Drawing : Form
    {
        public Form_Drawing()
        {
            InitializeComponent();
        }

        public void drawNDFA(string regEx)
        {



            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            // GraphGeneration can be injected via the IGraphGeneration interface

            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);

            byte[] output = wrapper.GenerateGraph("digraph{a -> b [ label = a];b->a; b -> c; c -> a; a[shape=circle,peripheries=2]; x->a; x[shape=none];}", Enums.GraphReturnType.Png);
            byte[] output2 = wrapper.GenerateGraph("digraph{" + stringAnalyzer(regEx) + "}",Enums.GraphReturnType.Png);
            MemoryStream ms = new MemoryStream(output2);
            pictureBox1.Image = Image.FromStream(ms);
        }

        public string stringAnalyzer(string s)
        {
            string output = "node [shape=circle];0 -> 1[label= ε];";
            output += "1->2[label=" + s + "]; 2[shape=doublecircle];";
            return output;
        }

        public void drawDFA(FMCollection[] collection)
        {


            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            // GraphGeneration can be injected via the IGraphGeneration interface

            var wrapper = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);

            byte[] output = wrapper.GenerateGraph("digraph{a -> b [ label = a];b->a; b -> c; c -> a; a[shape=circle,peripheries=2]; x->a; x[shape=none];}", Enums.GraphReturnType.Png);
            MemoryStream ms = new MemoryStream(output);
            pictureBox1.Image = Image.FromStream(ms);

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
