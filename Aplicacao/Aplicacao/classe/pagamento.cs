using System;
using System.Text;

namespace Aplicacao.classe
{

    public class Pagamento
    {
        public int codigoCliente { get; set; }

        public DateTime data { get; set; }

        public int codigoProduto { get; set; }

        public double valor { get; set; }

        public bool pago { get; set; }

        public override string ToString()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append("codigoCliente: " + codigoCliente + " data:" + data.ToString("dd/MM/yyyy") + " codigoProduto: " + codigoProduto + " valor:" + valor + " pago: " + pago);

            return _string.ToString();
        }
    }
}
