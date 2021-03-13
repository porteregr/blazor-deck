using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDeck.Shared.ComponentModels;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace BlazorDeck.Client.Services.ActionRunners
{
    public class NativeActionRunner: IActionRunner
    {
        public IJSRuntime jSRuntime;
        public NativeActionRunner(IJSRuntime js)
        {
            jSRuntime = js;
        }

        public Task RunAction(ITileAction action)
        {
            var actionJson = JsonConvert.SerializeObject(action);
            return jSRuntime.InvokeVoidAsync("external.sendMessage", "blazorDeck"+actionJson).AsTask();
        }
    }
}
