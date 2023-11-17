using System.Drawing.Text;

namespace Cine_App_2.Formularios
{
    public class PeliculaDAO
    {

        private int COD_PELICUAL { get; set; }
        private string NOMBRE { get; set; }
        private string SINOPSIS { get; set; }
        private string PRODUCTORA { get; set; }
        private int COD_CLASIFICACION_INCA { get; set; }
        private int COD_IDIOMA { get; set; }
        private bool SUBTITULADA { get; set; }


        public PeliculaDAO(int cOD_PELICUAL, string nOMBRE, string sINOPSIS, string pRODUCTORA, int cOD_CLASIFICACION_INCA, int cOD_IDIOMA, bool sUBTITULADA)
        {
            COD_PELICUAL = cOD_PELICUAL;
            NOMBRE = nOMBRE;
            SINOPSIS = sINOPSIS;
            PRODUCTORA = pRODUCTORA;
            COD_CLASIFICACION_INCA = cOD_CLASIFICACION_INCA;
            COD_IDIOMA = cOD_IDIOMA;
            SUBTITULADA = sUBTITULADA;
        }
    }
}
