using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arsma
{
	public partial class Form1 : Form
	{
		Double result = 0;
		String operation = null;
		bool isOperationSelected = false;
		bool isSelectedEqual = false;
		public Form1()
		{
			InitializeComponent();
		}
		private void number_Click(object sender, EventArgs e)
		{
			Button number1 = (Button)sender;
			area.Text += number1.Text;
			isSelectedEqual = false;
			if (isOperationSelected)
			{
				sum.Text += number1.Text;
			} else
			{
				sum.Text = "";
			}
		}

		private void operation_Click(object sender, EventArgs e)
		{
			Button operationSelected = (Button)sender;
			if(area.Text == "")
			{
				return;
			}
			if(!isOperationSelected)
			{
				operation = operationSelected.Text;
				result = Double.Parse(area.Text);
				area.Clear();
				sum.Text = result + " " + operation + " ";
				isOperationSelected = true;
				return;
			}
		}

		private void equal_Click(object sender, EventArgs e)
		{
			if ((area.Text == "" && !(operation == "^2" || operation == "^½") || isSelectedEqual))
			{
				return;
			}
			switch (operation)
			{
				case "+":
					result += Double.Parse(area.Text);
					operationHelper();
					break;
				case "-":
					result -= Double.Parse(area.Text);
					operationHelper();
					break;
				case "*":
					result *= Double.Parse(area.Text);
					operationHelper();
					break;
				case "/":
					result /= Double.Parse(area.Text);
					operationHelper();
					break;
				case "^2":
					result *= result;
					operationHelper();
					break;
				case "^½":
					result = Math.Sqrt(result);
					operationHelper();
					break;
			}
		}

		private void operationHelper()
		{
			sum.Text += " = " + result.ToString();
			isOperationSelected = false;
			area.Text = result.ToString();
			isSelectedEqual = true;
		}

		private void dot_Click(object sender, EventArgs e)
		{
			Button dot = (Button)sender;
			if (area.Text.Contains(",") || area.Text.Length == 0)
			{
				return;
			}
			area.Text += dot.Text;

			if (isOperationSelected)
			{
				sum.Text += dot.Text;
			}
			else
			{
				sum.Text = "";
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			dateAndTime.Text = DateTime.Now.ToString();
		}

		private void cleanButton(object sender, EventArgs e)
		{
			result = 0;
			sum.Text = "";
			isOperationSelected = false;
			area.Text = "";
		}
	}
}
