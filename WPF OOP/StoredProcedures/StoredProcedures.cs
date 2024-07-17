using System;
using System.Data.SqlClient;
using System.Data;
using WPF_OOP.Interfaces;
using AutoSproc;

namespace Winforms.StoredProcedures
{
    class StoredProcedures
    {
        //create private variable "m_ConnectionString" set the connection string
        //from property settings of the system
        private string m_ConnectionString = Winforms.Properties.Settings.Default.Connection;


        //create private variable "g_objConnection
        //for sql connection
        private SqlConnection g_objConnection;

        //create private variable "g_StoredProcedureInterface"
        //for the interface or collection group of interfaces.cs
        private IStoredProcedures g_StoredProcedureInterface;

        //public function to check the sql connection 
        //return "true" if connected and "false" if not connected
        public bool getConnected()
        {
            bool is_able_to_connect = false;

            g_objConnection = new SqlConnection();
            {
                try
                {
                    if ((g_objConnection.State == ConnectionState.Open))
                    {
                        g_objConnection.Close();
                    }

                    try
                    {
                        g_objConnection.ConnectionString = m_ConnectionString;
                        g_objConnection.Open();

                        InitializeInterfaceBindingsToStoredProcedures();

                        g_objConnection.Close();
                        is_able_to_connect = true;
                    }
                    catch (SystemException)
                    {
                        is_able_to_connect = false;
                        g_objConnection.Dispose();
                    }
                }
                catch (SystemException)
                {
                    is_able_to_connect = false;
                    g_objConnection.Dispose();
                }
            }

            return is_able_to_connect;
        }

        //constructor of the class StoredProcedures
        //and connect to sql
        public StoredProcedures()
        {
            g_objConnection = new SqlConnection();
            {
                try
                {
                    if ((g_objConnection.State == ConnectionState.Open))
                    {
                        g_objConnection.Close();
                    }

                    try
                    {
                        g_objConnection.ConnectionString = m_ConnectionString;
                        g_objConnection.Open();

                        InitializeInterfaceBindingsToStoredProcedures();

                        g_objConnection.Close();
                    }
                    catch (SystemException)
                    {
                        g_objConnection.Dispose();
                    }
                }
                catch (SystemException)
                {
                    g_objConnection.Dispose();
                }
            }
        }

        //public procedure to connect to sql using sql string
        public StoredProcedures(string p_ConnectionString)
        {
            g_objConnection = new SqlConnection(p_ConnectionString);
            g_objConnection.Open();

            InitializeInterfaceBindingsToStoredProcedures();
        }

        //public variable to get the group collection of class interfaces.cs
        public IStoredProcedures GetCollections()
        {
            return g_StoredProcedureInterface;
        }

        //initialize the group collection of class interfaces.cs to the sql storedprocedure
        private void InitializeInterfaceBindingsToStoredProcedures()
        {
            object m_objSprocFactory;

            m_objSprocFactory = SprocFactory.CreateInstance(typeof(IStoredProcedures), DBProvider.SQLServer);

            g_StoredProcedureInterface = (IStoredProcedures)m_objSprocFactory;
            g_StoredProcedureInterface.Connection = g_objConnection;
            g_StoredProcedureInterface.AutoClose = true;
        }

        //to check the returned dataset empty or has value
        public class Utilities
        {
            public bool IsDataSetNotEmpty(System.Data.DataSet p_objDataSet)
            {
                if ((p_objDataSet != null))
                {
                    if (p_objDataSet.Tables.Count > 0)
                    {
                        if (p_objDataSet.Tables[0].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
        }
    }
}
