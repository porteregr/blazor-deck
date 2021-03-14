using BlazorDeck.Shared.ComponentModels;
using BlazorDeck.Shared.ComponentModels.Actions;
using BlazorDeck.Shared.ComponentModels.Displays;
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

            var mute = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_MUTE), new IconTileDisplayDefinition("fa-volume-mute", lightGreen, white), "Mute", 2f);
            var volumeUp = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_UP), new IconTileDisplayDefinition("fa-volume-up", lightGreen, white), "Volune Up", 0f);
            var volumeDown = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_DOWN), new IconTileDisplayDefinition("fa-volume-down", lightGreen, white), "Volune Down", 1f);
            var play = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.MEDIA_PLAY_PAUSE), new IconTileDisplayDefinition("fa-play", lightGreen, white), "Volune Down", 3f);
            var outputSpeaker = new TileDefinition(new AudioOutputAction("Speakers (Realtek(R) Audio)"), new IconTileDisplayDefinition("fa-volume-up", lightGreen, white,"Speakers"), "Speakers", 4f, true, new AudioDeviceEvent("Speakers (Realtek(R) Audio)"));
            var outputHeadphones = new TileDefinition(new AudioOutputAction("Headphones (Realtek(R) Audio)"), new IconTileDisplayDefinition("fa-headphones-alt", lightGreen, white), "Headphones", 5f, true, new AudioDeviceEvent("Headphones (Realtek(R) Audio)"));
            var navTile = new TileDefinition(new NavTileAction("Sound Page"), new IconTileDisplayDefinition("fa-volume-up", lightGreen, white, "Sound"), "Nav Tile", 1);
            var soundTilePage = new TilePageDefinition(new List<TileDefinition> { mute, volumeDown, volumeUp, play, outputSpeaker, outputHeadphones },
            "Sound Page", navTile, new NullServerEvent());

            var monitor0 = new TileDefinition(new PrimaryMonitorAction(0), new IconTileDisplayDefinition("fa-desktop", lightGreen, white, "Monitor 1"), "Monitor 1", 0f);
            var monitor1 = new TileDefinition(new PrimaryMonitorAction(2), new IconTileDisplayDefinition("fa-desktop", lightGreen, white, "Monitor 3"), "Monitor 3", 2f);
            var monitor2 = new TileDefinition(new PrimaryMonitorAction(1), new IconTileDisplayDefinition("fa-desktop", lightGreen, white, "Monitor 2"), "Monitor 2", 3f);
            var monitorNavTile = new TileDefinition(new NavTileAction("Monitor"), new IconTileDisplayDefinition("fa-desktop", lightGreen, white), "Nav Tile", 2);
            var monitorTilePage = new TilePageDefinition(new List<TileDefinition> { monitor0, monitor1, monitor2 },
            "Monitor", monitorNavTile, new NullServerEvent());

            var tileDefinition1 = new TileDefinition(new ProgramRunAction("VisualStudio", "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Professional\\Common7\\IDE\\devenv.exe"), new SvgTileDisplayDefinition("BrandVisualStudioWin2019.svg", lightGreen), "Default", 0);
            var spotify = new TileDefinition(new ProgramRunAction("Spotify", "explorer.exe", "shell:appsFolder\\SpotifyAB.SpotifyMusic_zpdnekdrzrea0!Spotify"), new SvgTileDisplayDefinition("Spotify_Icon_RGB_White.svg", lightGreen), "Default", 1);
            var wol = new TileDefinition(new WOLTileAction("04-D9-F5-84-58-F2"), new IconTileDisplayDefinition("fa-power-off", lightGreen, white), "Default", 2);
            var clock = new TileDefinition(new DumbTileAction(), new DigitalClockDisplayDefinition("12:00", lightGreen, white), "Clock", 3f,false, null, 2,1);
            var navTile1 = new TileDefinition(new NavTileAction("Default Page"), new IconTileDisplayDefinition("fa-home", paleGreen, white), "Nav Tile", 0);
            var defaultTilePage = new TilePageDefinition(new List<TileDefinition> { tileDefinition1,wol, spotify, clock },
            "Default Page", navTile1, new NullServerEvent(), true);

            var configJson = JsonConvert.SerializeObject(new List<TilePageDefinition> { soundTilePage, defaultTilePage, monitorTilePage},new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText("C:\\Users\\porte\\Documents\\BlazorDeck\\tileConfig.json", configJson);
        }
    }
}
