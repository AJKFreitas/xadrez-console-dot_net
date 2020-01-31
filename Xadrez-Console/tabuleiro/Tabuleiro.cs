using Xadrez_Console.tabuleiro.exceptions;

namespace Xadrez_Console.tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas;
        public Tabuleiro()
        {
        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        public Peca GetPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }  
        public Peca RemovePeca(Posicao posicao)
        {
            if (GetPeca(posicao) == null)
            {
                return null;
            }
            Peca pecaAux = GetPeca(posicao);
            pecaAux.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return pecaAux;
        }

        public void SetPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }
            Pecas[posicao.Linha, posicao.Coluna] = peca;
            peca.Posicao = posicao;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            else
                return true;
        }
        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }

        public bool ExistePeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return GetPeca(posicao) != null;
        }
    }
}