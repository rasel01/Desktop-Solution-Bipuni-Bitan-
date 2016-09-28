using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BipuniBitan_Manager.Utility;
using BipuniBitan_Manager.Security;
using BipuniBitan_UI.Forms.Addional;

namespace BipuniBitan_UI.Forms.Security
{
    public partial class home : Form
    {
        //General general = new General();

        AuthenticationManager AuthManager = new AuthenticationManager();
       
       
        public home()
        {
            InitializeComponent();
            txtUserName.Text = "admin";
            txtPassword.Text = "admin";
            this.AcceptButton = btnLogin ;

            pnlForControls.BackColor = Color.FromArgb(235, 244, 250);
            underLoaginNameHeader.BackColor = Color.FromArgb(235, 244, 250);
            pnlSignUpHeader.Visible = false;
            privacyMsgPnl.Visible = false;
            //txtCreateFullName.Text = "MSHRasel";
            //txtCreateUserName.Text = "admin";
            //txtCreatePass.Text = "admin";
            //txtMobileNumber.Text = "01678525954";
            //txtAddress.Text = "abc";
            //rdBtnMale.Checked = true;


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginFormValidation())
            {

                DataTable LoginResult = AuthManager.GetLoginUserInfo(txtUserName.Text, txtPassword.Text);
                if (LoginResult.Rows.Count > 0)
                {
                    AuthenticationManager.LoginUserId = LoginResult.Rows[0]["id"].ToString();
                    AuthenticationManager.LoginUserName = LoginResult.Rows[0]["user_Name"].ToString();
                    AuthenticationManager.LoginUserPass = LoginResult.Rows[0]["user_Password"].ToString();

                    this.Hide();
                    MainForm main = new MainForm();
                    main.ShowDialog();

                }
                else
                {
                    General.WarningMessage("Inavalid user");
                }

            }

        }

        private bool LoginFormValidation()
        {
            string msg = string.Empty;
            bool value = false;

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                msg += "Please Enter your User Name" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                msg += "Please Enter your password" + Environment.NewLine;
            }

            if (msg == string.Empty)
            {
                value = true;
            }
            else
            {
                General.WarningMessage(msg);
            }

            return value;
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationWindow();
        }

        private void RegistrationWindow()
        {
            pnlLoginHeader.Visible = false;
            pnlSignUpHeader.Visible = true;
            privacyMsgPnl.Visible = true;
            HomeFormClearControls();
        }

        private void HomeFormClearControls()
        {
            txtCreateFullName.Text = string.Empty;
            txtCreateUserName.Text = string.Empty;
            txtCreatePass.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            rdBtnMale.Checked = false;
            rdBtnFemale.Checked = false;
        }

        private void lblLoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginWindow();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (RegisterFormValidation())
            {
                string sex;
                string fullName = txtCreateFullName.Text;
                string userName = txtCreateUserName.Text;
                string password = txtCreatePass.Text;
                string mobileNumber = txtMobileNumber.Text;
                string address = txtAddress.Text;
                if (rdBtnFemale.Checked)
                {
                     sex = "F";
                }
                else
                {
                    sex = "M";
                }


                int registrationResult= AuthManager.SaveNewRegisterUser(fullName, userName, password, mobileNumber, address, sex,String.Empty,String.Empty, String.Empty);
                if (registrationResult > 0)
                {
                    General.SuccessMessage("User Successfully registered");
                    LoginWindow();
                }
            }

        }

        private void LoginWindow()
        {
            pnlLoginHeader.Visible = true;
            pnlSignUpHeader.Visible = false;
            privacyMsgPnl.Visible = false;
        }

        private bool RegisterFormValidation()
        {
            string msg = string.Empty;
            bool value = false;

            if (string.IsNullOrEmpty(txtCreateFullName.Text))
            {
                msg += "Please enter user full name" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtCreateUserName.Text))
            {
                msg += "Please enter user name" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(txtCreateUserName.Text))
            {
                if (AuthManager.GetRegisteredUserName(txtCreateUserName.Text,txtCreatePass.Text))
                {
                    msg += "This UserName is not available, Choose Another UserName " + Environment.NewLine;
                    
                }
                
             
            }
            if (string.IsNullOrEmpty(txtCreatePass.Text))
            {
                msg += "Please enter user password" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtMobileNumber.Text))
            {
                msg += "Please enter user Mobile Number" + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(txtMobileNumber.Text))
            {

                if ((new Regex(@"^(?:\+?88)?01[15-9]\d{8}$").IsMatch(txtMobileNumber.Text)) == false)
                {
                    msg += "Please enter  Bangladeshi Mobile operator Number" + Environment.NewLine;
                }

            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                msg += "Please enter user Full Address" + Environment.NewLine;
            }
            if (!rdBtnMale.Checked && !rdBtnFemale.Checked)
            {
                msg += "Please enter user sex" + Environment.NewLine;
            }


            if (msg == string.Empty)
            {
                value = true;
            }
            else
            {
                General.WarningMessage(msg);
            }

            return value;


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
