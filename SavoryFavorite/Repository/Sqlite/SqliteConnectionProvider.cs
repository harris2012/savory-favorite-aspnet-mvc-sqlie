using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace SavoryFavorite.Repository.Sqlite
{
    public class SqliteConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            var connString = ConfigurationManager.ConnectionStrings["SavoryFavoriteDB"].ConnectionString;

            SQLiteConnection connection = new SQLiteConnection(connString);
            connection.Open();

            return connection;
        }
    }
}
