﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs6232_g4
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// tabs changing event handler
        /// </summary>
        private void MainDBTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.MainDBTabControl.SelectedIndex == 0)
            {
                this.memberRegistrationUserControl.ResetFields();
            }
        }
    }
}
