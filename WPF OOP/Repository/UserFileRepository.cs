using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPF_OOP.Interfaces;
using Winforms.StoredProcedures;

namespace WPF_OOP.Repository
{
    internal class UserFileRepository : IUserFileRepository
    {
        readonly myclasses xClass = new myclasses();
        public  DataSet dSet = new DataSet();
      IStoredProcedures objStorProc = null;
        int TotalRecords = 0;

        public void ActivateCustomer(int UserId)
        {
            this.ConnectionInit();
            this.dSet.Clear();
            this.dSet = objStorProc.sp_userfile(UserId, "", "", "", "activate");
        }

        public void AddUser(int UserFileId, int UserRightsId, string Username, string Password, string EmployeeName, string UserSection, string ReceivingStatus, int Position, string EmployeeLastName, int Department, string RequestorType, string Unit, string Gender, string Mode)
        {
            this.ConnectionInit();
            this.dSet.Clear();
            this.dSet = objStorProc.sp_userfileIncrement(0,
                UserRightsId,
                Username,
                Password,
                EmployeeName,
                UserSection,
                ReceivingStatus,
                Position,
                EmployeeLastName,
                Department,
                RequestorType,
                Unit,
                Gender,
                "add");
        }

        public void DeactivateCustomer(int UserId)
        {
            this.ConnectionInit();
            this.dSet.Clear();
            this.dSet = objStorProc.sp_userfile(UserId, "", "", "", "delete");
        }

        public void GetCustomer(DataGridView DataGridViews)
        {
            try
            {

                this.xClass.fillDataGridView(DataGridViews, "getcustomcustomer", this.dSet);

                this.TotalRecords = DataGridViews.RowCount;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void GetCustomerInactive(DataGridView DataGridViews)
        {
            try
            {

                this.xClass.fillDataGridView(DataGridViews, "usersInactive", this.dSet);

                this.TotalRecords = DataGridViews.RowCount;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void LoginValidation(string Username, string Password)
        {
            this.ConnectionInit();
            this.dSet.Clear();
            this.dSet = objStorProc.sp_userfile(0,
            Username,
            Password,
            "",
            "validate");

        }

        public void SearchActiveCustomer(string Mode)
        {
            this.ConnectionInit();
            this.dSet.Clear();
            this.dSet = objStorProc.sp_getMajorTables(Mode);
        }

        public void SearchInActiveCustomer(string Mode)
        {
            this.ConnectionInit();
            this.dSet.Clear();
            this.dSet = objStorProc.sp_getMajorTables(Mode);
        }

        public void ValidateUserIfExist(string UserName, string FirstName, string LastName)
        {
            this.ConnectionInit();
            dSet.Clear();
            dSet = objStorProc.sp_userfile(0,0,
                UserName,
                "",
                FirstName,
                "",
                "",
                "",
                LastName,
                "",
                "",
                "",
                "",
                "getbyname");
        }

        private void ConnectionInit()
        {

            this.objStorProc = xClass.g_objStoredProc.GetCollections();
        }

    }
}
