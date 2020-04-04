using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MessedTextResolver
{
    internal class Program
    {
        private static readonly HttpClient _client = new HttpClient(new HttpClientHandler{AllowAutoRedirect = true});

        static async Task Main(string[] args)
        {
            var messedText = await _client.GetStringAsync("https://bit.ly/2R7OofY");
            var charCounter = new Dictionary<char, int>();

            foreach (var character in messedText)
            {
                charCounter[character] = charCounter.GetValueOrDefault(character) + 1;
            }

            var resolvedText = new string(messedText.Where(character => charCounter[character] <= 10).ToArray());

            Console.WriteLine(resolvedText);
            Console.ReadLine();
        }
    }
}
