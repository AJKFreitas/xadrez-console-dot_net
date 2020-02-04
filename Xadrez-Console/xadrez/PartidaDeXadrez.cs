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
        public bool Xeque { get; private set; }
        public Peca VulneravelEnpassant { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            Terminada = false;
            VulneravelEnpassant = null;
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
            //#jogadaespecial roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna +2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torre = Tabuleiro.RemovePeca(origemT);
                torre.incrementaQuantidadeMovimento();
                Tabuleiro.SetPeca(torre, destinoT);
            }
            //#jogadaespecial roque grande
            if (peca is Rei && destino.Coluna == origem.Coluna -2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna -4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna -1 );
                Peca torre = Tabuleiro.RemovePeca(origemT);
                torre.incrementaQuantidadeMovimento();
                Tabuleiro.SetPeca(torre, destinoT);
            }
            //#jogadaespecial empassant
            if (peca is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada == null)
                {
                    Posicao posicaoPeao;
                    if (peca.Cor == Cor.Branco)
                    {
                        posicaoPeao = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    else
                    {
                        posicaoPeao = new Posicao(destino.Linha - 1, destino.Coluna);
                    }
                    pecaCapturada = Tabuleiro.RemovePeca(posicaoPeao);
                    Capituradas.Add(pecaCapturada);
                }
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
            Peca pecaMovida = Tabuleiro.GetPeca(destino);
            //#jogadaespecial promocao
            if (pecaMovida is Peao)
            {
                if (pecaMovida.Cor == Cor.Branco && destino.Linha ==0 || (pecaMovida.Cor == Cor.Preto && destino.Linha ==7))
                {
                    pecaMovida = Tabuleiro.RemovePeca(destino);
                    Pecas.Remove(pecaMovida);
                    Peca dama = new Dama(pecaMovida.Cor,Tabuleiro);
                    Tabuleiro.SetPeca(dama, destino);
                    Pecas.Add(dama);
                }
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            //Xeque = EstaEmXeque(Adversaria(JogadorAtual));
            if (TexteXequemate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno ++;
                MudaJogador();
            }
            if (pecaMovida is Peao &&(destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2))
            {
                VulneravelEnpassant = pecaMovida;
            }
            else
            {
                VulneravelEnpassant = null;
            }

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
            //#jogadaespecial roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torre = Tabuleiro.RemovePeca(destinoT);
                torre.DecrementaQuantidadeMovimento();
                Tabuleiro.SetPeca(torre, origemT);
            }
            //#jogadaespecial roque grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca torre = Tabuleiro.RemovePeca(destinoT);
                torre.DecrementaQuantidadeMovimento();
                Tabuleiro.SetPeca(torre, origemT);
            }
            //#jogadaespecial empassant
            if (peca is Peao)
            {
                if (origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnpassant)
                {
                    Peca peao = Tabuleiro.RemovePeca(destino);
                    Posicao posicaoP;
                    if (peca.Cor == Cor.Branco)
                    {
                        posicaoP = new Posicao(3, destino.Coluna);
                    }
                    else
                    {
                        posicaoP = new Posicao(4, destino.Coluna);
                    }
                    Tabuleiro.SetPeca(peao, posicaoP);
                }
            }
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
            if (!Tabuleiro.GetPeca(origem).MovimentoPossivel(destino))
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

        public bool TexteXequemate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca peca in PecasEmJogo(cor))
            {
                bool[,] mat = peca.MovimentosPossiveis();
                for (int linha = 0; linha < Tabuleiro.Linhas; linha++)
                {
                    for (int coluna = 0; coluna < Tabuleiro.Colunas; coluna++)
                    {
                        if (mat[linha, coluna])
                        {
                            Posicao origem = peca.Posicao;
                            Posicao destino = new Posicao(linha, coluna);
                            Peca pecaCapturada = MovimentarPeca(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void PreecherTabuleiro()
        {


            ColocarNovaPeca('a', 1, new Torre(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('d', 1, new Dama(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branco, Tabuleiro, this));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branco, Tabuleiro));
            ColocarNovaPeca('a', 2, new Peao(Cor.Branco, Tabuleiro,this));
            ColocarNovaPeca('b', 2, new Peao(Cor.Branco, Tabuleiro,this));
            ColocarNovaPeca('c', 2, new Peao(Cor.Branco, Tabuleiro,this));
            ColocarNovaPeca('d', 2, new Peao(Cor.Branco, Tabuleiro,this));
            ColocarNovaPeca('e', 2, new Peao(Cor.Branco, Tabuleiro,this));
            ColocarNovaPeca('f', 2, new Peao(Cor.Branco, Tabuleiro,this));
            ColocarNovaPeca('g', 2, new Peao(Cor.Branco, Tabuleiro,this));
            ColocarNovaPeca('h', 2, new Peao(Cor.Branco, Tabuleiro,this));

            ColocarNovaPeca('a', 8, new Torre(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('d', 8, new Dama(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preto, Tabuleiro));
            ColocarNovaPeca('a', 7, new Peao(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('b', 7, new Peao(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('c', 7, new Peao(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('d', 7, new Peao(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('e', 7, new Peao(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('f', 7, new Peao(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('g', 7, new Peao(Cor.Preto, Tabuleiro,this));
            ColocarNovaPeca('h', 7, new Peao(Cor.Preto, Tabuleiro,this));





        }

    }
}
