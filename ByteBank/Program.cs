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

            int resultado = Metodo();

            if(resultado == -2)
            {
                Console.WriteLine("Ocorreu um erro!");
            }

            Console.ReadLine();
        }

        public static int Metodo()
        {

            int resultadoDivisao1 = TestaDivisao(2);
            int resultadoDivisao2 = TestaDivisao(0);
            if (resultadoDivisao1 == -2)
            {
                return -2;
            }
            if (resultadoDivisao2 == -2)
            {
                return -2;
            }
            return 0;

        }

        public static int TestaDivisao(int divisor)
        {

            int resultado = Dividir(10, divisor);

            if(resultado == -2)
            {
                return -2;
            }
            if(resultado == -1)
            {
                Console.WriteLine("Não é possível fazer divisão por 0");
            }
            else
            {
                Console.WriteLine($"Resultado da divisão de 10 por {divisor} é {resultado}");
            }

            return 0;
            
        }
        public static int  Dividir(int numero, int divisor)
        {
            if(divisor == 0)
            {
                return -1;
            }

            if(divisor > numero)
            {
                return -2;
            }
            return numero / divisor;
        }

    }
}
