using Aplicacao.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Controller;
using System.ComponentModel.Design;

namespace Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            LerDados Ler = new LerDados();
            var negocioPagamentos = new NegocioPagamentos();
            var negocioCliente = new NegocioCliente();

            string retornoUsuario = "1";

            while (retornoUsuario.Equals("1"))
            {
                Controller.Controller.View();
                Console.WriteLine("Digite 1 para voltar ao menu e 2 para fechar o programa");
                retornoUsuario = Console.ReadLine();
            }
            Console.WriteLine("Programa encerrado, aperte uma tecla para fechar!\n");

            Console.ReadKey();
        }
    }
}
