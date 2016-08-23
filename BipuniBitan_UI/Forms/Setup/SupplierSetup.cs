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
    public partial class SupplierSetup : Form
    {
        //SupplierManager sm = new SupplierManager();
        AdditionalManager am = new AdditionalManager();
        public SupplierSetup()
        {
            InitializeComponent();
            LoadDgvSupplierList();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //if (validation())
            //{
            //    string SuppID = txtSupplierID.Text;
            //    string SuppName = txtSupplierNAME.Text;
            //    string suppAddress = txtSupplierADDRESS.Text;
            //    string suppCompanyName = txtSupplierCOMPANY.Text;
            //    string suppContactPersonName = txtSupplierCONTACT.Text;
            //    string suppPhoneNumber = txtSupplierPHONE.Text;
            //    string suppCountry = txtSupplierCOUNTRY.Text;
            //    string suppCity = txtSupplierCiTY.Text;
            //    string suppEmail = txtSupplierEMAIL.Text;
            //    string suppWebAddress = txtSupplierWEB.Text;

            //    //string suppPhoneNumber = txtSupplierPHONE.Text;
            //    try
            //    {

            //        bool result = sm.saveUpdateSupplier(SuppID, SuppName, suppAddress, suppCompanyName, suppContactPersonName,
            //            suppPhoneNumber, suppCountry, suppCity, suppEmail,
            //            suppWebAddress);
            //        if (result)
            //        {
            //            General.SuccessMessage(SuppName + " " + "Save successfully");
            //            LoadDgvSupplierList();
            //            SuppliersControlsClear();

            //        }

            //    }
            //    catch (Exception ex)
            //    {

            //        General.ErrorMessage(ex.Message);
            //    }



            //}
        }

        private void LoadDgvSupplierList()
        {
            //DataSet ds = sm.GetSupplierList();
            //if (ds.Tables.Count > 0  && ds.Tables[0].Rows.Count > 0)
            //{
            //    ShowSupplierList(ds);
            //}
            //else
            //{
            //    dgvSupplierList.DataSource = null;
            //    dgvSupplierList = General.ClearDataGridView(dgvSupplierList);
            //}
        }

        private void ShowSupplierList(DataSet ds)
        {
            //dgvSupplierList = General.CustomizeDataGridView(dgvSupplierList);

            //DataGridViewImageColumn edit = new DataGridViewImageColumn();
            //Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            //edit.Image = editeImage;
            //edit.Width = 20;
            //edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvSupplierList.Columns.Add(edit);


            //dgvSupplierList.Columns.Add("name", "Supplier name");
            //dgvSupplierList.Columns.Add("Company", "Company Name");
            //dgvSupplierList.Columns.Add("Address", "Address");
            //dgvSupplierList.Columns.Add("Phone_Number", "Phone Number");
            //dgvSupplierList.Columns.Add("City", "City");
            //dgvSupplierList.Columns.Add("Country", "Country");
            //dgvSupplierList.Columns.Add("webAddress", "web Address");
            //dgvSupplierList.Columns.Add("Email", "Email Address");
            //dgvSupplierList.Columns.Add("Contact_Person_Name", "Contact Man");
            //dgvSupplierList.Columns.Add("createby", "CreationID");
            //dgvSupplierList.Columns.Add("createID", "createID");
            //dgvSupplierList.Columns.Add("SuppID", "SuppID");



            //dgvSupplierList.Columns["name"].DataPropertyName = "name";
            //dgvSupplierList.Columns["Company"].DataPropertyName = "Company";
            //dgvSupplierList.Columns["Address"].DataPropertyName = "Address";
            //dgvSupplierList.Columns["Phone_Number"].DataPropertyName = "Phone_Number";
            //dgvSupplierList.Columns["City"].DataPropertyName = "City";
            //dgvSupplierList.Columns["Country"].DataPropertyName = "Country";
            //dgvSupplierList.Columns["webAddress"].DataPropertyName = "webAddress";
            //dgvSupplierList.Columns["Email"].DataPropertyName = "Email";
            //dgvSupplierList.Columns["Contact_Person_Name"].DataPropertyName = "Contact_Person_Name";
            //dgvSupplierList.Columns["createby"].DataPropertyName = "createby";
            //dgvSupplierList.Columns["createID"].DataPropertyName = "createID";
            //dgvSupplierList.Columns["SuppID"].DataPropertyName = "SuppID";


            //dgvSupplierList.DataSource = ds.Tables[0];
            //dgvSupplierList.Columns["createID"].Visible = false;
            //dgvSupplierList.Columns["SuppID"].Visible = false;
            

        }

        private void SuppliersControlsClear()
        {
            txtSupplierPHONE.Text = string.Empty;
            txtSupplierADDRESS.Text = string.Empty;
            txtSupplierCOMPANY.Text = string.Empty;
            txtSupplierCOUNTRY.Text = string.Empty;
            txtSupplierCiTY.Text = string.Empty;
            txtSupplierEMAIL.Text = string.Empty;
            txtSupplierWEB.Text = string.Empty;
            txtSupplierCONTACT.Text = string.Empty;
            txtSupplierID.Text = string.Empty;
            txtSupplierNAME.Text = string.Empty;
            

        }

        private bool validation()
        {
            bool flag = true;
            string msg = String.Empty;
            if (string.IsNullOrEmpty(txtSupplierNAME.Text))
            {
                msg = "Please enter a Supplier Name";
            }
            if (string.IsNullOrEmpty(txtSupplierCOMPANY.Text))
            {
                msg = "Please enter a Supplier Company Name";
            }
            if (string.IsNullOrEmpty(txtSupplierADDRESS.Text))
            {
                msg = "Please enter a Supplier Company Address Name";
            }
            if (string.IsNullOrEmpty(txtSupplierPHONE.Text))
            {
                msg = "Please enter a Supplier Contact Person Phone Number";
            }
            if (string.IsNullOrEmpty(txtSupplierCONTACT.Text))
            {
                msg = "Please enter a Supplier Contact Person Name";
            } 
            if (msg != String.Empty)
            {
                flag = false;
                General.WarningMessage(msg);
            }
            return flag;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult user = MessageBox.Show(@"Do You want to delete Brand ?", @"Confirmation",
            //    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //    if (user == DialogResult.OK)
            //    {
            //        string id = txtSupplierID.Text;
            //        string name = txtSupplierNAME.Text;
            //        bool result = sm.DeleteSupplierList(id);
            //        if (result)
            //        {
            //            General.SuccessMessage(name + " " + " Deleted successfully");
            //             LoadDgvSupplierList();
            //             SuppliersControlsClear();

            //        }
            //        else
            //        {
            //            General.SuccessMessage(name + " " + " : Failed to Delete");
            //            LoadDgvBrand();
            //            BrandControlsClear();
            //        }
            //    }



            //}
            //catch (Exception ex)
            //{

            //    General.ErrorMessage(ex.Message);
            //}

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SuppliersControlsClear();
        }

        private void dgvSupplierList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                txtSupplierNAME.Text = dgvSupplierList.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtSupplierCOMPANY.Text = dgvSupplierList.Rows[e.RowIndex].Cells["Company"].Value.ToString();
                txtSupplierADDRESS.Text = dgvSupplierList.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtSupplierPHONE.Text = dgvSupplierList.Rows[e.RowIndex].Cells["Phone_Number"].Value.ToString();
                txtSupplierCiTY.Text = dgvSupplierList.Rows[e.RowIndex].Cells["City"].Value.ToString();
                txtSupplierCOUNTRY.Text = dgvSupplierList.Rows[e.RowIndex].Cells["Country"].Value.ToString();
                txtSupplierWEB.Text = dgvSupplierList.Rows[e.RowIndex].Cells["webAddress"].Value.ToString();
                txtSupplierEMAIL.Text = dgvSupplierList.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSupplierCONTACT.Text = dgvSupplierList.Rows[e.RowIndex].Cells["Contact_Person_Name"].Value.ToString();
                txtSupplierID.Text = dgvSupplierList.Rows[e.RowIndex].Cells["SuppID"].Value.ToString();
                
            }
           
        }


        
    }
}
