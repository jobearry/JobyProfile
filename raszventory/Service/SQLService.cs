
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace raszventory
{
    class SQLService
    {
        public DataSet get(string searchString)
        {
            SqlConnection Connection = SQLUtility.DBConnect();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RZINVT01 WHERE item_type=@searchString", Connection);
            cmd.Parameters.AddWithValue("@searchString", searchString);
            Connection.Open();
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataSet dSet = new DataSet();
            dAdapter.Fill(dSet, "RZINVT01");
            return dSet;
        }
    }
}
