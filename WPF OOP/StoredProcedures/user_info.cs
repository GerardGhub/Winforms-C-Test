using System;
using System.Data;

namespace WPF_OOP.StoredProcedures
{
    class user_info
    {
        public static int user_id;
        public static int position_id;
        public static int department_id;
        public static int section_id;
        public static int user_rights_id;
        public static string username;
        public static string firstname;
        public static string lastname;

    }
    public class user_infos
    {
        public void set_values_to_user_info(DataSet dset_user_info)
        {
            user_info.user_id = Convert.ToInt16(dset_user_info.Tables[0].Rows[0][0].ToString());
            user_info.position_id = Convert.ToInt16(dset_user_info.Tables[0].Rows[0][1].ToString());
            user_info.department_id = Convert.ToInt16(dset_user_info.Tables[0].Rows[0][2].ToString());
            user_info.section_id = Convert.ToInt16(dset_user_info.Tables[0].Rows[0][3].ToString());
            user_info.user_rights_id = Convert.ToInt16(dset_user_info.Tables[0].Rows[0][4].ToString());
            user_info.username = dset_user_info.Tables[0].Rows[0][5].ToString();
            user_info.firstname = dset_user_info.Tables[0].Rows[0][6].ToString();
            user_info.lastname = dset_user_info.Tables[0].Rows[0][7].ToString();
        }
    }


}
