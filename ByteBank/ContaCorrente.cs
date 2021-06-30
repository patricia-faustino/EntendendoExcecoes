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
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException($"Saldo insuficiente para o saque no valor de R${valor}");
            }

            _saldo -= valor;
   
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}
