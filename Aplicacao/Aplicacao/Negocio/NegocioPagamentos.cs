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
        public List<Cliente> RetornaDevedores (List<Pagamento> pagamentos, List<Cliente> clientes)
        {
            var devedores = new List<Cliente>();

            foreach (var cliente in clientes)
                foreach (var pagamento in pagamentos)
                    if (cliente.codigoCliente == pagamento.codigoCliente && pagamento.pago is false)
                    {
                        devedores.Add(cliente);
                        break;
                    }

            return devedores;
        }
    }
}
