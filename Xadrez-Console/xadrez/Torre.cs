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
            Posicao posicaoM = new Posicao(Posicao.Linha, Posicao.Coluna);

            //acima
            posicaoM.definirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicaoM) && PodeMover(posicaoM))
            {
                mat[posicaoM.Linha, posicaoM.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoM) != null && Tabuleiro.GetPeca(posicaoM).Cor != Cor)
                {
                    break;
                }
                posicaoM.Linha = posicaoM.Linha - 1;
            }

            //abaixo
            posicaoM.definirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(posicaoM) && PodeMover(posicaoM))
            {
                mat[posicaoM.Linha, posicaoM.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoM) != null && Tabuleiro.GetPeca(posicaoM).Cor != Cor)
                {
                    break;
                }
                posicaoM.Linha = posicaoM.Linha + 1;
            }

            //direita
            posicaoM.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicaoM) && PodeMover(posicaoM))
            {
                mat[posicaoM.Linha, posicaoM.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoM) != null && Tabuleiro.GetPeca(posicaoM).Cor != Cor)
                {
                    break;
                }
                posicaoM.Coluna = posicaoM.Coluna + 1;
            }


            //esquerda
            posicaoM.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicaoM) && PodeMover(posicaoM))
            {
                mat[posicaoM.Linha, posicaoM.Coluna] = true;
                if (Tabuleiro.GetPeca(posicaoM) != null && Tabuleiro.GetPeca(posicaoM).Cor != Cor)
                {
                    break;
                }
                posicaoM.Coluna = posicaoM.Coluna - 1;
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
