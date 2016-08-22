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
            //if (validation())
            //{
            //    string catagoryID = txtCatagoryID.Text;
            //    string catagoryName = txtCatagoryName.Text;
            //    string remarks = txtCatagoryRemarks.Text;
            //    try
            //    {

            //        bool result = cm.saveUpdateCatagory(catagoryName, catagoryID, remarks);
            //        if (result)
            //        {
            //            General.SuccessMessage(catagoryName + " " + "Save successfully");
            //            LoadDgvCatagoryList();
            //            CatagoryControlsClear();

            //        }

            //    }
            //    catch (Exception ex)
            //    {

            //        General.ErrorMessage(ex.Message);
            //    }



            //}
        }
    }
}
