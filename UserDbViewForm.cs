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
    public partial class UserDbViewForm : Form
    {
        int admin = -1;
        public UserDbViewForm(int adm)
        {
            InitializeComponent();
            LoadData();
            admin = adm;
        }

        // BACK BUTTON -> DONE
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            //UserLogin u = new UserLogin();
            //u.Show();
        }

        // LOAD DATA -> DONE
        private void LoadData()
        {
            using (UserDbContext db = new UserDbContext())
            {
                var res = from s in db.Users
                          select new
                          {
                              s.IdUser,
                              s.UserUsername,
                              s.UserPoints
                          };
                          //error if add UserPassword
                dataGridView1.DataSource = res.ToList();
            }
        }

        // REFRESH BUTTON -> DONE
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // ADD -> DONE
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUserForm au = new AddUserForm();
            au.ShowDialog();
        }

        // DELETE -> DONE
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (admin == -1)
            {
                DeleteUserForm du = new DeleteUserForm();
                du.ShowDialog();
            }
            else
            {
                MessageBox.Show("You don't have admin permissions!");
            }
        }
    }
}