using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OOP.Models
{
    internal class UserFile
    {
        public int Userfile_Id { get; set; }
        public int User_Rights_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Employee_Name { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Date_Created {get; set;}
        public DateTime Date_Edited {get; set;}
        public string User_Section { get; set; }
        public string Receiving_Status { get; set; }
        public int Position { get; set; }
        public int Login { get; set; }
        public string Login_Timestamp { get; set; }
        public string Logout_Timestamp { get; set; }
        public string Employee_Lastname { get; set; }
        public int Department { get; set; }
        public string Requestor_Type { get; set; }
        public string Unit { get; set; }
        public string Gender { get; set; }
        public string Mode { get; set; }
        

    }
}
