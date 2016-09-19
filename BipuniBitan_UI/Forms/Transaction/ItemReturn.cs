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
        ItemReceiveManager irm = new ItemReceiveManager();
        public ItemReturn()
        {
            InitializeComponent();
            Intialization();

        }

        private void Intialization()
        {
            
            LoadSupplierList();
            LoadItemList();
            LoadReceiveList();

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
            dgvReceItmList = General.CustomizeDataGridView(dgvReceItmList);
            DataGridViewImageColumn edit = new DataGridViewImageColumn();
            Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            edit.Image = editeImage;
            edit.Width = 20;
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvReceItmList.Columns.Add(edit);


            //dgvReceItmList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvReceItmList.Columns.Add("ReceiveID", "ReceiveID");

            dgvReceItmList.Columns.Add("RcvItemID", "ItemID");

            dgvReceItmList.Columns.Add("ItmRcvPerBuy", "Buy Price(per unit)");
            dgvReceItmList.Columns.Add("ItmRcvPerSell", "Sell Price(per unit)");//commit
            dgvReceItmList.Columns.Add("ItmRcvTotalQuantity", "Total Quantity");
            dgvReceItmList.Columns.Add("Total_Price", "Total Price");

            dgvReceItmList.Columns.Add("ItmRcvSuppID", "Supp ID");

            dgvReceItmList.Columns.Add("ItmRcvDate", "Receive Date");
            dgvReceItmList.Columns.Add("ItmRcvRemarks", "Remarks");
            dgvReceItmList.Columns.Add("ItemName", "Item Name");
            dgvReceItmList.Columns.Add("ItmRcvSuppName", "Supplier Name");
            dgvReceItmList.Columns.Add("CataName", "Catagory Name");
            dgvReceItmList.Columns.Add("BrandName", "Brand Name");
            dgvReceItmList.Columns.Add("UnitName", "Unit Name");

            dgvReceItmList.Columns["ReceiveID"].DataPropertyName = "ReceiveID";
            dgvReceItmList.Columns["RcvItemID"].DataPropertyName = "RcvItemID";
            dgvReceItmList.Columns["ItmRcvPerBuy"].DataPropertyName = "ItmRcvPerBuy";
            dgvReceItmList.Columns["ItmRcvPerSell"].DataPropertyName = "ItmRcvPerSell";
            dgvReceItmList.Columns["ItmRcvTotalQuantity"].DataPropertyName = "ItmRcvTotalQuantity";
            dgvReceItmList.Columns["Total_Price"].DataPropertyName = "Total_Price";
            dgvReceItmList.Columns["ItmRcvSuppID"].DataPropertyName = "ItmRcvSuppID";
            dgvReceItmList.Columns["ItmRcvDate"].DataPropertyName = "ItmRcvDate";
            dgvReceItmList.Columns["ItmRcvRemarks"].DataPropertyName = "ItmRcvRemarks";
            dgvReceItmList.Columns["ItemName"].DataPropertyName = "ItemName";
            dgvReceItmList.Columns["ItmRcvSuppName"].DataPropertyName = "ItmRcvSuppName";
            dgvReceItmList.Columns["CataName"].DataPropertyName = "CataName";
            dgvReceItmList.Columns["BrandName"].DataPropertyName = "BrandName";
            dgvReceItmList.Columns["UnitName"].DataPropertyName = "UnitName";

            dgvReceItmList.DataSource = ds.Tables[0];
            dgvReceItmList.Columns["ReceiveID"].Visible = false;
            dgvReceItmList.Columns["RcvItemID"].Visible = false;
            dgvReceItmList.Columns["ItmRcvSuppID"].Visible = false;
            dgvReceItmList.Columns["CataName"].Visible = false;
            dgvReceItmList.Columns["BrandName"].Visible = false;
            dgvReceItmList.Columns["UnitName"].Visible = false;

        }
        private void dgvReceItmList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
              txtItmReceiveID.Text = dgvReceItmList.Rows[e.RowIndex].Cells["ReceiveID"].Value.ToString();
              ddlItem.SelectedValue = dgvReceItmList.Rows[e.RowIndex].Cells["RcvItemID"].Value.ToString();
              ddlSupplier.SelectedValue = dgvReceItmList.Rows[e.RowIndex].Cells["ItmRcvSuppID"].Value.ToString();
              dtpItemReceive.Text = dgvReceItmList.Rows[e.RowIndex].Cells["ItmRcvDate"].Value.ToString();
              txtRemarks.Text = dgvReceItmList.Rows[e.RowIndex].Cells["ItmRcvRemarks"].Value.ToString();
              txtTotalQuantity.Text = dgvReceItmList.Rows[e.RowIndex].Cells["ItmRcvTotalQuantity"].Value.ToString();
              txtToalPrice.Text = dgvReceItmList.Rows[e.RowIndex].Cells["Total_Price"].Value.ToString();
              txtBuyPrice.Text = dgvReceItmList.Rows[e.RowIndex].Cells["ItmRcvPerBuy"].Value.ToString();
              txtSellPrice.Text = dgvReceItmList.Rows[e.RowIndex].Cells["ItmRcvPerSell"].Value.ToString();
             

            }
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
                        LoadReceiveList();
                        ItemReceControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }

            }
        }

        private void LoadDgvReceiveItem()
        {
            throw new NotImplementedException();
        }

        private void ItemReceControlsClear()
        {
            txtItmReceiveID.Text  = String.Empty;
            txtBuyPrice.Text  = @"0.000";
            txtRemarks.Text  = String.Empty;
            txtSellPrice.Text = @"0.000";
            txtToalPrice.Text = @"0.000";
            txtTotalQuantity.Text = @"0.00";
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
