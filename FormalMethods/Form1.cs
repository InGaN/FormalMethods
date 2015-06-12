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
            formDraw.drawNDFA(grammarTextBox.Text);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
        public string ToString()
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
}
