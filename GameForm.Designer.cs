﻿
namespace QuizApp
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.label1 = new System.Windows.Forms.Label();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Answer1 = new System.Windows.Forms.Button();
            this.Answer2 = new System.Windows.Forms.Button();
            this.Answer4 = new System.Windows.Forms.Button();
            this.Answer3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question:";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.BackColor = System.Drawing.SystemColors.Window;
            this.QuestionLabel.Location = new System.Drawing.Point(9, 69);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(250, 13);
            this.QuestionLabel.TabIndex = 1;
            this.QuestionLabel.Text = "In what year did Romania join the European Union?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Answers:";
            // 
            // Answer1
            // 
            this.Answer1.BackColor = System.Drawing.Color.White;
            this.Answer1.Location = new System.Drawing.Point(12, 112);
            this.Answer1.Name = "Answer1";
            this.Answer1.Size = new System.Drawing.Size(125, 23);
            this.Answer1.TabIndex = 3;
            this.Answer1.Text = "1990";
            this.Answer1.UseVisualStyleBackColor = false;
            this.Answer1.Click += new System.EventHandler(this.Answer1_Click);
            // 
            // Answer2
            // 
            this.Answer2.BackColor = System.Drawing.Color.White;
            this.Answer2.Location = new System.Drawing.Point(193, 112);
            this.Answer2.Name = "Answer2";
            this.Answer2.Size = new System.Drawing.Size(125, 23);
            this.Answer2.TabIndex = 4;
            this.Answer2.Text = "1998";
            this.Answer2.UseVisualStyleBackColor = false;
            this.Answer2.Click += new System.EventHandler(this.Answer2_Click);
            // 
            // Answer4
            // 
            this.Answer4.BackColor = System.Drawing.Color.White;
            this.Answer4.Location = new System.Drawing.Point(193, 154);
            this.Answer4.Name = "Answer4";
            this.Answer4.Size = new System.Drawing.Size(125, 23);
            this.Answer4.TabIndex = 5;
            this.Answer4.Text = "1978";
            this.Answer4.UseVisualStyleBackColor = false;
            this.Answer4.Click += new System.EventHandler(this.Answer4_Click);
            // 
            // Answer3
            // 
            this.Answer3.BackColor = System.Drawing.Color.White;
            this.Answer3.Location = new System.Drawing.Point(12, 154);
            this.Answer3.Name = "Answer3";
            this.Answer3.Size = new System.Drawing.Size(125, 23);
            this.Answer3.TabIndex = 6;
            this.Answer3.Text = "1987";
            this.Answer3.UseVisualStyleBackColor = false;
            this.Answer3.Click += new System.EventHandler(this.Answer3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "User: aaaaaaaa | Points: 0";
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.SystemColors.Window;
            this.QuitButton.Location = new System.Drawing.Point(243, 4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 8;
            this.QuitButton.Text = "Quit Now";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(330, 187);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Answer3);
            this.Controls.Add(this.Answer4);
            this.Controls.Add(this.Answer2);
            this.Controls.Add(this.Answer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.QuestionLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Answer1;
        private System.Windows.Forms.Button Answer2;
        private System.Windows.Forms.Button Answer4;
        private System.Windows.Forms.Button Answer3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button QuitButton;
    }
}