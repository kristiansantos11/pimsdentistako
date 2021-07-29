﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using pimsdentistako.DBElements;
using System.Collections.ObjectModel;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Threading;

namespace pimsdentistako.DBHelpers
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

        public static bool compare(string obj1, string obj2)
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

        // square brackets to prevent query params being detected as reserved keyword
        public static string Preserved(string to_isolate)
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append("[").Append(to_isolate).Append("]").ToString();
        }

        //add square braces to provided array of string column names
        public static string[] BatchPreserved(string[] columns_or_tables)
        {
            for (int i = 0; i < columns_or_tables.Length; i++)
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

        //convert date string to DateTime
        public static DateTime ConvertToDateTime(string date_string)
        {
            return Convert.ToDateTime(date_string);
        }

        //INTELLIGENT ALGORITHM TO BIND NAMES ALTHOUGH BLANK INPUTS EXIST
        public static string BindFieldsByCondition(string condition_string, string string_to_add_if_match, int condition_mode, bool enableMiddleDot, params string[] strings_to_check)
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            foreach (string item in strings_to_check)
            {
                bool checker = item.Equals(condition_string);
                if (condition_mode != 0) //invert the condition if not in 0 mode
                {
                    checker = !checker;
                }
                if (checker)
                {
                    sb.Append(item);
                    if (counter == 1 && enableMiddleDot) sb.Append("."); //dot for middle initial
                    sb.Append(string_to_add_if_match);
                }
                counter++;
            }
            return sb.ToString().Trim(); ;
        }

        #region INPUT CHECKER
        public static bool IsValueNull(string field)
        {
            return string.IsNullOrEmpty(field);
        }

        public static string isMatchThenReplace(bool conditionBool, string valTrue, string valFalse)
        {
            return conditionBool ? valTrue : valFalse;
        }

        //CHECK IF THE USER DOES NOT ENTER ANY VALUE IF NOT REPLACE IT WITH BLANK_INPUT "-"
        public static string CheckNullEmptyInput(TextBox tb)
        {
            return String.IsNullOrEmpty(tb.Text) ? BLANK_INPUT : tb.Text.Trim();
        }
        public static string CheckNullEmptyInput(DatePicker dp)
        {
            return String.IsNullOrEmpty(dp.Text) ? BLANK_INPUT : dp.Text.Trim();
        }

        public static bool IsTextBoxTextNullEmpty(TextBox textBox)
        {
            return String.IsNullOrEmpty(textBox.Text);
        }
        public static bool IsTextBoxTextNullEmpty(DatePicker datePicker)
        {
            return String.IsNullOrEmpty(datePicker.Text);
        }
        #endregion INPUT CHECKER

        #region DIALOGS
        //USE ONLY IN DEBUGGING MODE
        public static void DisplayInMessageBox(string fromSource, Exception e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                MessageBox.Show(e.Message, "Debugger of: " + fromSource);
            }));
        }

        public static void DisplayWarningDialog(string dialog_label, string dialog_content)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            {
                MessageBox.Show(dialog_content, dialog_label, MessageBoxButton.OK, MessageBoxImage.Warning);
            }));
        }

        public static void DisplayErrorDialog(string dialog_label, string dialog_content)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() => { 
                MessageBox.Show(dialog_content, dialog_label, MessageBoxButton.OK, MessageBoxImage.Error); 
            }));
        }

        public static void DisplayDialog(string dialog_label, string dialog_content)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() => { 
                MessageBox.Show(dialog_content, dialog_label, MessageBoxButton.OK, MessageBoxImage.None); 
            }));
        }
        #endregion DIALOGS

        #region COMMON QUERY METHODS

        public static OleDbCommand SelectAllCommand(string myTable)
        {
            return new OleDbCommand("SELECT * FROM " + myTable, GetConnectionObject());
        }
        public static OleDbCommand SelectAllThatSatisfiesCommand(string myTable, string activeCol, string value, bool isNumber)
        {
            if (isNumber)
            {
                return new OleDbCommand("SELECT * FROM " + myTable + " WHERE " + activeCol + " = " + value, GetConnectionObject());
            }
            return new OleDbCommand("SELECT * FROM " + myTable + " WHERE " + activeCol + " = '" + value + "'", GetConnectionObject());
        }

        public static OleDbCommand LastRecordCommand(string myTable, string idColumn)
        {
            //"SELECT * FROM " + myTable + " WHERE " + col[0] + " = (SELECT MAX(" + col[0] + ") FROM " + myTable + ")"
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ").Append(myTable)
                .Append(" WHERE ").Append(idColumn)
                .Append(" = (SELECT MAX(").Append(idColumn)
                .Append(") FROM ")
                .Append(myTable).Append(")");
            return new OleDbCommand(sb.ToString(), GetConnectionObject());
        }

        public static OleDbCommand AddCommand(string myTable, string[] columns, int startIndex, int endIndex, List<string> valueSourceList)
        {
            char comma = ',';
            char closingPar = ')';
            char whiteSpace = ' ';

            StringBuilder query = new StringBuilder();
            StringBuilder valuesString = new StringBuilder("VALUES (");
            List<string> valuesPlaceHolder = new List<string>();

            query.Append("INSERT INTO ").Append(myTable).Append(" (");

            for(int i = startIndex; i <= endIndex; i++)
            {
                string placeHolder = "@" + i;
                query.Append("[").Append(columns[i]).Append("]");
                valuesString.Append(placeHolder);
                valuesPlaceHolder.Add(placeHolder);

                if (i == endIndex)
                {
                    query.Append(closingPar);
                    valuesString.Append(closingPar);
                }
                else 
                {
                    query.Append(comma);
                    valuesString.Append(comma).Append(whiteSpace);
                }
                query.Append(whiteSpace);
            }

            OleDbCommand insertCommand = new OleDbCommand(query.Append(valuesString).ToString(), GetConnectionObject());

            for(int i = 0; i < valueSourceList.Count; i++)
            {
                insertCommand.Parameters.Add(new OleDbParameter(valuesPlaceHolder[i], valueSourceList[i]));
            }
            return insertCommand;
        }

        public static OleDbCommand DeleteCommand(string myTable, string activeColumn, string testParam, bool isParamNumber)
        {
            if (isParamNumber)
            {
                //numbers in testParam must not contain '' so it is detected by ACCESS as number type not text
                return new OleDbCommand("DELETE FROM " + myTable + " WHERE [" + activeColumn + "]=" + testParam + ";", GetConnectionObject());
            }
            return new OleDbCommand("DELETE FROM " + myTable + " WHERE [" + activeColumn + "]='" + testParam + "';", GetConnectionObject());

        }

        #endregion COMMON QUERY METHODS
    }
}
