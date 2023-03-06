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

        public List<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        public override string ToString()
        {
            return $"{fechaprestamo} - {fechadevolucion} ";
        }

    }
}
