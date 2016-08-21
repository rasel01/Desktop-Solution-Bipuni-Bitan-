namespace BipuniBitan_UI
{
    partial class Raff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.LinkLabel();
            this.pnlForGridControls = new System.Windows.Forms.Panel();
            this.pnLGridHeader = new System.Windows.Forms.Panel();
            this.lblGridHeader = new System.Windows.Forms.Label();
            this.GridPnl = new System.Windows.Forms.Panel();
            this.dgvCatagoryList = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.pnlForGridControls.SuspendLayout();
            this.pnLGridHeader.SuspendLayout();
            this.GridPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatagoryList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFooter);
            this.panel2.Location = new System.Drawing.Point(57, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 36);
            this.panel2.TabIndex = 9;
            // 
            // lblFooter
            // 
            this.lblFooter.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.SystemColors.Window;
            this.lblFooter.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblFooter.LinkColor = System.Drawing.Color.Black;
            this.lblFooter.Location = new System.Drawing.Point(254, 9);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(464, 20);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.TabStop = true;
            this.lblFooter.Text = "Developed and Copyright © 2016 BipuniBitan. All rights reserved.";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlForGridControls
            // 
            this.pnlForGridControls.Controls.Add(this.pnLGridHeader);
            this.pnlForGridControls.Controls.Add(this.GridPnl);
            this.pnlForGridControls.Location = new System.Drawing.Point(94, 126);
            this.pnlForGridControls.Name = "pnlForGridControls";
            this.pnlForGridControls.Size = new System.Drawing.Size(1037, 211);
            this.pnlForGridControls.TabIndex = 10;
            // 
            // pnLGridHeader
            // 
            this.pnLGridHeader.BackColor = System.Drawing.SystemColors.Info;
            this.pnLGridHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLGridHeader.Controls.Add(this.lblGridHeader);
            this.pnLGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLGridHeader.Location = new System.Drawing.Point(0, 0);
            this.pnLGridHeader.Name = "pnLGridHeader";
            this.pnLGridHeader.Size = new System.Drawing.Size(1037, 24);
            this.pnLGridHeader.TabIndex = 6;
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.AutoSize = true;
            this.lblGridHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridHeader.Location = new System.Drawing.Point(5, 2);
            this.lblGridHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(104, 17);
            this.lblGridHeader.TabIndex = 1;
            this.lblGridHeader.Text = "Catagory List";
            // 
            // GridPnl
            // 
            this.GridPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GridPnl.Controls.Add(this.dgvCatagoryList);
            this.GridPnl.Location = new System.Drawing.Point(0, 0);
            this.GridPnl.Margin = new System.Windows.Forms.Padding(0);
            this.GridPnl.Name = "GridPnl";
            this.GridPnl.Size = new System.Drawing.Size(1037, 188);
            this.GridPnl.TabIndex = 2;
            // 
            // dgvCatagoryList
            // 
            this.dgvCatagoryList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCatagoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatagoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCatagoryList.Location = new System.Drawing.Point(0, 0);
            this.dgvCatagoryList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvCatagoryList.Name = "dgvCatagoryList";
            this.dgvCatagoryList.Size = new System.Drawing.Size(1035, 186);
            this.dgvCatagoryList.TabIndex = 0;
            // 
            // Raff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 367);
            this.Controls.Add(this.pnlForGridControls);
            this.Controls.Add(this.panel2);
            this.Name = "Raff";
            this.Text = "Raff";
            this.Load += new System.EventHandler(this.Raff_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlForGridControls.ResumeLayout(false);
            this.pnLGridHeader.ResumeLayout(false);
            this.pnLGridHeader.PerformLayout();
            this.GridPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatagoryList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lblFooter;
        private System.Windows.Forms.Panel pnlForGridControls;
        private System.Windows.Forms.Panel pnLGridHeader;
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.Panel GridPnl;
        private System.Windows.Forms.DataGridView dgvCatagoryList;

    }
}