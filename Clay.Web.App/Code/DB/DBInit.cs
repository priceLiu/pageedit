using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Smark.Data;

namespace Clay.Web.App.Code.DB
{
    public class DBInit:Smark.Data.IDBContextInithandler
    {
        public void Init()
        {
            string dbpath = @"Data Source={0}app_data\clay.db;Pooling=true;FailIfMissing=false;";
            DBContext.SetConnectionString(ConnectionType.Context1, string.Format(dbpath, Peanut.WebContext.Current.Request.PhysicalApplicationPath));
            DBContext.SetConnectionDriver<SqliteDriver>(ConnectionType.Context1);
        }
    }
}