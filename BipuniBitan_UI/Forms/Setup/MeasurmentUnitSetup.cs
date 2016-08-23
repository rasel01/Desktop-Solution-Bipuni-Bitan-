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

   
    public partial class MeasurmentUnitSetup : Form
    {
         MessurmentManager mm = new MessurmentManager();

        public MeasurmentUnitSetup()
        {
           InitializeComponent();
           LoadDgvMesurementList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validation())
            {
                string MessID = txtMessID.Text;
                string MessName = txtMessName.Text;
                string remarks = txtMessRemarks.Text;
                try
                {

                    bool result = mm.saveUpdateMesurerment(MessID, MessName, remarks);
                    if (result)
                    {
                        General.SuccessMessage(MessName + " " + "Save successfully");
                        LoadDgvMesurementList();
                        MesurementControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }



            }
        }

        private void MesurementControlsClear()
        {
           txtMessID.Text = String.Empty;
           txtMessName.Text = String.Empty;
           txtMessRemarks.Text = String.Empty;
           
        }

        private void LoadDgvMesurementList()
        {
            DataSet ds = mm.GetDgvMeasurmentUnit();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ShowMeasurementUnit(ds);
            }
            else
            {
                dgvMesurementList.DataSource = null;
                dgvMesurementList = General.ClearDataGridView(dgvMesurementList);
            }

        }

        private void ShowMeasurementUnit(DataSet ds)
        {
            dgvMesurementList = General.CustomizeDataGridView(dgvMesurementList);

            DataGridViewImageColumn edit = new DataGridViewImageColumn();
            Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            edit.Image = editeImage;
            edit.Width = 20;
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMesurementList.Columns.Add(edit);


            dgvMesurementList.Columns.Add("Measurment_Name", "Measurment Name");
            dgvMesurementList.Columns.Add("CreationBy", "Creation By");
            dgvMesurementList.Columns.Add("Measurement_Remarks", "Remarks");
            dgvMesurementList.Columns.Add("CreationID", "CreationID");
            dgvMesurementList.Columns.Add("Mess_ID", "Mess_ID");

            dgvMesurementList.Columns["Measurment_Name"].DataPropertyName = "Measurment_Name";
            dgvMesurementList.Columns["CreationBy"].DataPropertyName = "CreationBy";
            dgvMesurementList.Columns["Measurement_Remarks"].DataPropertyName = "Measurement_Remarks";
            dgvMesurementList.Columns["CreationID"].DataPropertyName = "CreationID";
            dgvMesurementList.Columns["Mess_ID"].DataPropertyName = "Mess_ID";

            dgvMesurementList.DataSource = ds.Tables[0];
            dgvMesurementList.Columns["Mess_ID"].Visible = false;
            dgvMesurementList.Columns["CreationID"].Visible = false;
         
        }

        private bool validation()
        {
            bool flag = true;
            string msg = String.Empty;
            if (string.IsNullOrEmpty(txtMessName.Text))
            {
                msg = "Please enter a Measurment Name";
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
            try
            {
                DialogResult user = MessageBox.Show(@"Do You want to delete Measurement ?", @"Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (user == DialogResult.OK)
                {
                    string id = txtMessID.Text;
                    string name = txtMessName.Text;
                    bool result = mm.DeleteMeasurementList(id);
                    if (result)
                    {
                        General.SuccessMessage(name + " " + " Deleted successfully");
                        LoadDgvMesurementList();
                        MesurementControlsClear();

                    }
                }



            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MesurementControlsClear();
        }

        private void dgvMesurementList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0  && e.ColumnIndex == 0)
            {
                txtMessID.Text = dgvMesurementList.Rows[e.RowIndex].Cells["Mess_ID"].Value.ToString();
                txtMessName.Text = dgvMesurementList.Rows[e.RowIndex].Cells["Measurment_Name"].Value.ToString();
                txtMessRemarks.Text = dgvMesurementList.Rows[e.RowIndex].Cells["Measurement_Remarks"].Value.ToString();
            }
        }
    }
}
