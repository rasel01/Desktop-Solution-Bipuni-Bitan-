using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BipuniBitan_Manager.Setup;
using BipuniBitan_Manager.Transaction;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_UI.Forms.Transaction
{
    public partial class ItemDistribution : Form
    {
        SupplierManager sm = new SupplierManager();
        ItemManager im = new ItemManager();
        ItemReceiveManager irm = new ItemReceiveManager();
        ItemDistributionManager itmdm = new ItemDistributionManager();
       

        
        public ItemDistribution()
        {
            InitializeComponent();
            Intialization();

        }

        private void Intialization()
        {
            
            LoadDistributorList();
            LoadItemList();
            LoadDistributionList();

        }

        private void LoadDistributorList()
        {
            DataSet ds = itmdm.LoadDistributorList();
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
                dt.Columns.Add("DistID");
                dt.Columns.Add("DistName");

                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

            }

            ddlDistributor.DataSource = dt;
            ddlDistributor.DisplayMember = "DistName";
            ddlDistributor.ValueMember = "DistID";
            ddlDistributor.SelectedIndex = 0;
        }

        private void LoadItemList()
        {
            DataSet ds = itmdm.LoadItemList();
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
                dt.Columns.Add("ItemCode");
                dt.Columns.Add("ItemName");

                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

            }

            ddlItem.DataSource = dt;
            ddlItem.DisplayMember = "ItemName";
            ddlItem.ValueMember = "ItemCode";
            ddlItem.SelectedIndex = 0;
        }

      

   
        
        private bool validation()
        {
            string msg = String.Empty;
            bool flag = false;
            try
            {

                if (string.IsNullOrEmpty(txtStockQuantity.Text))
                {
                    msg += "Must Receive Quantity of selected item" + Environment.NewLine;
                }

                

                if (string.IsNullOrEmpty(txtDisQuantity.Text))
                {
                    msg += "Must need amount of Distribution Quantity" + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(txtDisQuantity.Text))
                {

                    if (Convert.ToDecimal(txtDisQuantity.Text) > Convert.ToDecimal(txtStockQuantity.Text))
                    {
                        msg += "Insufficent Quantity" + Environment.NewLine;
                    }
                    
                }

                if (string.IsNullOrEmpty(txtDistributionPrice.Text))
                {
                    msg += "Price cannot be null" + Environment.NewLine;
                }
                
                
                if (ddlDistributor.SelectedValue.ToString() == "0")
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

        private void ddlItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet ds = GetReceivedItemInfo();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
            {
                txtStockQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
            }
        }

        private DataSet GetReceivedItemInfo()
        {
            string itemID = ddlItem.SelectedValue.ToString();
            DataSet ds = itmdm.GetItemReceiveInfo(itemID);
            return ds;
        }

       

        private void txtDisQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string stockQuantity = txtStockQuantity.Text;
                string disQuantity = txtDisQuantity.Text == String.Empty ? "0":txtDisQuantity.Text;

                if (Convert.ToDecimal(stockQuantity) >= Convert.ToDecimal(disQuantity))
                {
                    if (ddlItem.SelectedIndex != 0)
                    {
                        DataSet ds = GetReceivedItemInfo();
                        decimal perUnitPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["sellprice"].ToString());
                        decimal sellPrice = Convert.ToDecimal(disQuantity) * Convert.ToDecimal(perUnitPrice);
                        txtDistributionPrice.Text = sellPrice.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                   
                General.ErrorMessage(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                string dtime = dtpItemDistribute.Text;
                string sellPrice = txtDistributionPrice.Text;
                string Quantity = txtDisQuantity.Text;
                string remarks = txtRemarks.Text;
                string itemName = ddlItem.SelectedValue.ToString();
                string distributorname = ddlDistributor.SelectedValue.ToString();
                string distributionID = txtItmDistributionID.Text;
                



                try
                {
                    bool result = itmdm.SaveUpdate_ItemDistribution(dtime, sellPrice, Quantity,
                   remarks, itemName, distributorname, distributionID);
                    if (result)
                    {
                        General.SuccessMessage("Save successfully");
                        LoadDistributionList();
                        ItemDistributionControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }

            }
        }

        private void LoadDistributionList()
        {
            DataSet ds = itmdm.GetDistributionList();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ShowDistributionItemDgv(ds);
            }
            else
            {
                dgvDistributeItemst.DataSource = null;
                dgvDistributeItemst = General.ClearDataGridView(dgvDistributeItemst);
            }
        }

        private void ShowDistributionItemDgv(DataSet ds)
        {
            dgvDistributeItemst = General.CustomizeDataGridView(dgvDistributeItemst);

            dgvDistributeItemst.Columns.Add("DistributionCode", "Distribution Code");
            dgvDistributeItemst.Columns.Add("ItemName", "Item Name");
            dgvDistributeItemst.Columns.Add("DistributorName", "Distributor Name");
            dgvDistributeItemst.Columns.Add("Quantity", "Quantity");
            dgvDistributeItemst.Columns.Add("ItemPrice", "Item Price");

            dgvDistributeItemst.Columns["DistributionCode"].DataPropertyName = "DistributionCode";
            dgvDistributeItemst.Columns["ItemName"].DataPropertyName = "ItemName";
            dgvDistributeItemst.Columns["DistributorName"].DataPropertyName = "DistributorName";
            dgvDistributeItemst.Columns["Quantity"].DataPropertyName = "Quantity";
            dgvDistributeItemst.Columns["ItemPrice"].DataPropertyName = "ItemPrice";

            dgvDistributeItemst.DataSource = ds.Tables[0];



        }

        private void ItemDistributionControlsClear()
        {
            txtDisQuantity.Text = @"0.00";
            txtDistributionPrice.Text = @"0.000";
            txtItmDistributionID.Text = String.Empty;
            txtRemarks.Text = String.Empty;
            txtStockQuantity.Text = @"0.00";
            ddlDistributor.SelectedIndex = 0;
            ddlItem.SelectedIndex = 0;
            dtpItemDistribute.Text = String.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ItemDistributionControlsClear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
