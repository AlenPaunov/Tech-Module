using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Evolution
{
    class Pokemon_Evolution
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<PokemonEvolution>> pokemons = new Dictionary<string, List<PokemonEvolution>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "wubbalubbadubdub") break;

                string[] tokens = input.Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string pokemonName = tokens[0];

                if (tokens.Length == 1&&pokemons.ContainsKey(pokemonName))
                {

                    foreach (var item in pokemons.Where(x=>x.Key == pokemonName))
                    {
                        Console.WriteLine($"# {pokemonName}");
                        List<PokemonEvolution> evolutionData = item.Value;

                        foreach (var evolution in evolutionData)
                        {
                            string evolutionType = evolution.Type;
                            long evolutionIndex = evolution.Index;

                            Console.WriteLine($"{evolutionType} <-> {evolutionIndex}");
                        }
                    }                        
                       
                }
                else
                {
                    try
                    {
                        string evolutionType = tokens[1];
                        string evolutionIndex = tokens[2];

                        PokemonEvolution evolution = new PokemonEvolution(evolutionType, evolutionIndex);

                        if (!pokemons.ContainsKey(pokemonName))
                        {
                            pokemons.Add(pokemonName, new List<PokemonEvolution>());
                        }
                        pokemons[pokemonName].Add(evolution);
                    }
                    catch
                    {

                    }
                }
            }
            foreach (var pokemon in pokemons)
            {
                string pokemonName = pokemon.Key;
                List<PokemonEvolution> evolutions = pokemon.Value;

                Console.WriteLine($"# {pokemonName}");
                
                foreach (var item in evolutions.OrderByDescending(e => e.Index))
                {
                    Console.WriteLine($"{item.Type} <-> {item.Index}");
                }
            }
        }
    }

    class PokemonEvolution
    {
        public string Type;
        public long Index;

        public PokemonEvolution(string pokemonType, string pokemonIndex)
        {
            Type = pokemonType;
            Index = long.Parse(pokemonIndex);
        }
    }
}
