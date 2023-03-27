using Aplicacao.classe;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    class LerDados
    {
        public List<Cliente> LerArquivoClientes(string caminho)
        {
            try
            {
                var lines = File.ReadAllLines(caminho);

                var clientes = new List<Cliente>();

                foreach (var line in lines)
                {
                    var linha = line.Split(';');
                    Cliente _cliente = new Cliente();
                    try
                    {
                        _cliente.codigoCliente = int.Parse(linha[0]);
                        _cliente.cpf = linha[1];
                        _cliente.dataNascimento = StringToDateTime(linha[2]);
                        _cliente.telefone = linha[3];
                        _cliente.nomeCliente = linha[4];

                        clientes.Add(_cliente);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("erro" + ex.Message);
                    }
                }
                return clientes;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public List<Pagamento> LerArquivoPagamentos(string caminho)
        {
            try
            {
                var lines = File.ReadAllLines(caminho);

                var pagamentos = new List<Pagamento>();

                foreach (var line in lines)
                {
                    var linha = line.Split(';');
                    Pagamento _pagamento = new Pagamento();
                    try
                    {
                        _pagamento.codigoCliente = int.Parse(linha[0]);
                        _pagamento.data = StringToDateTime(linha[1]);
                        _pagamento.codigoProduto = int.Parse(linha[2]);
                        _pagamento.valor = double.Parse(linha[3]);
                        _pagamento.pago = linha[4].Equals("t") ? true : false;

                        pagamentos.Add(_pagamento);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("erro" + ex.Message);
                    }
                }
                return pagamentos;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            return null;
        }

        public DateTime StringToDateTime(string date)
        {
            if (date.Count() < 7)
                return DateTime.MinValue;

            if (date.Count().Equals(7)) 
                date = date.Insert(0, "0");

            return DateTime.ParseExact(s: date ,format: "ddMMyyyy", new CultureInfo("pt-BR"));
        }

    }
}
