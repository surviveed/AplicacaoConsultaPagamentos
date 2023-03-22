using Aplicacao.classe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    class LerDados
    {
        public List<cliente> LerArquivoClientes(string caminho)
        {
            try
            {
                var lines = File.ReadAllLines(caminho);

                var clientes = new List<cliente>();

                foreach (var line in lines)
                {
                    var linha = line.Split(';');
                    cliente _cliente = new cliente();
                    try
                    {
                        _cliente.codigoCliente = int.Parse(linha[0]);
                        _cliente.cpf = linha[1];
                        _cliente.dataNascimento= linha[2];
                        _cliente.telefone= linha[3];
                        _cliente.nomeCliente= linha[4];

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
                Console.WriteLine(ex.Message+ex.StackTrace);
            }
            return null;
        }

        public List<pagamento>  LerArquivoPagamentos (string caminho)
        {
            try
            {
                var lines = File.ReadAllLines(caminho);

                var pagamentos = new List<pagamento>();

                foreach (var line in lines)
                {
                    var linha = line.Split(';');
                    pagamento _pagamento= new pagamento();
                    try
                    {
                        _pagamento.codigoCliente = int.Parse(linha[0]);
                        _pagamento.data = linha[1];
                        _pagamento.codigoProduto = int.Parse(linha[2]);
                        _pagamento.valor = double.Parse(linha[3]);
                        _pagamento.pago =linha[4].Equals("t")?true:false;

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

    }
}
