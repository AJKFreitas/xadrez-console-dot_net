﻿using System;
using System.Collections.Generic;
using System.Text;
using xadrez;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.tabuleiro.exceptions;

namespace Xadrez_Console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public HashSet<Peca> Pecas { get; set; }
        public HashSet<Peca> Capituradas { get; set; }
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capituradas = new HashSet<Peca>();
            PreecherTabuleiro();
        }
        public Peca MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RemovePeca(origem);
            peca.incrementaQuantidadeMovimento();
            Peca pecaCapturada = Tabuleiro.RemovePeca(destino);
            Tabuleiro.SetPeca(peca, destino);
            if (pecaCapturada != null)
            {
                Capituradas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = MovimentarPeca(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");

            }
            Xeque = EstaEmXeque(Adversaria(JogadorAtual));
            

            Turno++;
            MudaJogador();

        }

        private void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tabuleiro.RemovePeca(destino);
            peca.DecrementaQuantidadeMovimento();
            if (pecaCapturada != null)
            {
                Tabuleiro.SetPeca(pecaCapturada, destino);
                Capituradas.Remove(pecaCapturada);

            }
            Tabuleiro.SetPeca(peca, origem);

        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branco)
            {
                JogadorAtual = Cor.Preto;
            }
            else
            {
                JogadorAtual = Cor.Branco;
            }
        }
        public void ValidarPosicaoDeOrigem(Posicao posicao)
        {
            if (Tabuleiro.GetPeca(posicao) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tabuleiro.GetPeca(posicao).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiro.GetPeca(posicao).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça de origem escolheida!");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Capituradas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Pecas)
            {
                if (peca.Cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.SetPeca(peca, new PosicaoXadrez(coluna, linha).ToPosition());
            Pecas.Add(peca);
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branco)
            {
                return Cor.Preto;
            }
            else
            {
                return Cor.Branco;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca peca in PecasEmJogo(cor))
            {
                if (peca is Rei)
                {
                    return peca;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
            {
                throw new TabuleiroException($"Não tem Rei da cor {cor} no tabuleiro!");
            }
            foreach (Peca peca in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }

            }
            return false;
        }

        private void PreecherTabuleiro()
        {


            ColocarNovaPeca('c', 1, new Torre(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branco, Tabuleiro));


            ColocarNovaPeca('c', 7, new Torre(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preto, Tabuleiro));



        }

    }
}
