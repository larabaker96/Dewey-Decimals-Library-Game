using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18002529_PROG7312_Task2
{
    public partial class IdentifyAreas : Form
    {
        IDictionary<string, string> callNumberCategories = new Dictionary<string, string>();
        List<string> questions = new List<string>();

        public IdentifyAreas()
        {
            InitializeComponent();
            panel2.Visible = false;

            txtXP.Text = GlobalXP.XP.ToString() + " xp";

            populateDictionary();

            populateUI();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

            //determines whether the call number and category combination is correct as in dictionary

            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null)
            {
                if (callNumberCategories[textBox1.Text] != comboBox1.SelectedItem.ToString())
                {
                    txtFeedback.Text = "Unfortunately your sorting is incorrect :(";
                }
                else if (callNumberCategories[textBox2.Text] != comboBox2.SelectedItem.ToString())
                {
                    txtFeedback.Text = "Unfortunately your sorting is incorrect :(";
                }
                else if (callNumberCategories[textBox3.Text] != comboBox3.SelectedItem.ToString())
                {
                    txtFeedback.Text = "Unfortunately your sorting is incorrect :(";
                }
                else if (callNumberCategories[textBox4.Text] != comboBox4.SelectedItem.ToString())
                {
                    txtFeedback.Text = "Unfortunately your sorting is incorrect :(";
                }
                else
                {
                    txtFeedback.Text = txtFeedback.Text = "Correct! You earn 100 xp points!";
                    GlobalXP.XP += 100;
                    txtXP.Text = GlobalXP.XP + " xp";
                }
            }
            else
            {
                txtFeedback.Text = "Unfortunately your sorting is incorrect :(";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetUI();
        }

        private void populateDictionary()
        {
            callNumberCategories.Add("001", "Computer Science, Information, General Works");
            callNumberCategories.Add("100", "Philosophy and Psychology");
            callNumberCategories.Add("200", "Religion");
            callNumberCategories.Add("300", "Social Sciences");
            callNumberCategories.Add("400", "Language");
            callNumberCategories.Add("500", "Science");
            callNumberCategories.Add("600", "Technology");
            callNumberCategories.Add("700", "Arts and Recreation");
            callNumberCategories.Add("800", "Literature");
            callNumberCategories.Add("900", "History and Geography");
        }

        private void populateUI()
        {
            //combines all call number descriptions into a dropdownlist
            comboBox1.Items.AddRange(callNumberCategories.Values.ToArray());
            comboBox2.Items.AddRange(callNumberCategories.Values.ToArray());
            comboBox3.Items.AddRange(callNumberCategories.Values.ToArray());
            comboBox4.Items.AddRange(callNumberCategories.Values.ToArray());

            //Sets game questions and works out corresponding answers from dictionary
            generateQuestions();
            populateAnswers();
        }

        private void generateQuestions()
        {

            //selects 4 random call numbers to test the user
            Random rnd = new Random();

            int i = 0;

            while(i < 4)
            {
                int j = rnd.Next(7);

                string question = callNumberCategories.ElementAt(j).Key;

                if (questions.Contains(question))
                {
                    continue;
                }
                else
                {
                    questions.Add(question);
                    i++;
                }
            }

            int n = 1;

            /*--The following code was adapted from StackOverflow
            Author: musefan
            Site:  https://stackoverflow.com/questions/17548344/populate-text-boxes-from-list-values */
            foreach (var item in questions)
            {
                //runs through the textboxes by name and populates them with call numbers
                if (n <= questions.Count)
                {
                    TextBox tb = panel1.Controls.Find("textBox" + n, false).FirstOrDefault() as TextBox;
                    tb.Text = item.ToString();
                    n++;
                }
            }
            /*----------------------------END----------------------------*/

        }

        public void populateAnswers()
        {
            int n = 1;
            foreach(string question in questions)
            {
                //runs through the textboxes by name and populates them with asked call numbers and corresponding answers according to the dictionary
                if (n <= questions.Count)
                {
                    TextBox tb = panel2.Controls.Find("lblAnswer" + n, false).FirstOrDefault() as TextBox;
                    tb.Text = question.ToString();

                    TextBox tbAns = panel2.Controls.Find("txtAnswer" + n, false).FirstOrDefault() as TextBox;
                    tbAns.Text = callNumberCategories[question];
                    n++;
                }
            }
        }
        private void resetUI()
        {
            panel2.Visible = false;

            int n = 1;
            foreach (var item in questions)
            {
                //runs through the comboboxes and makes the selected item empty
                if (n <= questions.Count)
                {
                    ComboBox cb = panel1.Controls.Find("comboBox" + n, false).FirstOrDefault() as ComboBox;
                    cb.SelectedItem = null;
                    n++;
                }
            }

            questions.Clear();
            txtFeedback.Clear();

            //Generates new questions 

            generateQuestions();
            populateAnswers();
        }

        //The next 4 methods hides correct answers when user wants to change their answer
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        
    }
}
