using System;
using System.Data;
using System.Windows.Forms;
using Winforms.StoredProcedures;
using WPF_OOP.Interfaces;
using WPF_OOP.Models;
using WPF_OOP.Notifications;
using WPF_OOP.Repository;


namespace WPF_OOP.ApplicationForm.User.Modals
{
    public partial class FrmAddorEditCustomer : Form
    {
        readonly FrmCustomer ths;
        UserFile UserFile = new UserFile();
        readonly UserFileRepository UserRepository = new UserFileRepository();
        readonly PopupNotifierClass GlobalStatePopup = new PopupNotifierClass();
        IStoredProcedures g_objStoredProcCollection = null;
        readonly myclasses myClass = new myclasses();
        DataSet dSet = new DataSet();
        public FrmAddorEditCustomer(FrmCustomer frm,  string Mode)
        {
            InitializeComponent();
            this.ths = frm;
            this.UserFile.Mode = Mode;
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }

        private void FrmAddorEditUser_Load(object sender, EventArgs e)
        {
            this.WindowsLoadData();
            this.ConnetionString();

            if (this.UserFile.Mode == "ADD")
            {
                this.loadUser_type();
                this.loadDepartment();
            }
        }


        public void loadDepartment()
        {
            this.myClass.fillComboBoxDepartment(this.CboDepartment, "department_dropdown_with_unit", dSet);
            this.UserFile.Department = Convert.ToInt32(this.CboDepartment.SelectedValue.ToString());
        }

        public void loadUser_type()
        {
            this.myClass.fillComboBox(this.CboUserRole, "user_type", dSet);
        }


        private void ConnetionString()
        {
            this.g_objStoredProcCollection = this.myClass.g_objStoredProc.GetCollections();
        }

        private void WindowsLoadData()
        {
            this.UserFile.Mode = this.UserFile.Mode;
        }

        private void TextBoxValidation()
        {
            bool FormValidation = (this.TxtFirstName.Text == String.Empty || this.TxtLastName.Text == String.Empty ||
                 this.TxtuserName.Text == String.Empty || this.TxtPassword.Text == String.Empty) ? this.BtnSave.Enabled = false : this.BtnSave.Enabled = true;
        }

        private void TxtFirstName_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxValidation();
        }

        private void TxtLastName_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxValidation();
        }

        private void TxtuserName_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxValidation();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            this.TextBoxValidation();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ths.textBox1.Text = textBox1.Text;
        }



        private void MetroSave()
        {
            if (UserFile.Mode == "ADD")
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to save? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    this.UserRepository.AddUser(0,this.UserFile.CustomerId, this.TxtuserName.Text.Trim(), this.TxtPassword.Text.Trim(),
                        this.TxtFirstName.Text.Trim(), this.UserFile.User_Section, this.UserFile.Receiving_Status, this.UserFile.Position, this.TxtLastName.Text.Trim(), this.UserFile.Department, this.UserFile.Requestor_Type,
                        this.UserFile.Unit, this.UserFile.Gender, "add");


                    textBox1.Text = "Save";
                    this.GlobalStatePopup.SuccessFullySave();


                    this.Close();

                }
                else
                {
                    return;
                }
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (this.UserFile.Mode == "ADD")
            {

                //Validation to minimize the duplicate fucking entries
       

                this.UserRepository.ValidateUserIfExist(this.TxtuserName.Text.Trim(), this.TxtFirstName.Text.Trim(), this.TxtLastName.Text.Trim());

                if (this.UserRepository.dSet.Tables[0].Rows.Count > 0)
                {
                    this.GlobalStatePopup.DataAlreadyExist();



                    this.TxtFirstName.Focus();
                    return;
                }
                else
                {
                    this.MetroSave();

                }



            }
            else
            {

                if (this.UserFile.Employee_Name == this.TxtFirstName.Text)
                {

                }
                else
                {
                    this.UserRepository.ValidateUserIfExist(this.TxtuserName.Text.Trim(), this.TxtFirstName.Text.Trim(), this.TxtLastName.Text.Trim());

                    if (UserRepository.dSet.Tables[0].Rows.Count > 0)
                    {
                        this.GlobalStatePopup.DataAlreadyExist();



                        this.TxtFirstName.Focus();
                        return;
                    }
                }



                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to update? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //this.TblCustomersRepositorys
                    //    .PutCustomer(
                    //    this.TblCustomersEntity.Cust_Id,
                    //    this.MatTxtName.Text,
                    //    this.metroCmbType.Text,
                    //    this.metroCmbCompany.Text,
                    //    this.TxtMobile.Text,
                    //    this.TxtLeadMan.Text,
                    //    this.TxtAddress.Text,
                    //   TblCustomersEntity.Cust_Added_By,
                    //    "",
                    //    TblCustomersEntity.Cust_Updated_by,
                    //    "",
                    //    true,
                    //    "edit");
                    //this.GlobalStatePopup.UpdatedSuccessfully();
                    //this.Close();
                }
                else
                {
                    return;
                }



            }



        }

        private void FrmAddorEditUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.textBox1.Text = "SuccessFully Save";
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void CboUserRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.UserFile.CustomerId = Convert.ToInt32(this.CboUserRole.SelectedValue);
        }

        private void CboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.UserFile.Department = Convert.ToInt32(this.CboDepartment.SelectedValue.ToString());
        }
    }





}
