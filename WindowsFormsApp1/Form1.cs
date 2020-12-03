using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "Что то происходит";
            double SumOfCredit = Double.Parse(textBox1.Text, CultureInfo.InvariantCulture) ;
            double InterestRate = Double.Parse(textBox2.Text, CultureInfo.InvariantCulture);
            double CreditPeriod = Double.Parse(textBox3.Text, CultureInfo.InvariantCulture);
            double MainPayment = SumOfCredit / CreditPeriod; // платеж по основному долгу
                                                           
            for (int i = 0; i < CreditPeriod; ++i)
            {
                double procentPart = SumOfCredit * (InterestRate / 12 / 100); //подсчет процентной части ежемесячного платежа
                SumOfCredit -= MainPayment; //подсчет остатка основного долга (с каждым месяцем уменьшается)
                dataGridView1.Rows.Add(); //добавляем строку в таблицу
                dataGridView1[0, i].Value = i + 1; //номер месяца
                dataGridView1[1, i].Value = (MainPayment + procentPart).ToString("N2"); //полный ежемесячный платеж
                dataGridView1[2, i].Value = MainPayment.ToString("N2"); //платеж по основному долгу
                dataGridView1[3, i].Value = procentPart.ToString("N2"); //процентная часть ежемесячного платежа
                dataGridView1[4, i].Value = SumOfCredit.ToString("N2"); //Остаток по основному долгу
            }
                    }
    

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace
            {
                e.Handled = true;
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 46) // цифры, клавиша BackSpace, точка и запятая
            {
                e.Handled = true;
                return;
            }
            if ((textBox3.Text.Contains(".") || textBox3.Text.Contains(",")) && (number == 44 || number == 46))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
