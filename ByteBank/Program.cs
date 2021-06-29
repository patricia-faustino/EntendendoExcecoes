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
            try
            {
                Metodo();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Não é possível dividir por zero!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }



            Console.ReadLine();
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
