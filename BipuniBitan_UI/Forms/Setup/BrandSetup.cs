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

namespace BipuniBitan_UI.Forms.Setup
{
    public partial class BrandSetup : Form
    {
        BrandManager bm = new BrandManager();
        public BrandSetup()
        {
            InitializeComponent();
            Intialize();
        }

        private void Intialize()
        {
            LoadCatagoryList();
        }

        private void LoadCatagoryList()
        {
            // catagory_id,catagory_name
            DataSet ds = bm.GetCatagoryList();
        }
    }
}
