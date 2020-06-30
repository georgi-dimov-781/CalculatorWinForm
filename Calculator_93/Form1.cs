using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_93
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double memoryOperand;


        private void updateDisplay(string update, Boolean replace = false)
        {
            if (display.Text == "0" || replace)
            {
                display.Text = update;
            }
            else
            {
                display.Text += update;
            }
        }





        private void btnWasClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string output;
            if (this.is_operands(btn.Text))
            {
                output = " " + btn.Text + " ";
            }
            else
            {
                output = btn.Text;
            }

            updateDisplay(output);
        }

        private void calculateBtn(object sender, EventArgs e)
        {
            String input = display.Text;

            try
            {
                var something = new DataTable().Compute(input, null);
                display.Text = Convert.ToString(something);
                listBox1.Items.Add(display.Text);


            }
            catch (Exception error)
            {
                MessageBox.Show("Грешка! Стойността, която въвеждате, може би не е валидна!");
            }
        }

        private void deleteWasClicked(object sender, EventArgs e)
        {
            bool actually_deleted_something = false;
            while (display.Text.Length > 0)
            {
                string nextChar = display.Text.Substring(display.Text.Length - 1);
                if (nextChar != " ")
                {
                    if (actually_deleted_something)
                    {
                        break;
                    }
                    actually_deleted_something = true;
                }
                display.Text = display.Text.Substring(0, display.Text.Length - 1);
            }


            if (display.Text.Length == 0)
            {
                display.Text = "0";
            }
        }

        public bool is_operands(string thing)
        {
            string[] operands = new String[] { "+", "-", "*", "/" };
            return operands.Contains(thing);

        }

        private void btnInvert_Click_1(object sender, EventArgs e)
        {
            if (this.display.Text != "0")
            {
                if (this.display.Text[0] == '-')
                    this.display.Text = this.display.Text.Substring(1);
                else
                    this.display.Text = "-" + this.display.Text;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            double percentage = double.Parse(display.Text);
            percentage = percentage / 100;
            display.Text = percentage.ToString();
            listBox1.Items.Add(display.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            display.Text = (Math.Sqrt(double.Parse(display.Text))).ToString();
            listBox1.Items.Add(display.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display.Text = "";
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            memoryOperand = Convert.ToDouble(this.display.Text.ToString());
            this.lblMemory.Text = "M";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            display.Text = memoryOperand.ToString();
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            this.memoryOperand = 0.0;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            memoryOperand += Convert.ToDouble(this.display.Text.ToString());
            this.lblMemory.Text = "M";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblMemory_Click(object sender, EventArgs e)
        {

        }
    }
}
