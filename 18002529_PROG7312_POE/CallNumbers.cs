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
    public partial class CallNumbers : Form
    {
        public CallNumbers()
        {
            InitializeComponent();

            txtXP.Text = GlobalXP.XP.ToString() + " xp";

            panelLvl2.Visible = false;
            panelLvl3.Visible = false;
        }
    }
}
