using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho02.Model
{
    class Functions
    {
        public static List<string> GeraTabela()
        {
            List<string> letras = new List<string>();
            letras.Add(LetraAleatoria50("A", "D"));
            letras.Add(LetraAleatoria50("E", "F"));
            letras.Add(LetraAleatoria50("B", "C"));
            letras.Add(LetraAleatoria33("G", "I", "U"));
            letras.Add(LetraAleatoria33("H", "J", "V"));
            letras.Add(LetraAleatoria50("K", "L"));
            letras.Add(LetraAleatoria33("M", "O", "Q"));
            letras.Add(LetraAleatoria33("N", "T", "P"));
            letras.Add(LetraAleatoria33("R", "S", "Z"));
            return letras;
        }
        public static string LetraAleatoria50(string primeiraLetra, string segundaLetra)
        {
            Random ran = new Random();
            string letra;
            int verificar = ran.Next(0, 2);
            if (verificar == 0)
            {
                letra = primeiraLetra;
            }
            else
            {
                letra = segundaLetra;
            }
            return letra;
        }
        public static string LetraAleatoria33(string primeiraLetra, string segundaLetra, string terceiraLetra)
        {
            Random ran = new Random();
            string letra;
            int verificar = ran.Next(0, 3);
            if (verificar == 0)
            {
                letra = primeiraLetra;
            }
            else if (verificar == 1)
            {
                letra = segundaLetra;
            }
            else
            {
                letra = terceiraLetra;
            }
            return letra;
        }

        public static bool ConferePalavraRepetida(List<string> listaPalavrasInseridas, string palavra)
        {
            bool encontrouPalavraDuplicada = false;
            foreach (var item in listaPalavrasInseridas)
            {
                if (palavra == item)
                {
                    encontrouPalavraDuplicada = true;
                    return encontrouPalavraDuplicada;
                }
            }
            if (!encontrouPalavraDuplicada)
            {

                listaPalavrasInseridas.Add(palavra);
            }
            return encontrouPalavraDuplicada;

        }

        public static string[][] PreencheMatriz(List<string> letrasDaTabela)
        {
            int indice = 0;
            string[][] matriz = new string[3][];
            for (int i = 0; i < matriz.Length; i++)
            {
                matriz[i] = new string[3];
            }

            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    matriz[i][j] = letrasDaTabela[indice];
                    indice++;
                }
            }
            return matriz;
        }

        public static char ProcurandoLetra(string palavra, int posicaoLetra)
        {
            char letra = ' ';
            letra = palavra[posicaoLetra];
            return letra;
        }



    }
}
