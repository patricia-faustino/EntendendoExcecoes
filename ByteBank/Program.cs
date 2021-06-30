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
                ContaCorrente conta = new ContaCorrente(540,54618);
                ContaCorrente conta2 = new ContaCorrente(485, 45678);

                conta2.Transferir(-10, conta);
                conta.Depositar(50);
                Console.WriteLine(conta.Saldo);
                conta.Sacar(-500);  

            }
            catch(ArgumentException ex)
            {
                //deve ser colocado o ex.Message para trazer a mensagem do erro
                Console.WriteLine($"Argumento com problema: {ex.ParamName}");
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
                Console.WriteLine(ex.Message);
            } 

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Não é possível dividir por zero!");
            }

            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
              
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
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
