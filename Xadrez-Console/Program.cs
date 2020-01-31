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
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
                Console.WriteLine("          (--Xadrez--)");
                while (!partidaDeXadrez.Terminada)
                {
             
                    Console.Clear();
                    Tela.ImprimeTabuleiroNaTela(partidaDeXadrez.Tabuleiro);
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosition();

                    bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimeTabuleiroNaTela(partidaDeXadrez.Tabuleiro, posicoesPossiveis);
                  //  ♔♕♖♗♘♙♚♛♜♝♞♟♞
                    Console.WriteLine("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosition();

                    partidaDeXadrez.MovimentarPeca(origem, destino);

                }
            }
            catch (TabuleiroException te)
            {

                Console.WriteLine(te.Message); ;
            }

        }
    }
}
