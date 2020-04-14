using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using SQLite;
using SQLitePasteleria.iOS;
using Xamarin.Forms;
using SQLitePasteleria.Datos;
using System.IO;

[assembly: Dependency(typeof(SQLiteDB))]
namespace SQLitePasteleria.iOS
{
   public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            // se crea la base de datos
            var path = Path.Combine(ruta, "PasteleriaSQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}