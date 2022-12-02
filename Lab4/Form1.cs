using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private const int MIN_LENGTH = 3;
        private string[] commonPasswords = { "qwerty","password" };
        private int counter = 0;
        private int blockedTime = 5;


        public Form1()
        {
            InitializeComponent();
            fiveMin = new System.Windows.Forms.Timer()
            {
                Interval = 1000
            };
            fiveMin.Tick += new EventHandler(fiveMin_Tick_2);

            threeMin = new System.Windows.Forms.Timer()
            {
                Interval = 10000
            };
            threeMin.Start();
            threeMin.Tick += new EventHandler(threeMin_Tick_1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (commonPasswords.Any(w => string.Equals(w, textBox1.Text, StringComparison.InvariantCultureIgnoreCase)))
            {
                label2.Text = "Введений пароль є надто поширеним";
                label2.ForeColor = Color.Red;
                counter++;
            }
            else //(!threeMin.Enabled)
            {
                label2.Text = "Пароль є надійним";
                label2.ForeColor = Color.Green;
                counter = 0;
                threeMin.Stop();
                fiveMin.Stop();
                Form2 example = new Form2();
                example.Show();
            }
        }

        private void threeMin_Tick_1(object sender, EventArgs e)
        {
            threeMin.Stop();
            fiveMin.Start();
            textBox1.Enabled = false;
            button1.Enabled = false;
            label2.Text = $"Зачекайте {blockedTime}с., щоб знову ввести пароль.";
            label2.ForeColor = Color.Red;
        }

        private void fiveMin_Tick_2(object sender, EventArgs e)
        {
            if (blockedTime-- <= 0)
            {
                textBox1.Enabled = true;
                button1.Enabled = true;
                fiveMin.Stop();
                threeMin.Start();
                label2.Text = "Можете знову вводити пароль!";
                blockedTime = 5;
            }
             //бла
             //   бла
             //   бла
             //   бла
             //   бла
            
        }
    }
}