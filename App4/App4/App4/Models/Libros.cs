using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;

namespace App4.Models
{

    [Serializable]
    public class Libros
    {
        public string nombre { get; set; }
        public string autor { get; set; }
        public DateTime fechadeimpresion { get; set; }

        public override string ToString()
        {
            return $"{nombre} - {autor} - {fechadeimpresion} ";
        }
    }
}