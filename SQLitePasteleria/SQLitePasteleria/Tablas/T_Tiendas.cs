using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLitePasteleria.Tablas
{
    class T_Tiendas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string NombreTienda { get; set; }
        [MaxLength(255)]
        public string CalleTienda { get; set; }
        [MaxLength(300)]
        public string NumeroEx { get; set; }
        [MaxLength(255)]
        public string NumeroIn { get; set; }
        [MaxLength(255)]
        public string Colonia { get; set; }
    }
}
