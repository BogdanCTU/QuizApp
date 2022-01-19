﻿using System;
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
    public partial class UserLogin : Form
    {
        static int ID_User = -1;
        public UserLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TO DO PARTE CRIPTARE SILVIU
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string uUsername = this.textBox1.Text;
            string uUserPassword = this.maskedTextBox1.Text;

            // COD SILVIU - FUCNTIE SILVIU SE APELEAZA AICI
            // decriptez parola
            if (string.IsNullOrWhiteSpace(textBox1.Text) != true || string.IsNullOrWhiteSpace(maskedTextBox1.Text) != true)
            {
                try
                {
                    using (UserDbContext db = new UserDbContext())
                    {
                        var res = from s in db.Users
                                  where s.UserUsername.Contains(uUsername)
                                  select new
                                  {
                                      s.IdUser,
                                      s.UserUsername,
                                      s.UserPassword   //cripata in baza de date
                                  };
                        foreach (var usr in res)
                        {
                            if (usr.UserPassword.Equals(uUserPassword) == true)
                            {
                                int iduser = usr.IdUser;
                                Form1 a = new Form1(true, ID_User);
                                a.Show();
                                this.Close();
                            }
                        }
                    }
                    textBox1.Clear();
                    maskedTextBox1.Clear();
                }
                catch
                {
                    MessageBox.Show("An error has occoured! \n   Please try again!");
                }
            }
            else
            {
                MessageBox.Show("Please insert correct username \n     and password!");
            }
        }

        //DONE
        private void userDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDbViewForm b = new UserDbViewForm(0);
            //this.Hide();
            b.Show();
        }

        // ADMIN - DONE
        private void AdminButton_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text == "admin" && this.maskedTextBox1.Text == "admin")
            {
                UserDbViewForm b = new UserDbViewForm(-1);
                //this.Hide();
                b.Show();
            }
            else
            {
                MessageBox.Show("Wrong admin credentials! \nRetry...");
            }
        }

        // DONE
        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(false, 0);
            f.Show();
            this.Close();
        }
    }
}
