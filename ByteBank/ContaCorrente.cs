// using _05_ByteBank;

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
            Agencia = agencia;
            Numero = numero;

            TaxaOperacao = 30 / TotalDeContasCriadas;

            TotalDeContasCriadas++;
        }


        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            return true;
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
