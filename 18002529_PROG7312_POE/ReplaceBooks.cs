using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18002529_PROG7312_POE
{
    public partial class ReplaceBooks : Form
    {
        List<string> listOfValues;
        string[] sortingArray;

        public ReplaceBooks()
        {
            InitializeComponent();

            //Allows user to drag and drop text into the answer box
            lstUserAnswer.AllowDrop = true;

            lstCorrectAnswer.Visible = false;
            pictureBox1.Visible = false;
            listOfValues = new List<string>();

            txtXP.Text = GlobalXP.XP.ToString() + " xp";

            populateTextboxes();
        }

        //Triggers drag-drop event once user drops the call number in the box
        /*--The following code was adapted from Youtube
            Author: BTNT TV
            Site:  https://www.youtube.com/watch?v=ln59zYyJvB4 */
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            lstUserAnswer.Items.Add(e.Data.GetData(DataFormats.Text));
        }

        //The next 10 methods below all allow for the drag-drop event
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();

            lstUserAnswer.DoDragDrop(textBox1.Text, DragDropEffects.All);
        }

        /*----------------------------END----------------------------*/

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.SelectAll();

            lstUserAnswer.DoDragDrop(textBox2.Text, DragDropEffects.All);
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.SelectAll();

            lstUserAnswer.DoDragDrop(textBox3.Text, DragDropEffects.All);
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox4.SelectAll();

            lstUserAnswer.DoDragDrop(textBox4.Text, DragDropEffects.All);
        }

        private void textBox5_MouseDown(object sender, MouseEventArgs e)
        {
            textBox5.SelectAll();

            lstUserAnswer.DoDragDrop(textBox5.Text, DragDropEffects.All);
        }

        private void textBox6_MouseDown(object sender, MouseEventArgs e)
        {
            textBox6.SelectAll();

            lstUserAnswer.DoDragDrop(textBox6.Text, DragDropEffects.All);
        }

        private void textBox7_MouseDown(object sender, MouseEventArgs e)
        {
            textBox7.SelectAll();

            lstUserAnswer.DoDragDrop(textBox7.Text, DragDropEffects.All);
        }

        private void textBox8_MouseDown(object sender, MouseEventArgs e)
        {
            textBox8.SelectAll();

            lstUserAnswer.DoDragDrop(textBox8.Text, DragDropEffects.All);
        }

        private void textBox9_MouseDown(object sender, MouseEventArgs e)
        {
            textBox9.SelectAll();

            lstUserAnswer.DoDragDrop(textBox9.Text, DragDropEffects.All);
        }

        private void textBox10_MouseDown(object sender, MouseEventArgs e)
        {
            textBox10.SelectAll();

            lstUserAnswer.DoDragDrop(textBox10.Text, DragDropEffects.All);
        }

        //Ensures answer display is reset and outputs user results
        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            lstCorrectAnswer.Items.Clear();
            SortNumbers();
            CheckAnswer();
            lblCorrect.Visible = true;
            lstCorrectAnswer.Visible = true;
            pictureBox1.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();

            populateTextboxes();
        }

        private void ResetGame()
        {
            lstUserAnswer.Items.Clear();
            lstCorrectAnswer.Items.Clear();
            listOfValues.Clear();
            sortingArray = null;
            txtFeedback.Text = "";
            pictureBox1.Visible = false;
        }

        private void populateTextboxes()
        {          
            GenerateCallNumbers();
        
            int n = 1;

            /*--The following code was adapted from StackOverflow
            Author: musefan
            Site:  https://stackoverflow.com/questions/17548344/populate-text-boxes-from-list-values */
            foreach (var item in listOfValues)
            {
                //runs through the textboxes by name and populates them with call numbers
                if (n <= listOfValues.Count)
                {
                    TextBox tb = panel1.Controls.Find("textBox" + n, false).FirstOrDefault() as TextBox;
                    tb.Text = item.ToString();
                    n++;
                }
            }
            /*----------------------------END----------------------------*/
        }

        //generates 10 doubles and 10 three letter strings and concatenates them
        private void GenerateCallNumbers()
        {
            Random random = new Random();
            string[] number = new string[10];

            for (int i = 0; i < 10; i++)
            {
                /*--The following code was adapted from StackOverflow
                Author: Habib
                Site:  https://stackoverflow.com/questions/10235038/how-to-generate-a-random-number-with-8-digits-total-in-c-4-integer-4-fractio */

                number[i] = random.Next(0, 999) + "." + random.Next(0, 9999);

                /*----------------------------END----------------------------*/
            }

            string[] surnames = new string[10];

            for (int p = 0; p < 10; p++)
            {
                /*--The following code was adapted from StackOverflow
                Author: Ohad Schneider
                Site:  https://stackoverflow.com/questions/9995839/how-to-make-random-string-of-numbers-and-letters-with-a-length-of-5 */

                string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                char[] chars = new char[3];
                for (int i = 0; i < 3; i++)
                {
                    chars[i] = letters[random.Next(letters.Length)];
                }

                surnames[p] = new string(chars);
                /*----------------------------END----------------------------*/
            }

            for (int s = 0; s < 10; s++)
            {
                listOfValues.Add(number[s] + " " + surnames[s]);
            }
        }

        public void SortNumbers()
        {
            //runs a bubble sort of the numbers and re-arranges into a new list
            sortingArray = listOfValues.ToArray();

            /*--The following code was adapted from TutorialsPoint
            Author: Karthikeya Boyini
            Site:  https://www.tutorialspoint.com/Bubble-Sort-program-in-Chash */

            string temporary;

            for (int j = 0; j <= sortingArray.Length - 2; j++)
            {
                for (int i = 0; i <= sortingArray.Length - 2; i++)
                {
                    double firstVal = Convert.ToDouble(sortingArray[i].Split(' ').First());
                    double secondVal = Convert.ToDouble(sortingArray[i + 1].Split(' ').First());

                    if ( firstVal > secondVal)
                    {
                        temporary = sortingArray[i + 1];
                        sortingArray[i + 1] = sortingArray[i];
                        sortingArray[i] = temporary;
                    }
                }
            }

            /*----------------------------END----------------------------*/

            foreach (var item in sortingArray)
            {
                lstCorrectAnswer.Items.Add(item);
            }
        }

        public void CheckAnswer()
        {
            //compares the list orders and flags the answer incorrect if they dont match
            bool correct = true;
            for(int a = 0; a < 10; a++)
            {
                if(lstUserAnswer.FindString(sortingArray[a]).Equals(a))
                {
                    continue;
                }
                else
                {
                    correct = false;
                }
            }

            if(correct == false)
            {
                txtFeedback.Text = "Unfortunately your sorting is incorrect :(";
                pictureBox1.Image = Image.FromFile("sadface.jpg");
            }
            else
            {
                //Gamification feature
                txtFeedback.Text = "Correct! You earn 100 xp points!";
                pictureBox1.Image = Image.FromFile("happyface.jpg");
                GlobalXP.XP += 100;
                txtXP.Text = GlobalXP.XP.ToString() + " xp";
            }
        }
    }


}
