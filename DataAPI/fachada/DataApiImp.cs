using CinemaApp.datos.Implementacion;
using CinemaApp.datos.Interfaz;
using CinemaApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.fachada
{
    public class DataApiImp : IDataApi
    {
        //ESTA CAPA DATAAPIIMP CREA LOS METODOS QUE ANTICIPAMOS EN LA INTERFAZ: IDATAAPI
        //QUE PERTENECE A LA CARPETA FACHADA DEL PROYECTO DATAAPI
        //ESTOS METODOS SOLAMENTE RETORNAN EL LLAMADO A LA CAPA DAO, Y ESPECIFICAMENTE A LOS METODOS CRUD DE ESA CAPA
        private IDaoFactura dao;

        public DataApiImp()
        {
            dao = new FacturaDao();
        }

        public List<Factura> ObtenerFacturasEnPeriodo(DateTime desde, DateTime hasta)
        {
            return dao.ObtenerEnPeriodo(desde, hasta);
        }

        public Factura ObtenerPorId(int nro)
        {
            return dao.ObtenerPorId(nro);
        }

        public bool CrearFactura(Factura factura)
        {
            return dao.Crear(factura);
        }

        public bool ActualizarFactura(Factura factura)
        {
            return dao.Actualizar(factura);
        }

        public bool BorrarFactura(int nroFactura)
        {
            return dao.Borrar(nroFactura);
        }
    }
}
