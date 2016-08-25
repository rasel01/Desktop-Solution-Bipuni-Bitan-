using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BipuniBitan_Manager.Setup;
using BipuniBitan_Manager.Utility;

namespace BipuniBitan_UI.Forms.Setup
{
    public partial class ItemSetup : Form
    {
        ItemManager im = new ItemManager();
        CatagoryManager cm = new CatagoryManager();
        MessurmentManager mm = new MessurmentManager();

        public ItemSetup()
        {
            InitializeComponent();
            Intialization();
        }

        private void Intialization()
        {
            LoadCatagoryList();
            LoadBrandList(ddlCatagory.SelectedValue.ToString());
            LoadMeasurementList();
            LoadDgvItem();

        }

        private void LoadMeasurementList()
        {
            DataSet ds = mm.LoadMeasurementList();
            DataTable dt = new DataTable();
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                dt = ds.Tables[0];
            }
            else
            {
                dt.Columns.Add("Mess_id");
                dt.Columns.Add("Mess_name");

                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                dt.Rows.InsertAt(dr, 0);
            }
            ddlUnit.DataSource = dt;
            ddlUnit.DisplayMember = "Mess_name";
            ddlUnit.ValueMember = "Mess_id";
            ddlUnit.SelectedIndex = 0;

        }

