using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        double secondNumber = 0;
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            display.Text += button.Text;
        }

        private void buttonOperation_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            firstNumber = double.Parse(display.Text);
            operation = button.Text;
            display.Text = "";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            secondNumber = double.Parse(display.Text);

            switch (operation)
            {
                case "+":
                    display.Text = (firstNumber + secondNumber).ToString();
                    break;
                case "-":
                    display.Text = (firstNumber - secondNumber).ToString();
                    break;
                case "*":
                    display.Text = (firstNumber * secondNumber).ToString();
                    break;
                case "/":
                    if (secondNumber != 0)
                        display.Text = (firstNumber / secondNumber).ToString();
                    else
                        display.Text = "Error";
                    break;
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            display.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText("results.txt", display.Text);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("results.txt"))
                display.Text = File.ReadAllText("results.txt");
        }
        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            this.BackColor = this.BackColor == Color.White ? Color.LightGray : Color.White;
        }

    }
}
