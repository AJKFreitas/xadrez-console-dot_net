using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "B ";
        }
        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            //NO
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna -1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
            } 
            //NE
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna +1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
            }
            //SE
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna +1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
            }
            //SE
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna -1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
            }
            return mat;
        }
    }
}
