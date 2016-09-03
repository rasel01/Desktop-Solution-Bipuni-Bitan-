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
            this.ddlcheck = new System.Windows.Forms.ComboBox();
            this.ddlAnother = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFooter);
            this.panel2.Location = new System.Drawing.Point(79, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 36);
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
            // ddlcheck
            // 
            this.ddlcheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlcheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlcheck.FormattingEnabled = true;
            this.ddlcheck.Location = new System.Drawing.Point(196, 45);
            this.ddlcheck.Name = "ddlcheck";
            this.ddlcheck.Size = new System.Drawing.Size(335, 24);
            this.ddlcheck.TabIndex = 11;
            // 
            // ddlAnother
            // 
            this.ddlAnother.BackColor = System.Drawing.SystemColors.Info;
            this.ddlAnother.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ddlAnother.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAnother.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlAnother.FormattingEnabled = true;
            this.ddlAnother.Location = new System.Drawing.Point(613, 45);
            this.ddlAnother.Name = "ddlAnother";
            this.ddlAnother.Size = new System.Drawing.Size(335, 24);
            this.ddlAnother.TabIndex = 12;
            // 
            // Raff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 576);
            this.Controls.Add(this.ddlAnother);
            this.Controls.Add(this.ddlcheck);
            this.Controls.Add(this.panel2);
            this.Name = "Raff";
            this.Text = "Raff";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel lblFooter;
        private System.Windows.Forms.ComboBox ddlcheck;
        private System.Windows.Forms.ComboBox ddlAnother;

    }
}