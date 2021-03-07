using BlazorDeck.Shared.ComponentModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorDeck.Server.Managers
{
    public class TileConfigManager
    {
        private const string configPath = "C:\\Users\\porte\\Documents\\BlazorDeck\\tileConfig.json";
        public IEnumerable<TilePageDefinition> GetPages()
        {
            var configText = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<List<TilePageDefinition>>(configText,new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}
