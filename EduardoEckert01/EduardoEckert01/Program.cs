using System;
using System.Collections.Generic;

namespace EduardoEckert01
{
    class Program
    {
        static void Main(string[] args)
        {

            int dia = 1;
            int[][] p1 = new int[6][];
            P1EstoqueInicial(p1);
            int[][] p2 = new int[6][];
            P2EstoqueInicial(p2);                                                                                                     // Criação matriz 6x6. Armazena os produtos 1, 2, 3, 4
            int[][] p3 = new int[6][];
            P3EstoqueInicial(p3);
            int[][] p4 = new int[6][];
            P4EstoqueInicial(p4);

            Console.WriteLine("Bem vindo ao EckertLogistics");
            Console.WriteLine("---------------------------------------------------------");
            MostraEstoqueTotal(p1, p2, p3, p4);                                                                                       // Mostra o estoque inicial
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Pressione ENTER para visualizar o dia a dia da Organização");
            Console.ReadLine();
            while (dia < 6 + 1)                                                                                                       // Quantidade de dias (O programa irá rodar por 6 dias)
            {
                Console.Clear();                                                                                                      // Limpa tela
                Console.WriteLine("Bem vindo ao EckertLogistics");                                                                    // Bem vindo chefia, fica a vontade
                Console.WriteLine("Dia " + dia);                                                                                      // Dia atual
                int QtdRecebimento = Geradores.Qtd();                                                                                 // Quantia de cargas
                Console.WriteLine("--------------------------------------Recebimento da carga e organização do estoque--------------------------------------------- \r\n");
                Console.WriteLine("Hoje a EckertLogistics recebeu -> " + QtdRecebimento + " carga(s)");                               // Mostra quantidade de cargas recebidas
                List<string> recebimento = new List<string>();                                                                        // Lista do recebimento
                for (int CargaAtual = 0; CargaAtual < QtdRecebimento; CargaAtual++)
                {
                    recebimento = Geradores.GeraEntrada();                                                                            // Recebe a quantia de produtos recebidas e armazena cada produto na lista em ordem crescente
                    Console.Write("Carga " + (CargaAtual + 1) + " -> ");                                                              // Mostra a carga atual
                    foreach (var item in recebimento)
                    {
                        Console.Write(item + " ");                                                                                    // Mostra os produtos da carga atual
                        OrganizaEstoque(p1, p2, p3, p4, item);                                                                        // Recebe produto por produto e organiza em seu determinado estoque se houver espaço (0)
                    }
                    Console.WriteLine();
                }

                Console.ReadLine();                                                                                                    // Aguarda o usuário digitar ENTER
                Console.WriteLine("-------------------------------------------Estoque atualizado com os Recebimentos-----------------------------------------------");
                MostraEstoqueTotal(p1, p2, p3, p4);                                                                                    // Mostra estoque com os recebimentos
                Console.ReadLine();                                                                                                    // Aguarda o usuário digitar ENTER
                Console.Clear();                                                                                                       // Limpa tela
                Console.WriteLine("Bem vindo ao EckertLogistics");                                                                    // Bem vindo chefia, fica a vontade
                Console.WriteLine("Dia " + dia);                                                                                      // Dia atual
                Console.WriteLine("------------------------------------------------------Envio de cargas----------------------------------------------------------\r\n");
                ConfereEstoqueEnvio(p1, p2, p3, p4);                                                                                   // Mostra quantas entregas foram solicitadas. Confere produto por produto se tem no estoque, se tiver armazena no vetor para envio e remove do estoque(0). Mostra o vetor de cada entrega 
                Console.ReadLine();                                                                                                    // Aguarda o usuário digitar ENTER

                Console.WriteLine("-------------------------------------------Estoque atualizado com os Envios-----------------------------------------------");
                MostraEstoqueTotal(p1, p2, p3, p4);                                                                                    // Mostra estoque depois dos envios
                Console.WriteLine("\r\nPressione ENTER para o próximo dia ->");
                Console.ReadLine();                                                                                                    // Aguarda o usuário digitar ENTER
                Console.Clear();                                                                                                       // Limpa tela
                dia++;                                                                                                                 // Incrementa o dia
            }
        }

