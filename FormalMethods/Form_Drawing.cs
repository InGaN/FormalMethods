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
        List<char> exceptions = new List<char> { '(', ')', '+', '|', '*' };

        public Form_Drawing()
        {
            InitializeComponent();
        }

        public string regExtoNDFA(string regEx)
        {
            string startNDFA = "digraph{node[shape=circle];";
            string endNDFA = "}";
            List<char> nodes = new List<char>();

            List<List<char>> sections = new List<List<char>>();

            if(!regEx.Contains("(") || !regEx.Contains(")"))
            {
                List<char> section = new List<char>();
                for (int i = 0; i < regEx.Length; i++)
                {
                    section.Add(regEx[i]);
                }
                sections.Add(section);
            }
            else
            {
                for(int i = 0 ;i < regEx.Length;i++)
                {
                    if(regEx[i].Equals('('))
                    {
                        i += 1;
                        List<char> section = new List<char>();
                        for(int j = i;i < regEx.Length;i++)
                        {
                            if (!regEx[i].Equals(')'))
                            {
                                section.Add(regEx[i]);
                            }
                            else
                            {
                                i -= 1;
                                sections.Add(section);
                                break;
                            }
                        }
                    }
                    else
                    {
                        i += 1;
                        List<char> section = new List<char>();
                        for(int j = i; i < regEx.Length;i++)
                        {
                            if(!regEx[i].Equals('('))
                            {
                                section.Add(regEx[i]);
                            }
                            else
                            {
                                i -= 1;
                                sections.Add(section);
                                break;
                            }
                        }
                        sections.Add(section);
                    }
                }
            }
            int x = sections.Count;
            int y = 0;




            //    for (int i = 0; i < regEx.Length; i++)
            //    {
            //        if (!exceptions.Contains(regEx[i]))
            //        {
            //            nodes.Add(regEx[i]);
            //        }
            //        else
            //        {
            //            //TODO
            //        }
            //    }

            //for (int i = 0; i < nodes.Count;i++)
            //{
                
            //}


                return null;
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
            MemoryStream ms = new MemoryStream(output);
            pictureBox1.Image = Image.FromStream(ms);
        }

        public string stringAnalyzer(string s)
        {
            string output = "node [shape=circle];0 -> 1[label= ε];";
            output += "1->2[label=" + s + "]; 2[shape=doublecircle];";
            return output;
        }

        public void drawNDFA(List<NodeArrow> arrows)
        {
            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            var wrapper = new GraphGeneration(getStartProcessQuery, getProcessStartInfoQuery, registerLayoutPluginCommand);

            StringBuilder sb = new StringBuilder("digraph{");
            for (int i = 0; i < arrows.Count; i++)
            {
                sb.Append(arrows[i].ToString());
            }
            sb.Append("}");

            byte[] output = wrapper.GenerateGraph(sb.ToString(), Enums.GraphReturnType.Png);           
            MemoryStream ms = new MemoryStream(output);
            pictureBox1.Image = Image.FromStream(ms);
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
