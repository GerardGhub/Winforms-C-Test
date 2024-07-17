using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OOP.Repository
{

    internal interface IUserFileRepository
    {
        void LoginValidation(string Username, string Password);

        void GetCustomer(System.Windows.Forms.DataGridView DataGridViews);
        void GetCustomerInactive(System.Windows.Forms.DataGridView DataGridViews);
        void DeactivateCustomer(int UserId);
        void ActivateCustomer(int UserId);
        void ValidateUserIfExist(string UserName, string FirstName, string LastName);

        void SearchActiveCustomer(string Mode);
        void SearchInActiveCustomer(string Mode);

        void AddUser(int UserFileId, int UserRightsId, string Username, string Password, string EmployeeName, string UserSection,
            string ReceivingStatus, int Position, string EmployeeLastName, int Department, string RequestorType, string Unit,
            string Gender, string Mode);

    }
}
