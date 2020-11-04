using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18002529_PROG7312_POE
{
    public partial class CallNumbers : Form
    {
        Tree deweyDecimalsTree;
        List<DeweyObject> lstQuestions;
        List<string> callDescriptions;
        int currentQuestion;

        public CallNumbers()
        {
            InitializeComponent();

            deweyDecimalsTree = new Tree();
            lstQuestions = new List<DeweyObject>();
            callDescriptions = new List<string>();
            currentQuestion = -1;

            txtXP.Text = GlobalXP.XP.ToString() + " xp";

            panelLvl2.Visible = false;
            panelLvl3.Visible = false;

            populateTreeFromFile();           
        }

        private void populateTreeFromFile()
        {
            deweyDecimalsTree.Root = new TreeNode() {};
            deweyDecimalsTree.Root.Children = new List<TreeNode>();

            StreamReader reader = new StreamReader("CallNumbers.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                DeweyObject deweyObject = new DeweyObject();
                deweyObject.callNumbers = Convert.ToInt32(line.Substring(0, 3));
                deweyObject.Description = line.Substring(6);

                int index;
                if(Convert.ToInt32(line.Substring(0,1)) == 0)
                {
                    index = 0;
                }
                else
                {
                    index = (deweyObject.callNumbers - Convert.ToInt32(line.Substring(0, 1) + "00")) / 10;
                }

                if (deweyObject.callNumbers % 10 == 0)
                {
                    deweyDecimalsTree.Root.Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root });
                    deweyDecimalsTree.Root.Children[index].Children = new List<TreeNode>();
                }
                else
                {
                    deweyDecimalsTree.Root.Children[index].Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root.Children[index] });
                }
            }
        }
    }
}
