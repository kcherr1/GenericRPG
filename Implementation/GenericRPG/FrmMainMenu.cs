﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GenericRPG
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        public void ShowMain()
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new FrmMap(false);
            newForm.Show();
            this.Close();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var newForm = new FrmMap(true);
            newForm.Show();
            this.Close();
        }
    }
}
