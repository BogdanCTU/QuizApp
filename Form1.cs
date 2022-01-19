using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        bool logged = false;
        public static int ID_User = -1, LastQuest = 2;
        public Form1(bool log, int IDU)
        {
            InitializeComponent();

            int a;
            logged = log;
            ID_User = IDU;
            if (logged != false && ID_User != -1)
            {
                //string username =
                SetUser();
                //UserLabel.Text = ("User: " + username);
            }
        }

        private void SetUser()
        {
            using (UserDbContext udb = new UserDbContext())
            {
                var res = from s in udb.Users
                          where s.IdUser.Equals(ID_User)
                          select new { s.UserUsername };
                foreach (var user in res)
                {
                    label1.Text = ("User: " + user.UserUsername);
                }
            }
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (logged == false)
            {
                MessageBox.Show("Please log-in first!");
            }
            else
            {
                GameForm g = new GameForm(1);
                g.ShowDialog();
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin u = new UserLogin();
            u.Show();
            //this.Close();
            this.Hide();
        }
    }
}
