using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IteratorPattern
{
    public partial class MainForm : Form
    {
        private Bank _bank = new Bank();

        public MainForm()
        {
            InitializeComponent();
            _bank.Manager = "Manager";
            _bank.Accountant = "Accountant";
            _bank.Cashier = "Cashier";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print(_bank.Manager);
            Print(_bank.Accountant);
            Print(_bank.Cashier);
        }

        private void Print(string name)
        {
            // Print the name
            MessageBox.Show(name + " printed..");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankIterator iterator = new BankIterator(_bank);
            foreach (string name in iterator)
                Print(name);
        }
    }
}
