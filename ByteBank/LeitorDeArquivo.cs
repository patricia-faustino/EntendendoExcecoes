using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable
    {
        //classe de teste 
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException();

            Console.WriteLine($"Abrindo arquivo {arquivo}");
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha...");
            throw new IOException();
            return "Linha do arquivo";
        }

 

        public void Dispose()
        {
            //responsabilidade de liberar os recursos
            Console.WriteLine("Fechando arquivo.");

        }
    }
}
