using System;
using System.Data;
using System.Windows.Forms;
using BipuniBitan_Manager.Setup;
using BipuniBitan_Manager.Transaction;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_UI.Forms.Transaction
{
    public partial class ItemReceive : Form
    {
        SupplierManager sm = new SupplierManager();
        ItemManager im = new ItemManager();
        ItemReceiveManager irm = new ItemReceiveManager();
        public ItemReceive()
        {
            InitializeComponent();
            Intialization();

        }

        private void Intialization()
        {
            
            LoadSupplierList();
            LoadItemList();
            //LoadReceiveList();

        }

        private void LoadReceiveList()
        {
            DataSet ds = irm.ReceivedItmList();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ShowReceiveItemList(ds);
            }
            else
            {
                dgvReceItmList.DataSource = null;
                dgvReceItmList = General.ClearDataGridView(dgvReceItmList);
            }
        }

        private void ShowReceiveItemList(DataSet ds)
        {
            throw new NotImplementedException();
        }

        private void LoadSupplierList()
        {
            DataSet ds = sm.LoadSupplierList();
            DataTable dt = new DataTable();
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr,0);
                dt = ds.Tables[0];
            }
            else
            {
                dt.Columns.Add("SupplerID");
                dt.Columns.Add("SupplerName");

                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

            }

            ddlSupplier.DataSource = dt;
            ddlSupplier.DisplayMember = "SupplerName";
            ddlSupplier.ValueMember = "SupplerID";
            ddlSupplier.SelectedIndex = 0;

        }

        private void LoadItemList()
        {
            DataSet ds = im.LoadItemList();
            DataTable dt = new DataTable();
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                dt = ds.Tables[0];
            }
            else
            {
                dt.Columns.Add("ItemID");
                dt.Columns.Add("ItemName");

                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

            }

            ddlItem.DataSource = dt;
            ddlItem.DisplayMember = "ItemName";
            ddlItem.ValueMember = "ItemID";
            ddlItem.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                string dtime = dtpItemReceive.Text;
                string buyPrice = txtBuyPrice.Text;
                string sellPrice = txtSellPrice.Text;
                string totalQuantity = txtTotalQuantity.Text;
                string totalPrice = txtToalPrice.Text;
                string remarks = txtRemarks.Text;
                string itemName = ddlItem.SelectedValue.ToString();
                string supplierName = ddlSupplier.SelectedValue.ToString();
                string ItemReceID = txtItmReceiveID.Text;

               

                try
                {
                    bool result = irm.SaveUpdate_ItemReceive(dtime, buyPrice, sellPrice,
                   totalQuantity, totalPrice, remarks, itemName, supplierName, ItemReceID);
                    if (result)
                    {
                        General.SuccessMessage("Save successfully");
                        //LoadDgvItem();
                        ItemReceControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }

            }
        }

        private void ItemReceControlsClear()
        {
            txtItmReceiveID.Text  = String.Empty;
            txtBuyPrice.Text  = String.Empty;
            txtRemarks.Text  = String.Empty;
            txtSellPrice.Text  = String.Empty;
            txtToalPrice.Text  = String.Empty;
            txtTotalQuantity.Text  = String.Empty;
            ddlSupplier.SelectedIndex = 0;
            ddlItem.SelectedIndex = 0;

        }

        private bool validation()
        {
            string msg = String.Empty;
            bool flag = false;
            try
            {

                if (string.IsNullOrEmpty(txtBuyPrice.Text))
                {
                    msg += "Must need a Item Per Unit Buy Price" + Environment.NewLine;
                }

                if (string.IsNullOrEmpty(txtSellPrice.Text))
                {
                    msg += "Must need a Item Per Unit Sell Price" + Environment.NewLine;
                }

                if (string.IsNullOrEmpty(txtToalPrice.Text))
                {
                    msg += "Must need a Item Total Price" + Environment.NewLine;
                }

                if (string.IsNullOrEmpty(txtTotalQuantity.Text))
                {
                    msg += "Must need a Item Toatal Quantity" + Environment.NewLine;
                }
                
                
                if (ddlSupplier.SelectedValue.ToString() == "0")
                {
                    msg += "Must select a Supplier Name" + Environment.NewLine;
                }
                if (ddlItem.SelectedValue.ToString() == "0")
                {
                    msg += "Must select a Item Name" + Environment.NewLine;
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
            ItemReceControlsClear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult user = MessageBox.Show(@"Do You want to delete ReceiveItem ?", @"Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (user == DialogResult.OK)
                {
                    string id = txtItmReceiveID.Text;
                    
                    bool result = irm.DeleteReceItemList(id);
                    if (result)
                    {
                        General.SuccessMessage("Deleted successfully");
                        ItemReceControlsClear();
                        //Intialization();


                    }
                    else
                    {
                        General.SuccessMessage( "Failed to Delete");
                        //Intialization();
                        ItemReceControlsClear();
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
