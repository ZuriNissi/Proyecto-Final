using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLitePasteleria.Tablas
{
   public class T_Productos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength (255)]
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Precio { get; set; }
        [MaxLength(300)]
        public string Descripcion { get; set; }
        [MaxLength(255)]
        public string Cantidad { get; set; }

    }
}
