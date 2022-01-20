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

        /// <summary>
        /// Local variable used to determine if user is
        /// </summary>
        int admin = -1;

        // Constructor
        public UserDbViewForm(int adm)
        {
            InitializeComponent();
            //Task.Run(() =>
            LoadData();
            //);
            admin = adm;
        }

        /// <summary>
        /// Action Button that closes actual Form and opens Main App Form (Form1)
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            ul.Show();
            this.Close();
        }

        /// <summary>
        /// Method Used to load data from User Database in ViewDataGrid
        /// </summary>
        private void LoadData()
        {
            try
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
                }
            catch
            {
                MessageBox.Show("Error loading User Database!");
            }
        }

        /// <summary>
        /// Action button that calls LoadData method
        /// </summary>
        private void RefreshButton_Click(object sender, EventArgs e)
        {

            //Task.Run(() => 
            LoadData();
                //);
            
        }

        /// <summary>
        /// Action button that opens AddUser Form
        /// </summary>
        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUserForm au = new AddUserForm();
            au.ShowDialog();
        }

        /// <summary>
        /// Action button that opens DeleteUser Form
        /// </summary>
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