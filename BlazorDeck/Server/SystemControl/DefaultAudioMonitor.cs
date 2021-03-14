using System;
using System.Linq;
using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using SoundSwitch.Framework.Audio.Lister;

namespace BlazorDeck.Server.SystemControl
{
    public class DefaultAudioMonitor : IMMNotificationClient, IDisposable
    {
        private readonly MMDeviceEnumerator enumerator;
        private readonly CachedAudioDeviceLister cachedAudioDeviceLister;
        public DefaultAudioMonitor(CachedAudioDeviceLister cachedAudioDeviceLister)
        {
            enumerator = new MMDeviceEnumerator();
            this.cachedAudioDeviceLister = cachedAudioDeviceLister;
            cachedAudioDeviceLister.Refresh();
            enumerator.RegisterEndpointNotificationCallback(this);
        }

        public EventHandler<string> DefaultAudioDeviceChanged;

        public void Dispose()
        {
            enumerator.UnregisterEndpointNotificationCallback(this);
        }

        public string CurrentAudioDevice()
        {
            var endpoint = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var endpointName = cachedAudioDeviceLister.PlaybackDevices.FirstOrDefault((devices) => devices.Id == endpoint.ID)?.NameClean;
            return endpointName;
        }

        public void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
        {
            if(flow == DataFlow.Render && role == Role.Multimedia)
            {
                var endpointName = cachedAudioDeviceLister.PlaybackDevices.FirstOrDefault((devices) => devices.Id == defaultDeviceId)?.NameClean;
                DefaultAudioDeviceChanged.Invoke(this, endpointName);
            }
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
            
        }

        public void OnDeviceRemoved(string deviceId)
        {
            
        }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
           
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
            
        }
    }
}
