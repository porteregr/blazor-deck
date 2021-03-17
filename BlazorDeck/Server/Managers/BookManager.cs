using BlazorDeck.Shared.ComponentModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BlazorDeck.Server.Managers
{
    public class BookManager
    {
        private const string configDirectory = "C:\\Users\\porte\\Documents\\BlazorDeck\\";
        private const string bookPrefix = "book-";
        private const string bookExtension = ".json";
        private readonly Dictionary<string, IEnumerable<TilePageDefinition>> booksByName = new();
        public BookManager()
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            var files = Directory.GetFiles(configDirectory,bookPrefix + "*");
            foreach(var file in files)
            {
                try
                {
                    var bookName = file.Replace(configDirectory+bookPrefix, "").Replace(bookExtension, "");
                    var book = LoadBook(file);
                    booksByName.Add(bookName, book);
                }
                catch
                {
                    //Do nothing for now. Log an error later
                }
            }
        }

        private IEnumerable<TilePageDefinition> LoadBook(string path)
        {
            var configText = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<TilePageDefinition>>(configText, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }

        public IEnumerable<TilePageDefinition> GetBook(string bookName)
        {
            if(booksByName.TryGetValue(bookName, out var book))
            {
                return book;
            }
            return null;
        }

        public IEnumerable<IEnumerable<TilePageDefinition>> GetBooks()
        {
            return booksByName.Values;
        }
    }
}
