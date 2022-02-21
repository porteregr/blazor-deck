using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorDeck.Shared.ComponentModels;
using Newtonsoft.Json;

namespace BlazorDeck.Client.Services
{
    public class BookManager
    {
        private readonly HttpClient http;
        public BookManager(HttpClient http)
        {
            this.http = http;
        }
        public async Task<IEnumerable<TilePageDefinition>> LoadBook(string bookName)
        {
            var results = await http.GetAsync($"api/books/{bookName}").ConfigureAwait(true);
            var tilepageJson = await results.Content.ReadAsStringAsync().ConfigureAwait(true);
            return JsonConvert.DeserializeObject<IEnumerable<TilePageDefinition>>(tilepageJson, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}
