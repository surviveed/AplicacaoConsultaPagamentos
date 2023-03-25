using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.classe
{
    public class Cliente
    {
        public int CodigoCliente { get; set; }

        public string Cpf { get; set; }

        public Nullable<DateTime> DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string NomeCliente { get; set; }

        public override string ToString()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append("código: " + CodigoCliente + " cpf:" + Cpf +
                " DataNascimento: " + (DataNascimento != null ? DataNascimento.Value.ToString("dd/MM/yyyy") : "") +
                " telefone:" + Telefone + " nome Cliente: " + NomeCliente);

            return _string.ToString();
        }
    }
}
