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
        int counter = 0;
        int endCounter = 1;

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
                                //i -= 1;
                                sections.Add(section);
                                break;
                            }
                        }
                    }
                    if(!exceptions.Contains(regEx[i]))
                    {
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
                        if (i == regEx.Length)
                        {
                            sections.Add(section);
                            break;
                        }
                    }
                    if(regEx[i].Equals('+'))
                    {
                        List<char> section = new List<char> { '+' };
                        sections.Add(section);
                    }
                    if(regEx[i].Equals('*'))
                    {
                        List<char> section = new List<char> { '*' };
                        sections.Add(section);
                    }
                    if(regEx[i].Equals('|'))
                    {
                        List<char> section = new List<char> { '|' };
                        sections.Add(section);
                    }
                }

            for (int i = 0; i < sections.Count;i++)
            {
                if (sections[i][0].Equals('+') && canWrite(i,sections))
                {
                    startNDFA += addPlusBrackets(sections, i);
                }
                if(sections[i][0].Equals('*') && canWrite(i,sections))
                {
                    startNDFA += addMulitplyBrackets(sections, i);
                }
                if(sections[i][0].Equals('|'))
                {
                    startNDFA += addOther(sections, i);
                }
                if (!exceptions.Contains(sections[i][0]) && canWrite(i, sections) )
                {
                    startNDFA += addString(sections[i]);
                }

            }


            endCounter -= 1;
            startNDFA += endCounter + "[shape=doublecircle]";
            startNDFA += endNDFA;



                return startNDFA;
        }

        public bool canWrite(int counter2,List<List<char>> sections)
        {
            if (counter2 - 1 != -1 && counter2 -2 != -1 && counter2 != -2)
            {
                if (!sections[counter2-1][0].Equals('|') && !sections[counter2-2][0].Equals('|'))
                {
                    if (counter2 + 1 != sections.Count)
                    {
                        if (!exceptions.Contains(sections[counter2 + 1][0]))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (counter2 + 1 != sections.Count)
                {
                    if (!exceptions.Contains(sections[counter2 + 1][0]))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public string addString(List<char> section)
        {
            string NDFA = "";
            string secString = new string(section.ToArray());
            if (secString.Contains('|'))
            {
                string firstPart = secString.Substring(0, secString.IndexOf('|'));
                string secondPart = secString.Substring(secString.IndexOf('|') + 1);
                int starter1 = counter;
                NDFA += counter + "->" + endCounter + "[label = e];";
                counter++;
                endCounter++;
                NDFA += addString(firstPart.ToList());
                int starter2 = counter;

                NDFA += starter1 + "->" + endCounter + "[label = e];";
                counter++;
                endCounter++;
                NDFA += addString(secondPart.ToList());

                NDFA += starter2 + "->" + endCounter + "[label = e];";
                NDFA += counter + "->" + endCounter + "[label = e];";
                counter++;
                endCounter++;


            }
            else
            {
                for (int j = 0; j < section.Count; j++)
                {
                    if (j + 1 != section.Count)
                    {
                        if (section[j + 1].Equals('*'))
                        {
                            int starter1 = counter;
                            int starter2 = endCounter;
                            NDFA += counter + "->" + endCounter + "[label = e];";
                            counter++;
                            endCounter++;
                            NDFA += counter + "->" + endCounter + "[label = " + section[j] + "];";
                            counter++;
                            endCounter++;

                            NDFA += counter + "->" + endCounter + "[label = e];";
                            NDFA += counter + "->" + starter2 + "[label = e];";
                            NDFA += starter1 + "->" + endCounter + "[label = e];";
                            counter++;
                            endCounter++;
                        }
                        if(section[j+1].Equals('+'))
                        {
                            int starter = endCounter;
                            NDFA += counter + "->" + endCounter + "[label = e];";
                            counter++;
                            endCounter++;
                            NDFA += counter + "->" + endCounter + "[label = " + section[j] + "];";
                            counter++;
                            endCounter++;
                            NDFA += counter + "->" + endCounter + "[label = e];";
                            NDFA += counter + "->" + starter + "[label = e];";
                            counter++;
                            endCounter++;
                        }
                        if(!section[j+1].Equals('+') && !section[j+1].Equals('*') && !section[j].Equals('+') && !section[j].Equals('*'))
                        {
                            NDFA += counter + "->" + endCounter + "[label = " + section[j] + "];";
                            counter++;
                            endCounter++;
                        }
                    }
                    else
                    {
                        if (!section[j].Equals('+') && !section[j].Equals('*'))
                        {
                            NDFA += counter + "->" + endCounter + "[label = " + section[j] + "];";
                            counter++;
                            endCounter++;
                        }
                    }


                    //NDFA += counter + "->" + endCounter + "[label = " + section[j] + "];";
                    //counter++;
                    //endCounter++;
                }
            }
            return NDFA;
        }

        public string addOther(List<List<char>> sections,int counter2)
        {
            string NDFA = "";
            int starter1 = counter;
            NDFA += counter + "->" + endCounter + "[label = e];";
            counter++;
            endCounter++;
            if(sections[counter2-1][0].Equals('+'))
            {
                NDFA += addPlusBrackets(sections, counter2 - 1);
            }
            if(sections[counter2-1][0].Equals('*'))
            {
                NDFA += addMulitplyBrackets(sections, counter2 - 1);
            }
            if(!sections[counter2-1][0].Equals('+') && !sections[counter2-1][0].Equals('*'))
            {
                NDFA += addString(sections[counter2 - 1]);
            }
            //int starter2 = endCounter + sections[counter2 + 1].Count + 1;
            int starter2 = counter;
            //NDFA += counter + "->" + starter2 + "[label = e];";
            NDFA += starter1 + "->" + endCounter + "[label = e];";
            counter++;
            endCounter++;
            if (counter2 + 2 != sections.Count)
            {
                if (sections[counter2 + 2][0].Equals('+'))
                {
                    NDFA += addPlusBrackets(sections, counter2 + 2);
                }
                if (sections[counter2 + 2][0].Equals('*'))
                {
                    NDFA += addMulitplyBrackets(sections, counter2 + 2);
                }
                if (!sections[counter2 + 2][0].Equals('+') && !sections[counter2 + 2][0].Equals('*'))
                {
                    NDFA += addString(sections[counter2 + 1]);
                }
            }
            else
            {
                NDFA += addString(sections[counter2 + 1]);
            }
            NDFA += starter2 + "->" + endCounter + "[label = e];";
            NDFA += counter + "->" + endCounter + "[label = e];";
            counter++;
            endCounter++;
            return NDFA;
        }

        public string addPlusBrackets(List<List<char>> sections,int counter2)
        {
            string NDFA = "";
            int starter = endCounter;
            NDFA += counter + "->" + endCounter + "[label = e];";
            counter++;
            endCounter++;
            NDFA += addString(sections[counter2 - 1]);
            NDFA += counter + "->" + endCounter + "[label = e];";
            NDFA += counter + "->" + starter + "[label = e];";
            counter++;
            endCounter++;
            return NDFA;
        }

        public string addMulitplyBrackets(List<List<char>> sections,int counter2)
        {
            int starter1 = counter;
            int starter2 = endCounter;
            string NDFA = "";
            NDFA += counter + "->" + endCounter + "[label = e];";
            counter++;
            endCounter++;
            //for (int j = 0; j < sections[i - 1].Count; j++)
            //{
            //    NDFA += counter + "->" + endCounter + "[label = " + sections[i - 1][j] + "];";
            //    counter++;
            //    endCounter++;
            //}
            NDFA+= addString(sections[counter2-1]);

            NDFA += counter + "->" + endCounter + "[label = e];";
            NDFA += counter + "->" + starter2 + "[label = e];";
            NDFA += starter1 + "->" + endCounter + "[label = e];";
            counter++;
            endCounter++;
            return NDFA;
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

            byte[] output = wrapper.GenerateGraph(regExtoNDFA(regEx), Enums.GraphReturnType.Png);
            //byte[] output2 = wrapper.GenerateGraph("digraph{" + stringAnalyzer(regEx) + "}",Enums.GraphReturnType.Png);
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

            StringBuilder sb = new StringBuilder("digraph{node [shape=circle]; rankdir=LR;");
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
