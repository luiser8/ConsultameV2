using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PSM_ConsultameV2.Utils
{
    public class CustomDataTable
    {
        public bool ErrorStatus { get; private set; }
        public string ErrorMsg { get; private set; }


        public DataTable Execute(string name, Hashtable hashtable)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PRD"].ToString();

            DataTable resp = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(name, conn);

            da.SelectCommand.CommandTimeout = 180;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            var el = hashtable.GetEnumerator();

            while (el.MoveNext())
            {
                da.SelectCommand.Parameters.AddWithValue(el.Key.ToString(), el.Value ?? DBNull.Value);
            }

            try
            {
                da.Fill(resp);
                ErrorStatus = true;
                ErrorMsg = "";
            }
            catch (SqlException ex)
            {
                ErrorStatus = false;
                ErrorMsg = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return resp;
        }
    }
}