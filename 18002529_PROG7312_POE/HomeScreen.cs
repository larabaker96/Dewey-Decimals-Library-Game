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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
            txtXP.Text = GlobalXP.XP.ToString() + " xp";
        }

        private void btnReplaceBooks_Click(object sender, EventArgs e)
        {
            ReplaceBooks rbWindow = new ReplaceBooks();

            //Allows user to go back to home screen 
            rbWindow.FormClosed += new FormClosedEventHandler(rbWindow_FormClosed);

            this.Hide();
            rbWindow.Show();
        }

        private void rbWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtXP.Text = GlobalXP.XP.ToString() + " xp";
        }

        private void btnIdentifyAreas_Click(object sender, EventArgs e)
        {
            IdentifyAreas iaWindow = new IdentifyAreas();

            //Allows user to go back to home screen 
            iaWindow.FormClosed += new FormClosedEventHandler(iaWindow_FormClosed);

            this.Hide();
            iaWindow.Show();
        }

        private void iaWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtXP.Text = GlobalXP.XP.ToString() + " xp";
        }

        private void btnCallNumbers_Click(object sender, EventArgs e)
        {
            CallNumbers cnWindow = new CallNumbers();

            //Allows user to go back to home screen 
            cnWindow.FormClosed += new FormClosedEventHandler(cnWindow_FormClosed);

            this.Hide();
            cnWindow.Show();
        }

        private void cnWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            txtXP.Text = GlobalXP.XP.ToString() + " xp";
        }
    }
}

//Sets a global XP level throught the game
public static class GlobalXP
{
    public static int XP;
}

