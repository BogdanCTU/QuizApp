using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) != true || string.IsNullOrWhiteSpace(textBox5.Text) != true)
            {
                try
                {
                    bool newUser = true;
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
                        string userUsername = this.textBox4.Text;
                        string userPassword = this.textBox5.Text;
                        int userPoints = 0;
                        Task.Run(() => AddUserAsync(userUsername, userPassword, userPoints));
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please insert values in textboxes!");
                }
            }
            else
            {
                MessageBox.Show("Please insert values in textboxes!");
            }
        }

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
        }
    }
}
