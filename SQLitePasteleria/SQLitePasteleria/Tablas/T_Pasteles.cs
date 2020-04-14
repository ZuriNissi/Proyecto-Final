using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLitePasteleria.Tablas
{
    class T_Pasteles
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string NombrePastel { get; set; }
        [MaxLength(5000)]
        public string DescripcionPastel { get; set; }
        [MaxLength(255)]
        public string PrecioPastel { get; set; }

    }
}
