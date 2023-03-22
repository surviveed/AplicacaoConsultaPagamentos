using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.classe
{

    public class pagamento
    {
        public int codigoCliente { get; set; }

        public string data { get; set; }

        public int codigoProduto { get; set; }

        public double valor { get; set; }

        public bool pago { get; set; }

        public override string ToString()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append("codigoCliente: " + codigoCliente + " data:" + data + " codigoProduto: " + codigoProduto + " valor:" + valor + " pago: " + pago);

            return _string.ToString();
        }
    }
}
