using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.classe
{

    public class Pagamento
    {
        public int CodigoCliente { get; set; }

        public Nullable<DateTime> Data { get; set; }

        public int CodigoProduto { get; set; }

        public double Valor { get; set; }

        public bool Pago { get; set; }

        public override string ToString()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append("codigoCliente: " + CodigoCliente + " data:" +
            (Data != null ? Data.Value.ToString("dd/MM/yyyy") : "")
                +
                " codigoProduto: " + CodigoProduto + " valor:" +
                Valor.ToString("F2", CultureInfo.InvariantCulture) + " pago: " + Pago);

            return _string.ToString();
        }
    }
}
