using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Primes
{
    public partial class Form1 : Form
    {
        private readonly List<Item> _listTask = new List<Item>();

        public Form1()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var currentValue = Value.Value;
            var createTask = new Item((int) currentValue);
            _listTask.Add(createTask);
            TaskPanel.Controls.Add(createTask);
            TaskPanel.ScrollControlIntoView(createTask);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var task in _listTask)
            {
               task.Stop(); 
            }
        }
    }
}
