﻿using System;
using Newtonsoft.Json;

namespace BlazorDeck.Shared.ComponentModels
{
    public interface IServerEvent: ITileProperty
    {
        public event EventHandler EventActive;
        public event EventHandler EventInactive;
        [JsonIgnore]
        public bool State { get; }
    }
}
