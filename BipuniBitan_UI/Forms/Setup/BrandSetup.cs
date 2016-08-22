using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BipuniBitan_Manager.Setup;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_UI.Forms.Setup
{
    public partial class BrandSetup : Form
    {
        BrandManager bm = new BrandManager();
        public BrandSetup()
        {
            InitializeComponent();
            Intialize();
        }

        private void Intialize()
        {
            // commit
            LoadCatagoryList();
        }

        private void LoadCatagoryList()
        {
          
            DataSet ds = bm.GetCatagoryList();
            DataTable dt = new DataTable();
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                dt = ds.Tables[0];
            }
            else
            {
                dt.Columns.Add("catagory_id");
                dt.Columns.Add("catagory_name");

                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                dt.Rows.InsertAt(dr, 0);
            }
            ddlCatagory.DataSource = dt;
            ddlCatagory.DisplayMember = "catagory_name";
            ddlCatagory.ValueMember = "catagory_id";
            ddlCatagory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                string BrandID = txtBrandID.Text;
                string catagoryName = ddlCatagory.SelectedValue.ToString();
                string Brandremarks = txtBrandRemarks.Text;
                string BrandName = txtBrandName.Text;

                try
                {

                    bool result = bm.saveUpdateBrand(BrandID, catagoryName, Brandremarks, BrandName);
                    if (result)
                    {
                        General.SuccessMessage(BrandName + " " + "Save successfully");
                        //LoadDgvCatagoryList();
                        BrandControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }
            }
        }

        private void BrandControlsClear()
        {
          txtBrandID.Text = String.Empty;
          txtBrandName.Text = String.Empty;
          txtBrandRemarks.Text = String.Empty;
          ddlCatagory.Text = String.Empty;

        }

        private bool validation()
        {
            string msg = String.Empty;
            bool flag = false;
            try
            {
                if (ddlCatagory.SelectedValue.ToString() == "0")
                {
                    
                    msg += "Must select a catagory"+ Environment.NewLine;
                }
                if (string.IsNullOrEmpty(txtBrandName.Text))
                {
                    msg += "Must take a brand name" + Environment.NewLine;
                }
                if (msg==String.Empty)
                {
                    flag = true;
                }
                else
                {
                    General.WarningMessage(msg);
                }

            }
            catch (Exception ex)
            {
                
               General.ErrorMessage(ex.Message);
            }
            return flag;
        }
    }
}
