using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hungman
{
    public partial class Form1 : Form
    {
        public int errorCounter = 0;

        public Form1()
        {
            InitializeComponent();
            questionBox.Text = GenerateRandomOperation();
            updateHangmanImage();
        }

        private static readonly Random random = new Random(); // Single instance

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), "Minimum value cannot be greater than maximum value.");
            }

            return random.Next(minValue, maxValue + 1);
        }

        public static string GenerateRandomOperation()
        {
            int value1 = GenerateRandomNumber(1, 10);
            int value2 = GenerateRandomNumber(1, 10);

            string operation = value1.ToString() + "x" + value2.ToString();
            return operation;
        }

        private void SetInputItem(string item)
        {
            string currentValueText = answerBox.Text;
            string newValue = item.ToString();

            currentValueText += newValue;
            answerBox.Text = currentValueText;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            SetInputItem("0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetInputItem("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetInputItem("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetInputItem("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetInputItem("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetInputItem("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetInputItem("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetInputItem("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetInputItem("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SetInputItem("9");
        }

        public static int getOperationResult(object sender, EventArgs e, TextBox textBox)
        {
            string input = textBox.Text;
            int operatorIndex = input.IndexOf('x'); // Find the index of the multiplication operator

            if (operatorIndex == -1)
            {
                throw new ArgumentException("Multiplication operator (x) not found in input.");
            }

            // Get first number
            string firstNumberString = input.Substring(0, operatorIndex);
            int number1 = int.Parse(firstNumberString);

            // Get second number
            string secondNumberString = input.Substring(operatorIndex + 1);
            int number2 = int.Parse(secondNumberString);

            return number1 * number2;
        }

        private void cleanAnswerBox()
        {
            answerBox.Text = "";
        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            int userAnswer = int.Parse(answerBox.Text);
            int operationResult = getOperationResult(this, EventArgs.Empty, questionBox);

            if (userAnswer == operationResult)
            {
                MessageBox.Show($"Congrats! you've got the correct answer!", "Correct answer!");
            }
            else
            {
                errorCounter++;
                updateHangmanImage();
                MessageBox.Show($"The answer was: {operationResult}, your answer: {userAnswer}", "Wrong answer!");
            }

            questionBox.Text = GenerateRandomOperation();
            cleanAnswerBox();
        }
        private void updateHangmanImage()
        {
            switch (errorCounter)
            {
                case 0: hangmanPicture.Image = Properties.Resources._0_err; break;
                case 1: hangmanPicture.Image = Properties.Resources._1_err; break;
                case 2: hangmanPicture.Image = Properties.Resources._2_err; break;
                case 3: hangmanPicture.Image = Properties.Resources._3_err; break;
                case 4: hangmanPicture.Image = Properties.Resources._4_err; break;
                case 5: hangmanPicture.Image = Properties.Resources._5_err; break;
                case 6: hangmanPicture.Image = Properties.Resources._6_err; break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
