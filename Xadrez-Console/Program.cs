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

            //  ♔♕♖♗♘♙♚♛♜♝♞♟♞
            PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();
            try
            {
                while (!partidaDeXadrez.Terminada)
                {
                    try
                    {

                        Console.Clear();
                        Console.WriteLine("          (--Xadrez--)");
                        Tela.ImprimirPartida(partidaDeXadrez);
                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosition();
                        partidaDeXadrez.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partidaDeXadrez.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
                       
                        Console.Clear();
                        Tela.ImprimeTabuleiroNaTela(partidaDeXadrez.Tabuleiro, posicoesPossiveis);
                        
                        Console.WriteLine();
                        Console.WriteLine("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosition();
                        partidaDeXadrez.ValidarPosicaoDeDestino(origem, destino);
                       
                        partidaDeXadrez.RealizaJogada(origem, destino);

                    }
                    catch (TabuleiroException e)
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();

                    }
                }
                    //Console.Clear();
                    //Console.WriteLine("          (--Xadrez--)");
                    //Tela.ImprimirPartida(partidaDeXadrez);
            }
            catch (TabuleiroException te)
            {

                Console.WriteLine(te.Message);
                Console.ReadLine();
            }

        }
    }
}
