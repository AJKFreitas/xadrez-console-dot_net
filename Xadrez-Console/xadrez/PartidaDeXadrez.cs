using System;
using System.Collections.Generic;
using System.Text;
using xadrez;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            PreecherTabuleiro();
        }

        private void PreecherTabuleiro()
        {
            Tabuleiro.SetPeca(new Torre(Cor.Branco, Tabuleiro), new PosicaoXadrez('c', 1).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Branco, Tabuleiro), new PosicaoXadrez('c', 2).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Branco, Tabuleiro), new PosicaoXadrez('d', 2).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Branco, Tabuleiro), new PosicaoXadrez('e', 2).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Branco, Tabuleiro), new PosicaoXadrez('e', 1).ToPosition());
            Tabuleiro.SetPeca(new Rei(Cor.Branco, Tabuleiro), new PosicaoXadrez('d', 1).ToPosition());


            Tabuleiro.SetPeca(new Torre(Cor.Preto, Tabuleiro), new PosicaoXadrez('c', 7).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Preto, Tabuleiro), new PosicaoXadrez('c', 8).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Preto, Tabuleiro), new PosicaoXadrez('d', 7).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Preto, Tabuleiro), new PosicaoXadrez('e', 7).ToPosition());
            Tabuleiro.SetPeca(new Torre(Cor.Preto, Tabuleiro), new PosicaoXadrez('e', 8).ToPosition());
            Tabuleiro.SetPeca(new Rei(Cor.Preto, Tabuleiro), new PosicaoXadrez('d', 8).ToPosition());



        }

        public void MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RemovePeca(origem);
            peca.incrementaQuantidadeMovimento();
            Peca pecaCapturada = Tabuleiro.RemovePeca(destino);
            Tabuleiro.SetPeca(peca, destino);
        }
    }
}
