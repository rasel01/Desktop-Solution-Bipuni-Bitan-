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

namespace BipuniBitan_UI.Forms.Transaction
{
    public partial class ItemReceive : Form
    {
        SupplierManager sm = new SupplierManager();
        ItemManager im = new ItemManager();
        public ItemReceive()
        {
            InitializeComponent();
            Intialization();

        }

        private void Intialization()
        {
            //dtpItemReceive.CustomFormat = @"yyyy-mm-dd";
            LoadSupplierList();
            LoadItemList();

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
                string dt = dtpItemReceive.Text;
                string buyPrice = txtBuyPrice.Text;
                string sellPrice = txtSellPrice.Text;
                string totalQuantity = txtTotalQuantity.Text;
                string totalPrice = txtToalPrice.Text;
                string remarks = txtRemarks.Text;
                string itemName = ddlItem.SelectedValue.ToString();
                string supplierName = ddlSupplier.SelectedValue.ToString();

               // bool result = 

            }
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

      

        


        
    }
}
