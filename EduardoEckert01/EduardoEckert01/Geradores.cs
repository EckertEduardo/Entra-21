using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduardoEckert01
{
    public static class Geradores
    {
        // Voce pode olhar e analisar o código quanto desejar
        // Mas em HIPÓTESE ALGUMA pode alterar o que esta digitado
        // Caso altere algo deste arquivo, automaticamente ganhará 0

        private static Random ran = new Random();
        /// <summary>
        /// Retorna de 1 a 3 para saber a quantidade de entrega ou entrada
        /// </summary>
        /// <returns></returns>
        public static int Qtd()
        {
            return ran.Next(1, 3 + 1);
        }

        /// <summary>
        /// Gera uma lista de elementos de forma organizada para ser a entrada
        /// </summary>
        /// <returns></returns>
        public static List<string> GeraEntrada()
        {
            
            List<string> lista = new List<string>();

            for (int i = 0; i < ran.Next(5,12+1); i++)
            {
                lista.Add(ran.Next(1, 4+1).ToString());
            }

            lista.Sort();
            return lista;
        }

        /// <summary>
        /// Gera uma string para ser a ordem de serviço, assim você deve gerar o vetor e preenche-lo
        /// </summary>
        /// <returns></returns>
        public static string OrdemDeServico()
        {
            int escolha = ran.Next(0, 2+1);
            if (escolha == 0)
            {
                escolha = 6;
            }
            else if (escolha == 1)
            {
                escolha = 8;
            }
            else
            {
                escolha = 10;
            }
            string ordemDeServico = "";

            for (int i = 0; i < escolha; i++)
            {
                ordemDeServico += ran.Next(1, 4 + 1).ToString();
            }

            return ordemDeServico;
        }



    }
}
