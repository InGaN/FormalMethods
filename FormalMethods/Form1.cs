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
        public Form1()
        {
            InitializeComponent();
        }

        private List<NodeArrow> parseRegularExpression(string regex)
        {
            RegExSection currentSection = new RegExSection("");
            bool fillSection = false;
            for (int i = 0; i < regex.Length; i++)
            {
                if (regex[i] == ')') { fillSection = false; }
                if (fillSection) {
                    currentSection.add(regex[i]);
                }
                if (regex[i] == '(') { fillSection = true; }                
            }

            int currentNode = 0;
            int nextNode = 1;
            List<NodeArrow> arrows = new List<NodeArrow>();

            for (int i = 0; i < currentSection.Length; i++)
            {
                NodeArrow arrow = new NodeArrow(currentNode.ToString(), nextNode.ToString(), currentSection.getSection()[i].ToString());
                arrows.Add(arrow);
                currentNode++;
                nextNode++;
            }
            
            Console.WriteLine(currentSection.getSection());
            return arrows;
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
            formDraw.regExtoNDFA(regexTextBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Drawing formDraw = new Form_Drawing();
            formDraw.Show();
            formDraw.drawNDFA(parseRegularExpression(regexTextBox.Text));
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

        public override string ToString()
        {
            return fromNode + " -> " + toNode + " [label = " + label + "];";
        }

        public string getFromNode() { return fromNode; }
        public string getToNode() { return toNode; }
        public string getLabel() { return label; }
    }
}
