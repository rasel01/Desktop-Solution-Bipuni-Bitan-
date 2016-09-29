using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BipuniBitan_Manager.Security;
using BipuniBitan_Manager.Setup;
using BipuniBitan_Manager.Transaction;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_UI.Forms.Transaction
{
    public partial class StaffCreation : Form
    {
        SupplierManager sm = new SupplierManager();
        ItemManager im = new ItemManager();
        ItemReturnManager itr = new ItemReturnManager();
        AuthenticationManager sessionManager = new AuthenticationManager();
        private string _UserPass;
        private string _UserSex;
        private string _UserMobile;

        private string _OldQuantity;
      


        public StaffCreation()
        {
            InitializeComponent();
            Intialization();



        }

        private void Intialization()
        {
            PnlInfoGrpbx.Visible = false;
            LoadDgvUserList();

        }

        private void LoadDgvUserList()
        {
            try
            {
                DataSet ds = sessionManager.LoadRegisteredUserName();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ShowUserList(ds);
                }
                else
                {
                    dgvUserItmList.DataSource = null;
                    dgvUserItmList = General.ClearDataGridView(dgvUserItmList);
                }
            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                if (validation())
                {
                    
                    try
                    {
                        if (AuthenticationManager.LoginUserId == @"admin")
                        {
                            int result = sessionManager.SaveNewRegisterUser(txtFullName.Text, txtUserName.Text,
                            txtPassword.Text, _UserMobile,
                            txtAddress.Text, _UserSex, ddlStatus.SelectedValue.ToString(), ddlUserType.SelectedValue.ToString(), txtUserID.Text);
                            if (result > 0)
                            {
                                General.SuccessMessage("Save successfully");
                                LoadDgvUserList();
                                ControlsClear();

                            }
                        }
                        else
                        {
                             General.WarningMessage("You do not have any permission");
                        }
                        

                    }
                    catch (Exception ex)
                    {

                        General.ErrorMessage(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }
        }

        private bool validation()
        {
            
            string msg = String.Empty;
            bool flag = false;
            try
            {

                if (string.IsNullOrEmpty(txtFullName.Text))
                {
                    msg += "Must need FullName of User" + Environment.NewLine;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    msg += "Must need Password of User" + Environment.NewLine;
                }
                if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    msg += "Must need Address of User" + Environment.NewLine;
                }
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    msg += "Must need User_Name of User" + Environment.NewLine;
                }

                if (ddlUserType.SelectedIndex.Equals(0))
                {
                    msg += "Must need Type of User" + Environment.NewLine;
                }
                if (ddlStatus.SelectedIndex.Equals(0))
                {
                    msg += "Must need Status of User" + Environment.NewLine;
                }
                

                if (msg == String.Empty)
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
            ControlsClear();
        }

        private void ControlsClear()
        {
            txtUserID.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtPassword.Text = string.Empty;
            ddlUserType.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            PnlInfoGrpbx.Visible = false;
             LoadDgvUserList();
        }

     



    

       


        private void ShowUserList(DataSet ds)
        {
            dgvUserItmList = General.CustomizeDataGridView(dgvUserItmList);
            DataGridViewImageColumn edit = new DataGridViewImageColumn();
            Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            edit.Image = editeImage;
            edit.Width = 20;
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUserItmList.Columns.Add(edit);


            


            dgvUserItmList.Columns.Add("user_Name", "Login Name");
            dgvUserItmList.Columns.Add("user_Type", "User Type");
            dgvUserItmList.Columns.Add("user_status", "Status");

            dgvUserItmList.Columns.Add("UserID", "UserID");
            dgvUserItmList.Columns.Add("name", "Full Name");
            dgvUserItmList.Columns.Add("user_Password", "Password");
            dgvUserItmList.Columns.Add("Mobile_Number", "Mobile");
            dgvUserItmList.Columns.Add("user_Sex", "Sex");
            dgvUserItmList.Columns.Add("address", "Address");







            dgvUserItmList.Columns["user_Name"].DataPropertyName = "user_Name";
            dgvUserItmList.Columns["user_Type"].DataPropertyName = "user_Type";
            dgvUserItmList.Columns["user_status"].DataPropertyName = "user_status";
            dgvUserItmList.Columns["UserID"].DataPropertyName = "UserID";
            dgvUserItmList.Columns["name"].DataPropertyName = "name";
            dgvUserItmList.Columns["user_Password"].DataPropertyName = "user_Password";
            dgvUserItmList.Columns["Mobile_Number"].DataPropertyName = "Mobile_Number";
            dgvUserItmList.Columns["user_Sex"].DataPropertyName = "user_Sex";
            dgvUserItmList.Columns["address"].DataPropertyName = "address";
           

            dgvUserItmList.DataSource = ds.Tables[0];
            dgvUserItmList.Columns["UserID"].Visible = false;
            dgvUserItmList.Columns["name"].Visible = false;
            dgvUserItmList.Columns["user_Password"].Visible = false;
            dgvUserItmList.Columns["Mobile_Number"].Visible = false;
            dgvUserItmList.Columns["user_Sex"].Visible = false;
            dgvUserItmList.Columns["address"].Visible = false;
            
        }

        private void dgvReturnItmList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                PnlInfoGrpbx.Visible = true;
                txtUserName.Text = dgvUserItmList.Rows[e.RowIndex].Cells["user_Name"].Value.ToString();
                LoadUserType();
                ddlUserType.SelectedValue = dgvUserItmList.Rows[e.RowIndex].Cells["user_Type"].Value.ToString();

                LoadUserStatus();
                ddlStatus.SelectedValue = (bool)dgvUserItmList.Rows[e.RowIndex].Cells["user_status"].Value ==  true ? "1" :"0";
                txtUserID.Text = dgvUserItmList.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
                txtFullName.Text = dgvUserItmList.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtPassword.Text = dgvUserItmList.Rows[e.RowIndex].Cells["user_Password"].Value.ToString();
                _UserMobile = dgvUserItmList.Rows[e.RowIndex].Cells["Mobile_Number"].Value.ToString();
                _UserSex = dgvUserItmList.Rows[e.RowIndex].Cells["user_Sex"].Value.ToString();
                txtAddress.Text = dgvUserItmList.Rows[e.RowIndex].Cells["address"].Value.ToString();

            }


        }

        private void LoadUserStatus()
        {
            DataTable dt = sessionManager.LoadUserStatus();
            ddlStatus.DataSource = dt;
            ddlStatus.DisplayMember = "StatusName";
            ddlStatus.ValueMember = "StatusID";
            ddlStatus.SelectedIndex = 0;
        }

        private void LoadUserType()
        {

            DataTable dt = sessionManager.LoadUserType();
            ddlUserType.DataSource = dt;
            ddlUserType.DisplayMember = "TypeName";
            ddlUserType.ValueMember = "TypeID";
            ddlUserType.SelectedIndex = 0;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

       








    }
}
