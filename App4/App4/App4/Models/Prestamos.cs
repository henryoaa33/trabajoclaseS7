using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Models
{

    [Serializable]
    public class Prestamo
    {

        public DateTime fechaprestamo { get; set; }
        public DateTime fechadevolucion { get; set; }

        public Persona personaprestamo { get; set; }

        public Libros libroprestamo { get; set; }

        public override string ToString()
        {
            return $"{fechaprestamo} - {fechadevolucion} ";
        }

    }
}
