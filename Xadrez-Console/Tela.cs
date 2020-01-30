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
                for (int coluna = 0; coluna < tabuleiro.Colunas; coluna++)
                {
                    if (tabuleiro.Pecas[linha,coluna] ==null)
                    {
                        Console.Write("- ");
                    }
                    Console.Write($"{tabuleiro.GetPeca(linha,coluna)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
