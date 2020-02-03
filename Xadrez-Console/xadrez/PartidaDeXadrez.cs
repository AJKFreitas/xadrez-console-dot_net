using System;
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
        public void MovimentarPeca(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RemovePeca(origem);
            peca.incrementaQuantidadeMovimento();
            Peca pecaCapturada = Tabuleiro.RemovePeca(destino);
            Tabuleiro.SetPeca(peca, destino);
            if (pecaCapturada != null)
            {
                Capituradas.Add(pecaCapturada);
            }
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            MovimentarPeca(origem, destino);
            Turno++;
            MudaJogador();

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
