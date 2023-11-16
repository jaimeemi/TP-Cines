using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cine_App_2.Entidades
{
    internal class GenerosDAO
    {
        private int CODGENERO {  get; set; }
        private string Nombre { get; set; }

        public GenerosDAO(int codigo, string nombre)
        { 
            CODGENERO = codigo;
            Nombre = nombre;
        }
    }
}
