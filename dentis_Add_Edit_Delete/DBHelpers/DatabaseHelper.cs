﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using dentis_Add_Edit_Delete.DBElements;
using System.Collections.ObjectModel;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;

namespace dentis_Add_Edit_Delete.DBHelpers
{
    public class DatabaseHelper
    {
        //Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\mydatabase.mdb;Jet OLEDB:Database Password = MyDbPassword;
        private static OleDbConnection _CONNECTION_OBJ;
        private static bool dEBUG;

        public static readonly string BLANK_INPUT = "-";
        public static readonly string EMPTY_INPUT = "";
        public static readonly string WHITE_SPACE_INPUT = " ";

        public static bool DEBUG { get => dEBUG; set => dEBUG = value; }

        public class ConnectionState
        {
            public static readonly string STATE_CLOSE = "Closed";
            public static readonly string STATE_OPEN = "Open";
        }

        public static string GetConnectionState()
        {
            return _CONNECTION_OBJ.State.ToString();
        }

        public static void TestConnection() //use only for testing connection
        {

            requestConnection(ConnectionState.STATE_OPEN);
            MessageBox.Show("Connection State: " + GetConnectionObject().State.ToString());
        }
     
        public static bool Init() //run on main window
        {
            if (_CONNECTION_OBJ == null)
            {
                _CONNECTION_OBJ = new OleDbConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }
            return true;
        }
    
        public static OleDbConnection GetConnectionObject()
        {
            _ = Init();
            return _CONNECTION_OBJ;
        }

        public static void requestConnection(string state)
        {
            _ = Init();
            if (state.Equals(ConnectionState.STATE_OPEN) && GetConnectionState().Equals(ConnectionState.STATE_CLOSE))
            {
                _CONNECTION_OBJ.Open();
            } 
            else if (state.Equals(ConnectionState.STATE_CLOSE) && GetConnectionState().Equals(ConnectionState.STATE_OPEN))
            {
                _CONNECTION_OBJ.Close();
            }
        }

        private static bool compare(string obj1, string obj2)
        {
            return obj1.Equals(obj2);
        }

        public static long GetMaxID(string Table) //returns 1 if value is DBNull
        {
            string activeIDCol = "";

            if (compare(Table, DBNames.TableNames.DENTAL_REC))
            {
                activeIDCol = DBNames.ColumnNames.Dental_Record[0];
            } 
            else if (compare(Table, DBNames.TableNames.DENTIST))
            { 
                activeIDCol = DBNames.ColumnNames.Dentist[0];
            }
            else if (compare(Table, DBNames.TableNames.EMERGENCY_INFO))
            {
                activeIDCol = DBNames.ColumnNames.Emergency_Information[0];
            }
            else if (compare(Table, DBNames.TableNames.PATIENT))
            {
                activeIDCol = DBNames.ColumnNames.Patient[0];
            }
            else if (compare(Table, DBNames.TableNames.TREATMENT))
            {
                activeIDCol = DBNames.ColumnNames.Treatment[0];
            }
            else if (compare(Table, DBNames.TableNames.TREATMENT_PLAN))
            {
                activeIDCol = DBNames.ColumnNames.Treatment_Plan[0];
            }
            else if (compare(Table, DBNames.TableNames.TREATMENT_TYPE))
            {
                activeIDCol = DBNames.ColumnNames.Treatment_Type[0];
            }
            else if (compare(Table, DBNames.TableNames.USER_ACC))
            {
                activeIDCol = DBNames.ColumnNames.User_Account[0];
            }

            requestConnection(ConnectionState.STATE_OPEN);
            OleDbCommand maxIdCommand = new OleDbCommand("SELECT MAX(" + activeIDCol + ") FROM " + Table, GetConnectionObject());
            object obj = maxIdCommand.ExecuteScalar();
            int maxAvailble;
            if (obj != null && DBNull.Value != obj)
            {
                maxAvailble = (int)obj;
                return maxAvailble += 1;
            }
            maxAvailble = 1;
            return maxAvailble;
        }

        //Replaces "-" to ""
        public static string BlankInputFieldReplacer(string field)
        {
            return field.Equals(BLANK_INPUT) ? EMPTY_INPUT : field;
        }

        //CHECK IF THE USER DOES NOT ENTER ANY VALUE IF NOT REPLACE IT WITH BLANK_INPUT "-"
        public static string CheckNullEmptyInput(TextBox tb)
        {
            return String.IsNullOrEmpty(tb.Text) ? BLANK_INPUT : tb.Text.Trim();
        }

        //USE ONLY IN DEBUGGING MODE
        public static void DisplayInMessageBox(string fromSource, Exception e)
        {
            MessageBox.Show(e.Message, "Debugger of: " + fromSource);
        }

        // square brackets to prevent query params being detected as reserved keyword
        public static string Preserved(string to_isolate)
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append("[").Append(to_isolate).Append("]").ToString();
        }

        //add square braces to provided array of string column names
        public static string[] BatchPreserved(string[] columns_or_tables)
        {
            for(int i = 0; i < columns_or_tables.Length; i++)
            {
                columns_or_tables[i] = Preserved(columns_or_tables[i]);
            }
            return columns_or_tables;
        }

        //check the index of active datagrid if valid to prevent access out of range or negative index
        public static bool IsSelectedIndexValid(int selected_index, int your_list_count)
        {
            return !(selected_index >= your_list_count || selected_index < 0);
        }
    }
}