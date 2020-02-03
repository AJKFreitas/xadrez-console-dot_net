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
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            //acima
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha = posicao.Linha - 1;
            }

            //abaixo
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Linha = posicao.Linha + 1;
            }

            //direita
            posicao.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna + 1;
            }


            //esquerda
            posicao.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.Coluna = posicao.Coluna - 1;
            }



            return mat;
        }

        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
    }
}
