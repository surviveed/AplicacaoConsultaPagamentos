using Aplicacao.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            LerDados Ler = new LerDados();
            var negocioPagamentos = new NegocioPagamentos();

            var listaClientes = Ler.LerArquivoClientes("C:\\Users\\jbortolini1\\source\\repos\\Aplicacao\\Aplicacao\\bin\\Debug\\1428624292050_clientes.txt");
            var listaPagamentos = Ler.LerArquivoPagamentos("C:\\Users\\jbortolini1\\source\\repos\\Aplicacao\\Aplicacao\\bin\\Debug\\1428624292736_pagamentos.txt");

            var desvedores = negocioPagamentos.RetornaDevedores(listaPagamentos, listaClientes);

            foreach (var devedor in desvedores)
            {
                Console.WriteLine(devedor.ToString());
            }
            Console.ReadLine();
        }
    }
}
