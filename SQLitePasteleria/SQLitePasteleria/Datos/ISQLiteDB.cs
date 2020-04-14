using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLitePasteleria.Datos
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}

// SQLiteAsyncConnection GetConnection(); 
//Abstrae la creacion de la cadena de conexion, 
//pues la ubicacion de la base de dato local varia por plataforma.