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
    public partial class UserDbViewForm : Form
    {
        int admin = -1;
        public UserDbViewForm(int adm)
        {
            InitializeComponent();
            Task.Run(() => LoadData());
            admin = adm;
        }

        // BACK BUTTON -> DONE
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // LOAD DATA -> DONE
        private async void LoadData()
        {
            await Task.Run(() =>
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
                        dataGridView1.DataSource = res.ToList();
                    }
                    Form1.TraceWrite("Loaded Users from DataBase");
                
            });
        }

        // REFRESH BUTTON -> DONE
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() => LoadData());
            }
            catch
            {
                MessageBox.Show("Error loading User Database!");
            }
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