        public static int[][] P1EstoqueInicial(int[][] p1)
        {
            for (int i = 0; i < p1.Length; i++)
            {
                p1[i] = new int[6];
            }

            for (int i = 0; i < p1.Length; i++)
            {
                if (i >= 3)
                {
                    for (int j = 0; j < p1[i].Length; j++)
                    {
                        p1[i][j] = 0;
                    }
                }
                else
                {

                    for (int j = 0; j < p1[i].Length; j++)
                    {
                        p1[i][j] = 1;
                    }
                }
            }
            return p1;
        }   // Preenche a matriz 6x6 com metade dos produtos (1) e a outra metade fica vazio (0)
        public static int[][] P2EstoqueInicial(int[][] p2)
        {
            for (int i = 0; i < p2.Length; i++)
            {
                p2[i] = new int[6];
            }
            for (int i = 0; i < p2.Length; i++)
            {
                if (i >= 3)
                {
                    for (int j = 0; j < p2[i].Length; j++)
                    {
                        p2[i][j] = 0;
                    }
                }
                else
                {

                    for (int j = 0; j < p2[i].Length; j++)
                    {
                        p2[i][j] = 2;
                    }
                }
            }
            return p2;
        }   // Preenche a matriz 6x6 com metade dos produtos (2) e a outra metade fica vazio (0)
        public static int[][] P3EstoqueInicial(int[][] p3)
        {
            for (int i = 0; i < p3.Length; i++)
            {
                p3[i] = new int[6];
            }
            for (int i = 0; i < p3.Length; i++)
            {
                if (i >= 3)
                {
                    for (int j = 0; j < p3[i].Length; j++)
                    {
                        p3[i][j] = 0;
                    }
                }
                else
                {

                    for (int j = 0; j < p3[i].Length; j++)
                    {
                        p3[i][j] = 3;
                    }
                }
            }
            return p3;
        }   // Preenche a matriz 6x6 com metade dos produtos (3) e a outra metade fica vazio (0)
        public static int[][] P4EstoqueInicial(int[][] p4)
        {
            for (int i = 0; i < p4.Length; i++)
            {
                p4[i] = new int[6];
            }
            for (int i = 0; i < p4.Length; i++)
            {
                if (i >= 3)
                {
                    for (int j = 0; j < p4[i].Length; j++)
                    {
                        p4[i][j] = 0;
                    }
                }
                else
                {

                    for (int j = 0; j < p4[i].Length; j++)
                    {
                        p4[i][j] = 4;
                    }
                }
            }
            return p4;
        }   // Preenche a matriz 6x6 com metade dos produtos (4) e a outra metade fica vazio (0)
        public static void MostraEstoqueTotal(int[][] p1, int[][] p2, int[][] p3, int[][] p4)
        {
            Console.WriteLine("Estoque Produto 1\r\n");
            for (int i = 0; i < p1.Length; i++)
            {
                for (int j = 0; j < p1[i].Length; j++)
                {
                    Console.Write(p1[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------- \r\nEstoque produto 2 \r\n");
            for (int i = 0; i < p2.Length; i++)
            {
                for (int j = 0; j < p2[i].Length; j++)
                {
                    Console.Write(p2[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------- \r\nEstoque produto 3 \r\n");
            for (int i = 0; i < p3.Length; i++)
            {
                for (int j = 0; j < p3[i].Length; j++)
                {
                    Console.Write(p3[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------- \r\nEstoque produto 4 \r\n");
            for (int i = 0; i < p4.Length; i++)
            {
                for (int j = 0; j < p4[i].Length; j++)
                {
                    Console.Write(p4[i][j] + " ");
                }
                Console.WriteLine();
            }
        }   // Mostra todo o estoque dos produtos
        public static void OrganizaEstoque(int[][] p1, int[][] p2, int[][] p3, int[][] p4, string item)
        {
            if (Convert.ToInt32(item) == 1)                       // (item) produto que está sendo avaliado no momento
            {

                for (int i = 0; i < p1.Length; i++)
                {
                    for (int j = 0; j < p1[i].Length; j++)
                    {
                        if (p1[i][j] == 0)
                        {
                            p1[i][j] = Convert.ToInt32(item);    // Se houver espaço (0) adiciona o (item) neste espaço
                            i = 6;
                            break;
                        }

                    }

                }
            }
            if (Convert.ToInt32(item) == 2)                     // (item) produto que está sendo avaliado no momento
            {

                for (int i = 0; i < p2.Length; i++)
                {
                    for (int j = 0; j < p2[i].Length; j++)
                    {
                        if (p2[i][j] == 0)
                        {
                            p2[i][j] = Convert.ToInt32(item);   // Se houver espaço (0) adiciona o (item) neste espaço
                            i = 6;
                            break;
                        }

                    }

                }
            }

            if (Convert.ToInt32(item) == 3)                     // (item) produto que está sendo avaliado no momento                                      // Se não houver espaço para o (item), o mesmo é descartado e segue para o próximo
            {

                for (int i = 0; i < p3.Length; i++)
                {
                    for (int j = 0; j < p3[i].Length; j++)
                    {
                        if (p3[i][j] == 0)
                        {
                            p3[i][j] = Convert.ToInt32(item);   // Se houver espaço (0) adiciona o (item) neste espaço
                            i = 6;
                            break;
                        }

                    }

                }
            }
            if (Convert.ToInt32(item) == 4)                    // (item) produto que está sendo avaliado no momento
            {

                for (int i = 0; i < p4.Length; i++)
                {
                    for (int j = 0; j < p4[i].Length; j++)
                    {
                        if (p4[i][j] == 0)
                        {
                            p4[i][j] = Convert.ToInt32(item);   // Se houver espaço (0) adiciona o (item) neste espaço
                            i = 6;
                            break;
                        }

                    }

                }
            }
        } // Recebe produto por produto e organiza em seu determinado estoque se houver espaço (0)
        public static void ConfereEstoqueEnvio(int[][] p1, int[][] p2, int[][] p3, int[][] p4)
        {
            int QtdEnvio = Geradores.Qtd();                                                                                          // Recebe quantidade de pedidos do dia
            Console.WriteLine("Hoje a EckertLogistics enviou -> " + QtdEnvio + " carga(s) \n");                                         // Mostra quantidade de cargas enviadas

            for (int CargaAtual = 0; CargaAtual < QtdEnvio; CargaAtual++)                                                            // Percorre de acordo com a quantia de pedidos
            {

                string OrdemEnvio = Geradores.OrdemDeServico();                                                                       // Recebe o pedido do cliente (gera um novo pedido a cada ciclo)
                string OrdemEnvioTratado = "";                                                                                        // Receberá o 'char' correspondente aquele produto do pedido 
                string OrdemEnvioFinal = "";                                                                                          // Receberá o OrdemEnvioTratado e irá adicionar '#' para futuramente fazer a separação e adicionar no vetor
                string[] VetorNumeroString = OrdemEnvioFinal.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);      // Cria o vetor que receberá OrdemEnvioFinal(1#2#2#3) e separa o 'char' a cada '#'. A criação dentro desse 'for' garante que o vetor não acumule os valores de pedidos anteriores
                int[] vetorEnvio = new int[VetorNumeroString.Length];                                                                 // Cria o vetor que receberá os valores já convertido em int, e posteriormente mostra na tela. A criação dentro desse 'for' garante que o vetor não acumule os valores de pedidos anteriores



                Console.WriteLine("Carga " + (CargaAtual + 1) + "-> " + OrdemEnvio);                                                  // Mostra quantidade de pedidos do dia
                for (int z = 0; z < OrdemEnvio.Length; z++)                                                                           // Percorre de acordo com a quantia de produtos do pedido
                {

                    OrdemEnvioTratado = OrdemEnvio.Substring(z, 1);                                                                   // Recebe o 'char' selecionado
                    switch (OrdemEnvioTratado)

                    {
                        case "1":
                            for (int i = p1.Length - 1; i >= 0; i--)
                            {
                                for (int j = p1[i].Length - 1; j >= 0; j--)
                                {
                                    if (p1[i][j] == 1)
                                    {
                                        p1[i][j] = 0;
                                        i = -1;
                                        OrdemEnvioFinal += "1#";
                                        break;

                                    }
                                }
                            }
                            break;
                        case "2":
                            for (int i = p2.Length - 1; i >= 0; i--)
                            {
                                for (int j = p2[i].Length - 1; j >= 0; j--)                                                          // Caso o produto solicitado for igual ao case, faz a busca dentro do estoque de trás pra frente
                                {
                                    if (p2[i][j] == 2)                                                                               // Se encontrar o produto
                                    {
                                        p2[i][j] = 0;                                                                                // Adiciona 0 na posição removendo o item do estoque
                                        i = -1;
                                        OrdemEnvioFinal += "2#";                                                                     // Adiciona ao OrdemEnvioFinal o 'char' referente ao produto e adiciona '#' para futuramente fazer a separação e adicionar no vetor
                                        break;

                                    }                                                                                                // Caso não tenha o produto no estoque, este processo é ignorado e segue para o próximo produto do pedido
                                }
                            }
                            break;
                        case "3":
                            for (int i = p3.Length - 1; i >= 0; i--)
                            {
                                for (int j = p3[i].Length - 1; j >= 0; j--)
                                {
                                    if (p3[i][j] == 3)
                                    {
                                        p3[i][j] = 0;
                                        i = -1;
                                        OrdemEnvioFinal += "3#";
                                        break;

                                    }
                                }
                            }
                            break;
                        case "4":
                            for (int i = p4.Length - 1; i >= 0; i--)
                            {
                                for (int j = p4[i].Length - 1; j >= 0; j--)
                                {
                                    if (p4[i][j] == 4)
                                    {
                                        p4[i][j] = 0;
                                        i = -1;
                                        OrdemEnvioFinal += "4#";
                                        break;

                                    }
                                }
                            }
                            break;
                    }

                }

                VetorNumeroString = OrdemEnvioFinal.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);         // Cria o vetor string de acordo com a quantia de produtos encontrados no estoque
                Console.Write("A carga enviada para este pedido,de acordo com a disponibilidade do estoque  é -> ");            // Mostra o vetor de envio com as cargas
                if (VetorNumeroString.Length <= 6)                                                                              // Aqui ele confere qual o tamanho do 'caminhão' que será selecionado (6.8.10)
                {
                    vetorEnvio = new int[6];
                    for (int i = 0; i < vetorEnvio.Length; i++)
                    {
                        if (i < VetorNumeroString.Length)                                                                              // Preenche o caminhão com os produtos do vetor string
                        {
                            vetorEnvio[i] = Convert.ToInt32(VetorNumeroString[i]);                                                      // Preenche o vetor int  e converte o resultado do VetorNumeroString para int. Este é o vetor que será enviado ao cliente
                            Console.Write(vetorEnvio[i] + " ");                                                                         // Mostra o produto enviado
                        }
                        else                                                                                                            // *Se tivermos menos produtos do que o tamanho do caminhão selecionado, preenchemos o restante com 0 (espaço vazio)
                        {
                            vetorEnvio[i] = 0;
                            Console.Write(vetorEnvio[i] + " ");                                                                         // Mostra o produto enviado
                        }
                    }
                    Console.WriteLine("\n");
                }
                else if (VetorNumeroString.Length <= 8)
                {
                    vetorEnvio = new int[8];
                    for (int i = 0; i < vetorEnvio.Length; i++)
                    {
                        if (i < VetorNumeroString.Length)                                                                              // Preenche o caminhão com os produtos do vetor string
                        {
                            vetorEnvio[i] = Convert.ToInt32(VetorNumeroString[i]);                                                      // Preenche o vetor int  e converte o resultado do VetorNumeroString para int. Este é o vetor que será enviado ao cliente
                            Console.Write(vetorEnvio[i] + " ");                                                                         // Mostra o produto enviado
                        }
                        else                                                                                                            // *Se tivermos menos produtos do que o tamanho do caminhão selecionado, preenchemos o restante com 0 (espaço vazio)
                        {
                            vetorEnvio[i] = 0;
                            Console.Write(vetorEnvio[i] + " ");                                                                         // Mostra o produto enviado
                        }
                    }
                    Console.WriteLine("\n");
                }
                else if (VetorNumeroString.Length <= 10)
                {
                    vetorEnvio = new int[10];
                    for (int i = 0; i < vetorEnvio.Length; i++)
                    {
                        if (i < VetorNumeroString.Length)                                                                              // Preenche o caminhão com os produtos do vetor string
                        {
                            vetorEnvio[i] = Convert.ToInt32(VetorNumeroString[i]);                                                      // Preenche o vetor int  e converte o resultado do VetorNumeroString para int. Este é o vetor que será enviado ao cliente
                            Console.Write(vetorEnvio[i] + " ");                                                                         // Mostra o produto enviado
                        }
                        else                                                                                                            // *Se tivermos menos produtos do que o tamanho do caminhão selecionado, preenchemos o restante com 0 (espaço vazio)
                        {
                            vetorEnvio[i] = 0;
                            Console.Write(vetorEnvio[i] + " ");                                                                         // Mostra o produto enviado
                        }
                    }
                    Console.WriteLine("\n");
                }
            }
        } // Recebe o pedido do cliente, confere produto por produto se tem no estoque, se tiver, armazena no vetor de envio e por último mostra o vetor com os produtos enviado

    }
}