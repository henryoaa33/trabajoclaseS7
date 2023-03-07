using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Models
{

    [Serializable]
    public class Persona
    {

        public string nombre2 { get; set; }
        public double numerocuenta { get; set; }


        public override string ToString()
        {
            return $"{nombre2} - {numerocuenta} ";
        }
    }
}
