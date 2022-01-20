using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SilviuDLL;

namespace QuizApp
{
    public partial class AddUserForm : Form
    {
        // Silviu
        Class1 c1 = new Class1();

        // Constructor
        public AddUserForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Action Button that opens closes actual Form
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Action Button that access user Database and adds an instance of user
        /// </summary>
        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) != true || string.IsNullOrWhiteSpace(textBox5.Text) != true)
            {
                try
                {
                    //variables
                    string userUsername = this.textBox4.Text;
                    string userPassword = this.textBox5.Text;
                    string cryptedPassword = " ";
                    bool newUser = true;

                    // SALVARE PASSSWORD SI CHEIE IN XML
                    // PASSWORD TREBUIE SA FIE CRIPTATA
                    // SILVIU 
                    cryptedPassword = c1.EncryptInXml(userPassword);

                    using (UserDbContext udb = new UserDbContext())
                    {
                        var res = from s in udb.Users
                                  where s.UserUsername.Equals(textBox4.Text)
                                  select new { s.UserPassword, s.IdUser };

                        foreach (var users in res)
                        {
                            var res2 = from s in udb.Users
                                       where s.UserPassword.Equals(textBox5.Text)
                                       select new { s.IdUser };
                            if (res2 != null) newUser = false;
                        }
                    }

                    if (newUser == true)
                    {
                        int userPoints = 0;
                        AddUserAsync(userUsername, cryptedPassword, userPoints);
                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Please insert values in textboxes!");
                }
            }
            else
            {
                MessageBox.Show("Please insert values in textboxes!");
            }
        }

        /// <summary>
        /// Async method that add User instance in Database
        /// </summary>
        private void AddUserAsync(string userUsername, string userPassword, int userPoints)
        {
            using (UserDbContext udb = new UserDbContext())
            {
                User u = new User();
                u.UserUsername = userUsername;
                u.UserPassword = userPassword;
                u.UserPoints = userPoints;
                udb.Users.Add(u);
                udb.SaveChanges();
            }
            this.DialogResult = DialogResult.OK;
            Form1.TraceWrite("Add User");
        }
    }
}
