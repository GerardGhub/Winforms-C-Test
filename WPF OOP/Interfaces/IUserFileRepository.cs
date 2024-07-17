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

        void GetUsers(System.Windows.Forms.DataGridView DataGridViews);
        void GetUsersInactive(System.Windows.Forms.DataGridView DataGridViews);
        void DeactivateUser(int UserId);
        void ActivateUser(int UserId);
        void ValidateUserIfExist(string UserName, string FirstName, string LastName);

        void SearchActiveUser(string Mode);
        void SearchInActiveUser(string Mode);

        void AddUser(int UserFileId, int UserRightsId, string Username, string Password, string EmployeeName, string UserSection,
            string ReceivingStatus, int Position, string EmployeeLastName, int Department, string RequestorType, string Unit,
            string Gender, string Mode);

    }
}
