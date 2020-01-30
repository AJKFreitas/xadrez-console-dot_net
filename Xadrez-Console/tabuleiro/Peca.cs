using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.tabuleiro
{
public  class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QuantidadeMovimento { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca()
        {
        }

        public Peca(Posicao posicao, Cor cor,  Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;
            QuantidadeMovimento = 0;
            Tabuleiro = tabuleiro;
        }
    }
}
