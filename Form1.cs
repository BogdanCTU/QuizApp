using System;
using System.Data;
using System.Diagnostics;
using System.IO;
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
            //Trace data
            FileStream traceLog = new FileStream("DatabaseTrace_Trace.txt", FileMode.OpenOrCreate);
            TextWriterTraceListener traceListener = new TextWriterTraceListener(traceLog);
            Trace.Listeners.Add(traceListener);
            Trace.AutoFlush = true;

            InitializeComponent();
            int a;
            logged = log;
            ID_User = IDU;
            if(logged != false && ID_User != -1)
            {
                string username = GetUsername();
                UserLabel.ResetText();
                UserLabel.Text = ("User: " + username);
            }
        }

        public static void TraceWrite(string message)
        {
            Trace.WriteLine($"{DateTime.Now} : {message}");
        }

        public static string GetUsername()
        {
            string usrn = " ";
            try
            {
                using (UserDbContext db = new UserDbContext())
                {
                    var res = from s in db.Users
                              where s.IdUser.Equals(ID_User)
                              select new
                              {
                                  s.UserUsername,
                              };
                    foreach (var usr in res)
                    {
                        usrn = usr.UserUsername;
                    }
                }
                TraceWrite("GetUsername");
            }
            catch
            {
                MessageBox.Show("An error has occoured! \n   Please try again!");
            }
            return usrn;
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
            this.Hide();
        }
    }
}
