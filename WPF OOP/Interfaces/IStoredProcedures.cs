using AutoSproc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OOP.Interfaces
{
    public interface IStoredProcedures : ISprocBase
    {
        DataSet DisciplinaryInitialResolutionReleased(int daId);

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






        DataSet sp_position(
        int position_id,
        string position_name,
        string department_id,
        string created_by,
        string created_at,
        string modified_by,
        string modified_date,
        string primary_user_id,
        string mode);


        DataSet sp_department(
        int department_id,
        string department_name,
        string created_by,
        string created_at,
        string updated_at,
        string updated_by,
        string primary_user_id,
        string location_id,
        string mode);






   











        DataSet sp_DryWHIssueParents(
        int Id,
        string ParentDescription,
        string Remarks,
        bool IsActive,
        string AddedBy,
        DateTime DateAdded,
        string mode);





        DataSet sp_tblCustomers(
        int cust_id,
        string cust_name,
        string cust_type,
        string cust_company,
        string cust_mobile,
        string cust_leadman,
        string cust_address,
        int cust_added_by,
        string cust_date_added,
        string cust_updated_by,
        string cust_date_updated,
        bool is_active,
        string mode);




        DataSet sp_PrimaryUnitManagement(
        int id,
        string active_pu_primary_id,
        string active_pu_description,
        string active_pu_conversion,
        string item_primary_id,
        string item_item_code,
        string item_description,
        string created_at,
        string created_by,
        string modified_at,
        string modified_by,
        string is_active,
        string mode);



        DataSet sp_Location(int location_id,
        string location_name,
        string created_at,
        string created_by,
        string updated_at,
        string updated_by,
        string mode);



        DataSet sp_available_menu_grandChild(int menu_id,
      string menu_name,
      string menu_form_name,
      string parent_menu,
      string created_at,
      string created_by,
      string updated_at,
      string updated_by,
      string mode);



        DataSet sp_DepartmentUnit(int unit_id,
        string unit_description,
        string department,
        string updated_at,
        string updated_by,
        string created_at,
        string created_by,
        string mode);

        DataSet sp_user_rights(int user_rights_id, string user_rights_name, string mode);

        DataSet sp_user_rights_details(int user_rights_details_id,
            int user_rights_id,
            int menu_id,
            string updated_at,
            string updated_by,
            string Tagging_Relationship,
            string FirstName,
            string IDPerUser,
            string mode);





        DataSet sp_user_rights_details(int user_rights_details_id, string mode);









    }
}
