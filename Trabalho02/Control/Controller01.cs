using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho02.Model;

namespace Trabalho02.Control
{
    class Controller01
    {
        /// <summary>
        /// Preenche a lista com a letra aleatória
        /// </summary>
        /// <returns></returns>
        public static List<string> GeraTabela()
        {
            List<string> letras = new List<string>();
            return letras = Functions.GeraTabela();
        }
        public static string LetraAleatoria50(string primeiraLetra, string segundaLetra)
        {
            string letra;
            return letra = Functions.LetraAleatoria50 (primeiraLetra,segundaLetra);
        }
        public static string LetraAleatoria33(string primeiraLetra, string segundaLetra, string terceiraLetra)
        {
            string letra;
            return letra = Functions.LetraAleatoria33(primeiraLetra, segundaLetra, terceiraLetra);
        }
        

        /// <summary>
        /// Confere se a palavra inserida pelo jogador, possui ou não outra palavra repetida. Ex: 'ABCD' 'AJDK' 'ABCD' = encontrouPalavraDuplicada(true)
        /// </summary>
        /// <returns></returns>
        /// 
        public static bool ConferePalavraRepetida(List<string> listaPalavrasInseridas, string palavra)
        {
           return Functions.ConferePalavraRepetida(listaPalavrasInseridas, palavra);
        }

        /// <summary>
        /// Preenche a matriz utilizando a lista letrasDaTabela
        /// </summary> 
        /// <returns></returns>
        public static string[][] PreencheMatriz(List<string> letrasDaTabela)
        {
            return Functions.PreencheMatriz(letrasDaTabela);
        }

        /// <summary>
        /// Procura qual a letra o usuário deseja encontrar na Tabela
        /// </summary>
        /// <returns></returns>
        public static char ProcurandoLetra(string palavra,int posicaoLetra)
        {

            return Functions.ProcurandoLetra(palavra, posicaoLetra);
        }

