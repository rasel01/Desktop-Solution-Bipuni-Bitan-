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
            PnlInfoGrpbx.Visible = false;

        }






        

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                //string dtime = dtpItemReceive.Text;
                //string buyPrice = txtBuyPrice.Text;
                //string sellPrice = txtSellPrice.Text;
                //string totalQuantity = txtTotalQuantity.Text;
                //string totalPrice = txtToalPrice.Text;
                //string remarks = txtRemarks.Text;
                //string itemName = ddlItem.SelectedValue.ToString();
                //string supplierName = ddlSupplier.SelectedValue.ToString();
                //string ItemReceID = txtItmReceiveID.Text;



                try
                {
                    // bool result = irm.SaveUpdate_ItemReceive(dtime, buyPrice, sellPrice,
                    //totalQuantity, totalPrice, remarks, itemName, supplierName, ItemReceID);
                    // if (result)
                    // {
                    //     General.SuccessMessage("Save successfully");
                    //     LoadReceiveList();
                    //     ItemReceControlsClear();

                    // }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }

            }
        }

        private bool validation()
        {
            throw new NotImplementedException();
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
            txtSellPrice.Text = @"0.000";
            txtRemarks.Text = String.Empty;
            txtTotalPrice.Text = @"0.000";
            txtTotalQuantity.Text = @"0.00";
            txtSupplierID.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtDistributorName.Text = string.Empty;
            dtpDistDate.ResetText();
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
            LoadDgvReturnItemList();
        }

        private void LoadDgvReturnItemList()
        {
            try
            {
                DataSet ds = irm.ReceivedItmList();
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

            //dgvReturnItmList.Columns.Add("ReceiveID", "ReceiveID");

            //dgvReturnItmList.Columns.Add("RcvItemID", "ItemID");

            //dgvReturnItmList.Columns.Add("ItmRcvPerBuy", "Buy Price(per unit)");
            //dgvReturnItmList.Columns.Add("ItmRcvPerSell", "Sell Price(per unit)");//commit
            //dgvReturnItmList.Columns.Add("ItmRcvTotalQuantity", "Total Quantity");
            //dgvReturnItmList.Columns.Add("Total_Price", "Total Price");

            //dgvReturnItmList.Columns.Add("ItmRcvSuppID", "Supp ID");

            //dgvReturnItmList.Columns.Add("ItmRcvDate", "Receive Date");
            //dgvReturnItmList.Columns.Add("ItmRcvRemarks", "Remarks");
            //dgvReturnItmList.Columns.Add("ItemName", "Item Name");
            //dgvReturnItmList.Columns.Add("ItmRcvSuppName", "Supplier Name");
            //dgvReturnItmList.Columns.Add("CataName", "Catagory Name");
            //dgvReturnItmList.Columns.Add("BrandName", "Brand Name");
            //dgvReturnItmList.Columns.Add("UnitName", "Unit Name");

            //dgvReturnItmList.Columns["ReceiveID"].DataPropertyName = "ReceiveID";
            //dgvReturnItmList.Columns["RcvItemID"].DataPropertyName = "RcvItemID";
            //dgvReturnItmList.Columns["ItmRcvPerBuy"].DataPropertyName = "ItmRcvPerBuy";
            //dgvReturnItmList.Columns["ItmRcvPerSell"].DataPropertyName = "ItmRcvPerSell";
            //dgvReturnItmList.Columns["ItmRcvTotalQuantity"].DataPropertyName = "ItmRcvTotalQuantity";
            //dgvReturnItmList.Columns["Total_Price"].DataPropertyName = "Total_Price";
            //dgvReturnItmList.Columns["ItmRcvSuppID"].DataPropertyName = "ItmRcvSuppID";
            //dgvReturnItmList.Columns["ItmRcvDate"].DataPropertyName = "ItmRcvDate";
            //dgvReturnItmList.Columns["ItmRcvRemarks"].DataPropertyName = "ItmRcvRemarks";
            //dgvReturnItmList.Columns["ItemName"].DataPropertyName = "ItemName";
            //dgvReturnItmList.Columns["ItmRcvSuppName"].DataPropertyName = "ItmRcvSuppName";
            //dgvReturnItmList.Columns["CataName"].DataPropertyName = "CataName";
            //dgvReturnItmList.Columns["BrandName"].DataPropertyName = "BrandName";
            //dgvReturnItmList.Columns["UnitName"].DataPropertyName = "UnitName";

            //dgvReturnItmList.DataSource = ds.Tables[0];
            //dgvReturnItmList.Columns["ReceiveID"].Visible = false;
            //dgvReturnItmList.Columns["RcvItemID"].Visible = false;
            //dgvReturnItmList.Columns["ItmRcvSuppID"].Visible = false;
            //dgvReturnItmList.Columns["CataName"].Visible = false;
            //dgvReturnItmList.Columns["BrandName"].Visible = false;
            //dgvReturnItmList.Columns["UnitName"].Visible = false;
        }

        private void dgvReturnItmList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PnlInfoGrpbx.Visible = true;
        }









    }
}
