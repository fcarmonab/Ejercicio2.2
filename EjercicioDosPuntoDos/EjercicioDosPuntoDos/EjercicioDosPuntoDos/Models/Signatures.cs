using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace EjercicioDosPuntoDos.Models
{
    public class Signatures
    {
        [PrimaryKey, AutoIncrement]
        public int CodigoFirma { get; set; }

        [MaxLength(45)]
        public String Nombre { get; set; }

        [MaxLength(80)]
        public String Descripcion { get; set; }

        public Byte[] Imagen { get; set; }
    }
}
