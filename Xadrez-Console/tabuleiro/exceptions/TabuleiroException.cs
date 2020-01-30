using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez_Console.tabuleiro.exceptions
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg):base(msg)
        {
        }
    }
}
