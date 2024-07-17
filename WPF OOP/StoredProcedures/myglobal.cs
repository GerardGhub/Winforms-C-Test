using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winforms.StoredProcedures;
using WPF_OOP.Interfaces;

namespace Winforms.StoredProcedures
{
    class myglobal
    {
        public static string rp_item_description = "";
        public static string bmx_proddate = "";
        public static string global_module = "";
        public static string mode = "";
        public static int temp_id = 0;
        public static int temp_number = 0;
        public static string r_item_code = "";
        public static string r_supplier = "";

        public string received_id = "";

        //public static bool updated;
        public static int swtcherprint = 0;
        public static DateTime DATE_START;
        public static DateTime DATE_END;
        public static string DATE_REPORT;
        public static string DATE_REPORT2;
        public static string DATE_REPORT3;
        public static string DATE_REPORT4;

        public string message_window_occur_for_approval_store_module = "";
        public string for_approval_store_module_formLoad = "";
        public string AllocationStatusMode = "0";


        public static int with_date = 0;
        public static int print_all = 0;
        public static int selected_only = 0;
        public static string etc = "";


        public static string Searchcategory = "";
        public static string Filter = "";
        public static string department_id = "";
        public static string department_name = "";
        public static string REPORT_NAME = "";
        public static string emp_id = "";
        public static string loan_from = "";
        //public static System.Drawing.Color color;
        public static int employee_id = 0;
        public static string employee_name = "";
        public static string employee_number = "";
        public static int feed_id = 0;
        public static string feed_code = "";
        public static string feed_type = "";
        public static string validity = "";
        public static string position = "";

        public static string flag = "";

        public static int rptflag = 0;

        public static string loan_type = "";

        public static string emp_firstname = "";
        public static string emp_lastname = "";


        public static string user_password = "";

        public static string offense_description = "";

        public static string ln_type = "";
        public static string ln_worksheet = "";
        public static string ln_title = "";

        public static string loan_from_type = "";
        public static string loan_filter = "";
        public static string loan_filter1 = "";

        public static string rep_gen = "";

        //classess xClass = new classess();
        myclasses xClass = new myclasses();
        IStoredProcedures objStorProc = null;

        DataSet dset_post = new DataSet();



        int i = 0;

        public void populateModule(DataSet dset, DataGridView dgvHeader, string mcolumns, string mode)
        {



            objStorProc = xClass.g_objStoredProc.GetCollections();

            try
            {
                dset.Clear();
                dset = objStorProc.sp_getMajorTables(mode);





                if (dset.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset.Tables[0]);
                    dgvHeader.DataSource = dv;

                    for (i = 0; i < dgvHeader.Columns.Count; i++)
                    {
                        if (mcolumns.IndexOf(dgvHeader.Columns[i].Name.ToString()) > 0)
                        {
                            dgvHeader.Columns[i].Visible = true;
                        }
                        else
                        {
                            dgvHeader.Columns[i].Visible = false;
                        }

                    }

                    // dgvHeader.Columns[i-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    for (int x = 0; x < dgvHeader.Columns.Count; x++)
                    {
                        if (mcolumns.IndexOf(dgvHeader.Columns[x].DataPropertyName.ToString()) > 0)
                        {
                            dgvHeader.Columns[x].Visible = true;
                        }
                        else
                        {
                            dgvHeader.Columns[x].Visible = false;
                        }
                    }

                }

            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }









        }
        public void populateModuleMoveOrder(DataSet dset, DataGridView dgvHeader, string mcolumns, string eTableName, string feed_code, int cid, string category, string fgdate)
        {



            objStorProc = xClass.g_objStoredProc.GetCollections();

            try
            {
                dset.Clear();
                dset = objStorProc.sp_GetCategory(eTableName, cid, feed_code, category, fgdate);





                if (dset.Tables.Count > 0)
                {
                    DataView dv = new DataView(dset.Tables[0]);
                    dgvHeader.DataSource = dv;

                    for (i = 0; i < dgvHeader.Columns.Count; i++)
                    {
                        if (mcolumns.IndexOf(dgvHeader.Columns[i].Name.ToString()) > 0)
                        {
                            dgvHeader.Columns[i].Visible = true;
                        }
                        else
                        {
                            dgvHeader.Columns[i].Visible = false;
                        }

                    }

                    // dgvHeader.Columns[i-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    for (int x = 0; x < dgvHeader.Columns.Count; x++)
                    {
                        if (mcolumns.IndexOf(dgvHeader.Columns[x].DataPropertyName.ToString()) > 0)
                        {
                            dgvHeader.Columns[x].Visible = true;
                        }
                        else
                        {
                            dgvHeader.Columns[x].Visible = false;
                        }
                    }

                }

            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }









        }

    }
}
