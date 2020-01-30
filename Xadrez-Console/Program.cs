using System;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.tabuleiro.exceptions;
using Xadrez_Console.xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Tabuleiro tab = new Tabuleiro(8,8);
            tab.SetPeca(new Torre(Cor.Preto, tab), new Posicao(0, 5));
            tab.SetPeca(new Rei(Cor.Preto, tab), new Posicao(0, 5));
            tab.SetPeca(new Rei(Cor.Preto, tab), new Posicao(2, 5));
            tab.SetPeca(new Torre(Cor.Preto, tab), new Posicao(1, 5));
            Console.WriteLine("          (--Xadrez--)");
            Tela.ImprimeTabuleiroNaTela(tab);

            }
            catch (TabuleiroException te)
            {

                Console.WriteLine(te.Message); ;
            }

        }
    }
}
