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
                    try
                    {

                        Console.Clear();
                        Tela.ImprimirPartida(partidaDeXadrez);
                        Tela.ImprimeTabuleiroNaTela(partidaDeXadrez.Tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partidaDeXadrez.Turno);
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosition();
                        partidaDeXadrez.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimeTabuleiroNaTela(partidaDeXadrez.Tabuleiro, posicoesPossiveis);
                        //  ♔♕♖♗♘♙♚♛♜♝♞♟♞
                        Console.WriteLine("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosition();
                        partidaDeXadrez.ValidarPosicaoDeDestino(origem, destino);
                        partidaDeXadrez.MovimentarPeca(origem, destino);

                    }
                    catch (TabuleiroException e)
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();

                    }
                }
            }
            catch (TabuleiroException te)
            {

                Console.WriteLine(te.Message); ;
            }

        }
    }
}
