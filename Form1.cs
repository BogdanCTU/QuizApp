using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        bool logged = false;
        int ID_User = 0;
        public Form1(bool log, int IDU)
        {
            InitializeComponent();
            int a;
            logged = log;
            ID_User = IDU;
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (logged == false)
            {
                MessageBox.Show("Please log-in first!");
            }
            else
            {
                GameForm g = new GameForm();
                g.ShowDialog();
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin u = new UserLogin();
            u.Show();
            this.Hide();
        }
    }
}
