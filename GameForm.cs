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
    public partial class GameForm : Form
    {
        // Local variables
        int Quest;
        string answer;

        // Constructor
        public GameForm(int question)
        {
            InitializeComponent();
            Quest = question;
            LoadQuiz();
            string UserName = Form1.Get_UserName();
            int points = Get_UserPoints();
            label2.Text = ("User: " + UserName + " | Points: " + points);
        }

        /// <summary>
        /// 4 Action Button which verify the correctness of the response given by the user
        /// </summary>
        private void Answer1_Click(object sender, EventArgs e)
        {
            if (Quest <= GlobalUtilities.LastQuest)
            {
                if (answer == Answer1.Text)
                {
                    MessageBox.Show("Your answer is correct! \n    +1");
                    Task.Run(() => AddPoint());
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your answer is wrong!");
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Game finished!");
                //Form1 f = new Form1(true, Form1.ID_User);
                //f.Show();
            }
        }

        private void Answer2_Click(object sender, EventArgs e)
        {
            if (Quest <= GlobalUtilities.LastQuest)
            {
                if (answer == Answer2.Text)
                {
                    MessageBox.Show("Your answer is correct! \n    +1");
                    Task.Run(() => AddPoint());
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your answer is wrong!");
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Game finished!");
                //Form1 f = new Form1(true, Form1.ID_User);
                //f.Show();
            }
        }

        private void Answer3_Click(object sender, EventArgs e)
        {
            if (Quest <= GlobalUtilities.LastQuest)
            {
                if (answer == Answer3.Text)
                {
                    MessageBox.Show("Your answer is correct! \n    +1");
                    Task.Run(() => AddPoint());
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your answer is wrong!");
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Game finished!");
                //Form1 f = new Form1(true, Form1.ID_User);
                //f.Show();
            }
        }

        private void Answer4_Click(object sender, EventArgs e)
        {
            if (Quest <= GlobalUtilities.LastQuest)
            {
                if (answer == Answer4.Text)
                {
                    MessageBox.Show("Your answer is correct! \n    +1");
                    Task.Run(() => AddPoint());
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your answer is wrong!");
                    GameForm gf = new GameForm(Quest++);
                    gf.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Game finished!");
                //Form1 f = new Form1(true, Form1.ID_User);
                //f.Show();
            }
        }

        /// <summary>
        /// Async Method called in Constructor
        /// Loads new data from the Database for game current session
        /// </summary>
        private async void LoadQuiz()
        {
            await Task.Run(() =>
            {
                try
                {
                    using (QuizDbContext db = new QuizDbContext())
                    {
                        var res = from s in db.Quizes
                                  where s.IDQuiz.Equals(Quest)
                                  select new
                                  {
                                      s.Question,
                                      s.Answer1,
                                      s.Answer2,
                                      s.Answer3,
                                      s.Answer4,
                                      s.CorectAnswer
                                  };
                        foreach (var q in res)
                        {
                            Answer1.Text = q.Answer1;
                            Answer2.Text = q.Answer2;
                            Answer3.Text = q.Answer3;
                            Answer4.Text = q.Answer4;
                            answer = q.CorectAnswer;
                        }
                    }
                    Form1.TraceWrite("Loaded Quiz");
                }
                catch
                {
                    MessageBox.Show("Error accessing DataBase! \nTry again...");
                }
            });
        }

        /// <summary>
        /// Async Method called in buttons, it is used to add one point to
        /// User's points in Database
        /// </summary>
        private async void AddPoint()
        {
            await Task.Run(() =>
            {
                using (UserDbContext db = new UserDbContext())
                {
                    var res = db.Users.SingleOrDefault(u => u.IdUser == GlobalUtilities.ID_User);

                    if (res != null)
                    {
                        res.UserPoints++;
                        db.SaveChanges();
                    }
                }
                Form1.TraceWrite("Added Point on UserPoints in UserDB");
            });
        }

        /// <summary>
        /// Synchronous method thet loads User's Points from Database
        /// </summary>
        private int Get_UserPoints()
        {
            int points = 0;
            try
            {
                using (UserDbContext db = new UserDbContext())
                {
                    var res = db.Users.SingleOrDefault(u => u.IdUser == GlobalUtilities.ID_User);

                    if (res != null)
                    {
                        points = res.UserPoints;
                    }
                }
                Form1.TraceWrite("Readed Points in User Database");
                return points;
            }
            catch
            {
                MessageBox.Show("Error accessing User Database!");
                return points;
            }
        }

        /// <summary>
        /// Action Button that closes actual Form (ends actual game session)
        /// </summary>
        private void QuitButton_Click(object sender, EventArgs e)
        {
            //Form1 f = new Form1(true, Form1.ID_User);
            //f.Show();
            this.Close();
        }
    }
}
