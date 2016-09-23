using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BipuniBitan_Manager.Setup;
using BipuniBitan_Manager.Transaction;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_UI.Forms.Transaction
{
    public partial class ItemReturn : Form
    {
        SupplierManager sm = new SupplierManager();
        ItemManager im = new ItemManager();
        ItemReturnManager itr = new ItemReturnManager();
        private int _ItemCode;
        private int _UserID;
        private string _OldQuantity;
        //private int _UserID;
        
        
        public ItemReturn()
        {
            InitializeComponent();
            Intialization();



        }

        private void Intialization()
        {
            PnlInfoGrpbx.Visible = false;
            
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                if (validation())
                {
                    string dtime = dtpDistDate.Text;
                    string sellPrice = txtSellPrice.Text;
                    string totalQuantity = txtTotalQuantity.Text;
                    string remarks = txtRemarks.Text;
                    string itemName = txtItemName.ToString();
                    string dtributorName = txtDistributorName.ToString();
                    string distrinutionCode = txtDistCode.Text;
                    string itemCode = _ItemCode.ToString();
                    string userCode = _UserID.ToString();


                    try
                    {
                        bool result = itr.SaveUpdate_ItemReturn(dtime, sellPrice, totalQuantity,
                       remarks, itemName, dtributorName, distrinutionCode, itemCode, userCode);
                        if (result)
                        {
                            General.SuccessMessage("Save successfully");
                            LoadDgvReturnItemList(String.Empty);
                            ItemReturnControlsClear();

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
           decimal quantity =Convert.ToDecimal(txtTotalQuantity.Text);
           decimal oldQuantity =Convert.ToDecimal(_OldQuantity);
            string msg = String.Empty;
            bool flag = false;
            try
            {

                if (string.IsNullOrEmpty(txtTotalQuantity.Text))
                {
                    msg += "Must need a Quantity that want return" + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(txtTotalQuantity.Text))
                {
                    if (quantity > oldQuantity)
                    {
                        msg += "Return Item Must Equal or Less than Distribute Quantity" + Environment.NewLine;
                    }
                   
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



        //private void ItemReceControlsClear()
        //{
        //    txtItmReceiveID.Text  = String.Empty;
        //    txtBuyPrice.Text  = @"0.000";
        //    txtRemarks.Text  = String.Empty;
        //    txtSellPrice.Text = @"0.000";
        //    txtToalPrice.Text = @"0.000";
        //    txtTotalQuantity.Text = @"0.00";
        //    ddlSupplier.SelectedIndex = 0;
        //    ddlItem.SelectedIndex = 0;


        //}

        //private bool validation()
        //{
        //    string msg = String.Empty;
        //    bool flag = false;
        //    try
        //    {

        //        if (string.IsNullOrEmpty(txtBuyPrice.Text))
        //        {
        //            msg += "Must need a Item Per Unit Buy Price" + Environment.NewLine;
        //        }

        //        if (string.IsNullOrEmpty(txtSellPrice.Text))
        //        {
        //            msg += "Must need a Item Per Unit Sell Price" + Environment.NewLine;
        //        }

        //        if (string.IsNullOrEmpty(txtToalPrice.Text))
        //        {
        //            msg += "Must need a Item Total Price" + Environment.NewLine;
        //        }

        //        if (string.IsNullOrEmpty(txtTotalQuantity.Text))
        //        {
        //            msg += "Must need a Item Toatal Quantity" + Environment.NewLine;
        //        }


        //        if (ddlSupplier.SelectedValue.ToString() == "0")
        //        {
        //            msg += "Must select a Supplier Name" + Environment.NewLine;
        //        }
        //        if (ddlItem.SelectedValue.ToString() == "0")
        //        {
        //            msg += "Must select a Item Name" + Environment.NewLine;
        //        }

        //        if (msg == String.Empty)
        //        {
        //            flag = true;
        //        }
        //        else
        //        {
        //            General.WarningMessage(msg);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        General.ErrorMessage(ex.Message);
        //    }
        //    return flag;
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ItemReturnControlsClear();
        }

        private void ItemReturnControlsClear()
        {
            txtDistCode.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            txtSellPrice.Text = @"0.000";
            txtTotalQuantity.Text = @"0.00";
            txtItemName.Text = string.Empty;
            txtDistributorName.Text = string.Empty;
            dtpDistDate.ResetText();
            txtSearch.Text = string.Empty;
            PnlInfoGrpbx.Visible = false;
            LoadDgvReturnItemList(String.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult user = MessageBox.Show(@"Do You want to delete ReceiveItem ?", @"Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (user == DialogResult.OK)
                {
                    //string id = txtItmReceiveID.Text;

                    //bool result = irm.DeleteReceItemList(id);
                    //if (result)
                    //{
                    //    General.SuccessMessage("Deleted successfully");
                    //    ItemReceControlsClear();
                    //    //Intialization();


                    //}
                    //else
                    //{
                    //    General.SuccessMessage( "Failed to Delete");
                    //    //Intialization();
                    //    ItemReceControlsClear();
                    //}
                }



            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }
        }



        private void btnSerach_Click(object sender, EventArgs e)
        {
            string id = txtSearch.Text;
            LoadDgvReturnItemList(id);
        }

        private void LoadDgvReturnItemList(string id)
        {
            try
            {
                DataSet ds = itr.DistributeItmList(id);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ShowReturnItemList(ds);
                }
                else
                {
                    dgvReturnItmList.DataSource = null;
                    dgvReturnItmList = General.ClearDataGridView(dgvReturnItmList);
                }
            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }
        }


        private void ShowReturnItemList(DataSet ds)
        {
            dgvReturnItmList = General.CustomizeDataGridView(dgvReturnItmList);
            DataGridViewImageColumn edit = new DataGridViewImageColumn();
            Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            edit.Image = editeImage;
            edit.Width = 20;
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvReturnItmList.Columns.Add(edit);


            //dgvReceItmList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvReturnItmList.Columns.Add("DistributeID", "DistributeID");
            dgvReturnItmList.Columns.Add("ItemName", "ItemName");
            dgvReturnItmList.Columns.Add("Quantity", "Quantity");
            dgvReturnItmList.Columns.Add("Price", "Price");//commit
            dgvReturnItmList.Columns.Add("DistDate", "DistDate");
            dgvReturnItmList.Columns.Add("DistName", "DistName");
            dgvReturnItmList.Columns.Add("Remarks", "Remarks");

            dgvReturnItmList.Columns.Add("itemCode", "itemCode");
            dgvReturnItmList.Columns.Add("UserID", "UserID");
            //dgvReturnItmList.Columns.Add("ItemName", "Item Name");
            //dgvReturnItmList.Columns.Add("ItmRcvSuppName", "Supplier Name");
            //dgvReturnItmList.Columns.Add("CataName", "Catagory Name");
            //dgvReturnItmList.Columns.Add("BrandName", "Brand Name");
            //dgvReturnItmList.Columns.Add("UnitName", "Unit Name");

            dgvReturnItmList.Columns["DistributeID"].DataPropertyName = "DistributeID";
            dgvReturnItmList.Columns["ItemName"].DataPropertyName = "ItemName";
            dgvReturnItmList.Columns["Quantity"].DataPropertyName = "Quantity";
            dgvReturnItmList.Columns["Price"].DataPropertyName = "Price";
            dgvReturnItmList.Columns["DistDate"].DataPropertyName = "DistDate";
            dgvReturnItmList.Columns["DistName"].DataPropertyName = "DistName";
            dgvReturnItmList.Columns["Remarks"].DataPropertyName = "Remarks";
            dgvReturnItmList.Columns["itemCode"].DataPropertyName = "itemCode";
            dgvReturnItmList.Columns["UserID"].DataPropertyName = "UserID";
            //dgvReturnItmList.Columns["ItemName"].DataPropertyName = "ItemName";
            //dgvReturnItmList.Columns["ItmRcvSuppName"].DataPropertyName = "ItmRcvSuppName";
            //dgvReturnItmList.Columns["CataName"].DataPropertyName = "CataName";
            //dgvReturnItmList.Columns["BrandName"].DataPropertyName = "BrandName";
            //dgvReturnItmList.Columns["UnitName"].DataPropertyName = "UnitName";

            dgvReturnItmList.DataSource = ds.Tables[0];
            dgvReturnItmList.Columns["itemCode"].Visible = false;
            dgvReturnItmList.Columns["UserID"].Visible = false;
            //dgvReturnItmList.Columns["ItmRcvSuppID"].Visible = false;
            //dgvReturnItmList.Columns["CataName"].Visible = false;
            //dgvReturnItmList.Columns["BrandName"].Visible = false;
            //dgvReturnItmList.Columns["UnitName"].Visible = false;
        }

        private void dgvReturnItmList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                PnlInfoGrpbx.Visible = true;
                txtDistCode.Text = dgvReturnItmList.Rows[e.RowIndex].Cells["DistributeID"].Value.ToString();
                txtItemName.Text = dgvReturnItmList.Rows[e.RowIndex].Cells["ItemName"].Value.ToString();
                txtTotalQuantity.Text = dgvReturnItmList.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                _OldQuantity =  dgvReturnItmList.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                txtSellPrice.Text = dgvReturnItmList.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                dtpDistDate.Text = dgvReturnItmList.Rows[e.RowIndex].Cells["DistDate"].Value.ToString();
                txtDistributorName.Text = dgvReturnItmList.Rows[e.RowIndex].Cells["DistName"].Value.ToString();
                txtRemarks.Text = dgvReturnItmList.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
                _ItemCode = (int) dgvReturnItmList.Rows[e.RowIndex].Cells["itemCode"].Value;
                _UserID = (int) dgvReturnItmList.Rows[e.RowIndex].Cells["UserID"].Value;
            }
          
           
        }









    }
}
