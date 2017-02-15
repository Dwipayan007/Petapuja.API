using Petapuja.API.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Petapuja.API.Repo
{
    public class ProductRepo
    {
        public static DataTable getAllProductById(int id)
        {
          return DbUtility.GetAllProductData(id);
        }
    }
}