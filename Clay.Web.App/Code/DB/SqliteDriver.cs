using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clay.Web.App.Code.DB
{
    public class SqliteDriver : Smark.Data.DriverTemplate<
        System.Data.SQLite.SQLiteConnection,
        System.Data.SQLite.SQLiteCommand,
        System.Data.SQLite.SQLiteDataAdapter,
        System.Data.SQLite.SQLiteParameter,
        Smark.Data.SqlitBuilder>
    {
    }
}