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
        private void Form1_Shown(object sender, EventArgs e)
        {
            changeCheckboxes1();
        }

        private List<NodeArrow> parseRegularExpression(string regex)
        {
            List<RegExSection> sections = new List<RegExSection>(); // a section is part of the regex between ( and )     
            List<NodeArrow> arrows = new List<NodeArrow>(); // arrows between 2 nodes

            bool fillSection = false;

            RegExSection currentSection = new RegExSection(""); 
            for (int i = 0; i < regex.Length; i++)
            {
                if (regex[i] == ')') { 
                    fillSection = false;
                    if (currentSection.Length != 0) { 
                        sections.Add(currentSection);
                        currentSection = new RegExSection("");
                    }
                }
                if (fillSection) {
                    currentSection.add(regex[i]);
                }
                if (regex[i] == '(') { fillSection = true; }                
            }

            for (int i = 0; i < sections.Count; i++) 
            {
                List<NodeArrow> arrowsPipe = parseRegexPipes(sections[i].getSection());
                for (int x = 0; x < arrowsPipe.Count; x++)
                {
                    arrows.Add(arrowsPipe[x]);
                }
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
                    arrows.Add(new NodeArrow(nodes[currentNode], nodes[nodeCounter], 'ε'));
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
            else // no | present
            {
                for(int i = 0; i < input.Length; i++)
                {
                    arrows.Add(new NodeArrow(nodes[nodeCounter], nodes[nodeCounter + 1], input[i]));
                    nodeCounter++;
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
            if (rb1_regex.Checked) { formDraw.drawNDFA(parseRegularExpression(regexTextBox.Text)); formDraw.Text = "Regex -> NDFA";  }
            else if (rb1_grammar.Checked) { formDraw.Text = "Grammar -> NDFA"; }

            formDraw.Show();            
        }

        private void regexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button2_Click(null, null); }
        }

        // Checkbox behavior
        private void rb1_regex_CheckedChanged(object sender, EventArgs e) { changeCheckboxes1(); }
        private void rb2_grammar_CheckedChanged(object sender, EventArgs e) { changeCheckboxes1(); }
        private void changeCheckboxes1()
        {
            if (rb1_regex.Checked) { regexTextBox.Enabled = label_regex.Enabled = true; grammarTextBox.Enabled = label_grammar.Enabled = false; btn_Grammar.Enabled = true; }
            else if (rb1_grammar.Checked) { regexTextBox.Enabled = label_regex.Enabled = false; grammarTextBox.Enabled = label_grammar.Enabled = true; btn_Grammar.Enabled = false; }
        }

        private void btn_Grammar_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LanguageTextBox.Text = (LanguageTextBox.Text.Length == 0) ? "S,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34" : "";
            regexTextBox.Text = (regexTextBox.Text.Length == 0) ? "(aab|abab|b)(ab)(a|b)" : "";       

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"spider.wav");
            //player.Play();
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
