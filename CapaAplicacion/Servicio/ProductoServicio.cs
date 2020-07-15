using CapaDominio.Entidades;
using CapaPersistencia.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion.Servicio
{
    public class ProductoServicio
    {
        private GestorMySQL gestorMySQL;
        private ProductoDAO productoDAO;

        public ProductoServicio()
        {
            gestorMySQL = new GestorMySQL();
            productoDAO = new ProductoDAO(gestorMySQL);
        }

        public List<Producto> listarProductos()
        {
            gestorMySQL.abrirConexion();
            List<Producto> listaProductos = productoDAO.listarProductos();
            gestorMySQL.cerrarConexion();
            return listaProductos;
        }
    }
}
