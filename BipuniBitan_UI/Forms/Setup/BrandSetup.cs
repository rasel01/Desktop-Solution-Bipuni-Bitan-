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
           
            LoadCatagoryList();
            LoadDgvBrand();
        }

        private void LoadDgvBrand()
        {
            DataSet ds = bm.GetDgvBrandList();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
               ShowDgvBrandList(ds);
            }
            else
            {
                dgvBrandList.DataSource = null;
                dgvBrandList = General.ClearDataGridView(dgvBrandList);
            }
        }

        private void ShowDgvBrandList(DataSet ds)
        {
            dgvBrandList = General.CustomizeDataGridView(dgvBrandList);

            DataGridViewImageColumn edit = new DataGridViewImageColumn();
            Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            edit.Image = editeImage;
            edit.Width = 20;
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBrandList.Columns.Add(edit);


            dgvBrandList.Columns.Add("Brand_Name", "Brand Name");
            dgvBrandList.Columns.Add("Catagory_Name", "Catagory Name");
            dgvBrandList.Columns.Add("Creationby", "Creation By");
            dgvBrandList.Columns.Add("catagory_id", "catagory_id");
            dgvBrandList.Columns.Add("Brand_Remarks", "Remarks");
            dgvBrandList.Columns.Add("Brand_id", "Brand_id");

            dgvBrandList.Columns["Brand_Name"].DataPropertyName = "Brand_Name";
            dgvBrandList.Columns["Catagory_Name"].DataPropertyName = "Catagory_Name";
            dgvBrandList.Columns["Creationby"].DataPropertyName = "Creationby";
            dgvBrandList.Columns["Brand_Remarks"].DataPropertyName = "Brand_Remarks";
            dgvBrandList.Columns["Brand_id"].DataPropertyName = "Brand_id";
            dgvBrandList.Columns["catagory_id"].DataPropertyName = "catagory_id";

            dgvBrandList.DataSource = ds.Tables[0];
            dgvBrandList.Columns["Brand_id"].Visible = false;
            dgvBrandList.Columns["catagory_id"].Visible = false;
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
                        LoadDgvBrand();
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
          ddlCatagory.SelectedValue = "0";

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BrandControlsClear();
        }

        private void dgvBrandList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                txtBrandID.Text = dgvBrandList.Rows[e.RowIndex].Cells["Brand_id"].Value.ToString();
                txtBrandName.Text = dgvBrandList.Rows[e.RowIndex].Cells["Brand_Name"].Value.ToString();
                txtBrandRemarks.Text = dgvBrandList.Rows[e.RowIndex].Cells["Brand_Remarks"].Value.ToString();
                ddlCatagory.SelectedValue = dgvBrandList.Rows[e.RowIndex].Cells["catagory_id"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult user = MessageBox.Show(@"Do You want to delete Brand ?", @"Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (user == DialogResult.OK)
                {
                    string id = txtBrandID.Text;
                    string name = txtBrandName.Text;
                    bool result = bm.DeleteCatagoryList(id);
                    if (result)
                    {
                        General.SuccessMessage(name + " " + " Deleted successfully");
                        LoadDgvBrand();
                        BrandControlsClear();

                    }
                    else
                    {
                        General.SuccessMessage(name + " " + " : Failed to Delete");
                        LoadDgvBrand();
                        BrandControlsClear();
                    }
                }



            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }
        }
    }
}
