using BlazorDeck.Shared.ComponentModels;
using BlazorDeck.Shared.ComponentModels.Actions;
using BlazorDeck.Shared.ComponentModels.Displays;
using System;
using System.Collections.Generic;
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
            var lightGreen = "#008E00";
            var paleGreen = "#4CAF50";
            var white = "#FFFFFF";

            Console.WriteLine("Hello World!");
            var mute = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_MUTE), new IconTileDisplayDefinition("fa-volume-mute", paleGreen, white), "Mute", 2f);
            var volumeUp = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_UP), new IconTileDisplayDefinition("fa-volume-up", paleGreen, white), "Volune Up", 0f);
            var volumeDown = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_DOWN), new IconTileDisplayDefinition("fa-volume-down", paleGreen, white), "Volune Down", 1f);
            var navTile = new TileDefinition(new NavTileAction("Sound Page"), new IconTileDisplayDefinition("fa-volume-up", paleGreen, white), "Nav Tile", 1);
            var soundTilePage = new TilePageDefinition(new List<TileDefinition> { mute, volumeDown, volumeUp },
            "Sound Page", navTile, new NullServerEvent());

            var tileDefinition1 = new TileDefinition(new ProgramRunAction("VisualStudio", "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Professional\\Common7\\IDE\\devenv.exe"), new SvgTileDisplayDefinition("BrandVisualStudioWin2019.svg", lightGreen, white), "Default", 0);
            var navTile1 = new TileDefinition(new NavTileAction("Default Page"), new IconTileDisplayDefinition("fa-home", paleGreen, white), "Nav Tile", 0);
            var defaultTilePage = new TilePageDefinition(new List<TileDefinition> { tileDefinition1 },
            "Default Page", navTile1, new NullServerEvent(), true);
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
