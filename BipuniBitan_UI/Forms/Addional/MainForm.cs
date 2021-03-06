﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BipuniBitan_Manager;
using BipuniBitan_Manager.Security;
using BipuniBitan_UI.Forms.Security;
using BipuniBitan_UI.Forms.Setup;
using BipuniBitan_UI.Forms.Transaction;

namespace BipuniBitan_UI.Forms.Addional
{
    public partial class MainForm : Form
    {
        AuthenticationManager LoginManager = new AuthenticationManager();
        public MainForm()
        {
            InitializeComponent();
            
          
            this.Text = @"BipuniBitan.com :" + AuthenticationManager.LoginUserName;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show(@"Do you want logout ?", @"Signing Off", MessageBoxButtons.OKCancel);
            if (logout.Equals(DialogResult.OK))
            {
                AuthenticationManager.LoginUserName = string.Empty;
                AuthenticationManager.LoginUserId = string.Empty;
                AuthenticationManager.LoginUserPass = string.Empty;
                this.Hide();
                home login = new home();
                login.ShowDialog();
                // commit
            }

        }

        private void catagorySetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            CatagorySetup catagory = new CatagorySetup();
            catagory.TopLevel = false;
            catagory.Dock = DockStyle.Fill;
            catagory.AutoScroll = true;
            catagory.FormBorderStyle = FormBorderStyle.None;
            MainFormPanel.Controls.Add(catagory);
            catagory.Show();
        }

        private void brandSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            BrandSetup brand = new BrandSetup();
            brand.TopLevel = false;
            brand.AutoScroll = true;
            brand.Dock = DockStyle.Fill;
            brand.FormBorderStyle = FormBorderStyle.None;
            MainFormPanel.Controls.Add(brand);
            brand.Show();

        }

        private void mesurementSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            MeasurmentUnitSetup measurmentUnit = new MeasurmentUnitSetup();
            measurmentUnit.TopLevel = false;
            measurmentUnit.AutoScroll = true;
            measurmentUnit.Dock = DockStyle.Fill;
            measurmentUnit.FormBorderStyle = FormBorderStyle.None;
            MainFormPanel.Controls.Add(measurmentUnit);
            measurmentUnit.Show();



        }

        private void itemSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            ItemSetup item = new ItemSetup();
            item.TopLevel = false;
            item.AutoScroll = true;
            item.FormBorderStyle = FormBorderStyle.None;
            item.Dock = DockStyle.Fill;
            MainFormPanel.Controls.Add(item);
            item.Show();
        }

        private void supplierSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            SupplierSetup supplier  = new SupplierSetup();
            supplier.TopLevel = false;
            supplier.AutoScroll = true;
            supplier.FormBorderStyle = FormBorderStyle.None;
            supplier.Dock = DockStyle.Fill;
            MainFormPanel.Controls.Add(supplier);
            supplier.Show();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            
        }

        private void receieveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            ItemReceive ItmRece = new ItemReceive();
            ItmRece.TopLevel = false;
            ItmRece.AutoScroll = true;
            ItmRece.FormBorderStyle = FormBorderStyle.None;
            ItmRece.Dock = DockStyle.Fill;
            MainFormPanel.Controls.Add(ItmRece);
            ItmRece.Show();
        }

        private void stockInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            ItemStock ItmS = new ItemStock();
            ItmS.TopLevel = false;
            ItmS.AutoScroll = true;
            ItmS.FormBorderStyle = FormBorderStyle.None;
            ItmS.Dock = DockStyle.Fill;
            MainFormPanel.Controls.Add(ItmS);
            ItmS.Show();
        }

        private void distributeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            ItemDistribution ItmDis = new ItemDistribution();
            ItmDis.TopLevel = false;
            ItmDis.AutoScroll = true;
            ItmDis.FormBorderStyle = FormBorderStyle.None;
            ItmDis.Dock = DockStyle.Fill;
            MainFormPanel.Controls.Add(ItmDis);
            ItmDis.Show();
        }

        private void returnItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            ItemReturn itemRet = new ItemReturn();
            itemRet.TopLevel = false;
            itemRet.AutoScroll = true;
            itemRet.FormBorderStyle = FormBorderStyle.None;
            itemRet.Dock = DockStyle.Fill;
            MainFormPanel.Controls.Add(itemRet);
            itemRet.Show();
        }

        private void staffCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MainFormPanel.Controls.Clear();
            StaffCreation staff = new StaffCreation();
            staff.TopLevel = false;
            staff.AutoScroll = true;
            staff.FormBorderStyle = FormBorderStyle.None;
            staff.Dock = DockStyle.Fill;
            MainFormPanel.Controls.Add(staff);
            staff.Show();

        }
    }
}