        /// <summary>
        /// Confere se o jogador acertou alguma letra da tabela, e retorna os índices dessa letra
        /// </summary>
        /// <returns></returns>
        public static bool ConferePrimeiraPosicao(string[][] matriz, char letra,/**/ out int linhaAtual, out int colunaAtual)
        {

            linhaAtual = 0; colunaAtual = 0;
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    // esta percorrendo a matriz 
                    if (Convert.ToChar(matriz[i][j]) == letra)
                    {
                        linhaAtual = i;
                        colunaAtual = j;
                        return true;
                        
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Soma quantos acertos o jogador possuí
        /// </summary>
        /// <returns></returns>
        public static int Acertos(bool jogadorAcertou, int totalAcertos)
        {
            if (jogadorAcertou)
            {
                totalAcertos++;
            }
            return totalAcertos;
        }

        /// <summary>
        /// Buscador o 'Cérebro' do Jogo. Confere os índices vizinhos do índice atual e retorna se o jogador acertou ou não
        /// </summary>
        /// <returns></returns>
        public static bool Buscador(int linhaAtual, int colunaAtual, char letra, string[][] matriz,List<char>letraRepetida,/**/ out int linha, out int coluna)
        {
            bool jogadorAcertou = false;
            bool modificou = false;
            bool verificaLetraRepetida = false;
            linha = 0; coluna = 0;
                foreach (var item in letraRepetida)
                {
                    if (item == letra)
                    {
                        verificaLetraRepetida = true;
                        break;
                    }
                }
            while (!verificaLetraRepetida)
            {
                ////////////////////////////////////////////////////////////////////////// 
                int tempLinha = linhaAtual, tempColuna = colunaAtual; //(i,j)

                SubtraiLinha(linhaAtual, colunaAtual,/**/out tempLinha, out tempColuna, out modificou); //(i-1 | j)  Indice Verificado
                jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                if (jogadorAcertou)
                {
                    linha = tempLinha;
                    coluna = tempColuna;
                    break;
                }
                if (modificou)
                {
                    SubtraiColuna(tempLinha, colunaAtual,/**/out tempLinha, out tempColuna); //(i-1 | j-1) Indice Verificado                       
                    jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                    if (jogadorAcertou)
                    {
                        linha = tempLinha; 
                        coluna = tempColuna;
                        break;
                    }

                    SomaColuna(tempLinha, colunaAtual,/**/out tempLinha, out tempColuna); //(i-1 | j+1) Indice Verificado
                    jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                    if (jogadorAcertou)
                    {
                        linha = tempLinha;
                        coluna = tempColuna;
                        break;
                    }
                }

                //***//
                SubtraiColuna(linhaAtual, colunaAtual,/**/out tempLinha, out tempColuna); //(i | j-1) Indice Verificado
                jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                if (jogadorAcertou)
                {
                    linha = tempLinha;
                    coluna = tempColuna;
                    break;
                }
                SomaColuna(tempLinha, colunaAtual,/**/out tempLinha, out tempColuna); //(i | j+1) Indice Verificado
                jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                if (jogadorAcertou)
                {
                    linha = tempLinha;
                    coluna = tempColuna;
                    break;
                }
                //***//

                SomaLinha(linhaAtual, colunaAtual,/**/out tempLinha, out tempColuna, out modificou); //(i+1 | j) Indice Verificado
                jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                if (jogadorAcertou)
                {
                    linha = tempLinha;
                    coluna = tempColuna;
                    break;
                }
                if (modificou)
                {
                    SubtraiColuna(tempLinha, colunaAtual,/**/out tempLinha, out tempColuna); //(i+1 | j-1) Indice Verificado                      
                    jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                    if (jogadorAcertou)
                    {
                        linha = tempLinha;
                        coluna = tempColuna;
                        break;
                    }

                    SomaColuna(tempLinha, colunaAtual,/**/out tempLinha, out tempColuna); //(i+1 | j+1) Indice Verificado
                    jogadorAcertou = ConferePosicao(matriz, tempLinha, tempColuna, letra);
                    if (jogadorAcertou)
                    {
                        linha = tempLinha;
                        coluna = tempColuna;
                        break;
                    }
                }

                break;
            }




            return jogadorAcertou;
        }
        public static void SubtraiLinha(int linha, int coluna,/**/out int tempLinha, out int tempColuna, out bool modificou)
        {
            modificou = false;
            tempLinha = linha;
            tempColuna = coluna;
            if (tempLinha > 0)
            {
                tempLinha--;             //Subtrai Linha se possível
                modificou = true;
            }
        }
        public static void SomaLinha(int linha, int coluna,/**/out int tempLinha, out int tempColuna, out bool modificou)
        {
            modificou = false;
            tempLinha = linha;
            tempColuna = coluna;
            if (tempLinha != 2)
            {
                tempLinha++;             //Soma Linha se possível
                modificou = true;
            }
        }
        public static void SubtraiColuna(int linha, int coluna,/**/out int tempLinha, out int tempColuna)
        {
            tempLinha = linha;
            tempColuna = coluna;
            if (tempColuna != 0)
            {
                tempColuna--;             //Subtrai Coluna se possível
            }
        }
        public static void SomaColuna(int linha, int coluna,/**/out int tempLinha, out int tempColuna)
        {
            tempLinha = linha;
            tempColuna = coluna;
            if (tempColuna != 2)
            {
                tempColuna++;             //Soma Coluna se possível
            }
        }
        public static bool ConferePosicao(string[][] matriz, int tempLinha, int tempColuna, char letra)
        {
            if (Convert.ToChar(matriz[tempLinha][tempColuna]) == letra)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calcula a pontuação do jogador. A cada 2 acertos = 1 Ponto
        /// </summary>
        /// <returns></returns>
        public static int Pontuacao(int pontuacao, int totalAcertos, /**/ out int pontuacaoRodada)
        {
            pontuacaoRodada = 0;
            for (int i = totalAcertos; i >= 2; i = i-2)
            {
                pontuacao++;
                pontuacaoRodada++;
            }
            return pontuacao;
        }




    }
}
