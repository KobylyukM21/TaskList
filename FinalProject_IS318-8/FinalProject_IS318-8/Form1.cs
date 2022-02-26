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


namespace FinalProject_IS318_8
{
    public partial class Form1 : Form
    {
        private int totalSeconds;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) // Daily Tasks Label
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e) // Daily Tasks Check Box List
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e) // Weekly Tasks Check Box List
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Daily Tasks Text Box
        {
            
        }

        private void label2_Click(object sender, EventArgs e) // Weekly Tasks Label
        {

        }

        private void button1_Click_1(object sender, EventArgs e) // Enter Button
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) // Checks to see if text box is emply
            {
                MessageBox.Show("Please Enter A Task"); // Prints message on screen if text box is empty
            }
            else
            {
                listBox1.Items.Add(textBox1.Text.ToString()); // Add textBox1 (Daily Tasks) to checkedListBox1
                textBox1.Text = string.Empty; // Clear textBox1 (Daily Tasks) After Submit Tasks Button is Clicked
            }
        }

        private void button5_Click(object sender, EventArgs e) // Delete Selected items in Daily Tasks
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox1);
            selectedItems = listBox1.SelectedItems;

            if (listBox1.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox1.Items.Remove(selectedItems[i]); // Deleted Selected Items 
            }
            else
            {
                MessageBox.Show("No Items Selected");
            }
        }

        private void button3_Click(object sender, EventArgs e) // Enter Button
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text)) // Checks to see if text box is emply
            {
                MessageBox.Show("Please Enter A Task"); // Prints message on screen if text box is empty
            }
            else
            {
                listBox2.Items.Add(textBox2.Text.ToString()); // Add textBox1 (Daily Tasks) to checkedListBox1
                textBox2.Text = string.Empty; // Clear textBox1 (Daily Tasks) After Submit Tasks Button is Clicked
            }
        }

        private void button4_Click(object sender, EventArgs e) // Enter Button
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text)) // Checks to see if text box is emply
            {
                MessageBox.Show("Please Enter A Task"); // Prints message on screen if text box is empty
            }
            else
            {
                listBox3.Items.Add(textBox3.Text.ToString()); // Add textBox1 (Daily Tasks) to checkedListBox1
                textBox3.Text = string.Empty; // Clear textBox1 (Daily Tasks) After Submit Tasks Button is Clicked
            }
        }

        private void button7_Click(object sender, EventArgs e) // Delete Selected items in Daily Tasks
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox3);
            selectedItems = listBox3.SelectedItems;

            if (listBox3.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox3.Items.Remove(selectedItems[i]); // Deleted Selected Items 
            }
            else
            {
                MessageBox.Show("No Items Selected");
            }
        }

        private void button6_Click(object sender, EventArgs e) // Delete Selected items in Weekly Tasks
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox2);
            selectedItems = listBox2.SelectedItems;

            if (listBox2.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox2.Items.Remove(selectedItems[i]); // Deleted Selected Items 
            }
            else
            {
                MessageBox.Show("No Items Selected");
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) // File Strip Menu
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) // Save Strip Menu
        {
            using (System.IO.StreamWriter A = new System.IO.StreamWriter(@"C:\Users\Public\Documents\DailyTaskList.txt")) // Saves Daily Tasks to Database
            {
                foreach (var item in listBox1.Items)
                {
                    A.WriteLine(item.ToString());
                }
            using (System.IO.StreamWriter B = new System.IO.StreamWriter(@"C:\Users\Public\Documents\WeeklyTaskList.txt")) // Saves Daily Tasks to Database
                {
                    foreach (var item in listBox2.Items)
                    {
                        B.WriteLine(item.ToString());
                    }
                }
            using (System.IO.StreamWriter C = new System.IO.StreamWriter(@"C:\Users\Public\Documents\MonthlyTaskList.txt")) // Saves Daily Tasks to Database
                {
                    foreach (var item in listBox3.Items)
                    {
                        C.WriteLine(item.ToString());
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // Exit Strip Menu
        {
            this.Close(); // Exit Button Closes Program
        }

        private void button2_Click(object sender, EventArgs e) // Start Timer Button
        {
            this.button2.Enabled = false; // Disables Start Button
            this.button8.Enabled = true; // Enables Stop Button

            int minutes = int.Parse(this.comboBox1.SelectedItem.ToString());
            int seconds = int.Parse(this.comboBox2.SelectedItem.ToString());

            totalSeconds = (minutes * 60) + seconds;

            this.timer1.Enabled = true; // Enables Timer

        }

        private void timer1_Tick(object sender, EventArgs e) // Timer
        {
            if(totalSeconds > 0)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds - (minutes * 60);
                this.label7.Text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                this.timer1.Stop();
                MessageBox.Show("Time is Up!");
                this.button2.Enabled = true;
                this.button8.Enabled = false;
            }
        }

        private void label6_Click(object sender, EventArgs e) // Seconds Label
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button8.Enabled = false;

            for (int i = 0; i < 60; i++) // Adds Mins into Timer
            {
                this.comboBox1.Items.Add(i.ToString());
            }
            for (int i = 0; i < 60; i++) // Adds Seconds into Timer
            {
                this.comboBox2.Items.Add(i.ToString()); 
            }
            this.comboBox1.SelectedIndex = 1;
            this.comboBox2.SelectedIndex = 1;
        }

        private void button8_Click(object sender, EventArgs e) // Stop Button
        {
            this.button8.Enabled = false; // Disables Stop Button
            this.button2.Enabled = true; // Enables Start Button

            totalSeconds = 0;
            this.timer1.Enabled = false; // Disables Stop Button
            label7.Text = "00:00"; // Resets the label to dafault text
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) // About Strip Tab
        {
            string message = ("Create by Maksim Kobylyuk\nLast Updated: December 2021");
            string title = ("About");
            MessageBox.Show(message, title);
        }

        private void label5_Click(object sender, EventArgs e) // Mins Label
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // Minutes ComboBox
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // Seconds ComboBox
        {

        }

        private void label7_Click(object sender, EventArgs e) // Timer Label
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string DailyTaskList = @"C:\Users\Public\Documents\DailyTaskList.txt"; // String Daily Task Database
            if (File.Exists(DailyTaskList))
            {
                using (System.IO.StreamReader A = new StreamReader(@"C:\Users\Public\Documents\DailyTaskList.txt")) // Opens Database when load button is clicked..
                    while (A.Peek() > -1)
                        listBox1.Items.Add(A.ReadLine());
            }
            else
            {
                MessageBox.Show("Daily Task List Database Does Not Exist!"); // Error message if database does not exist.
            }
            string WeeklyTaskList = @"C:\Users\Public\Documents\WeeklyTaskList.txt"; // String Weekly Task Database
            if (File.Exists (WeeklyTaskList))
            {
                using (System.IO.StreamReader B = new StreamReader(@"C:\Users\Public\Documents\WeeklyTaskList.txt")) // Opens Database when load button is clicked.
                    while (B.Peek() > -1)
                        listBox2.Items.Add(B.ReadLine());
            }
            else
            {
                MessageBox.Show("Weekly Task List Database Does Not Exist!"); // Error message if database does not exist.
            }
            string MonthlyTaskList = @"C:\Users\Public\Documents\MonthlyTaskList.txt"; // String Monthly Task Database
            if (File.Exists (MonthlyTaskList))
            {
                using (System.IO.StreamReader C = new StreamReader(@"C:\Users\Public\Documents\MonthlyTaskList.txt")) // Opens Database when load button is clicked.
                    while (C.Peek() > -1)
                        listBox3.Items.Add(C.ReadLine());
            }
            else
            {
                MessageBox.Show("Monthly Task List Database Does Not Exist!"); // Error message if database does not exist.
            }



        }
    }
}
