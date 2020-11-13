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

namespace Dewey_Decimals_Library_Game
{
    public partial class CallNumbers : Form
    {
        Tree deweyDecimalsTree;
        List<DeweyObject> lstQuestions;
        List<string> callDescriptions;
        int currentQuestion;
        int treeLevel;

        public CallNumbers()
        {
            //Initialising all variables 
            InitializeComponent();

            deweyDecimalsTree = new Tree();
            lstQuestions = new List<DeweyObject>();
            callDescriptions = new List<string>();
            currentQuestion = -1;
            treeLevel = 0;

            txtXP.Text = GlobalXP.XP.ToString() + " xp";

            panelLvl2.Visible = false;
            panelLvl3.Visible = false;

            populateTreeFromFile();
            generateQuestions();
        }

        private void populateTreeFromFile()
        {
            //Creates the beginning of the tree list
            deweyDecimalsTree.Root = new TreeNode() {};
            deweyDecimalsTree.Root.Children = new List<TreeNode>();

            using (StreamReader reader = new StreamReader("CallNumbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    DeweyObject deweyObject = new DeweyObject();
                    deweyObject.callNumbers = Convert.ToInt32(line.Substring(0, 3));
                    deweyObject.description = line.Substring(6);

                    int mainLevelIndex = Convert.ToInt32(line.Substring(0, 1));
                    int secondLevelIndex = Convert.ToInt32(line.Substring(1, 1));

                    if (deweyObject.callNumbers < 10)
                    {
                        mainLevelIndex = 0;
                        secondLevelIndex = 0;
                    }
                    else if (deweyObject.callNumbers < 100)
                    {
                        mainLevelIndex = 0;
                    }

                    //Checks if number is from main dewey level (hundreds)
                    if (line.Substring(1, 2).Equals("00"))
                    {
                        deweyDecimalsTree.Root.Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root });
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children = new List<TreeNode>();

                        //Creates category for values less than 010
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root.Children[mainLevelIndex] });
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex].Children = new List<TreeNode>();
                    }
                    //Checks if number is from second dewey level (tens)
                    else if (line.Substring(2, 1).Equals("0"))
                    {
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root.Children[mainLevelIndex] });
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex].Children = new List<TreeNode>();
                    }
                    else
                    {
                        //Adds 3rd level value
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex].Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex] });
                    }
                }
            }
        }

        private void generateQuestions()
        {
            Random random = new Random();
            lstQuestions.Clear();

            //calls a random number and gets the description from the tree
            while(lstQuestions.Count != 10)
            {
                DeweyObject question = new DeweyObject();

                int callNumber = random.Next(0,940);

                if (!(callNumber % 10 == 0))
                {
                    //Checks if the question exists using tree search
                    question = deweyDecimalsTree.searchLvl3(callNumber);

                    if ((question != null) && (!lstQuestions.Contains(question)))
                    {
                        lstQuestions.Add(question);
                    }
                }
            }
            currentQuestion = 0;
            treeLevel = 1;

            populateAnswers();
        }

        private void populateAnswers()
        {
            callDescriptions.Clear();

            if(currentQuestion >= 0 && currentQuestion <= 10)
            {
                txtQuestion.Text = lstQuestions[currentQuestion].description;

                switch (treeLevel)
                {
                    case 1:
                        Level1Categories lvl1 = new Level1Categories();
                        Dictionary<string, string> categories = lvl1.level1Numbers;

                        //Determines correct category from tree search
                        string questionCategory = lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 1);

                        if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(1) || lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(2))
                        {
                            questionCategory = "0";
                        }
                        
                        callDescriptions.Add(deweyDecimalsTree.Root.Children[Convert.ToInt32(questionCategory)].Data.callNumberDesc());

                        Random random = new Random();

                        //Adds 3 incorrect answers
                        while(callDescriptions.Count != 4)
                        {
                            int r = random.Next(10);

                            string descr = categories.ElementAt(r).Key + " - " + categories.ElementAt(r).Value;

                            if (!callDescriptions.Contains(descr))
                            {
                                callDescriptions.Add(descr);
                            }
                        }

                        callDescriptions.Sort();

                        //Sorts answers & Populates answer buttons
                        for (int i = 0; i < callDescriptions.Count; i++)
                        {
                            Button btnAnswer = panelLvl1.Controls.Find("btnLevel1_" + (i + 1), false).FirstOrDefault() as Button;
                            btnAnswer.Text = callDescriptions[i];
                        }
                        break;

                    case 2:
                        callDescriptions.Clear();

                        int level2Category = Convert.ToInt32(lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 2) + "0");

                        if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(1))
                        {
                            level2Category = 0;
                        }
                        else if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(2))
                        {
                            level2Category = Convert.ToInt32(lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 2));
                        }

                        //Adds correct answer
                        callDescriptions.Add(deweyDecimalsTree.searchLvl2(level2Category).callNumberDesc());

                        Random randomL2 = new Random();
                        int randomStart = Convert.ToInt32(level2Category.ToString().Substring(0,1)+ "0");
                        while (callDescriptions.Count != 4)
                        {
                            int r = randomL2.Next(randomStart, randomStart+9) * 10;

                            DeweyObject obj = deweyDecimalsTree.searchLvl2(r);

                            if(obj != null)
                            {
                                string descript = obj.callNumberDesc();
                                if (!callDescriptions.Contains(descript))
                                {
                                    callDescriptions.Add(descript);
                                };
                            }
                        }

                        //Sorts answers & Populates answer buttons
                        callDescriptions.Sort();

                        for (int i = 0; i < callDescriptions.Count; i++)
                        {
                            Button btnAnswer = panelLvl2.Controls.Find("btnLevel2_" + (i + 1), false).FirstOrDefault() as Button;
                            btnAnswer.Text = callDescriptions[i];
                        }

                        panelLvl2.Visible = true;
                        break;

                    case 3:
                        callDescriptions.Clear();

                        callDescriptions.Add(lstQuestions[currentQuestion].callNumberDesc());

                        Random randomLvl3 = new Random();
                        int randStart = Convert.ToInt32(lstQuestions[currentQuestion].callNumberDesc().Substring(0, 2)+"0");
                        int randEnd = Convert.ToInt32(lstQuestions[currentQuestion].callNumberDesc().Substring(0, 2) + "9");

                        while (callDescriptions.Count != 4)
                        {
                            int z = randomLvl3.Next(randStart, randEnd);

                            DeweyObject obj = deweyDecimalsTree.searchLvl3(z);

                            if (obj != null)
                            {
                                string descript = obj.callNumberDesc();
                                if (!callDescriptions.Contains(descript))
                                {
                                    callDescriptions.Add(descript);
                                }
                            }
                        }

                        //Sorts answers & populates answer buttons
                        callDescriptions.Sort();

                        for (int i = 0; i < callDescriptions.Count; i++)
                        {
                            Button btnAnswer = panelLvl3.Controls.Find("btnLevel3_" + (i + 1), false).FirstOrDefault() as Button;
                            btnAnswer.Text = callDescriptions[i];
                        }

                        panelLvl3.Visible = true;
                        break;
                }               
            }
        }

        private void checkAnswer(int btn, string btnText, int level)
        {
            //checks tree for button text depending on tree level
            switch (level)
            {
                case 1:
                    string questionCategory = lstQuestions[currentQuestion].callNumbers.ToString().Substring(0,1);

                    //Checks tree level 1 for main category
                    if (btnText.Equals(deweyDecimalsTree.Root.Children[Convert.ToInt32(questionCategory)].Data.callNumberDesc()))
                    {
                        txtFeedback.Text = "Correct! On to the next level!";
                        treeLevel++;
                        populateAnswers();
                    }
                    else
                    {
                        txtFeedback.Text = "Wrong Answer! :(";
                        panelLvl2.Visible = false;
                        panelLvl3.Visible = false;
                        generateQuestions();
                    }
                    break;

                case 2:
                    panelLvl3.Visible = false;
                    int level2Category = Convert.ToInt32(lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 2) + "0");

                    if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(1))
                    {
                        level2Category = 0;
                    }
                    else if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(2))
                    {
                        Convert.ToInt32(lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 2));
                    }

                    //Checks tree level 2 for sub category
                    if (btnText.Equals(deweyDecimalsTree.searchLvl2(level2Category).callNumberDesc()))
                    {
                        txtFeedback.Text = "Correct! On to the next level!";
                        treeLevel++;
                        populateAnswers();
                    }
                    else
                    {
                        txtFeedback.Text = "Wrong Answer! :(";
                        panelLvl2.Visible = false;
                        panelLvl3.Visible = false;
                        generateQuestions();
                    }

                    break;
                case 3:

                    if (btnText.Equals(lstQuestions[currentQuestion].callNumberDesc()))
                    {
                        GlobalXP.XP = GlobalXP.XP + 10;
                        txtXP.Text = GlobalXP.XP + " xp";

                        if(currentQuestion == 9)
                        {
                            txtFeedback.Text = "Congrats! Lets Play Again!";
                        }
                        else
                        {
                            txtFeedback.Text = "Wow you are clever! Next Question!";
                        }
                        currentQuestion++;
                        treeLevel = 1;
                        populateAnswers();

                        panelLvl2.Visible = false;
                        panelLvl3.Visible = false;
                    }
                    else
                    {
                        txtFeedback.Text = "Wrong Answer! :(";
                        panelLvl2.Visible = false;
                        panelLvl3.Visible = false;
                        generateQuestions();
                    }

                    break;
            }
        }

        private void btnLevel1_1_Click(object sender, EventArgs e)
        {
            checkAnswer(1, btnLevel1_1.Text, 1);
        }

        private void btnLevel1_2_Click(object sender, EventArgs e)
        {
            checkAnswer(2, btnLevel1_2.Text, 1);
        }
        private void btnLevel1_3_Click(object sender, EventArgs e)
        {
            checkAnswer(3, btnLevel1_3.Text, 1);
        }
        private void btnLevel1_4_Click(object sender, EventArgs e)
        {
            checkAnswer(4, btnLevel1_4.Text, 1);
        }
        private void btnLevel2_1_Click(object sender, EventArgs e)
        {
            checkAnswer(1, btnLevel2_1.Text, 2);
        }
        private void btnLevel2_2_Click(object sender, EventArgs e)
        {
            checkAnswer(2, btnLevel2_2.Text, 2);
        }
        private void btnLevel2_3_Click(object sender, EventArgs e)
        {
            checkAnswer(3, btnLevel2_3.Text, 2);
        }
        private void btnLevel2_4_Click(object sender, EventArgs e)
        {
            checkAnswer(4, btnLevel2_4.Text, 2);
        }
        private void btnLevel3_1_Click(object sender, EventArgs e)
        {
            checkAnswer(1, btnLevel3_1.Text, 3);
        }
        private void btnLevel3_2_Click(object sender, EventArgs e)
        {
            checkAnswer(2, btnLevel3_2.Text, 3);
        }
        private void btnLevel3_3_Click(object sender, EventArgs e)
        {
            checkAnswer(3, btnLevel3_3.Text, 3);
        }
        private void btnLevel3_4_Click(object sender, EventArgs e)
        {
            checkAnswer(4, btnLevel3_4.Text, 3);
        }
    }
}
