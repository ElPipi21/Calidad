using CapaDominio.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPersistencia.MySQL
{
    public class ClienteDAO
    {
        private GestorMySQL gestorMySQL;
        public ClienteDAO(GestorMySQL gestorMySQL)
        {
            this.gestorMySQL = gestorMySQL;
        }
        public Cliente verificarAcceso(string cliente, string clave)
        {
            MySqlCommand comandoMySQL = new MySqlCommand("spVerificarAcceso");
            try
            {
                comandoMySQL = gestorMySQL.obtenerComandoDeProcedimiento(comandoMySQL);
                comandoMySQL.Parameters.AddWithValue("prmstrNombre", cliente);
                comandoMySQL.Parameters.AddWithValue("prmstrPassword", clave);
                comandoMySQL.ExecuteNonQuery();
                Cliente cli = null;
                MySqlDataReader resultadoMySQL = gestorMySQL.ejecutarComandoDeProcedimientoSinParametros(comandoMySQL);
                while(resultadoMySQL.Read())
                {
                    cli = new Cliente()
                    {
                        Nombre = resultadoMySQL["nombre"].ToString(),
                        Apellido = resultadoMySQL["apellido"].ToString(),
                        Direccion = resultadoMySQL["direccion"].ToString(),
                        Ciudad = resultadoMySQL["ciudad"].ToString(),
                        Telefono = Convert.ToInt32(resultadoMySQL["telefono"]),
                        Email = resultadoMySQL["email"].ToString(),
                        Fecha_nacimiento = Convert.ToDateTime(resultadoMySQL["fecha nacimiento"]),
                        Sexo = Convert.ToChar(resultadoMySQL["sexo"]),
                        Password = Convert.ToInt32(resultadoMySQL["password"]),
                    };
                    //return cli;
                }
                resultadoMySQL.Close();
                return cli;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public bool insertarCliente(Cliente cliente)
        {
            MySqlCommand comandoMySQL = new MySqlCommand("spInsertarCliente");
            bool insertar = false;
            try
            {
                comandoMySQL = gestorMySQL.obtenerComandoDeProcedimiento(comandoMySQL);
                comandoMySQL.Parameters.AddWithValue("prmstrNombre", cliente.Nombre);
                comandoMySQL.Parameters.AddWithValue("prmstrApellido", cliente.Apellido);
                comandoMySQL.Parameters.AddWithValue("prmstrDireccion", cliente.Direccion);
                comandoMySQL.Parameters.AddWithValue("prmstrCiudad", cliente.Ciudad);
                comandoMySQL.Parameters.AddWithValue("prmintTelefono", cliente.Telefono);
                comandoMySQL.Parameters.AddWithValue("prmstrEmail", cliente.Email);
                comandoMySQL.Parameters.AddWithValue("prmdateFecha_nacimiento", cliente.Fecha_nacimiento);
                comandoMySQL.Parameters.AddWithValue("prmstrSexo", cliente.Sexo );
                comandoMySQL.Parameters.AddWithValue("prmstrPassword", cliente.Password);
                //comandoMySQL.Parameters.AddWithValue("prmboolEstado", cliente.Estado);
                comandoMySQL.ExecuteNonQuery();
                if(comandoMySQL != null)
                {
                    insertar = true;
                }
                return insertar;
            }
            catch (Exception err)
            {
                throw new Exception("Ocurrio un problema al insertar cliente.", err);
            }
        }

        public bool editarCliente(Cliente cliente)
        {
            MySqlCommand comandoMySQL = new MySqlCommand("spEditarCliente");
            bool editar = false;
            try
            {
                comandoMySQL = gestorMySQL.obtenerComandoDeProcedimiento(comandoMySQL);
                comandoMySQL.Parameters.AddWithValue("prmintIdCliente", cliente.IdCliente);
                comandoMySQL.Parameters.AddWithValue("prmstrNombre", cliente.Nombre);
                comandoMySQL.Parameters.AddWithValue("prmstrApellido", cliente.Apellido);
                comandoMySQL.Parameters.AddWithValue("prmstrDireccion", cliente.Direccion);
                comandoMySQL.Parameters.AddWithValue("prmstrCiudad", cliente.Ciudad);
                comandoMySQL.Parameters.AddWithValue("prmintTelefono", cliente.Telefono);
                comandoMySQL.Parameters.AddWithValue("prmstrEmail", cliente.Email);
                comandoMySQL.Parameters.AddWithValue("prmdateFecha_nacimiento", cliente.Fecha_nacimiento);
                comandoMySQL.Parameters.AddWithValue("prmstrSexo", cliente.Sexo);
                comandoMySQL.Parameters.AddWithValue("prmstrPassword", cliente.Password);
                //comandoMySQL.Parameters.AddWithValue("prmboolEstado", cliente.Estado);
                comandoMySQL.ExecuteNonQuery();
                if (comandoMySQL != null)
                {
                    editar = true;
                }
                return editar;
            }
            catch (Exception err)
            {
                throw new Exception("Ocurrio un problema al editar cliente.", err);
            }
        }
    }
}
