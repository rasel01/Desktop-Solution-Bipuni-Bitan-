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

namespace BipuniBitan_UI
{
    public partial class Raff : Form
    {
        public Raff()
        {
            InitializeComponent();
            LoadCatagory();
            LoadAnother();
        }

        private void LoadAnother()
        {
            CatagoryManager cm = new CatagoryManager();
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

                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

            }
            ddlAnother.DataSource = dt;
            ddlAnother.DisplayMember = "catagory_name";
            ddlAnother.ValueMember = "catagory_id";
            ddlAnother.SelectedIndex = 0;
        }

        private void LoadCatagory()
        {
            CatagoryManager cm = new CatagoryManager();
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

                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = 0;
                dr[1] = "--select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

            }
                ddlcheck.DataSource = dt;
                ddlcheck.DisplayMember = "catagory_name";
                ddlcheck.ValueMember = "catagory_id";
                ddlcheck.SelectedIndex = 0;

            

        }
    }
}