        private void LoadBrandList(string catagory)
        {
            DataSet ds = im.LoadBrandListCatagoryWise(catagory);
            DataTable dt = new DataTable();
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                dt = ds.Tables[0];
            }
            else
            {
                dt.Columns.Add("brand_id");
                dt.Columns.Add("Brand_Name");

                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                dt.Rows.InsertAt(dr, 0);
            }
            ddlBrand.DataSource = dt;
            ddlBrand.DisplayMember = "Brand_Name";
            ddlBrand.ValueMember = "brand_id";
            ddlBrand.SelectedIndex = 0;
        }

        private void LoadCatagoryList()
        {


            DataSet ds = cm.LoadCatagoryList();
            DataTable dt = new DataTable();
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                dt = ds.Tables[0];
            }
            else
            {
                dt.Columns.Add("catagory_id");
                dt.Columns.Add("catagory_name");

                DataRow dr = dt.NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                dt.Rows.InsertAt(dr, 0);
            }
            ddlCatagory.DataSource = dt;
            ddlCatagory.DisplayMember = "catagory_name";
            ddlCatagory.ValueMember = "catagory_id";
            ddlCatagory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {

                
                
                string ItemName = txtItemNAME.Text;
                string  catagoryId =ddlCatagory.SelectedValue.ToString();
                string branID = ddlBrand.SelectedValue.ToString();
                string unitID = ddlUnit.SelectedValue.ToString();
                string itemDes = txtItemDescription.Text;
                string itemID = txtItemID.Text;
                byte[] image = GetImage();
               

                try
                {
                    bool result = im.saveUpdateItem(image, ItemName, catagoryId, branID, unitID, itemDes, itemID);
                    if (result)
                    {
                        General.SuccessMessage(ItemName + " " + "Save successfully");
                        LoadDgvItem();
                        ItemControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }

            }
        }

        private void LoadDgvItem()
        {
            DataSet ds = im.GetItemList();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ShowItemList(ds);
            }
            else
            {
                dgvItemList.DataSource = null;
                dgvItemList = General.ClearDataGridView(dgvItemList);
            }

        }

        private void ShowItemList(DataSet ds)
        {
            dgvItemList = General.CustomizeDataGridView(dgvItemList);

            DataGridViewImageColumn edit = new DataGridViewImageColumn();
            Image editeImage = (Image)(new Bitmap(Properties.Resources.edit, new Size(22, 22)));
            edit.Image = editeImage;
            edit.Width = 20;
            edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvItemList.Columns.Add(edit);


            dgvItemList.Columns.Add("item_name", "Item ");
            dgvItemList.Columns.Add("CatagoryName", "Catagory ");
            dgvItemList.Columns.Add("BrandName", "Brand ");
            dgvItemList.Columns.Add("MessName", "Measurment Unit");
            dgvItemList.Columns.Add("ides", "Item Description");
            dgvItemList.Columns.Add("ItemCatID", "ItemCatID");
            dgvItemList.Columns.Add("ItemBrandId", "ItemBrandId");
            dgvItemList.Columns.Add("ItemMessID", "ItemMessID");
            dgvItemList.Columns.Add("ItemImage", "ItemImage");
            dgvItemList.Columns.Add("itemID", "itemID");


            dgvItemList.Columns["item_name"].DataPropertyName = "item_name";
            dgvItemList.Columns["CatagoryName"].DataPropertyName = "CatagoryName";
            dgvItemList.Columns["BrandName"].DataPropertyName = "BrandName";
            dgvItemList.Columns["MessName"].DataPropertyName = "MessName";
            dgvItemList.Columns["ides"].DataPropertyName = "ides";
            dgvItemList.Columns["ItemCatID"].DataPropertyName = "ItemCatID";
            dgvItemList.Columns["ItemBrandId"].DataPropertyName = "ItemBrandId";
            dgvItemList.Columns["ItemImage"].DataPropertyName = "ItemImage";
            dgvItemList.Columns["itemID"].DataPropertyName = "itemID";
            dgvItemList.Columns["ItemMessID"].DataPropertyName = "ItemMessID";
            

            dgvItemList.DataSource = ds.Tables[0];
            dgvItemList.Columns["ItemCatID"].Visible = false;
            dgvItemList.Columns["ItemBrandId"].Visible = false;
            dgvItemList.Columns["ItemMessID"].Visible = false;
            dgvItemList.Columns["ItemImage"].Visible = false;
            dgvItemList.Columns["itemID"].Visible = false;
        }

        private void ItemControlsClear()
        {
            txtItemID.Text = String.Empty;
            txtItemNAME.Text = String.Empty;
            txtItemDescription.Text = String.Empty;
            //ItemPICBx.InitialImage = null;
            ItemPICBx.Image = null;
            ddlCatagory.SelectedIndex = 0;
            ddlBrand.SelectedIndex = 0;
            ddlUnit.SelectedIndex = 0;

        }

        private byte[] GetImage()
        {
            MemoryStream stream = new MemoryStream();
            ItemPICBx.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] pic = stream.ToArray();
            return pic;
        }

        private bool validation()
        {
            string msg = String.Empty;
            bool flag = false;
            try
            {

                if (string.IsNullOrEmpty(txtItemNAME.Text))
                {
                    msg += "Must need a Item name" + Environment.NewLine;
                }
                if (ItemPICBx.Image == null)
                {
                    msg += "Must need a Item Picture" + Environment.NewLine;
                }
                if (ddlCatagory.SelectedValue.ToString() == "0")
                {
                    msg += "Must select a catagory" + Environment.NewLine;
                }
                if (ddlBrand.SelectedValue.ToString() == "0")
                {
                    msg += "Must select a Brand Name" + Environment.NewLine;
                }
                if (ddlUnit.SelectedValue.ToString() == "0")
                {
                    msg += "Must select a Measurement Unit" + Environment.NewLine;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ItemControlsClear();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            bool flag = LoadPicture();

        }

        private bool LoadPicture()
        {
            bool flag = false;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = @"Choose Item Photo";
                ofd.Filter = @"images | *.JPG ; *.PNG";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ItemPICBx.Image = Image.FromFile(ofd.FileName);
                    //ItemPICBx = 
                    ItemPICBx.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (ItemPICBx != null)
                    {
                        flag = true;

                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                General.ErrorMessage(ex.Message);
            }

            return flag;

        }

        private void ddlCatagory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string catagory = ddlCatagory.SelectedValue.ToString();
            LoadBrandList(catagory);
        }

        private void dgvItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    txtItemDescription.Text = dgvItemList.Rows[e.RowIndex].Cells["ides"].Value.ToString();
                    txtItemID.Text = dgvItemList.Rows[e.RowIndex].Cells["itemID"].Value.ToString();
                    txtItemNAME.Text = dgvItemList.Rows[e.RowIndex].Cells["item_name"].Value.ToString();
                    ddlCatagory.SelectedValue = dgvItemList.Rows[e.RowIndex].Cells["ItemCatID"].Value.ToString();
                    LoadBrandList(ddlCatagory.SelectedValue.ToString());
                    ddlBrand.SelectedValue = dgvItemList.Rows[e.RowIndex].Cells["ItemBrandId"].Value;
                    ddlUnit.SelectedValue = dgvItemList.Rows[e.RowIndex].Cells["ItemMessID"].Value.ToString();
                    byte[] imageData = (byte[])dgvItemList.Rows[e.RowIndex].Cells["ItemImage"].Value;
                    Image img = GetExistsImage(imageData);
                    ItemPICBx.Image = img;
                }
                catch (Exception ex)
                {
                    
                    General.ErrorMessage(ex.Message);
                }

            }
        }

        private Image GetExistsImage(byte[] imageData)
        {
            Image newImage = null;
            try
            {
                MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length);
                ms.Write(imageData,0,imageData.Length);
                newImage = Image.FromStream(ms,true);

            }
            catch (Exception ex)
            {
                
                General.ErrorMessage(ex.Message);
            }

            return newImage;
        }
    }
}
