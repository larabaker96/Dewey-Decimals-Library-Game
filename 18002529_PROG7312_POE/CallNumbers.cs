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
        int treeLevel;

        public CallNumbers()
        {
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
            deweyDecimalsTree.Root = new TreeNode() {};
            deweyDecimalsTree.Root.Children = new List<TreeNode>();

            StreamReader reader = new StreamReader("CallNumbers.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                DeweyObject deweyObject = new DeweyObject();
                deweyObject.callNumbers = Convert.ToInt32(line.Substring(0, 3));
                deweyObject.description = line.Substring(6);

                int mainLevelIndex = Convert.ToInt32(line.Substring(0, 1));
                int secondLevelIndex = Convert.ToInt32(line.Substring(1, 1));
                if(Convert.ToInt32(line.Substring(1, 2)) < 10)
                {
                    secondLevelIndex = 0;
                }

                if (deweyObject.callNumbers % 100 == 0)
                {
                    deweyDecimalsTree.Root.Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root });
                    deweyDecimalsTree.Root.Children[mainLevelIndex].Children = new List<TreeNode>();

                }
                else if (deweyObject.callNumbers % 10 == 0)
                {
                    deweyDecimalsTree.Root.Children[mainLevelIndex].Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root.Children[mainLevelIndex]});
                    deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex].Children = new List<TreeNode>();
                }
                else
                {
                    if (Convert.ToInt32(line.Substring(1, 1)) == 0)
                    {
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root.Children[mainLevelIndex] });
                        deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex].Children = new List<TreeNode>();
                    }

                    deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex].Children.Add(new TreeNode() { Data = deweyObject, Parent = deweyDecimalsTree.Root.Children[mainLevelIndex].Children[secondLevelIndex] });
                }
            }
        }

        private void generateQuestions()
        {
            Random random = new Random();
            lstQuestions.Clear();
            while(lstQuestions.Count < 10)
            {
                DeweyObject question = new DeweyObject();

                int callNumber = random.Next(0,999);

                if (callNumber % 10 != 0)
                {
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

            if(currentQuestion >= 0 && currentQuestion < 10)
            {
                txtQuestion.Text = lstQuestions[currentQuestion].description;

                switch (treeLevel)
                {
                    case 1:
                        Level1Categories lvl1 = new Level1Categories();
                        Dictionary<string, string> categories = lvl1.level1Numbers;

                        string questionCategory = lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 1);

                        if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(1) || lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(2))
                        {
                            questionCategory = "0";
                        }
                        
                        callDescriptions.Add(deweyDecimalsTree.Root.Children[Convert.ToInt32(questionCategory)].Data.callNumberDesc());

                        Random random = new Random();

                        while(callDescriptions.Count != 4)
                        {
                            int r = random.Next(10);

                            string descr = categories.ElementAt(r).Key + " - " + categories.ElementAt(r).Value;

                            if (!callDescriptions.Contains(descr))
                            {
                                callDescriptions.Add(descr);
                            }
                        }

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
                            Convert.ToInt32(lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 2));
                        }

                        //Adds correct answer
                        callDescriptions.Add(deweyDecimalsTree.searchLvl2(level2Category).callNumberDesc());

                        Random randomL2 = new Random();

                        while (callDescriptions.Count != 4)
                        {
                            int r = randomL2.Next(99) * 10;

                            DeweyObject obj = deweyDecimalsTree.searchLvl2(r);

                            if(obj != null)
                            {
                                string descript = obj.callNumberDesc();
                                if (!callDescriptions.Contains(descript))
                                {
                                    callDescriptions.Add(descript);
                                }
                            }                        
                        }

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

                        while(callDescriptions.Count != 4)
                        {
                            int r = randomLvl3.Next(999);

                            DeweyObject obj = deweyDecimalsTree.searchLvl3(r);

                            if (obj != null)
                            {
                                string descript = obj.callNumberDesc();
                                if (!callDescriptions.Contains(descript))
                                {
                                    callDescriptions.Add(descript);
                                }
                            }
                        }

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

        private void checkAnswer(int btn, string btnText)
        {
            switch (treeLevel)
            {
                case 1:
                    string questionCategory = lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 1);

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
                    int level2Category = Convert.ToInt32(lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 2) + "0");

                    if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(1))
                    {
                        level2Category = 0;
                    }
                    else if (lstQuestions[currentQuestion].callNumbers.ToString().Length.Equals(2))
                    {
                        Convert.ToInt32(lstQuestions[currentQuestion].callNumbers.ToString().Substring(0, 2));
                    }

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
                        GlobalXP.XP++;
                        txtXP.Text = GlobalXP.XP + " xp";
                        txtFeedback.Text = "Wow you are clever! Next Question!";
                        currentQuestion++;
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
            }
        }
    }
}
