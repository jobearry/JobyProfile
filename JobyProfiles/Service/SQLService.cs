
using JobyProfiles.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobyProfiles
{
    class SQLService
    {
        public DataSet Get(string searchString)
        {
            SqlConnection Connection = SQLUtility.DBConnect();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM {SQLUtility.TableName} WHERE item_type=@searchString", Connection);
            cmd.Parameters.AddWithValue("@searchString", searchString);
            Connection.Open();
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet dSet = new DataSet();
            dAdapter.Fill(dSet, SQLUtility.TableName);
            Connection.Close();
            return dSet;
        }

        public DataSet Put(List<UserModel> listContent, string searchString) 
        {
            SqlConnection Connection = SQLUtility.DBConnect();
            foreach (UserModel content in listContent)
            {
                //SqlCommand cmd = new SqlCommand($"UPDATE {SQLUtility.TableName} " +
                //    $"SET item_type = '{content.item_type}', " +
                //    $"item_name = '{content.item_name}'," +
                //    $"item_code = '{content.item_code}'," +
                //    $"model_no = '{content.model_no}'" +
                //    $"WHERE item_type = '{content.item_type}'" +
                //    $"AND id = '{content.id}'", Connection);
                Connection.Open();
                //cmd.ExecuteNonQuery();
                Connection.Close();
            }
            
            return Get(searchString);
        }
    }
}
