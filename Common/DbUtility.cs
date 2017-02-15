using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Petapuja.API.Common
{
    public class DbUtility
    {
        
        public static DataTable GetAllProductData(int id)
        {
            DbInstancce db = new DbInstancce();
            MySqlCommand scmd = new MySqlCommand();
            scmd.CommandText = "Select * from product where productid=@productid";
            scmd.Parameters.AddWithValue("productid", id);
            return db.GetDataTable(scmd);
        }
    }
}