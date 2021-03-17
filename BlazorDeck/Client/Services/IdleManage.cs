using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components;

namespace BlazorDeck.Client.Services
{
    public class IdleManager
    {
        private readonly NavigationManager navigationManager;
        private readonly BlazorTimer blazorTimer;
        private readonly HttpClient httpClient;
        private bool isIdle = false;
        public IdleManager(NavigationManager navigationManager, BlazorTimer blazorTimer, HttpClient httpClient)
        {
            this.navigationManager = navigationManager;
            this.blazorTimer = blazorTimer;
            this.httpClient = httpClient;
            ConfigureTimer();
        }

        public EventHandler IsIdle;

        private void ConfigureTimer()
        {
            blazorTimer.OnElapsed += Ping;
            blazorTimer.SetTimer(TimeSpan.FromSeconds(30).TotalMilliseconds);
        }

        private async void Ping()
        {
            try
            {
                var response = await httpClient.GetAsync("api/ping");
                if (!response.IsSuccessStatusCode)
                {
                    IsIdle?.Invoke(this, null);
                    isIdle = true;
                }
                else
                {
                    if (isIdle)
                    {
                        Refresh();
                    }
                    isIdle = false;
                }
            }
            catch (Exception e)
            {
                IsIdle?.Invoke(this, null);
                isIdle = true;
            }
        }

        private void Refresh()
        {
            navigationManager.NavigateTo(navigationManager.BaseUri, true);
        }
    }
}
