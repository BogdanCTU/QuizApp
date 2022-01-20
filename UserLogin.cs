using SilviuDLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class UserLogin : Form
    {
        //variable sended in Form1 constructor, necessary to verify login
        int ID_User = -1;

        // Silviu
        Class1 c1 = new Class1();

        // constructor
        public UserLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button Action that logins the user if inserted data is
        /// available and equal with data in User Database
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string uUsername = this.textBox1.Text;
            string uUserPassword = this.maskedTextBox1.Text;

            // COD SILVIU - FUCNTIE SILVIU SE APELEAZA AICI
            // CITESTI DIN XML CHEIA SI PAROLA CRIPTATA
            // DECRIPTEZI PAROLA PRIN CHEIE
            // SILVIU

            if (string.IsNullOrWhiteSpace(textBox1.Text) != true || string.IsNullOrWhiteSpace(maskedTextBox1.Text) != true)
            {
                UserLogin_(uUsername, uUserPassword);
            }
            else
            {
                MessageBox.Show("Please insert correct username \n     and password!");
            }
        }

        /// <summary>
        /// Method used in LoginButton
        /// </summary>
        private void UserLogin_(string Username, string UserPassword)
        {
            try
            {
                using (UserDbContext db = new UserDbContext())
                {
                    var res = from s in db.Users
                              where s.UserUsername.Contains(Username)
                              select new
                              {
                                  s.IdUser,
                                  s.UserUsername,
                                  s.UserPassword   //cripata in baza de date
                              };
                    foreach (var usr in res)
                    {
                        //string decriptedPassword = c1.DecryptFromXml(UserPassword);
                        //if (usr.UserPassword.Equals(decriptedPassword) == true)
                        if (usr.UserPassword.Equals(UserPassword) == true)
                        {
                            int iduser = usr.IdUser;
                            Form1 a = new Form1(true, iduser);
                            a.Show();
                            this.Close();
                        }
                    }
                }
                textBox1.Clear();
                maskedTextBox1.Clear();
                Form1.TraceWrite("User Login");
            }
            catch
            {
                MessageBox.Show("An error has occoured! \n   Please try again!");
            }
        }

        /// <summary>
        /// Action Button that opens user Database view Form
        /// </summary>
        private void userDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDbViewForm b = new UserDbViewForm(0);
            b.Show();
            this.Close();
        }

        /// <summary>
        /// Action Button that opens user Database view Form as administrator
        /// it has some specific proprieties (the only one that can delete
        /// users from Database)
        /// </summary>
        private void AdminButton_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "admin" && this.maskedTextBox1.Text == "admin")
            {
                UserDbViewForm b = new UserDbViewForm(-1);
                this.Close();
                b.Show();
            }
            else
            {
                MessageBox.Show("Wrong admin credentials! \nRetry...");
            }
        }

        // DONE
        /// <summary>
        /// Action Button that opens user Main App Form (Form1)
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(false, 0);
            this.Close();
            f.ShowDialog();
            
        }
    }
}
