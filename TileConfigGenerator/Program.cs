using BlazorDeck.Shared.ComponentModels;
using BlazorDeck.Shared.ComponentModels.Actions;
using BlazorDeck.Shared.ComponentModels.Displays;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using WindowsInput.Native;
using BlazorDeck.Shared.ComponentModels.ServerEvents;
using SoundSwitch.Framework.Audio.Lister;
using System;
using System.Reflection;
using System.Linq;
using BlazorDeck.Shared.ComponentModels.Actions.Builders;

namespace TileConfigGenerator
{
    class Program
    {
        static void Main(string[] args)
        {


            var lightGreen = "#008E00";
            var paleGreen = "#4CAF50";
            var white = "#FFFFFF";
            
            

            var devices = new CachedAudioDeviceLister(NAudio.CoreAudioApi.DeviceState.Active);
            devices.Refresh();
            foreach(var decice in devices.PlaybackDevices)
            {
                Console.WriteLine(decice.NameClean);
            }

            var mute = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_MUTE), new IconTileDisplayDefinition("fa-volume-mute", lightGreen, white), "Mute", 2);
            var volumeUp = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_UP), new IconTileDisplayDefinition("fa-volume-up", lightGreen, white), "Volune Up", 0);
            var volumeDown = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.VOLUME_DOWN), new IconTileDisplayDefinition("fa-volume-down", lightGreen, white), "Volune Down", 1);
            var play = new TileDefinition(new APITileAction("api/keyboard/press", HttpMethod.Post, VirtualKeyCode.MEDIA_PLAY_PAUSE), new IconTileDisplayDefinition("fa-play", lightGreen, white), "Volune Down", 3);
            var outputSpeaker = new TileDefinition(new AudioOutputAction("Speakers (High Definition Audio Device)"), new IconTileDisplayDefinition("fa-volume-up", lightGreen, white,"Speakers"), "Speakers", 4, true, new AudioDeviceEvent("Speakers (High Definition Audio Device)"));
            var outputHeadphones = new TileDefinition(new AudioOutputAction("Speakers (Avantree Leaf)"), new IconTileDisplayDefinition("fa-headphones-alt", lightGreen, white), "Headphones", 5, true, new AudioDeviceEvent("Speakers (Avantree Leaf)"));
            var outputTV = new TileDefinition(new AudioOutputAction("LG TV (NVIDIA High Definition Audio)"), new IconTileDisplayDefinition("fa-tv", lightGreen, white), "TV", 6, true, new AudioDeviceEvent("LG TV (NVIDIA High Definition Audio)"));
            var navTile = new TileDefinition(new NavTileAction("Sound Page"), new IconTileDisplayDefinition("fa-volume-up", lightGreen, white, "Sound"), "Nav Tile", 1);
            var soundTilePage = new TilePageDefinition(new List<TileDefinition> { mute, volumeDown, volumeUp, play, outputSpeaker, outputHeadphones, outputTV },
            "Sound Page", navTile, new NullServerEvent());

            ConfigureBuilders(mute);

            var monitor0 = new TileDefinition(new PrimaryMonitorAction(0), new IconTileDisplayDefinition("fa-desktop", lightGreen, white, "Monitor 1"), "Monitor 1", 0);
            var monitor1 = new TileDefinition(new PrimaryMonitorAction(1), new IconTileDisplayDefinition("fa-desktop", lightGreen, white, "Monitor 2"), "Monitor 2", 2);
            var monitor2 = new TileDefinition(new PrimaryMonitorAction(2), new IconTileDisplayDefinition("fa-desktop", lightGreen, white, "Monitor 3"), "Monitor 3", 3);
            var monitorNavTile = new TileDefinition(new NavTileAction("Monitor"), new IconTileDisplayDefinition("fa-desktop", lightGreen, white), "Nav Tile", 2);
            var monitorTilePage = new TilePageDefinition(new List<TileDefinition> { monitor0, monitor1, monitor2 },
            "Monitor", monitorNavTile, new NullServerEvent());

            var tileDefinition1 = new TileDefinition(new ProgramRunAction("VisualStudio", "C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\devenv.exe"), new SvgTileDisplayDefinition("BrandVisualStudioWin2019.svg", lightGreen), "Default", 0);
            var spotify = new TileDefinition(new ProgramRunAction("Spotify", "explorer.exe", "shell:appsFolder\\SpotifyAB.SpotifyMusic_zpdnekdrzrea0!Spotify"), new SvgTileDisplayDefinition("Spotify_Icon_RGB_White.svg", lightGreen), "Default", 1);
            var wol = new TileDefinition(new WOLTileAction("04-D9-F5-84-58-F2"), new IconTileDisplayDefinition("fa-power-off", lightGreen, white), "Default", 2);
            var clock = new TileDefinition(new DumbTileAction(), new DigitalClockDisplayDefinition("12:00", lightGreen, white), "Clock", 3,false, null, 2,1);
            var navTile1 = new TileDefinition(new NavTileAction("Default Page"), new IconTileDisplayDefinition("fa-home", paleGreen, white), "Nav Tile", 0);
            var defaultTilePage = new TilePageDefinition(new List<TileDefinition> { tileDefinition1,wol, spotify, clock },
            "Default Page", navTile1, new NullServerEvent(), true);

            var configJson = JsonConvert.SerializeObject(new List<TilePageDefinition> { soundTilePage, defaultTilePage, monitorTilePage},new JsonSerializerSettings() {TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText("C:\\Users\\porte\\Documents\\BlazorDeck\\book-modbro.json", configJson);
        }

        private static void ConfigureBuilders(TileDefinition tile)
        {
            var builderType = GetTypeBuilderType(LoadType<ITileActionBuilder>(), tile.Action.GetType());
            var constructor = builderType.GetConstructor(new[] { tile.Action.GetType() });
            var builder = constructor.Invoke(new[] { tile.Action }) as ITileActionBuilder;
        }

        private static TypeInfo GetTypeBuilderType(List<TypeInfo> typeInfos, Type typeInfo)
        {
            return typeInfos.Where((buildertype) => buildertype.ImplementedInterfaces.Any((implementedInterface) => implementedInterface.GenericTypeArguments.Contains(typeInfo))).FirstOrDefault();
        }

        private static void LoadTypes()
        {
            var actionTypes = LoadType<ITileActionBuilder>();
        }

        private static List<TypeInfo> LoadType<T>()
        {
            var types = new List<TypeInfo>();
            var baseAssembly = Assembly.GetExecutingAssembly();
            var assemblies = baseAssembly.GetReferencedAssemblies().Where((assembly) => assembly.FullName.StartsWith("BlazorDeck"));
            foreach (var assembly in assemblies)
            {
                var assemblyRef = Assembly.Load(assembly);
                types.AddRange(assemblyRef.DefinedTypes.Where(ti => ti.ImplementedInterfaces.Contains(typeof(T))));
            }
            return types;
        }
    }
}
