using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch(Exception)
            {
                Console.WriteLine("Catch no método main");
            }

            Console.ReadLine();
        }

        private static void CarregarContas()
        {     
            // se for utilizar o using deve-se implementar o IDisposable
            using(LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt"))
            {
                leitor.LerProximaLinha();
            }

            // ---------------------------------------------------------------------------------------
            //LeitorDeArquivo leitor = null;

            //try
            //{
            // leitor = new LeitorDeArquivo("contas.txt");

            //leitor.LerProximaLinha();
            //leitor.LerProximaLinha();
            //leitor.LerProximaLinha();
            //leitor.LerProximaLinha();
            //leitor.LerProximaLinha();

            //}
            //finally
            //{
            //    //caso não trate o a exceção podemos chamar somente o finally, sendo esse obrigatório
            //    Console.WriteLine("Executando o finally");
            //    //é executado sempre independente de ocorrer exceção
            //    if(leitor != null)
            //        leitor.Fechar();
            //}

        }
        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                //conta1.Transferir(1000, conta2);
                conta1.Sacar(1000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                /* Console.WriteLine("Informações da INNER EXCEPTION (EXCEÇÃO INTERNA): ");
                 Console.WriteLine(e.InnerException.Message);
                 Console.WriteLine(e.InnerException.StackTrace);*/
            }
        }
        public static void Metodo()
        {

            TestaDivisao(0);
            TestaDivisao(2);
        }

        public static void TestaDivisao(int divisor)
        {

            int resultado = Dividir(10, divisor);
            Console.WriteLine($"Resultado da divisão de 10 por {divisor} é {resultado}");


        }
        public static int Dividir(int numero, int divisor)
        {
            try
            {            
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Exceção com número = {numero} e divisor = {divisor}");
                // controle de fluxo
                throw;
            }

        }

    }
}
