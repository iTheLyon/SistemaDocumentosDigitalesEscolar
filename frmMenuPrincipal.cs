﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDD2
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmBusquedaDocumento frmBusquedaDocumento1 = new frmBusquedaDocumento();
            frmBusquedaDocumento1.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            frmDocumento frmDocumento1 = new frmDocumento();
            frmDocumento1.Show();
          
        }
    }
}