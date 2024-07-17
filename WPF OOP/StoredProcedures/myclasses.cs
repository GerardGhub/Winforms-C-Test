using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WPF_OOP.Interfaces;
using WPF_OOP.StoredProcedures;

namespace Winforms.StoredProcedures
{
    class myclasses
    {
        public StoredProcedures g_objStoredProc = new StoredProcedures();
        public IStoredProcedures g_objStoredProcFill;


        public user_infos muser_infos = new user_infos();

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

  


        public void fillDataGridView(DataGridView eDataGrid, string eTablename, DataSet dSet)
        {
            g_objStoredProcFill = g_objStoredProc.GetCollections();
            dSet.Clear();
            dSet = g_objStoredProcFill.sp_getMinorTables(eTablename, null, null, null, null, null);
            eDataGrid.DataSource = dSet.Tables[0];
        }





        public void ClearTxt(TextBox textbox, TextBox textbox2)
        {
            textbox.Text = String.Empty;
            textbox2.Text = String.Empty;
        }





    }

}
