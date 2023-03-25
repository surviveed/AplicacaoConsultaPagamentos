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
                        _cliente.CodigoCliente = int.Parse(linha[0]);
                        _cliente.Cpf = linha[1];
                        _cliente.DataNascimento = ConverteStringParaData(linha[2]);
                        _cliente.Telefone = linha[3];
                        _cliente.NomeCliente = linha[4];

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
                        _pagamento.CodigoCliente = int.Parse(linha[0]);
                        _pagamento.Data = ConverteStringParaData(linha[1]);
                        _pagamento.CodigoProduto = int.Parse(linha[2]);
                        _pagamento.Valor = double.Parse(linha[3]);
                        _pagamento.Pago = linha[4].Equals("t") ? true : false;

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

        public Nullable<DateTime> ConverteStringParaData(string data)
        {
            if (data.Length != 0)
            {
                string dataFormatada;
                if (data.Length < 8)
                {
                    dataFormatada = "0" + data.Substring(0, 1) + "/" + data.Substring(1, 2) + "/" + data.Substring(3);
                }
                else
                {
                    dataFormatada = data.Substring(0, 2) + "/" + data.Substring(2, 2) + "/" + data.Substring(4);

                }
                return DateTime.ParseExact(dataFormatada, "dd/MM/yyyy", null);
            }
            else
            {
                return null;
            }
        }

    }
}
