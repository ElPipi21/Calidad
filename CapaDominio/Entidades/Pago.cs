using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
    public class Pago
    {
        private int idPago;
        public int IdPago
        {
            get { return idPago; }
            set { idPago = value; }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int tipo;
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
