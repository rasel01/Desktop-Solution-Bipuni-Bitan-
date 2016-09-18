using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using BipuniBitan_Manager.Setup;
using BipuniBitan_Manager.Transaction;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_UI.Forms.Transaction
{
    public partial class ItemStock : Form
    {
        SupplierManager sm = new SupplierManager();
        ItemManager im = new ItemManager();
        ItemReceiveManager irm = new ItemReceiveManager();
        ItemStockInfoManager ism = new ItemStockInfoManager();
        public ItemStock()
        {
            InitializeComponent();
            Intialization();
            // commit
        }

        private void Intialization()
        {

            LoadItemStockInfo();

        }

        private void LoadItemStockInfo()
        {
            DataSet ds = ism.GetItemStockList(txtItemCode.Text,txtItemName.Text);
            if (ds.Tables.Count > 0  && ds.Tables[0].Rows.Count > 0)
            {
                //if (txtItemCode.Text.Length > 0 || txtItemName.Text.Length > 0 )
                //{
                //    //int id = txtItemCode.Text == null ? 0 : Convert.ToInt32(txtItemCode.Text);

                //    //var itemCodeResult = from myrow in ds.Tables[0].AsEnumerable()
                //    //                     where myrow.Field<Int32>("ItemCode").CompareTo(Convert.ToInt32(txtItemCode.Text))
                //    //                     select myrow;

                //    //var itemNameResult = from myrow in ds.Tables[0].AsEnumerable()
                //    //    where myrow.Field<string>("ItemName").Contains(txtItemName.Text)
                //    //    select myrow;
                    
                //    //if (itemCodeResult.Count() > 0)
                //    //{
                //    //    ShowStockList(itemCodeResult.CopyToDataTable());
                //    //}
                //    //if (itemNameResult.Count() > 0)
                //    //{
                //    //    ShowStockList(itemNameResult.CopyToDataTable());
                //    //}

                //}
                 
                //else
                //{
                   
                //}
               // ShowStockList(ds);
                ShowStockList(ds.Tables[0]);
            }
            else
            {
                dgvItmStockInfo.DataSource = null;
                dgvItmStockInfo = General.ClearDataGridView(dgvItmStockInfo);
            }
        }

        private void ShowStockList(DataTable dt)
        {
            dgvItmStockInfo = General.CustomizeDataGridView(dgvItmStockInfo);

            dgvItmStockInfo.Columns.Add("ItemCode", "Item Code");
            dgvItmStockInfo.Columns.Add("ItemName", "Item Name");
            dgvItmStockInfo.Columns.Add("CatagoryName", "Catagory Name");
            dgvItmStockInfo.Columns.Add("BrandName", "Brand Name");
            dgvItmStockInfo.Columns.Add("UnitName", "Measurement Name");
            dgvItmStockInfo.Columns.Add("StockQuantity", "Current Stock Quantity");

            dgvItmStockInfo.Columns["ItemCode"].DataPropertyName = "ItemCode";
            dgvItmStockInfo.Columns["ItemName"].DataPropertyName = "ItemName";
            dgvItmStockInfo.Columns["CatagoryName"].DataPropertyName = "CatagoryName";
            dgvItmStockInfo.Columns["BrandName"].DataPropertyName = "BrandName";
            dgvItmStockInfo.Columns["UnitName"].DataPropertyName = "UnitName";
            dgvItmStockInfo.Columns["StockQuantity"].DataPropertyName = "StockQuantity";

            dgvItmStockInfo.DataSource = dt;


        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            LoadItemStockInfo();// commmm
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            LoadItemStockInfo();
        }
    }
}
