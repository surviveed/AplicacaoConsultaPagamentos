using Aplicacao.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.classe;
using System.Globalization;

namespace Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            LerDados ler = new LerDados();
            var negocioPagamentos = new NegocioPagamentos();

            var listaClientes = ler.LerArquivoClientes("X:\\Documentos\\Faculdade\\5º Semestre\\Laboratório de software\\AplicacaoConsultaPagamentos\\Aplicacao\\Aplicacao\\1428624292050_clientes.txt");
            var listaPagamentos = ler.LerArquivoPagamentos("X:\\Documentos\\Faculdade\\5º Semestre\\Laboratório de software\\AplicacaoConsultaPagamentos\\Aplicacao\\Aplicacao\\1428624292736_pagamentos.txt");



            while (true)
            {
                Console.WriteLine("---------------Menu---------------");
                Console.WriteLine("1 - Lista de clientes devedores");
                Console.WriteLine("2 - Valores ordenados por data");
                Console.WriteLine("3 - Valor pago por cliente");
                Console.WriteLine("4 - Valor total recebido");
                Console.WriteLine("5 - Valor total devido");
                Console.WriteLine("0 - Sair");

                int escolha = int.Parse(Console.ReadLine());

                if (escolha == 0)
                {
                    Console.WriteLine("SAINDO...");
                    break;
                }

                switch (escolha)
                {
                    case 1:
                        var devedores = negocioPagamentos.RetornaDevedores(listaPagamentos, listaClientes);
                        foreach (var devedor in devedores)
                        {
                            Console.WriteLine(devedor.ToString());
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Selecione a opção:");
                            Console.WriteLine("1 - Valores devidos");
                            Console.WriteLine("2 - Valores recebidos");
                            Console.WriteLine("3 - Voltar");

                            int op = int.Parse(Console.ReadLine());

                            if (op == 3)
                            {
                                break;
                            }

                            var dictValData = negocioPagamentos.ValoresPorData(listaPagamentos);

                            switch (op)
                            {
                                case 1:
                                    var devido = dictValData["Devido"];
                                    foreach (var item in devido)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    break;
                                case 2:
                                    var recebido = dictValData["Recebido"];
                                    foreach (var item in recebido)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    break;
                            }
                        }
                        break;
                    case 3:
                        var dict = negocioPagamentos.ValorPagoPorCliente(listaPagamentos, listaClientes);
                        foreach (KeyValuePair<int, double> item in dict)
                        {
                            Console.WriteLine("Cliente" + item.Key + " = " + item.Value.ToString("F2", CultureInfo.InvariantCulture));

                        }
                        break;
                    case 4:
                        double valor = negocioPagamentos.ValorTotalRecebido(listaPagamentos);
                        Console.WriteLine("Valor total recebido: " + valor.ToString("F2", CultureInfo.InvariantCulture));
                        break;
                    case 5:
                        double val = negocioPagamentos.ValorTotalDevido(listaPagamentos);
                        Console.WriteLine("Valor total recebido: " + val.ToString("F2", CultureInfo.InvariantCulture));
                        break;
                }
            }
        }
    }
}
