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
    public partial class Form_Grammar : Form
    {
        public Form_Grammar()
        {
            InitializeComponent();
        }

        public void drawToGrammar(List<NodeArrow> arrows) // huge mess, too tired
        {
            if (arrows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                List<FMCollection> fmList = new List<FMCollection>();
                string starter = "";

                for (int i = 0; i < arrows.Count; i++)
                {
                    if (starter != filterStars(arrows[i].getFromNode()))
                    {
                        starter = filterStars(arrows[i].getFromNode());
                        
                        List<string> steps = new List<string>();

                        for (int x = 0; x < arrows.Count; x++)
                        {
                            if (filterStars(arrows[x].getFromNode()) == starter)
                            {
                                if (arrows[x].getLabel() != "-")
                                {
                                    steps.Add(arrows[x].getLabel() + arrows[x].getToNode());
                                }
                            }
                        }
                        if (steps.Count != 0)
                        {
                            fmList.Add(new FMCollection(starter, steps.ToArray()));
                        }                       
                    }                  
                }
                for (int i = 0; i < fmList.Count; i++)
                {
                    FMCollection item = fmList[i];
                    sb.Append(item.getStartCharacter());
                    for (int x = 0; x < item.getSteps().Length; x++)
                    {
                        if (x == 0)
                            sb.Append(">");
                        else
                            sb.Append("|");
                        sb.Append(item.getSteps()[x]);
                    }
                    sb.Append("\r\n");
                }
                label_grammarForm.Text = sb.ToString();
            }
        }

        private string filterStars(string input)
        {
            string output = input;
            if (input.Contains("*"))
            {
                output = input.Substring(1);
            }
            return output;
        }
    }
}
