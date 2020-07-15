using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Entidades
{
    public class Pedido
    {
        private int idPedido;
        public int IdPedido
        {
            get { return idPedido; }
            set { idPedido = value; }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int numero;
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private bool estado;
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private Cliente cliente;
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private Categoria categoria;
        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private List<LineaDePedido> listaLineasDePedido;
        public List<LineaDePedido> ListaLineasDePedido
        {
            get { return listaLineasDePedido; }
            set { listaLineasDePedido = value; }
        }
        public Pedido()
        {
            fecha = DateTime.Now;
            listaLineasDePedido = new List<LineaDePedido>();
        }
        public Boolean AgregarLineaDePedido(LineaDePedido lineaDePedido) //prod+cantidad
        {
            if (lineaDePedido.EsCantidadValida())
            {
                //lineaDePedido.EsCtualizarEstado();
                listaLineasDePedido.Add(lineaDePedido);
                return true;
            }
            return false;
        }

        public double CalcularTotal()
        {
            double totalGeneral = 0;
            foreach (LineaDePedido lineaDePedido in listaLineasDePedido)
            {
                totalGeneral += lineaDePedido.CalcularSubTotal();
            }
            return totalGeneral;
        }

        public double CalcularDescuento()
        {
            double descuento = 0;
            if (CalcularTotal() > 100)
            {
                descuento = CalcularTotal() * 0.1;
            }
            return descuento;
        }
        public double CalcularIgv()
        {
            return CalcularTotal() * 0.18;
        }
        public double CalcularPago()
        {
            return CalcularTotal() - CalcularDescuento();
        }

        public Boolean EsMontoPagoValido(double montoPagado)
        {
            if (montoPagado >= CalcularPago())
            {
                return true;
            }
            return false;
        }
        public double CalcularVuelto(double montoPagado)
        {
            double vuelto = 0;
            if (montoPagado > CalcularPago())
                vuelto = montoPagado - CalcularPago();
            return vuelto;
        }

        public Boolean TieneLineasDePedido()
        {
            return listaLineasDePedido.Count > 0;
        }
    }
}
