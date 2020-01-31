using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;
using Xceed.Wpf.Toolkit;

namespace Xadrez_Console.xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);

            //acima
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            //ne
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //direita
            posicao.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //se
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //abaixo
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //so
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna -1);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //esquerda
            posicao.definirValores(Posicao.Linha, Posicao.Coluna -1);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            //no
            posicao.definirValores(Posicao.Linha -1, Posicao.Coluna -1);
            if(Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            return mat;
        }

      

        public override string ToString()
        {
                     
            return "R ";
        }
    }
}
