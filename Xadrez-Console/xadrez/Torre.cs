using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "T ";
        }
    }
}
