using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPF_OOP.Interfaces;
using WPF_OOP.StoredProcedures;

namespace Winforms.StoredProcedures
{
    class myclasses
    {
        public StoredProcedures g_objStoredProc = new StoredProcedures();
        public IStoredProcedures g_objStoredProcFill;

        //public static string confirmPassword;
        public user_infos muser_infos = new user_infos();
        public string SubCategory { get; set; }
        public string PrimaryMenuId { get; set; }
        public DataSet DataSetRMMoverOrderReceipt = new DataSet();
        public DataSet DataSetRMMoverOrderIssue = new DataSet();
        public DataSet getTable(string eTablename)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            return g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);
        }
        public void ActivitiesLogs(string logs)
        {

            try
            {
                const string location = @"aActivities";

                if (!File.Exists(location))
                {
                    var createText = "New Activities Logs" + Environment.NewLine;
                    File.WriteAllText(location, createText);
                }
                var appendLogs = "Activities Logs: " + logs + " " + DateTime.Now + Environment.NewLine;
                File.AppendAllText(location, appendLogs);
            }
            catch (Exception ex)
            {
                const string location = @"aActivities";
                if (!File.Exists(location))
                {
                    TextWriter file = File.CreateText(@"C:\aActivities");
                    var createText = "New Activities Logs" + Environment.NewLine;

                    File.WriteAllText(location, createText);

                }
                var appendLogs = ex.Message + logs + DateTime.Now + Environment.NewLine;
                File.AppendAllText(location, appendLogs);

            }

        }

        public void TextBoxToUpperCase(KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);

        }


        public void fillListBox(ListBox eListBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eListBox.DataSource = dSet.Tables[0].DefaultView;

            eListBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();

            //eListBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eListBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }

        public void DataGridViewBindingClearSelection(DataGridView dataGridView)
        {

            dataGridView.ClearSelection();
        }

        public void fillListBoxMajorMenu(ListBox eListBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eListBox.DataSource = dSet.Tables[0].DefaultView;

            eListBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();

            eListBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }







        public void fillComboBox(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }

        public void fillComboBoxDepartment(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }

        public void fillComboBoxRMDryItemCode(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[2].ToString();

            DataSetRMMoverOrderReceipt = dSet;

            // this.SubCategory = dSet.Tables[0].Rows[0]["sub_category"].ToString();
            //MessageBox.Show(this.SubCategory);

            g_objStoredProcFill = null;
        }

        public void fillCmbTransactionNo(ComboBox eComboBox, string eTablename, DataSet dSet, int UserId)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, UserId, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();

            DataSetRMMoverOrderReceipt = dSet;

            // this.SubCategory = dSet.Tables[0].Rows[0]["sub_category"].ToString();
            //MessageBox.Show(this.SubCategory);

            g_objStoredProcFill = null;
        }

        public void fillCmbItemCode(ComboBox eComboBox, string eTablename, DataSet dSet, string ItemCode)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, 0, ItemCode, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();

            DataSetRMMoverOrderIssue = dSet;

            // this.SubCategory = dSet.Tables[0].Rows[0]["sub_category"].ToString();
            //MessageBox.Show(this.SubCategory);

            g_objStoredProcFill = null;
        }




        public void fillComboBoxStoreOrderApproval(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }

        public void fillComboBoxStoreOrderApprovalSync(ComboBox eComboBox, string eTablename, DataSet dSet, string string_data_find, string string_data_find2, string string_data_find3, string string_data_find4)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, string_data_find, string_data_find2, string_data_find3, string_data_find4);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }

        public void fillGunaDataGridSync(DataGridView eDatagrid, string eTablename, DataSet dSet, string string_data_find, string string_data_find2, string string_data_find3, string string_data_find4)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, string_data_find, string_data_find2, string_data_find3, string_data_find4);







            g_objStoredProcFill = null;
        }

        public void fillComboBoxStoreOrderApprovalSyncStore(ComboBox eComboBox, string eTablename, DataSet dSet, string string_data_find, string string_data_find2, string string_data_find3, string string_data_find4)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, string_data_find, string_data_find2, string_data_find3, string_data_find4);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }
        public void fillComboBoxSearch(ComboBox eComboBox, string eTablename, DataSet dSet, int pkId)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }


        public void fillComboBoxMaterial(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }


        public void fillComboBoxRepacking(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();




            g_objStoredProcFill = null;
        }


        public void fillComboBoxFGReceipt(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();


            g_objStoredProcFill = null;
        }
        public void fillComboBoxWH(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();




            g_objStoredProcFill = null;
        }



        public void fillComboBoxFormula(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }

        public void fillComboBoxAdjustReceived(ComboBox eComboBox, string eTablename, string feed_code, string category, string fgdate, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();

            dSet.Clear();
            dSet = g_objStoredProcFill.sp_GetCategory(eTablename, null, feed_code, null, null);
            DataView dv = new DataView(dSet.Tables[0]);
            dv.RowFilter = "Balance >= -0";



            eComboBox.DataSource = dv;/*RowFilter = "Qty > 0";*/
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            g_objStoredProcFill = null;
        }
        public void fillComboBoxDays(ComboBox eComboBox, string eTablename, string feed_code, string category, string fgdate, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();

            dSet.Clear();
            dSet = g_objStoredProcFill.sp_GetCategory(eTablename, null, feed_code, null, null);
            DataView dv = new DataView(dSet.Tables[0]);




            eComboBox.DataSource = dv;/*RowFilter = "Qty > 0";*/
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            g_objStoredProcFill = null;
        }

        public void fillComboBoxCategory(ComboBox eComboBox, string eTablename, string feed_code, string category, string fgdate, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();

            dSet.Clear();
            dSet = g_objStoredProcFill.sp_GetCategory(eTablename, null, feed_code, null, null);
            DataView dv = new DataView(dSet.Tables[0]);
            dv.RowFilter = "Qty > 0";



            eComboBox.DataSource = dv;/*RowFilter = "Qty > 0";*/
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            g_objStoredProcFill = null;
        }

        public void fillComboBoxproddate(ComboBox eComboBox, string eTablename, string feed_code, string category, string fgdate, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();

            dSet.Clear();
            dSet = g_objStoredProcFill.sp_GetCategory(eTablename, null, feed_code, category, null);
            DataView dv = new DataView(dSet.Tables[0]);
            dv.RowFilter = "Qty > 0";



            eComboBox.DataSource = dv;/*RowFilter = "Qty > 0";*/
            eComboBox.DisplayMember = dSet.Tables[0].Columns[2].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[2].ToString();


            g_objStoredProcFill = null;
        }
        public void fillComboBoxFeedcode(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);
            DataView dv = new DataView(dSet.Tables[0]);
            dv.RowFilter = "Qty > 0";

            eComboBox.DataSource = dv;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();





            g_objStoredProcFill = null;
        }

        public void fillComboBoxFeedType(ComboBox eComboBox, string eTablename, string feed_code, string category, string fgdate, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_GetCategory(eTablename, null, feed_code, category, null);



            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            g_objStoredProcFill = null;
        }

        public void fillComboBoxplatenumber(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);



            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();


            g_objStoredProcFill = null;
        }

        public void fillComboBoxremark(ComboBox eComboBox, string eTablename, string feed_code, string category, string fgdate, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_GetCategory(eTablename, null, feed_code, category, null);



            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            g_objStoredProcFill = null;
        }

        public void fillComboBoxFGMoveorder(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);



            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();


            g_objStoredProcFill = null;
        }

        public void fillComboBoxFormulaDescription(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[0].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();


            //if (eTablename == "workers")
            //    dSet.Clear();
            //dSet = g_objStoredProcFill.sp_getMinorTables("workers_selection", workId);
            //eComboBox.SelectedValue = Convert.ToInt32(dSet.Tables[0].Rows[0][0].ToString());

            //foreach (char item in eComboBox.ValueMember)
            //{
            //    if(item == '')      
            //}


            g_objStoredProcFill = null;
        }


        public void AlloW2Decimal(TextBox textBox, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
                e.Handled = true;
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {
                if (Regex.IsMatch(
                 textBox.Text,
                 "^\\d*\\.\\d{2}$")) e.Handled = true;
            }
            else e.Handled = e.KeyChar != (char)Keys.Back;
        }

        public void AlloW3Decimal(TextBox textBox, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
                e.Handled = true;
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {
                if (Regex.IsMatch(
                 textBox.Text,
                 "^\\d*\\.\\d{3}$")) e.Handled = true;
            }
            else e.Handled = e.KeyChar != (char)Keys.Back;
        }

        public void fillComboBox1(ComboBox eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[2].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[1].ToString();
            g_objStoredProcFill = null;
        }

        public void fillGridComboBox(DataGridViewComboBoxColumn eComboBox, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }

        public void fillDataGridView(DataGridView eDataGrid, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);
            eDataGrid.DataSource = dSet.Tables[0];
        }




        public void fillComboboxID(DataGridView eDataGrid, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMajorTables(eTablename);
            eDataGrid.DataSource = dSet.Tables[0];
        }


        public void datagridSort(DataTable dt, int ci, string so)
        {
            if ((ci > 0) && (so != ""))
            {
                DataView dv = dt.DefaultView;
                if (so == "Ascending")
                {
                    dv.Sort = dt.Columns[ci].ColumnName + " ASC";
                }
                else if (so == "Descending")
                {
                    dv.Sort = dt.Columns[ci].ColumnName + " DESC";
                }
            }
        }

        public bool CheckEmailAddress(string eadd)
        {
            string patternLenient = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reLenient = new Regex(patternLenient);

            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$";

            Regex reStrict = new Regex(patternStrict);

            bool isLenientMatch = reLenient.IsMatch(eadd);
            return isLenientMatch;
        }
        //UPDate ko muna etoj
        public void fillComboBoxFilter(ComboBox eComboBox, string eTablename, DataSet dSet, string eDescription, int Pk)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getFilterTables(eTablename, eDescription, Pk);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[0].ToString();
            g_objStoredProcFill = null;
        }

        public void fillComboBoxFilterFormulaqty(ComboBox eComboBox, string eTablename, DataSet dSet, string eDescription, int Pk)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getFilterTables(eTablename, eDescription, Pk);

            eComboBox.DataSource = dSet.Tables[0].DefaultView;
            eComboBox.DisplayMember = dSet.Tables[0].Columns[1].ToString();
            eComboBox.ValueMember = dSet.Tables[0].Columns[2].ToString();
            g_objStoredProcFill = null;
        }

        public void is_valid_phone_no(TextBox txtbox)
        {
            string str_phone_no = txtbox.Text;
            Regex matchRegex = new Regex(@"\d{3}-\d{3}-\d{4}$");
            MatchCollection matches = matchRegex.Matches(str_phone_no);
            if (matches.Count == 0)
            {
                MessageBox.Show("Wrong phone number format.");
                txtbox.Focus();
                return;
            }
        }
        public void is_valid_zip_code(TextBox txtbox)
        {
            string str_zip_code = txtbox.Text;
            Regex matchRegex = new Regex(@"\d{5}-\d{4}$");
            MatchCollection matches = matchRegex.Matches(str_zip_code);
            if (matches.Count == 0)
            {
                MessageBox.Show("Wrong Zip/Postal Code format.");
                txtbox.Focus();
                return;
            }
        }
        public void is_valid_url(TextBox txtbox)
        {
            string str_url = txtbox.Text;
            Regex matchRegex = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?");
            MatchCollection matches = matchRegex.Matches(str_url);
            if (matches.Count == 0)
            {
                MessageBox.Show("Wrong URL format.");
                txtbox.Focus();
                return;
            }
        }
        public bool IsDataValidated(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strTextEntry)
                 && (strTextEntry != "");
        }
        public bool isNumberFormat(string val)
        {
            try
            {
                double xxx = Convert.ToDouble(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean isNumeric(string val)
        {
            try
            {
                double xval = Convert.ToDouble(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void clearTxt(Form myform)
        {
            foreach (Control txt in myform.Controls)
            {
                if (txt.GetType() == typeof(TextBox) || txt.GetType() == typeof(ComboBox) || txt.GetType() == typeof(MaskedTextBox))
                    txt.Text = "";
            }
        }
        public void clearTxt2(GroupBox myform)
        {
            foreach (Control txt in myform.Controls)
            {
                if (txt.GetType() == typeof(TextBox) || txt.GetType() == typeof(ComboBox) || txt.GetType() == typeof(MaskedTextBox))
                    txt.Text = "";
            }
        }
        public void enabledTxt(Form myform, int var)
        {
            foreach (Control txt in myform.Controls)
            {
                if (txt.GetType() == typeof(TextBox) || txt.GetType() == typeof(ComboBox) || txt.GetType() == typeof(MaskedTextBox))
                    if (Convert.ToBoolean(var == 1))
                        txt.Enabled = true;
                    else
                        txt.Enabled = false;
            }
        }
        public void disabledTxt(TextBox textbox)
        {
            textbox.ReadOnly = true;
        }

        public void ClearTxt(TextBox textbox, TextBox textbox2)
        {
            textbox.Text = String.Empty;
            textbox2.Text = String.Empty;
        }





    }

}
