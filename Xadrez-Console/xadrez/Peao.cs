using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;
        public Peao(Cor cor, Tabuleiro tabuleiro, PartidaDeXadrez  partida) : base(cor, tabuleiro)
        {
            this.Partida = partida;
        }
        public override string ToString()
        {
            return "P ";
        }
        protected bool PodeMover(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null || peca.Cor != Cor;
        }
        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            return Tabuleiro.GetPeca(posicao) == null;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao posicao = new Posicao(Posicao.Linha, Posicao.Coluna);

            if (Cor == Cor.Branco)
            {
                posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QuantidadeMovimento == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.definirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                //#jogadaespecial empassant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda)
                        && Tabuleiro.GetPeca(esquerda) == Partida.VulneravelEnpassant)
                    {
                        mat[esquerda.Linha -1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita)
                        && Tabuleiro.GetPeca(direita) == Partida.VulneravelEnpassant)
                    {
                        mat[direita.Linha -1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(posicao) && Livre(posicao) && QuantidadeMovimento == 0)
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }

                posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                posicao.definirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicao) && ExisteInimigo(posicao))
                {
                    mat[posicao.Linha, posicao.Coluna] = true;
                }
                //#jogadaespecial empassant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) 
                        && Tabuleiro.GetPeca(esquerda) == Partida.VulneravelEnpassant)
                    {
                        mat[esquerda.Linha +1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) 
                        && Tabuleiro.GetPeca(direita) == Partida.VulneravelEnpassant)
                    {
                        mat[direita.Linha +1, direita.Coluna] = true;
                    }
                }
            }


            return mat;
        }

    }
}
