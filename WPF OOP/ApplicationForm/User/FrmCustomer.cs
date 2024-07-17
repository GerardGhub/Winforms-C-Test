using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Winforms.StoredProcedures;
using WPF_OOP.ApplicationForm.User.Modals;
using WPF_OOP.Interfaces;
using WPF_OOP.Models;
using WPF_OOP.Notifications;
using WPF_OOP.Repository;


namespace WPF_OOP.ApplicationForm.User
{
    public partial class FrmCustomer : Form
    {
        readonly UserFileRepository UserFileRepository = new UserFileRepository();
        readonly PopupNotifierClass GlobalStatePopup = new PopupNotifierClass();
        IStoredProcedures g_objStoredProcCollection = null;
        readonly myclasses xClass = new myclasses();
        readonly UserFile UserFile = new UserFile();
        public DataSet dSet = new DataSet();


        private int currentPageIndex = 0;
        private int pageSize = 10; // Number of records per page
        private int totalRecords = 0;



        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            this.ConnetionString();
            this.RadioActive.Checked = true;            
            this.textBox1.Text = String.Empty;
        }

        private void ConnetionString()
        {
            this.g_objStoredProcCollection = this.xClass.g_objStoredProc.GetCollections();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.BtnNew.Visible = false;
            this.UserFile.Mode = "ADD";

           FrmAddorEditCustomer  showModal = new FrmAddorEditCustomer(this, this.UserFile.Mode);
            showModal.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.BtnNew.Visible = true;
            this.FrmUsers_Load(sender, e);
        }

        private void RadioActive_CheckedChanged(object sender, EventArgs e)
        {
            this.BtnInActive.Text = "InActive";
            this.GetActivatedUser();
        }
        private void GetActivatedUser()
        {
            this.UserFileRepository.GetCustomer(this.DgvUsers);

            this.PaginateData();

            this.LblTotalRecords.Text = this.DgvUsers.RowCount.ToString();
        }

        private void PaginateData()
        {
            DataTable dataTable = (DataTable)DgvUsers.DataSource;
            DataView dataView = dataTable.DefaultView;

            dataView.RowFilter = string.Empty; // Clear any previous filters

            DataTable paginatedTable = dataView.ToTable().AsEnumerable()
                .Skip(currentPageIndex * pageSize)
                .Take(pageSize)
                .CopyToDataTable();

            this.DgvUsers.DataSource = paginatedTable;
            this.LblTotalRecords.Text = $"Page {currentPageIndex + 1} of {Math.Ceiling((double)totalRecords / pageSize)}";
        }



        private void RadioInActive_CheckedChanged(object sender, EventArgs e)
        {
            this.BtnInActive.Text = "Activate";
            this.GetDeactivateUser();
        }

        private void GetDeactivateUser()
        {
            this.UserFileRepository.GetCustomerInactive(this.DgvUsers);

            this.LblTotalRecords.Text = this.DgvUsers.RowCount.ToString();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            this.SearchProc();
            this.DoSearchOnMaterialTextBox();
        }

        public void SearchProc()
        {
            try
            {
                if (this.RadioActive.Checked == true)
                {
                    this.UserFileRepository.SearchActiveCustomer("searchActiveCustomer");
                }
                else
                {
                    this.UserFileRepository.SearchInActiveCustomer("searchInActiveCustomer");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        public void DoSearchOnMaterialTextBox()
        {
            try
            {
                if (this.UserFileRepository.dSet.Tables.Count > 0)
                {
                    DataView dv = new DataView(this.UserFileRepository.dSet.Tables[0]);


                    dv.RowFilter = "Place '%" + this.TxtSearch.Text + "%' " +
                        "or CustomerId like '%" + this.TxtSearch.Text + "%' " +
                        "or CustomerName like '%" + this.TxtSearch.Text + "%'   ";


                    this.DgvUsers.DataSource = dv;
                    this.LblTotalRecords.Text = this.DgvUsers.RowCount.ToString();
                }
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Invalid character found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            catch (EvaluateException)
            {
                MessageBox.Show("Invalid character found 2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
        }

        private void BtnInActive_Click(object sender, EventArgs e)
        {

            //Start
            if (this.RadioActive.Checked == true)
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to deactivate?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (this.DgvUsers.Rows.Count > 0)
                    {
                        this.UserFileRepository.DeactivateCustomer(this.UserFile.CustomerId);
                        this.GetActivatedUser();
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
           
                    if (MetroFramework.MetroMessageBox.Show(this, "Are you sure that you want to activate?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.DgvUsers.Rows.Count > 0)
                        {
                            this.UserFileRepository.ActivateCustomer(this.UserFile.CustomerId);
                           this.GetDeactivateUser();
                    }
                    }
                    else
                    {
                        return;
                    }
                


            }

            //End

        }

        private void DgvUsers_CurrentCellChanged(object sender, EventArgs e)
        {
            this.CurrentCellChanged();
        }

        public void CurrentCellChanged()
        {
            if (this.DgvUsers.RowCount > 0)
            {
                if (this.DgvUsers.CurrentRow != null)
                {
                    if (this.DgvUsers.CurrentRow.Cells["username"].Value != null)
                    {

                        this.UserFile.CustomerId = Convert.ToInt32(this.DgvUsers.CurrentRow.Cells["CustomerId"].Value.ToString());
                        this.UserFile.Employee_Name = this.DgvUsers.CurrentRow.Cells["CustomerName"].Value.ToString();
                        this.UserFile.Employee_Lastname = this.DgvUsers.CurrentRow.Cells["Place"].Value.ToString();

                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((currentPageIndex + 1) * pageSize < totalRecords)
            {
                currentPageIndex++;
                this.PaginateData();
            }
        }
    }
}
