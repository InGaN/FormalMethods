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
        Form_Drawing formDraw;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            changeCheckboxes1();
        }

        private void btn_NDFA1_Click(object sender, EventArgs e)
        {
            formDraw = new Form_Drawing();
            formDraw.Show();
            formDraw.drawNDFA(regexTextBox.Text);
            //formDraw.regExtoNDFA(regexTextBox.Text);
        }

        private void btn_NDFA2_Click(object sender, EventArgs e)
        {
            Form_Drawing formDraw = new Form_Drawing();
            nodes = parseNodes(nodesTextBox.Text);
            if (rb1_regex.Checked) { formDraw.drawRegexToNDFA(parseRegularExpression(regexTextBox.Text)); formDraw.Text = "Regex -> NDFA"; }
            else if (rb1_grammar.Checked) { formDraw.drawRegexToNDFA(parseGrammar(grammarTextBox.Text)); formDraw.Text = "Grammar -> NDFA"; }
            else if (rb1_NDFA.Checked) { formDraw.drawRegexToNDFA(parseNDFA(textBox_table1.Text, textBox_table2.Text, textBox_table3.Text)); formDraw.Text = "NDFA table -> NDFA graph"; }

            formDraw.Show();
        }

        private void regexTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btn_NDFA2_Click(null, null); }
        }

        private void btn_Grammar_Click(object sender, EventArgs e)
        {
            Form_Grammar formGrammar = new Form_Grammar();
            nodes = parseNodes(nodesTextBox.Text);
            if (rb1_regex.Checked) { formGrammar.drawToGrammar(parseRegularExpression(regexTextBox.Text)); formGrammar.Text = "Regex -> Grammar"; }
            else if (rb1_NDFA.Checked) { formGrammar.drawToGrammar(parseNDFA(textBox_table1.Text, textBox_table2.Text, textBox_table3.Text)); formGrammar.Text = "NDFA table -> Grammar"; }
            formGrammar.Show();
        }

        // Checkbox behavior
        private void rb1_regex_CheckedChanged(object sender, EventArgs e) { changeCheckboxes1(); }
        private void rb2_grammar_CheckedChanged(object sender, EventArgs e) { changeCheckboxes1(); }
        private void changeCheckboxes1()
        {
            if (rb1_regex.Checked) { regexTextBox.Enabled = label_regex.Enabled = nodesTextBox.Enabled = label_nodes.Enabled = btn_Grammar.Enabled = btn_NDFA1.Enabled = btn_NDFA2.Enabled = true; grammarTextBox.Enabled = label_grammar.Enabled = tableLayoutPanel_NDFA.Enabled = false; }
            else if (rb1_grammar.Checked) { regexTextBox.Enabled = label_regex.Enabled = nodesTextBox.Enabled = label_nodes.Enabled = btn_Grammar.Enabled = btn_NDFA1.Enabled = tableLayoutPanel_NDFA.Enabled = false; grammarTextBox.Enabled = label_grammar.Enabled = btn_NDFA2.Enabled = true; }
            else if (rb1_NDFA.Checked) { btn_NDFA1.Enabled = label_nodes.Enabled = label_regex.Enabled = label_grammar.Enabled = regexTextBox.Enabled = grammarTextBox.Enabled = nodesTextBox.Enabled = false; tableLayoutPanel_NDFA.Enabled = btn_Grammar.Enabled = btn_NDFA2.Enabled = true; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            nodesTextBox.Text = (nodesTextBox.Text.Length == 0) ? "S, q1, 40" : "";
            regexTextBox.Text = (regexTextBox.Text.Length == 0) ? "(aab|abab|b)(ab)(a|b)" : "";
            grammarTextBox.Text = (grammarTextBox.Text.Length == 0) ? System.Text.RegularExpressions.Regex.Replace("S>a1|b2|a3 \r\n 1>a3 \r\n 2>b3 \r\n 3>a4|a|b \r\n 4>a", @"[^\S\r\n]+", "") : ""; // removes whitespace except newlines
            textBox_table1.Text = (textBox_table1.Text.Length == 0) ? "S\r\n*1\r\n2\r\n3\r\n*4" : "";
            textBox_table2.Text = (textBox_table2.Text.Length == 0) ? "1,3\r\n2\r\n3\r\n3\r\n-" : "";
            textBox_table3.Text = (textBox_table3.Text.Length == 0) ? "2\r\n-\r\nS\r\n2,4\r\n-" : "";
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"spider.wav");
            //player.Play();
        }

        //  #################################          PARSE BEHAVIOR          #################################

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
            string[] vars = (input.Trim()).Split(',');
            string starter = vars[0];
            string incrementer = vars[1];
            int sizer = 0;
            Int32.TryParse(vars[2], out sizer);

            string[] nodes = new string[sizer];

            int n = 0;
            int numPos = 0; // find the numeric value of the incrementer
            for (int x = 0; x < incrementer.Length; x++)
            {                
                if (Int32.TryParse(incrementer[x].ToString(), out n))
                {
                    numPos = x;
                    break;
                }
            }

            string incStart = incrementer.Substring(0, numPos);
            string incEnd = incrementer.Substring(numPos + 1);

            for (int i = 0; i < sizer; i++) {
                incrementer = (incStart + n + incEnd).ToString();
                if (i == 0) {
                    nodes[i] = starter;
                }
                else {
                    nodes[i] = incrementer;
                    n++;
                }
                
            }
            return nodes;
        }

        private List<NodeArrow> parseGrammar(string input)
        {
            List<NodeArrow> arrows = new List<NodeArrow>(); // arrows between 2 nodes
            string[] separators = { ">", "\r\n" };
            string[] grammar = ((input).Trim()).Split(separators, StringSplitOptions.RemoveEmptyEntries);

            FMCollection[] fmArray = new FMCollection[grammar.Length / 2];
            for (int i = 0; i < grammar.Length; i++)
            {
                if (i % 2 == 0)
                    fmArray[i / 2] = new FMCollection(grammar[i]);
                else
                {
                    string[] steps = (grammar[i]).Split('|');
                    (fmArray[i / 2]).addSteps(steps);
                }
            }
            for (int i = 0; i < fmArray.Length; i++)
            {
                for (int i2 = 0; i2 < fmArray[i].getSteps().Length; i2++)
                {
                    if ((fmArray[i].getSteps()[i2]).Length == 1) // no following step, final Node
                    {
                        arrows.Add(new NodeArrow(fmArray[i].getStartCharacter(), fmArray[i].getStartCharacter(), fmArray[i].getSteps()[i2][0], true));
                    }
                    else
                    {
                        arrows.Add(new NodeArrow(fmArray[i].getStartCharacter(), (fmArray[i].getSteps()[i2]).Substring(1), fmArray[i].getSteps()[i2][0]));
                    }
                }                
            }
            return arrows;
        }

        private List<NodeArrow> parseNDFA(string inputNodes, string inputA, string inputB)
        {
            List<NodeArrow> arrows = new List<NodeArrow>();
            string[] separators = { "\r\n" };
            string[] grammar1 = ((inputNodes).Trim()).Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] grammar2 = ((inputA).Trim()).Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] grammar3 = ((inputB).Trim()).Split(separators, StringSplitOptions.RemoveEmptyEntries);

            FMCollection[] fmArray = new FMCollection[grammar1.Length];
            for (int i = 0; i < grammar1.Length; i++)
            {
                string[] stepsA = grammar2[i].Split(',');
                string[] stepsB = grammar3[i].Split(',');                
                for (int x = 0; x < stepsA.Length; x++) {
                    stepsA[x] = (stepsA[x] != "-") ? "a" + stepsA[x] : "-";                
                }
                for (int x = 0; x < stepsB.Length; x++) {
                    stepsB[x] = (stepsB[x] != "-") ? "b" + stepsB[x] : "-";                
                }

                int originalLength = stepsA.Length;
                Array.Resize<string>(ref stepsA, originalLength + stepsB.Length);
                Array.Copy(stepsB, 0, stepsA, originalLength, stepsB.Length );

                fmArray[i] = new FMCollection(grammar1[i], stepsA);                              
            }

            for (int i = 0; i < fmArray.Length; i++)
            {
                int ends = 0;
                for (int i2 = 0; i2 < fmArray[i].getSteps().Length; i2++)
                {                    
                    if ((fmArray[i].getSteps()[i2]) != "-")
                    {
                        if (fmArray[i].getStartCharacter()[0] == '*')
                            arrows.Add(new NodeArrow(fmArray[i].getStartCharacter(), (fmArray[i].getSteps()[i2]).Substring(1), fmArray[i].getSteps()[i2][0], true));
                        else
                            arrows.Add(new NodeArrow(fmArray[i].getStartCharacter(), (fmArray[i].getSteps()[i2]).Substring(1), fmArray[i].getSteps()[i2][0]));
                        
                    }
                    else
                    {
                        ends++;
                        if (ends >= 2)
                        {
                            arrows.Add(new NodeArrow(fmArray[i].getStartCharacter(), fmArray[i].getStartCharacter(), fmArray[i].getSteps()[i2][0], true));
                        }
                    }
                }                
            }

            return arrows;
        }

        private void btn_DFA_Click(object sender, EventArgs e)
        {
            formDraw.drawDFA();
        }       
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
        private bool endNode = false;

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
        public NodeArrow(string from, string to, string label, bool endNode)
        {
            fromNode = from;
            toNode = to;
            this.label = label;
            this.endNode = endNode;
        }
        public NodeArrow(string from, string to, char label, bool endNode)
        {
            fromNode = from;
            toNode = to;
            this.label = label.ToString();
            this.endNode = endNode;
        }

        public override string ToString()
        {
            string final = (this.endNode) ? fromNode + "[shape=doublecircle]" : "";
            return fromNode + " -> " + toNode + " [label = " + label + "];" + final;
        }

        public string getFromNode() { return fromNode; }
        public string getToNode() { return toNode; }
        public string getLabel() { return label; }
        public bool getEndNode() { return endNode; }
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
            for (int idx = 0; idx < steps.Length; idx++)
            {
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
}
