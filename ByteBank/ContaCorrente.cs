// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; set; }
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }

        public int Agencia { get; }

        public int ContadorDeSaquesNaoPermitidos { get; private set; }

        public int ContadorDeTransferenciasNaoPermitidos { get; private set; }

        //readonly: somente leitura, não pode ser atribuido fora do construtor
        //private readonly int _numero;
        // por baixo dos panos ele seta o _numero a Numero
        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            if(agencia <= 0)
            {
                //nameof() : devolve como string o argumento -- obriga assim a mudar o nome da variavel caso ela seja modificada
                throw new ArgumentException("O argumento agencia deve ser maiores que zero", nameof(agencia));
               
            }
            if (numero <= 0)
            {
               throw new ArgumentException("O argumento numero deve ser maiores que zero", nameof(numero));
                
            }
            Agencia = agencia;
            Numero = numero;



            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if( valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorDeSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
   
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));
            }

            if (_saldo < valor)
            {

            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException)
            {
                ContadorDeTransferenciasNaoPermitidos++;

                //mantém o caminho do StackTrace correto
                throw;
            }

            contaDestino.Depositar(valor);

        }
    }
}
