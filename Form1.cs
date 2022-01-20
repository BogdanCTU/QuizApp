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

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1(bool log, int IDU)
        {
            InitializeComponent();

            int a;
            logged = log;
            GlobalUtilities.ID_User = IDU;
            if (logged != false && GlobalUtilities.ID_User != -1)
            {
                string usernm = Get_UserName();
                label1.Text = ("User: " + usernm);
            }
            if(GlobalUtilities.TraceOpened == false && GlobalUtilities.FileOpened == false)
            {
                TraceInstance();
                GlobalUtilities.TraceOpened = true;
                GlobalUtilities.FileOpened = true;
            }
        }

        /// <summary>
        /// Method to instance Trace Class, it will be used only one time, at program's
        /// first run.
        /// </summary>
        private void TraceInstance()
        {
            try
            {
                FileStream traceLog = new FileStream("DatabaseTrace_Trace.txt", FileMode.OpenOrCreate);
                TextWriterTraceListener traceListener = new TextWriterTraceListener(traceLog);
                Trace.Listeners.Add(traceListener);
                Trace.AutoFlush = true;
            }
            catch
            {
                MessageBox.Show("Error with Trace Class!");
            }
        }

        /// <summary>
        /// Global Method used to write data in Trace
        /// </summary>
        public static void TraceWrite(string message)
        {
            Trace.WriteLine($"{DateTime.Now} : {message}");
        }

        /// <summary>
        /// Global method to get user's username from Database
        /// </summary>
        public static string Get_UserName()
        {
            string u;
            try
            {
                using (UserDbContext udb = new UserDbContext())
                {
                    var res = udb.Users.SingleOrDefault(p => p.IdUser == GlobalUtilities.ID_User);
                    u = res.UserUsername;
                }
                Form1.TraceWrite("Readed Username in User Database");
                return u;
            }
            catch
            {
                MessageBox.Show("Error accessing User Database!");
                return " ";
            }
        }

        /// <summary>
        /// Button Action that opens Game Interface
        /// </summary>
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

        /// <summary>
        /// Button Action that opens User Menu Interface
        /// </summary>
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin u = new UserLogin();
            u.Show();
            //this.Close();
            this.Hide();
        }
    }
}
