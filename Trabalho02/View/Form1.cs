using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho02.Control;

namespace Trabalho02
{
    public partial class Form1 : Form
    {
        List<string> palavras = new List<string>();
        List<string> letrasDaTabela = new List<string>();
        int rodada = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GeraTabela();           //Gera a Tabela Assim que iniciar o Programa
        }
        private void GeraTabela()
        {
            letrasDaTabela = Controller01.GeraTabela();
            Letra1.Text = letrasDaTabela[0];
            Letra2.Text = letrasDaTabela[1];
            Letra3.Text = letrasDaTabela[2];
            Letra4.Text = letrasDaTabela[3];
            Letra5.Text = letrasDaTabela[4];
            Letra6.Text = letrasDaTabela[5];
            Letra7.Text = letrasDaTabela[6];
            Letra8.Text = letrasDaTabela[7];
            Letra9.Text = letrasDaTabela[8];
        }
        private void btnBusca_Click(object sender, EventArgs e) // Após pressionar o botão BUSCA
        {
            List<char> letraRepetida = new List<char>();
            string palavra = txtPalavra.Text.ToUpper().Replace(" ", "");         // Obrigatoriamente a palavra inserida pelo jogador é convertida para letras MAIÚSCULAS. Também remove possíveis espaços existentes

            if (string.IsNullOrEmpty(palavra))         //Confere se a palavra inserida pelo jogador é ou não 'vazia'
            {
                MessageBox.Show("Insira Alguma Letra Por Favor");
            }
            else
            {
                bool encontrouPalavraDuplicada = Controller01.ConferePalavraRepetida(palavras, palavra);
                if (encontrouPalavraDuplicada)
                {
                    MessageBox.Show("Palavra Repetida");

                }

                else
                {
                    lBoxPalavras.Items.Add(palavra);
                    //Caso nenhum dos erros anteriores sejam encontrados o código segue normalmente
                    int linha, coluna;              // Variáveis que armazenam os índices onde o Buscador se encontra
                    int posicaoLetra = 0;           // Variavél que acrescenta a cada letra correta até percorrer toda a palavra inserida pelo jogador ou o jogador buscar por uma letra incorreta
                    int totalAcertos = 0;           // Variável que armazena o total de letras corretas que o jogador inseriu
                    bool jogadorAcertou = false;    // Booleano para caso jogador acertou(true) ou errou(false);

                    string[][] matriz = Controller01.PreencheMatriz(letrasDaTabela);

                    char letra = Controller01.ProcurandoLetra(palavra, posicaoLetra);
                    letraRepetida.Add(letra); // Adiciona a primeira letra na lista, para posteriormente conferir

                    jogadorAcertou = Controller01.ConferePrimeiraPosicao(matriz, letra,/**/ out linha, out coluna);

                    totalAcertos = Controller01.Acertos(jogadorAcertou, totalAcertos);
                    while (jogadorAcertou && posicaoLetra + 1 < palavra.Length)
                    {
                        posicaoLetra++;
                        letra = Controller01.ProcurandoLetra(palavra, posicaoLetra);
                        jogadorAcertou = Controller01.Buscador(linha, coluna, letra, matriz, letraRepetida,/**/ out linha, out coluna);
                        totalAcertos = Controller01.Acertos(jogadorAcertou, totalAcertos);
                        letraRepetida.Add(letra); //Adiciona o restante das letras na lista, para posteriormente conferir
                    }
                    int pontuacaoRodada = 0; // Zera a pontuação da Rodada, para atribuir o novo valor;
                    lPontuacao.Text = Convert.ToString(Controller01.Pontuacao(Convert.ToInt32(lPontuacao.Text), totalAcertos,/**/ out pontuacaoRodada));

                    if (totalAcertos != 0)
                    {
                        MessageBox.Show($"Parabéns você acertou ( {totalAcertos} ) letra(s) :)\nE pontuou ( {pontuacaoRodada} ) ponto(s) nessa rodada!");

                    }
                    else
                    {
                        MessageBox.Show("Não foi dessa vez : / \nNão fique triste, tente novamente :)");
                    }

                }

            }
            txtPalavra.Clear();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            GeraTabela();
            palavras.Clear();
            lBoxRodadas.Items.Add($"Rodada : {rodada} Pontuação : {lPontuacao.Text}");
            lBoxRodadas.Items.Add("-------------------//------------------\n");
            lBoxPalavras.Items.Clear();
            lPontuacao.Text = "0"; //Limpa Pontuação ao Clicar em Novo
            rodada++;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("       Obrigado por Jogar o Nosso Jogo :) \n\n                      Desenvolvido por: \n\n-Eduardo Eckert\n-Enzo Sacani\n-Isabelle Schork");
            Application.Exit();   //Encerra o programa
        }

        
    }
}
