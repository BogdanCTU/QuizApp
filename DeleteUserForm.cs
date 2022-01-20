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
    public partial class DeleteUserForm : Form
    {
        // Constructor
        public DeleteUserForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Action Button that search an instance of User in Database
        /// that coincides with the appropriate User ID
        /// </summary>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) != true)
            {
                int id_u = int.Parse(textBox1.Text);
                //Task.Run(() => 
                //SearchUser(int.Parse(textBox1.Text));
                //);
                SearchUser(id_u);
            }
            else
            {
                MessageBox.Show("Please insert User ID in textbox! \n    Try again...");
            }
        }

        /// <summary>
        /// Method called in SearchButton
        /// used to search the appropriate instance of User
        /// </summary>
        private void SearchUser(int ID)
        {
            //await Task.Run(() =>
            //{
            try
            {
                using (UserDbContext db = new UserDbContext())
                {

                    var res = from s in db.Users
                              where s.IdUser.Equals(ID)
                              select new
                              {
                                  s.IdUser,
                                  s.UserUsername,
                                  s.UserPoints
                              };
                    dataGridView1.DataSource = res.ToList();
                }
                Form1.TraceWrite("Searched User in DataBase");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please insert values in textbox!");
            }
            //});
        }

        /// <summary>
        /// Action Button that search an instance of User in Database
        /// that coincides with the appropriate User ID and deletes it
        /// </summary>
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

        /// <summary>
        /// Action Button that closes actual Form
        /// </summary>
        private void BackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method that search an instance of User in Database
        /// that coincides with the appropriate User ID and deletes it
        /// </summary>
        private async void DeleteUserAsync(int ID)
        {
            await Task.Run(() =>
            {
                using (UserDbContext db = new UserDbContext())
                {
                    var res = db.Users.SingleOrDefault(p => p.IdUser == ID);

                    if (res != null)
                    {
                        db.Entry(res).State = System.Data.Entity.EntityState.Deleted;   // delete user
                        db.SaveChanges();
                    }
                }
                this.DialogResult = DialogResult.OK;
                Form1.TraceWrite("Delete User");
            });
        }

        // EOF
    }
}
