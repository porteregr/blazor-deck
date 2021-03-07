using BlazorDeck.Shared.ComponentModels;
using BlazorDeck.Shared.ComponentModels.Actions;
using BlazorDeck.Shared.ComponentModels.Displays;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using WindowsInput.Native;
using BlazorDeck.Shared.ComponentModels.ServerEvents;

namespace TileConfigGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tileDefinition = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_MUTE), new TextTileDisplay(), "Mute", 0.1f);
            var tileDefinition3 = new TileDefinition(new DumbTileAction(), new TextTileDisplay(), "Whatch this!", 0);
            var navTile = new TileDefinition(new NavTileAction(), new TextTileDisplay(), "Nav Tile", 0);
            var soundTilePage = new TilePageDefinition(new List<TileDefinition> { tileDefinition, tileDefinition3 },
            "Sound Page", navTile, new ActiveWindowEvent("Microsoft Visual Studio"));

            var tileDefinition1 = new TileDefinition(new DumbTileAction(), new TextTileDisplay(), "Default", 0);
            var tileDefinition2 = new TileDefinition(new DumbTileAction(), new TextTileDisplay(), "Default", 1);
            var defaultTilePage = new TilePageDefinition(new List<TileDefinition> { tileDefinition1, tileDefinition2 },
            "Default Page", navTile, new NullServerEvent(), true);
            //var configJson = JsonSerializer.Serialize(new List<TilePageDefinition>() { tilePageDefinition });
            //var serializer = new XmlSerializer(typeof(List<TilePageDefinition>));
            //var writer = new StreamWriter("C:\\Users\\porte\\Documents\\BlazorDeck\\tileConfig.json");
            //serializer.Serialize(writer, new List<TilePageDefinition> { tilePageDefinition });
            //writer.Close();
            var configJson = JsonConvert.SerializeObject(new List<TilePageDefinition> { soundTilePage, defaultTilePage },new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText("C:\\Users\\porte\\Documents\\BlazorDeck\\tileConfig.json", configJson);
        }
    }
}
