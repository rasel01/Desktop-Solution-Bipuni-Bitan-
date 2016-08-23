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
                byte[] image = GetImage();
                string ItemName = txtItemNAME.Text;
                string  catagoryId =ddlCatagory.SelectedValue.ToString();
                string branID = ddlBrand.SelectedValue.ToString();
                string unitID = ddlUnit.SelectedValue.ToString();
                string itemDes = txtItemDescription.Text;
                string itemID = txtItemID.Text;

                try
                {

                    bool result = im.saveUpdateItem(image, ItemName, catagoryId, branID, unitID, itemDes, itemID);
                    if (result)
                    {
                        General.SuccessMessage(ItemName + " " + "Save successfully");
                        //LoadDgvBrand();
                        ItemControlsClear();

                    }

                }
                catch (Exception ex)
                {

                    General.ErrorMessage(ex.Message);
                }



            }



        }

        private void ItemControlsClear()
        {
            txtItemID.Text = String.Empty;
            txtItemNAME.Text = String.Empty;
            txtItemDescription.Text = String.Empty;
            ItemPICBx = null;

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
                if (!LoadPicture())
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

                throw;
            }

            return flag;

        }

        private void ddlCatagory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string catagory = ddlCatagory.SelectedValue.ToString();
            LoadBrandList(catagory);
        }
    }
}
