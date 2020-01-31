using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

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
                    if (tabuleiro.Pecas[linha,coluna] == null)
                    {
                        Console.Write("-  ");
                    }
                    else
                    {
                        ImprimirPeca(tabuleiro.GetPeca(linha, coluna));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A  B  C  D  E  F  G  H");
        }

        public static void ImprimirPeca(Peca peca)
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
