using Aplicacao.classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Negocio
{
    public class NegocioPagamentos
    {
        public List<Cliente> RetornaDevedores(List<Pagamento> pagamentos, List<Cliente> clientes)
        {
            var devedores = new List<Cliente>();

            foreach (var cliente in clientes)
                foreach (var pagamento in pagamentos)
                    if (cliente.CodigoCliente == pagamento.CodigoCliente && pagamento.Pago is false)
                    {
                        devedores.Add(cliente);
                        break;
                    }

            return devedores;
        }

        public Dictionary<String, List<Pagamento>> ValoresPorData(List<Pagamento> pagamentos)
        {
            Dictionary<string, List<Pagamento>> dict = new Dictionary<string, List<Pagamento>>();

            List<Pagamento> recebido = new List<Pagamento>();
            List<Pagamento> devido = new List<Pagamento>();

            foreach (var pagamento in pagamentos)
            {
                if (pagamento.Pago is true)
                {
                    recebido.Add(pagamento);
                }
                else
                {
                    devido.Add(pagamento);
                }
            }

            List<Pagamento> recebidoOrdenados = recebido.OrderBy(x => x.Data).ToList();
            List<Pagamento> devidoOrdenados = devido.OrderBy(x => x.Data).ToList();

            dict.Add("Devido", devidoOrdenados);
            dict.Add("Recebido", recebidoOrdenados);

            return dict;
        }

        public Dictionary<int, double> ValorPagoPorCliente(List<Pagamento> pagamentos, List<Cliente> clientes)
        {
            Dictionary<int, double> valorPagoPorCliente = new Dictionary<int, double>();
            int codCliente;
            double valor;

            foreach (var cliente in clientes)
            {
                codCliente = cliente.CodigoCliente;
                valor = 0;
                foreach (var pagamento in pagamentos)
                {
                    if (cliente.CodigoCliente == pagamento.CodigoCliente && pagamento.Pago is true)
                    {
                        valor += pagamento.Valor;
                    }
                }
                valorPagoPorCliente.Add(codCliente, valor);
            }

            return valorPagoPorCliente;
        }

        public double ValorTotalDevido(List<Pagamento> pagamentos)
        {
            double total = 0;

            foreach (var pag in pagamentos)
            {
                if (pag.Pago is false)
                {
                    total += pag.Valor;
                }
            }

            return total;
        }

        public double ValorTotalRecebido(List<Pagamento> pagamentos)
        {
            double total = 0;

            foreach (var pag in pagamentos)
            {
                if (pag.Pago is true)
                {
                    total += pag.Valor;
                }
            }

            return total;
        }
    }
}
