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
        public List<Pagamento> ValorRecebidoPorData(List<Pagamento> pagamentos) => pagamentos.Where(x => x.pago.Equals(true)).OrderBy(x => x.data).ToList();

        public List<Pagamento> ValorDevidoPorData(List<Pagamento> pagamentos) => pagamentos.Where(x => x.pago.Equals(false)).OrderBy(x => x.data).ToList();
    }
}
