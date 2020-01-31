using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace xadrez
{
    public class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }
        public Posicao ToPosition()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }
        public override string ToString()
        {
            return $"{Coluna} {Linha}";
        }
    }
}
