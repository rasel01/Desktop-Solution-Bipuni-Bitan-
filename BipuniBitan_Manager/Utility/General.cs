using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BipuniBitan_Manager.Utility
{
    public class General
    {
        public static void WarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void SuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }



        public static DataGridView ClearDataGridView(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Refresh();
            return dgv;

        }

        public static DataGridView CustomizeDataGridView(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersVisible = false;
            //dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //dgv.EnableHeadersVisualStyles = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor =Color.LightBlue;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.GhostWhite;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial",10F,FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Azure;







            //grid.AllowUserToAddRows = false;
            //grid.AllowUserToDeleteRows = false;
            //grid.AllowUserToResizeRows = false;
            //grid.AllowUserToResizeColumns = true;

            //grid.ReadOnly = true;
            //grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //grid.Columns.Clear();
            ////grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            //grid.AutoGenerateColumns = false;
            //grid.RowHeadersVisible = false;
            //grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 246, 243);
            //grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157);
            //grid.EnableHeadersVisualStyles = false;
            //grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            //grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Azure;
            //grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //grid.ScrollBars = ScrollBars.Both;

            /////grid.ColumnHeadersHeight = 30;//5D7B9D
            ////F7F6F3
            //// grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(93, 123, 157) ;  //5D7B9D


            //return grid;














            return dgv;
        }
    }
}
