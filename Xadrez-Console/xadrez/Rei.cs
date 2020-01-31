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
          //  Posicao posicao = new Posicao(0, 0);

            //acima
            Posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }

            //ne
            Posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }
            //direita
            Posicao.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }
            //se
            Posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }
            //abaixo
            Posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }
            //so
            Posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna -1);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }
            //esquerda
            Posicao.definirValores(Posicao.Linha, Posicao.Coluna -1);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }
            //no
            Posicao.definirValores(Posicao.Linha -1, Posicao.Coluna -1);
            if(Tabuleiro.PosicaoValida(Posicao) && PodeMover(Posicao))
            {
                mat[Posicao.Linha, Posicao.Coluna] = true;
            }

            return mat;
        }

      

        public override string ToString()
        {
                     
            return "R ";
        }
    }
}
