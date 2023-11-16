using CinemaApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.fachada
{
    public interface IDataApi
    {
        //INTERFA QUE ANTICIPA LOS CRUD QUE SE PODRAN HACER CON LA APIWEB
        //1.CONSULTA SOBRE FACTURACION
        public List<Factura> ObtenerFacturasEnPeriodo(DateTime desde, DateTime hasta);
        //2.ALTA DE FACTURA
        public bool CrearFactura(Factura factura);
        //3.MODIFICA-ACTUALIZA FACTURA: LO DBEEMOS ELIMINAR. LO DEJAMOS COMO MOLDE PARA FUNCIONES
        public bool ActualizarFactura(Factura factura);
        //4.BORRA-DA DE BAJA FACTURA. LO DBEEMOS ELIMINAR. LO DEJAMOS COMO MOLDE PARA FUNCIONES
        public bool BorrarFactura(int nroFactura);

        public Factura ObtenerPorId(int nro);
    }
}
