using MessengerServiceLibrary.Classes;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerServiceLibrary.Db
{
    class DbHelper
    {


        private SqlDatabase _database;
        protected DbCommand command;

        public static string ConnectionString
        {
            get
            {
                return ConfigurationSettings.AppSettings["SqlConnectionString"];
            }
        }

        public SqlDatabase database
        {
            get
            {
                if (_database == null)
                    _database = new SqlDatabase(ConnectionString);
                return _database;
            }
        }
    }
}
