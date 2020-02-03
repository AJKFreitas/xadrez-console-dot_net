using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        public override string ToString()
        {
            return "D ";
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(0, 0);
            
            //esquerda
            posicao.definirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(Posicao.Linha, Posicao.Coluna - 1);
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
                posicao.definirValores(Posicao.Linha, Posicao.Coluna + 1);
            }
            //acima
            posicao.definirValores(Posicao.Linha -1, Posicao.Coluna );
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(Posicao.Linha -1, Posicao.Coluna);
            }
            //abaixo
            posicao.definirValores(Posicao.Linha +1, Posicao.Coluna );
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(Posicao.Linha +1, Posicao.Coluna);
            }
            //NO
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            }
            //NE
            posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            }
            //SE
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            }
            //SE
            posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(posicao) && PodeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
                if (Tabuleiro.GetPeca(posicao) != null && Tabuleiro.GetPeca(posicao).Cor != Cor)
                {
                    break;
                }
                posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            }
            return mat;

        }
    }
}
