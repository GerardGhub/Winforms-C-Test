using AutoSproc;
using System;
using System.Data;

namespace WPF_OOP.Interfaces
{
    public interface IStoredProcedures : ISprocBase
    {


        //from login page - user's login
        DataSet sp_userlogin(string username, string password);

        //general (any pages) - get single table
        DataSet sp_getMinorTables(string eTableName,
            int? pkId,
            string string_data_find,
            string string_data_find2,
            string string_data_find3,
            string string_data_find4);
        DataSet sp_getFilterTables(string eTableName, string eDescription, int ePk);

        DataSet sp_GetCategory(string eTableName, int? cid, string feed_code, string category, string fgdate);

        //store proc for getting table data - with joins
        DataSet sp_getMajorTables(string eTableName);


        DataSet sp_userfile(int userfile_id,
            int user_rights_id,
            string username, string password,
            string employee_name,
            string user_section,
            string receiving_status,
            string Position,
            string employee_lastname,
            string Department,
            string requestor_type,
            string Unit,
            string gender,
            string mode);

        DataSet sp_userfileIncrement(int userfile_id,
         int user_rights_id,
         string username, string password,
         string employee_name,
         string user_section,
         string receiving_status,
         int Position,
         string employee_lastname,
         int Department,
         string requestor_type,
         string Unit,
         string gender,
         string mode);

        DataSet sp_userfile(int userfile_id, string username, string password, string user_section, string mode);



    }
}
