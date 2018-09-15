using System;
using System.Linq;

namespace Candies
{
    class Program
    {
        //Candies Problem - Solution By DeltaFoX aka Russo Paolo Rito 
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string array divided by space example (3 1 2 2) :\n");
            string[] nd = Console.ReadLine().Trim().Split(' ');
            //Se Input è minore o uguale a 2 Esco dal Soft
            if (nd.Length <= 2)
                Environment.Exit(0);
            //Salto il primo valore dell'array inserito che è la lunghezza dell'array e converto il restante in int
            int[] arr = Array.ConvertAll(nd.Skip(1).ToArray(), int.Parse);
            Console.WriteLine("\n\nFinal Result :\n");
            //Invio al Metodo candies il primo valore dell'array inserito convertito in int ed il precedente array convertito in int
            Console.WriteLine(candies(int.Parse(nd[0]), arr));
            Console.ReadLine();
        }

        //Metodo per il calcolo del numero minimo di caramelle richieste per soddisfare il problema
        private static long candies(int n, int[] arr)
        {
            //Inizio con inizializzare un array con il numero del rating of the student inserito (arr)
            int[] candies = new int[arr.Length];
            //Imposto ad 1 il valore del primo array numero minimo di caramelle da dare ad ogni bambino
            candies[0] = 1;
            //verifico se il bambino seduto vicino ha un rating più alto in caso positivo riceve lui 1 caramella in più del compagno
            //e lo setto nel relativo array candies altrimenti il bambino in valutazione ricevera un minimo 1 di caramelle
            for (int i = 1; i < arr.Length; i++)
                if (arr[i - 1] < arr[i])
                    candies[i] = candies[i - 1] + 1;
                else
                    candies[i] = 1;
            //Ottengo la somma ricalcolando i risultati da dx a sx
            long sumCandies = candies[arr.Length - 1];
            //Nuovo ciclo for per determinare le ultime caramelle da acquistar
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1])
                    candies[i] = Math.Max(candies[i + 1] + 1, candies[i]); // verifico il valore più grande tra i due e setto
                sumCandies += candies[i]; //altrimenti sommo
            }
            //ritorno il valore trovato
            return sumCandies;
        }
    }
}
