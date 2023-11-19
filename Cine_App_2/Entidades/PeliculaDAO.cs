using System.Drawing.Text;

namespace Cine_App_2.Formularios
{
    public class PeliculaDAO
    {

        public int COD_PELICUAL { get; set; }
        public string NOMBRE { get; set; }
        public string SINOPSIS { get; set; }
        public string PRODUCTORA { get; set; }
        public int COD_CLASIFICACION_INCA { get; set; }
        public int COD_IDIOMA { get; set; }
        public bool SUBTITULADA { get; set; }
        public int COD_GENERO { get; set; }


        public PeliculaDAO(int cOD_PELICUAL, string nOMBRE, string sINOPSIS, string pRODUCTORA, int cOD_CLASIFICACION_INCA, int cOD_IDIOMA, bool sUBTITULADA, int cOD_GENERO)
        {
            COD_PELICUAL = cOD_PELICUAL;
            NOMBRE = nOMBRE;
            SINOPSIS = sINOPSIS;
            PRODUCTORA = pRODUCTORA;
            COD_CLASIFICACION_INCA = cOD_CLASIFICACION_INCA;
            COD_IDIOMA = cOD_IDIOMA;
            SUBTITULADA = sUBTITULADA;
            COD_GENERO = cOD_GENERO;
        }
    }
}
