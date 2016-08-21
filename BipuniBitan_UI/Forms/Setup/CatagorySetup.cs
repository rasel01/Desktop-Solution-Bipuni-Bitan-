using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BipuniBitan_Manager.Utility;
using BipuniBitan_Manager.Setup;

namespace BipuniBitan_UI.Forms.Setup
{

    public partial class CatagorySetup : Form
    {
        CatagoryManager cm = new CatagoryManager();
        public CatagorySetup()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            LoadDgvCatagoryList();
        }

        private void LoadDgvCatagoryList()
        {

            DataSet ds = cm.GetDgvCatagoryList();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ShowDgvCatagoryList(ds);
            }
            else
            {
                dgvCatagoryList.DataSource = null;

                dgvCatagoryList = General.ClearDataGridView(dgvCatagoryList);

            }
        }
        private void ShowDgvCatagoryList(DataSet ds)
        {
            dgvCatagoryList = General.CustomizeDataGridView(dgvCatagoryList);

            DataGridViewImageColumn edit = new DataGridViewImageColumn();
            Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            edit.Image = editeImage;
            edit.Width = 20;
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCatagoryList.Columns.Add(edit);


            dgvCatagoryList.Columns.Add("catagory_name", "Catagory Name");
            dgvCatagoryList.Columns.Add("createDate", "Creation Date");
            dgvCatagoryList.Columns.Add("Createby", "Creation By");
            dgvCatagoryList.Columns.Add("remarks", "Remarks");
            dgvCatagoryList.Columns.Add("catagory_id", "catagory_id");

            dgvCatagoryList.Columns["catagory_name"].DataPropertyName = "catagory_name";
            dgvCatagoryList.Columns["remarks"].DataPropertyName = "remarks";
            dgvCatagoryList.Columns["createDate"].DataPropertyName = "createDate";
            dgvCatagoryList.Columns["Createby"].DataPropertyName = "Createby";
            dgvCatagoryList.Columns["catagory_id"].DataPropertyName = "catagory_id";

            dgvCatagoryList.DataSource = ds.Tables[0];
            dgvCatagoryList.Columns["catagory_id"].Visible = false;

        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validation())
            {
                string catagoryID = txtCatagoryID.Text;
                string catagoryName = txtCatagoryName.Text;
                string remarks = txtCatagoryRemarks.Text;
                try
                {

                    bool result = cm.saveUpdateCatagory(catagoryName, catagoryID, remarks);
                    if (result)
                    {
                        General.SuccessMessage(catagoryName + " " + "Save successfully");
                        LoadDgvCatagoryList();
                        CatagoryControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }



            }

        }

        private void CatagoryControlsClear()
        {
            txtCatagoryID.Text = String.Empty;
            txtCatagoryName.Text = String.Empty;
            txtCatagoryRemarks.Text = String.Empty;
            LoadDgvCatagoryList();
        }

        private bool validation()
        {
            bool flag = true;
            string msg = String.Empty;
            if (string.IsNullOrEmpty(txtCatagoryName.Text))
            {
                msg = "Please enter a Catagory Name";
            }
            if (msg != String.Empty)
            {
                flag = false;
                General.WarningMessage(msg);
            }
            return flag;
        }

        private void dgvCatagoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                txtCatagoryID.Text = dgvCatagoryList.Rows[e.RowIndex].Cells["catagory_id"].Value.ToString();
                txtCatagoryName.Text = dgvCatagoryList.Rows[e.RowIndex].Cells["catagory_name"].Value.ToString();
                txtCatagoryRemarks.Text = dgvCatagoryList.Rows[e.RowIndex].Cells["remarks"].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CatagoryControlsClear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult user = MessageBox.Show(@"Do You want to delete catagory ?", @"Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (user == DialogResult.OK)
                {
                    string id = txtCatagoryID.Text;
                    string name = txtCatagoryName.Text;
                    bool result = cm.DeleteCatagoryList(id);
                    if (result)
                    {
                        General.SuccessMessage(name + " " + " Deleted successfully");
                        LoadDgvCatagoryList();
                        CatagoryControlsClear();

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
