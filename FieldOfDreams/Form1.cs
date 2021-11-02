using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FieldOfDreams
{
    public partial class Form1 : Form
    {
        string SecretWord = "Программист";
        string MaskWord = "";
        int Count = 10;

        void GenerateButtons()
        {
            for (char i ='А'; i <= 'Я'; i++)
            {
                Button X = new Button();
                X.Width = 30;
                X.Height = 30;
                X.Text += i;
                X.BackColor = Color.Cyan;
                X.Click += Letter_Click;
                flowLayoutPanel1.Controls.Add(X);
            }
        }

        private void Letter_Click(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Fuchsia;


            if (EndGame())
                MessageBox.Show("Конец игры");
            else
            {
                string result = SearchAndReplace(SecretWord, (sender as Button).Text, MaskWord);
                if (result == "error")
                    MessageBox.Show("Ошибка");
                else
                {
                    MaskWord = result;
                    labelWord.Text = result;
                    if (result == SecretWord)
                    {
                        MessageBox.Show("Победа");
                        Count = 0;
                    }
                }
                Count--;
            }
        }


            public Form1()
        {
            InitializeComponent();
            GenerateButtons();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SecretWord = SecretWord.ToUpper();

            for (int i = 0; i < SecretWord.Length; i++)
                MaskWord += "*";
            labelWord.Text = MaskWord;

        }

        private string SearchAndReplace(string secret, string input, string mask)
        {

            if (input.Length == 1 && input[0] >= 'А' && input[0] <= 'Я')
            {
                string temp = "";
                for (int i = 0; i < secret.Length; i++)
                    if (secret[i] == input[0])
                        temp += input[0];
                    else
                        temp += mask[i];
                return temp;
            }
            else
                return "error";

        }

        private bool EndGame()
        {
            return Count == 0;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {

        }
    }
}
