using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cine_App_2.Datos
{
     public class Parametros
    {
            
        public string Key { get; set; }
        public string Value { get; set; }
        public string TipoDato { get; set; }

        public Parametros(string key, string value, string tipoDato = null)
        {
            Key = key;
            Value = value;
            TipoDato = tipoDato;
        }

    }
}

