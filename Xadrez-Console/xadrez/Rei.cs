using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;
using Xceed.Wpf.Toolkit;

namespace Xadrez_Console.xadrez
{
    class Rei : Peca
    {
        public PartidaDeXadrez PartidaDeXadrez { get; private set; }
        public Rei(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez partidaDeXadrez) : base(cor, tabuleiro)
        {
            this.PartidaDeXadrez = partidaDeXadrez;
        }
        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca != null && peca is Torre && peca.Cor == Cor && QuantidadeMovimento == 0;

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

            //#jogadaespecial roque
            if (QuantidadeMovimento ==0 && !PartidaDeXadrez.Xeque)
            {
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna +3);
                if (TesteTorreParaRoque(posicaoTorre1))
                {
                    Posicao posicao1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao posicao2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.GetPeca(posicao1) == null && Tabuleiro.GetPeca(posicao2) ==null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
            }
            //#jogadaespecial roque grande
            if (QuantidadeMovimento ==0 && !PartidaDeXadrez.Xeque)
            {
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna -4);
                if (TesteTorreParaRoque(posicaoTorre2))
                {
                    Posicao posicao1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao posicao2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao posicao3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.GetPeca(posicao1) == null && Tabuleiro.GetPeca(posicao2) == null && Tabuleiro.GetPeca(posicao3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }

      

        public override string ToString()
        {
                     
            return "R ";
        }
    }
}
