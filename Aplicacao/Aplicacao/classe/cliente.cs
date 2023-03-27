using System;
using System.Text;

namespace Aplicacao.classe
{
    public class Cliente
    {
        public int codigoCliente { get; set; }

        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }

        public string telefone { get; set; }

        public string nomeCliente { get; set; }

        public override string ToString()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append("código: " + codigoCliente + " cpf:" + cpf + " DataNascimento: " + dataNascimento.ToString("dd/MM/yyyy") + " telefone:" + telefone + " nome Cliente: " + nomeCliente);

            return _string.ToString();
        }
    }
}
