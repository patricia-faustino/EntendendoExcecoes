using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(7480, 874150);

           // Console.WriteLine(ContaCorrente.TaxaOperacao);

            Console.WriteLine("Iniciando aplicação...");
            int numero = 10;
            int divisor = 0;
            int resultado = numero / divisor;
            Console.WriteLine("Fim da aplicação. Tecle enter para sair...");

            Console.ReadLine();
        }
    }
}
