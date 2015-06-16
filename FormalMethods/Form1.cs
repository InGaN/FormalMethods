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
    public partial class Form1 : Form
    {
        private string[] nodes;
        private int nodeCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private List<NodeArrow> parseRegularExpression(string regex)
        {
            RegExSection currentSection = new RegExSection(""); // a section is part of the regex between ( and )
            bool fillSection = false;
            for (int i = 0; i < regex.Length; i++)
            {
                if (regex[i] == ')') { fillSection = false; }
                if (fillSection) {
                    currentSection.add(regex[i]);
                }
                if (regex[i] == '(') { fillSection = true; }                
            }


            List<NodeArrow> arrows = new List<NodeArrow>();

            List<NodeArrow> arrowsPipe = parseRegexPipes(currentSection.getSection());
            for (int i = 0; i < arrowsPipe.Count; i++)
            {
                arrows.Add(arrowsPipe[i]);
            }

            //for (int i = 0; i < currentSection.Length; i++)
            //{
            //    NodeArrow arrow = new NodeArrow(nodes[nodeCounter], nodes[nodeCounter + 1], currentSection.getSection()[i].ToString());
            //    arrows.Add(arrow);
            //    nodeCounter++;
            //}
            
            Console.WriteLine(currentSection.getSection());
            nodeCounter = 0;
            return arrows;
        }

        private List<NodeArrow> parseRegexPipes(string input)
        {
            List<NodeArrow> arrows = new List<NodeArrow>();
            if (input.Contains('|'))
            {
                string[] sections = input.Split('|');             
                int lastNode = 0;
                int currentNode = nodeCounter;
                // first create ε arrows for each | in regex section
                for (int i = 0; i < sections.Length; i++)
                {
                    lastNode += (sections[i].Length-1);                    
                    nodeCounter++;
                    arrows.Add(new NodeArrow(nodes[currentNode], nodes[nodeCounter], "ε"));
                }

                lastNode += nodeCounter;
                lastNode += 1; // one additional step
                string finalNode = nodes[nodeCounter + lastNode];
                int nodeCounterPipes = nodeCounter - sections.Length;
                nodeCounter++;
                for (int i = 0; i < sections.Length; i++)
                {
                    nodeCounterPipes++;
                    Console.WriteLine(sections[i]);
                    for (int i2 = 0; i2 < sections[i].Length; i2++)
                    {                        
                        if (i2 == 0) // first char
                        {                            
                            arrows.Add(new NodeArrow(nodes[nodeCounterPipes], nodes[nodeCounter], sections[i][i2]));
                        }
                        else if (i2 == (sections[i].Length - 1)) // final char
                        {
                            arrows.Add(new NodeArrow(nodes[nodeCounter], nodes[lastNode], sections[i][i2]));
                            nodeCounter++;
                        }
                        else // all in between
                        {
                            arrows.Add(new NodeArrow(nodes[nodeCounter], nodes[nodeCounter + 1], sections[i][i2]));
                            nodeCounter++;
                        }
                    }
                }
                
            } 
            return arrows;
        }

        private string[] parseNodes(string input)
        {
            return (input.Trim()).Split(',');
        }

        private void parseM()
        {
            string[] separators = {">", "\r\n"};
            string[] input = ((grammarTextBox.Text).Trim()).Split(separators, StringSplitOptions.RemoveEmptyEntries);

            FMCollection[] fmArray = new FMCollection[input.Length / 2];
            for (int idx = 0; idx < input.Length; idx++) {
                if(idx%2==0)
                    fmArray[idx/2] = new FMCollection(input[idx]);
                else {
                    string[] steps = (input[idx]).Split('|');                    
                    (fmArray[idx/2]).addSteps(steps);
                }                    
            }

            Console.WriteLine("=== printing steps ===");
            for (int idx = 0; idx < fmArray.Length; idx++) {
                Console.WriteLine(fmArray[idx].ToString());
            }

            Form_Drawing formDraw = new Form_Drawing();
            formDraw.Show();
            formDraw.drawDFA(fmArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //parseM(); 
            Form_Drawing formDraw = new Form_Drawing();
            formDraw.Show();
            formDraw.drawNDFA(regexTextBox.Text);
            //formDraw.regExtoNDFA(regexTextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Drawing formDraw = new Form_Drawing();
            nodes = parseNodes(LanguageTextBox.Text);
            formDraw.Show();
            formDraw.drawNDFA(parseRegularExpression(regexTextBox.Text));
        }

        private void regexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button2_Click(null, null); }
        }
    }

    public class FMCollection
    {
        private string startCharacter;
        private string[] steps;

        public FMCollection(string character)
        {
            startCharacter = character;
        }
        public FMCollection(string character, string[] input)
        {
            startCharacter = character;
            steps = input;
        }
        public void addSteps(string[] input)
        {
            steps = input;
        }
        public override string ToString()
        {
            string output = "(" + startCharacter + ">";
            for (int idx = 0; idx < steps.Length; idx++) {
                output += steps[idx];
                if (idx < steps.Length - 1)
                    output += "|";
            }
            output += ")";
            return output;
        }

        public string getStartCharacter() { return startCharacter; }
        public string[] getSteps() { return steps; }
    }

    public class RegExSection
    {
        private string section;
        private System.Text.StringBuilder sb;
        public int Length;

        public RegExSection(string section)
        {
            this.section = section;
            sb = new System.Text.StringBuilder(section);
            this.Length = section.Length;
        }

        public void add(string addition)
        {
            sb.Append(addition);
            this.section = sb.ToString();
            this.Length += addition.Length;
        }
        public void add(char addition)
        {
            sb.Append(addition);
            this.section = sb.ToString();
            this.Length++;
        }

        public string getSection() { return section; }
    }

    public class NodeArrow
    {
        private string fromNode;
        private string toNode;
        private string label;

        public NodeArrow(string from, string to, string label)
        {
            fromNode = from;
            toNode = to;
            this.label = label;
        }
        public NodeArrow(string from, string to, char label)
        {
            fromNode = from;
            toNode = to;
            this.label = label.ToString();
        }

        public override string ToString()
        {
            return fromNode + " -> " + toNode + " [label = " + label + "];";
        }

        public string getFromNode() { return fromNode; }
        public string getToNode() { return toNode; }
        public string getLabel() { return label; }
    }
}
