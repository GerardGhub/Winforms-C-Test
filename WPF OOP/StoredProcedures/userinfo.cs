using System;
using System.Data;

namespace Winforms.StoredProcedures
{
    class userinfo
    {
        //Declaration
        public static int USER_LOG = 0;
        public static int user_id;
        public static string user_name;
        public static string password;
        public static string emp_name;
        public static string emp_lastname;
        public static int user_rights_id;
        public static string user_section;
        public static string receiving_status;
        public static string position;
        public static string image_employee;
        public static string department;

        public static void set_user_parameters(DataSet dset_user)
        {
            user_id = Convert.ToInt32(dset_user.Tables[0].Rows[0][0].ToString());
            user_rights_id = Convert.ToInt32(dset_user.Tables[0].Rows[0][1].ToString());
            user_name = dset_user.Tables[0].Rows[0][2].ToString();
            password = dset_user.Tables[0].Rows[0][3].ToString();
            emp_name = dset_user.Tables[0].Rows[0][4].ToString();
            user_section = dset_user.Tables[0].Rows[0][5].ToString();
            receiving_status = dset_user.Tables[0].Rows[0][6].ToString();
            emp_lastname = dset_user.Tables[0].Rows[0][7].ToString();
            position = dset_user.Tables[0].Rows[0][8].ToString();
            image_employee = dset_user.Tables[0].Rows[0][10].ToString();
            department = dset_user.Tables[0].Rows[0][11].ToString();
            USER_LOG = 1;
        }
    }
}
