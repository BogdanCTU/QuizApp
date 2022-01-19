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
    public partial class DeleteUserForm : Form
    {
        public DeleteUserForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (UserDbContext db = new UserDbContext())
                {
                    int uid = int.Parse(textBox1.Text);
                    var res = from s in db.Users
                              where s.IdUser.Equals(uid)
                              select new
                              {
                                  s.IdUser,
                                  s.UserUsername,
                                  s.UserPoints
                              };
                    dataGridView1.DataSource = res.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please insert values in textbox!");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) != true)
            {
                try
                {
                    int UID = int.Parse(textBox1.Text);
                    Task.Run(() => DeleteUserAsync(UID));
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

        private void BackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteUserAsync(int UID)
        {
            using (UserDbContext db = new UserDbContext())
            {
                var res = db.Users.SingleOrDefault(p => p.IdUser == UID);

                if (res != null)
                {
                    db.Entry(res).State = System.Data.Entity.EntityState.Deleted;   // delete user
                    db.SaveChanges();
                }
            }
        }

        // EOF
    }
}
