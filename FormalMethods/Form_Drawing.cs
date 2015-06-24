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
        List<Node> NDFAnodes = new List<Node>();
        List<Node> DFAnodes = new List<Node>();
        Dictionary<Node, char> nodes = new Dictionary<Node, char>();
        string NDFA = "NULL";

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

            NDFA = regExtoNDFA(regEx);
            
            byte[] output = wrapper.GenerateGraph(NDFA, Enums.GraphReturnType.Png);
            //byte[] output2 = wrapper.GenerateGraph("digraph{" + stringAnalyzer(regEx) + "}",Enums.GraphReturnType.Png);
            MemoryStream ms = new MemoryStream(output);
            pictureBox1.Image = Image.FromStream(ms);
        }

        public void drawDFA()
        {
            if (NDFA != "NULL")
            {
                List<char> labels = new List<char>();
                List<string> nodeTransitions = NDFA.Split(';').ToList<string>();
                for (int i = 1; i < nodeTransitions.Count; i++)
                {
                    string nodeName = "";
                    char c = ' ';
                    int j = 0;
                    while (c != '-' && c != '[')
                    {
                        c = nodeTransitions[i][j];
                        if (c == '-' || c == '[')
                            break;
                        nodeName += c;
                        j++;
                    }

                    bool sameName = false;
                    for (int x = 0; x < NDFAnodes.Count; x++)
                    {
                        if (NDFAnodes[x].NodeName == nodeName)
                            sameName = true;
                    }
                    if (!sameName)
                        NDFAnodes.Add(new Node(nodeName));
                    if (NDFAnodes.Count == 0)
                    {
                        NDFAnodes.Add(new Node(nodeName));
                    }

                }

                for (int i = 1; i < nodeTransitions.Count - 1; i++)
                {
                    string nodeName = "";
                    char c = ' ';
                    int j = 0;
                    while (c != '-' && c != '[')
                    {
                        c = nodeTransitions[i][j];
                        if (c == '-' || c == '[')
                            break;
                        nodeName += c;
                        j++;
                    }
                    List<string> splitString = nodeTransitions[i].Split('[').ToList<string>();
                    string secondNodeName = splitString[0].Substring(j + 2);
                    char label = splitString[1][8];
                    for (int x = 0; x < NDFAnodes.Count; x++)
                    {
                        if (NDFAnodes[x].NodeName == nodeName)
                        {
                            for (int z = 0; z < NDFAnodes.Count; z++)
                            {
                                if (NDFAnodes[z].NodeName == secondNodeName)
                                {
                                    NDFAnodes[x].transistions.Add(NDFAnodes[z], label);
                                    if (!labels.Contains(label) && label != 'e')
                                        labels.Add(label);
                                }
                            }
                        }
                    }
                }

                Node newNode = new Node(NDFAnodes[0].NodeName);
                newNode.transistions = newNode.transistions.Union(NDFAnodes[0].transistions).ToDictionary(k => k.Key, v => v.Value);
                for (int i = 0; i < NDFAnodes[0].transistions.Count; i++)
                {
                    newNode = makeNode(NDFAnodes[0].transistions.ElementAt(i).Key, NDFAnodes[0].transistions.ElementAt(i).Value, false, newNode);
                }
                DFAnodes.Add(newNode);
                while (newNode.transistions.Count != 0)
                {
                    //Node newNode2 = new Node(newNode.transistions.ElementAt(0).Key.NodeName);
                    //newNode2.transistions = newNode2.transistions.Union(NDFAnodes[j].transistions).ToDictionary(k => k.Key, v => v.Value);
                    nodes = new Dictionary<Node, char>();
                    for (int i = 0; i < newNode.transistions.Count; i++)
                    {
                        Node newNode2 = new Node("");
                        bool makeNew = false;
                        for (int j = 0; j < nodes.Count; j++)
                        {
                            if (!nodes.ContainsValue(newNode.transistions.ElementAt(i).Value))
                            {
                                makeNew = true;
                            }
                            else
                            {
                                newNode2 = new Node(nodes.ElementAt(j).Key.NodeName);
                                newNode2.transistions = newNode2.transistions.Union(nodes.ElementAt(j).Key.transistions).ToDictionary(k => k.Key, v => v.Value);
                            }
                        }

                        newNode2.NodeName += newNode.transistions.ElementAt(i).Key.NodeName;
                        newNode2.transistions = newNode2.transistions.Union(newNode.transistions.ElementAt(i).Key.transistions).ToDictionary(k => k.Key, v => v.Value);
                        for (int r = 0; r < newNode2.transistions.Count; r++)
                        {

                            if (newNode2.transistions.ElementAt(r).Value == 'e')
                            {
                                for (int l = 0; l < labels.Count; l++)
                                {
                                    Node newNode2old = new Node(newNode2);
                                    newNode2 = makeNode(newNode2.transistions.ElementAt(r).Key, labels[l], true, newNode2);
                                    if (!nodes.ContainsValue(labels[l]))
                                    {
                                        nodes.Add(newNode2, labels[l]);
                                    }
                                    else
                                    {
                                        int w = 0;
                                        for (int q = 0; q < nodes.Count; q++)
                                        {
                                            if (nodes.ElementAt(q).Value == labels[l])
                                            {
                                                w = q;
                                            }
                                        }
                                        nodes.ElementAt(w).Key.NodeName = newNode2.NodeName;
                                        nodes.ElementAt(w).Key.transistions = newNode2.transistions.Union(nodes.ElementAt(w).Key.transistions).ToDictionary(k => k.Key, v => v.Value);
                                    }
                                    newNode2 =  new Node(newNode2old);
                                }
                            }
                            else
                            {

                                newNode2 = makeNode(newNode2.transistions.ElementAt(r).Key, newNode.transistions.ElementAt(i).Value, false, newNode2);
                                if (!nodes.ContainsValue(newNode.transistions.ElementAt(i).Value))
                                {
                                    //nodes.Add(newNode2, newNode.transistions.ElementAt(i).Value);
                                }
                                else
                                {
                                    int w = 0;
                                    for (int q = 0; q < nodes.Count; q++)
                                    {
                                        if (nodes.ElementAt(q).Value == newNode.transistions.ElementAt(i).Value)
                                        {
                                            w = q;
                                        }
                                    }
                                    nodes.ElementAt(w).Key.NodeName = newNode2.NodeName;
                                    nodes.ElementAt(w).Key.transistions = newNode2.transistions.Union(nodes.ElementAt(w).Key.transistions).ToDictionary(k => k.Key, v => v.Value);
                                }
                            }
                            string test2 = "test";
                            newNode = new Node(newNode2);
                        }
                    }
                }
                string test = "test";
            }
        }



        public Node makeNode(Node n,char transistion, bool canTrans,Node NewNode)
        {
            NewNode.NodeName += n.NodeName;
            NewNode.transistions = NewNode.transistions.Union(n.transistions).ToDictionary(k => k.Key, v => v.Value);

            for(int i =0 ;i < n.transistions.Count;i++)
            {
                if (n.transistions.ElementAt(i).Value == 'e')
                {
                    makeNode(n.transistions.ElementAt(i).Key, transistion, canTrans,NewNode);
                }
                else
                {
                    if (n.transistions.ElementAt(i).Value == transistion && canTrans)
                    {
                        makeNode(n.transistions.ElementAt(i).Key, transistion, false, NewNode);
                    }
                }
            }
            return NewNode;
        }

        public string stringAnalyzer(string s)
        {
            string output = "node [shape=circle];0 -> 1[label= ε];";
            output += "1->2[label=" + s + "]; 2[shape=doublecircle];";
            return output;
        }

        public void drawRegexToNDFA(List<NodeArrow> arrows)
        {
            if (arrows.Count > 0) {
                var getStartProcessQuery = new GetStartProcessQuery();
                var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
                var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

                var wrapper = new GraphGeneration(getStartProcessQuery, getProcessStartInfoQuery, registerLayoutPluginCommand);

                StringBuilder sb = new StringBuilder("digraph{node [shape=circle]; rankdir=LR;");
                sb.Append("x->" + arrows[0].getFromNode() + "; x[shape=point]");
                for (int i = 0; i < arrows.Count; i++)
                {
                    sb.Append(arrows[i].ToString());
                }
                sb.Append("}");

                byte[] output = wrapper.GenerateGraph(sb.ToString(), Enums.GraphReturnType.Png);
                MemoryStream ms = new MemoryStream(output);
                pictureBox1.Image = Image.FromStream(ms);
            }            
        }

        public void drawGrammarToNDFA(List<NodeArrow> arrows)
        {

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
