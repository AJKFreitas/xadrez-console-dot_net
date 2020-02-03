using System;
using System.Collections.Generic;
using System.Text;
using xadrez;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.xadrez;

namespace Xadrez_Console
{
    class Tela
    {
        public static void ImprimeTabuleiroNaTela(Tabuleiro tabuleiro)
        {
            for (int linha = 0; linha < tabuleiro.Linhas; linha++)
            {
                Console.Write($"{8 - linha} ");
                for (int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
                {
                    ImprimirPeca(tabuleiro.GetPeca(linha, coluna));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A  B  C  D  E  F  G  H");
        }

        internal static void ImprimirPartida(PartidaDeXadrez partidaDeXadrez)
        {
            ImprimeTabuleiroNaTela(partidaDeXadrez.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapituradas(partidaDeXadrez);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partidaDeXadrez.Turno}");
            Console.WriteLine($"Aguardando jogada: {partidaDeXadrez.JogadorAtual}");
        }

        private static void ImprimirPecasCapituradas(PartidaDeXadrez partidaDeXadrez)
        {
            Console.WriteLine("Peças Capituradas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partidaDeXadrez.PecasCapturadas(Cor.Branco));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ImprimirConjunto(partidaDeXadrez.PecasCapturadas(Cor.Preto));
        }

        private static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca + " ");
            }
            Console.Write("]");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string posicao = Console.ReadLine();
            char coluna = posicao[0];
            int linha = int.Parse(posicao[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        internal static void ImprimeTabuleiroNaTela(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoMarcado = ConsoleColor.DarkBlue;

            for (int linha = 0; linha < tabuleiro.Linhas; linha++)
            {
                Console.Write($"{8 - linha} ");
                for (int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
                {
                    if (posicoesPossiveis[linha, coluna])
                    {
                        Console.BackgroundColor = fundoMarcado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tabuleiro.GetPeca(linha, coluna));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A  B  C  D  E  F  G  H");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("-  ");
            }
            else
            {
                if (peca.Cor == Cor.Branco)
                {
                    Console.Write($"{peca} ");
                }
                else
                {
                    ConsoleColor corOriginal = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{peca} ");
                    Console.ForegroundColor = corOriginal;
                }
            }
        }
    }
}
