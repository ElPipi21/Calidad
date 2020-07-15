using CapaDominio.Entidades;
using CapaPersistencia.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion.Servicio
{
    public class ClienteServicio
    {
        private GestorMySQL gestorMySQL;
        private ClienteDAO clienteDAO;

        public ClienteServicio()
        {
            gestorMySQL = new GestorMySQL();
            clienteDAO = new ClienteDAO(gestorMySQL);
        }
        public Cliente verificarAcceso(string cliente, string clave)
        {
            gestorMySQL.iniciarTransaccion();
            var cli = clienteDAO.verificarAcceso(cliente, clave);
            gestorMySQL.terminarTransaccion();
            gestorMySQL.cancelarTransaccion();
            return cli;
            //gestorMySQL.cancelarTransaccion();
        }
        public bool insertarCliente(Cliente cliente)
        {
            gestorMySQL.iniciarTransaccion();
            bool insertar = clienteDAO.insertarCliente(cliente);
            if (insertar)
                gestorMySQL.terminarTransaccion();
            else
                gestorMySQL.cancelarTransaccion();
            return insertar;
        }

        public bool editarCliente(Cliente cliente)
        {
            gestorMySQL.iniciarTransaccion();
            bool editar = clienteDAO.editarCliente(cliente);
            if (editar)
                gestorMySQL.terminarTransaccion();
            else
                gestorMySQL.cancelarTransaccion();
            return editar;
        }

    }
}
