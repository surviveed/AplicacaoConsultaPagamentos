using Aplicacao.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Controller
{
    public class Controller
    {
        public static void View()
        {
            LerDados Ler = new LerDados();
            var negocioPagamentos = new NegocioPagamentos();
            var negocioCliente = new NegocioCliente();


            var listaClientes = Ler.LerArquivoClientes(@"C:\Users\franc\source\repos\AplicacaoConsultaPagamentos\Aplicacao\Aplicacao\1428624292050_clientes.txt");
            var listaPagamentos = Ler.LerArquivoPagamentos(@"C:\Users\franc\source\repos\AplicacaoConsultaPagamentos\Aplicacao\Aplicacao\1428624292736_pagamentos.txt");

            Console.WriteLine("Digite o numero para escolher uma das opçoes abaixo\n" +
                                        "(1) Lista de clientes devedores\n" +
                                        "(2) Valor recebido ordenado por data\n" +
                                        "(3) Valor devido ordenado por data\n" +
                                        "(4) Valor pago por cliente");

            var opcao = Console.ReadLine();

            switch (int.Parse(opcao))
            {
                case 1:
                    foreach (var devedor in negocioCliente.RetornaDevedores(listaPagamentos, listaClientes))
                        Console.WriteLine(devedor);
                    break;
                case 2:
                    foreach (var pagamento in negocioPagamentos.ValorRecebidoPorData(listaPagamentos))
                        Console.WriteLine(pagamento);
                    break;
                case 3:
                    foreach (var pagamento in negocioPagamentos.ValorDevidoPorData(listaPagamentos))
                        Console.WriteLine(pagamento);
                    break;
                case 4:
                    foreach (var pagamento in negocioCliente.PagoPorCliente(listaPagamentos, listaClientes))
                    {
                        Console.Write(pagamento.Key);
                        Console.WriteLine(" Valor pago é " + pagamento.Value + " Reais");
                    }
                    break;
            }
            
        }
    }
}
