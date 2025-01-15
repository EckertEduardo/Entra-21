using System;
using System.Collections.Generic;

namespace Desafio02
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Baralho> carta = new List<Baralho>();
            //MontaBaralho(carta);
            //string jogador = "";
            //int pontuaçãoTotal = 0;


            //Console.WriteLine("Bem vindo ao BlackJack");
            //Console.WriteLine("Puxe a primeira carta");




            //while (jogador == "")
            //{
            //    Console.WriteLine("Puxar carta -> ENTER");
            //    jogador = Console.ReadLine();

            //    if (jogador != "")
            //    {
            //        break;
            //    }
            //    Random ran = new Random();      //Puxa uma carta aleatória
            //    int x = ran.Next(carta.Count);
            //    Console.WriteLine("Carta -> {0}", carta[x].Carta);
            //    Console.WriteLine("Valor -> {0}", carta[x].Valor);
            //    Console.WriteLine();
            //    pontuaçãoTotal = pontuaçãoTotal + carta[x].Valor;
            //    carta.Remove(carta[x]);         //Remove a carta do baralho
            //    Console.WriteLine("Sua pontuação total até agora é -> {0}", pontuaçãoTotal);
            //    if (pontuaçãoTotal > 21)
            //    {
            //        Console.WriteLine("Você perdeu, pois sua pontuação ultrapassou 21 pontos :(");
            //        break;
            //    }
            //    else if (pontuaçãoTotal == 21)
            //    {
            //        Console.WriteLine("Parabéns você ganhou :)");
            //        break;
            //    }
            //    Console.WriteLine("Parar -> (0)");
            //}

            List<Baralho> carta = new List<Baralho>();
            MontaBaralho(carta);
            string jogador = "";
            int bot = 1;
            int pontuaçãoTotal = 0;
            int pontuaçãoBot = 0;


            Console.WriteLine("Bem vindo ao BlackJack");
            Console.WriteLine();

            do
            {
                if (jogador == "")
                {
                    Console.WriteLine("------------------||----------------");
                    Console.WriteLine("Turno do Jogador");
                    Console.WriteLine("Puxar Carta -> ENTER");
                    Console.WriteLine("Parar -> (0)");
                    jogador = Console.ReadLine();
                    if (jogador == "0")
                    {
                        Console.WriteLine("O jogador decidiu parar");
                    }
                    else
                    {


                        Console.WriteLine();
                        Random ran = new Random();      //Puxa uma carta aleatória
                        int x = ran.Next(carta.Count);
                        Console.WriteLine("Carta -> {0}", carta[x].Carta);
                        Console.WriteLine("Valor -> {0}", carta[x].Valor);
                        Console.WriteLine();
                        pontuaçãoTotal = pontuaçãoTotal + carta[x].Valor;
                        carta.Remove(carta[x]);         //Remove a carta do baralho
                        Console.WriteLine("Sua pontuação total até agora é -> {0}", pontuaçãoTotal);
                        if (pontuaçãoTotal > 21)
                        {
                            Console.WriteLine("Você perdeu, pois sua pontuação ultrapassou 21 pontos :(");
                            pontuaçãoTotal = 0;
                            break;
                        }
                        else if (pontuaçãoTotal == 21)
                        {
                            Console.WriteLine("Parabéns você ganhou :)");
                            break;
                        }
                    }
                }

                Console.WriteLine("------------------||----------------");

                if (bot == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Turno do Bot");
                    Console.ReadLine();
                    Random ran = new Random();
                    int x = ran.Next(carta.Count);
                    Console.WriteLine("Carta -> {0}", carta[x].Carta);
                    Console.WriteLine("Valor -> {0}", carta[x].Valor);
                    Console.WriteLine();
                    pontuaçãoBot = pontuaçãoBot + carta[x].Valor;
                    carta.Remove(carta[x]);         //Remove a carta do baralho
                    Console.WriteLine("A pontuação total do Bot até agora é -> {0}", pontuaçãoBot);
                    if (pontuaçãoBot > 21)
                    {
                        Console.WriteLine("O Bot perdeu, pois sua pontuação ultrapassou 21 pontos :(");
                        pontuaçãoBot = 0;
                        break;
                    }
                    else if (pontuaçãoBot == 21)
                    {
                        Console.WriteLine("Parabéns, o Bot ganhou :)");
                        break;
                    }



                    double chance = 0.0;
                    chance = ChancePassar21(pontuaçãoBot, carta, chance);

                    if (chance < 5)
                    {
                        bot = 1;
                    }
                    else if (chance < 50)
                    {
                        bot = Random5();
                    }
                    else if (chance >= 50 && chance < 80)
                    {
                        bot = Random50();
                    }
                    else 
                    {
                        bot = Random80();
                    }


                }
                else
                {
                    Console.WriteLine("O Bot decidiu parar ");
                }
            }
            while (jogador == "" || bot == 1);
            Console.WriteLine();
            if(pontuaçãoBot == pontuaçãoTotal)
            {
                Console.WriteLine("O jogo empatou");
            }
            else if (pontuaçãoBot > pontuaçãoTotal)
            {
                Console.WriteLine("O bot ganhou");
            }
            else
            {
                Console.WriteLine("O jogador ganhou");
            }

        }
        public static List<Baralho> MontaBaralho(List<Baralho> carta)
        {
            //List<Baralho> carta = new List<Baralho>();
            for (int i = 0; i < 13; i++)
            {
                Baralho temp = new Baralho();
                for (int j = i + 1; j < i + 2; j++)
                {
                    if (i >= 8)
                    {
                        temp.Valor = 10;
                        if (i == 8)
                        {

                            temp.Carta = "10";
                        }
                        else if (i == 9)
                        {

                            temp.Carta = "J";
                        }
                        else if (i == 10)
                        {

                            temp.Carta = "Q";
                        }
                        else if (i == 11)
                        {

                            temp.Carta = "K";
                        }
                        else if (i == 12)
                        {

                            temp.Carta = "A";
                        }
                        carta.Add(temp);
                        carta.Add(temp);
                        carta.Add(temp);
                        carta.Add(temp);                                //Baralho

                    }
                    else
                    {

                        temp.Valor = j + 1;
                        temp.Carta = Convert.ToString(temp.Valor);
                        carta.Add(temp);
                        carta.Add(temp);
                        carta.Add(temp);
                        carta.Add(temp);
                    }
                }
            }
            return carta;
        }
        public static double ChancePassar21(int pontuacaoBot, List<Baralho> carta, double chance)
        {
            int cartaMorte = 0;
            chance = 0;
            switch (pontuacaoBot)
            {
                case <= 11:
                    chance = 0;
                    return chance;


                case 12:

                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;

                case 13:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
                case 14:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9 || carta[i].Valor == 8)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
                case 15:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9 || carta[i].Valor == 8 || carta[i].Valor == 7)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
                case 16:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9 || carta[i].Valor == 8 || carta[i].Valor == 7 || carta[i].Valor == 6)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
                case 17:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9 || carta[i].Valor == 8 || carta[i].Valor == 7 || carta[i].Valor == 6 || carta[i].Valor == 5)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
                case 18:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9 || carta[i].Valor == 8 || carta[i].Valor == 7 || carta[i].Valor == 6 || carta[i].Valor == 5 || carta[i].Valor == 4)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
                case 19:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9 || carta[i].Valor == 8 || carta[i].Valor == 7 || carta[i].Valor == 6 || carta[i].Valor == 5 || carta[i].Valor == 4 || carta[i].Valor == 3)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
                case 20:
                    for (int i = 0; i < carta.Count; i++)
                    {
                        if (carta[i].Valor == 10 || carta[i].Valor == 9 || carta[i].Valor == 8 || carta[i].Valor == 7 || carta[i].Valor == 6 || carta[i].Valor == 5 || carta[i].Valor == 4 || carta[i].Valor == 3 || carta[i].Valor == 2)
                        {
                            cartaMorte = cartaMorte + 1;
                        }
                    }
                    break;
            }
            chance = (cartaMorte / Convert.ToDouble(carta.Count));
            chance = chance * 100;


            return chance;
        }       // Chance de passar 21
        public static int Random5()
        {
            Random ran = new Random();
            int acao = ran.Next(1, 11);
            if (acao == 10)
            {
                acao = 0;
            }
            else
            {
                acao = 1;
            }
            return acao;
        }
        public static int Random50()
        {
            Random ran = new Random();
            int acao = ran.Next(1, 101);
            if (acao > 50)
            {
                acao = 0;
            }
            else
            {
                acao = 1;
            }
            return acao;
        }
        public static int Random80()
        {
            Random ran = new Random();
            int acao = ran.Next(1, 101);
            if (acao > 20)
            {
                acao = 0;
            }
            else
            {
                acao = 1;
            }
            return acao;
        }
    }
}
