﻿/********************************************************************
* Copyright (C) 2015-2017 Antoine Aflalo
*
* This program is free software; you can redistribute it and/or
* modify it under the terms of the GNU General Public License
* as published by the Free Software Foundation; either version 2
* of the License, or (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NAudio.CoreAudioApi;
using Serilog;
using SoundSwitch.Common.Framework.Audio.Device;
using SoundSwitch.Model;
using SoundSwitch.Util.Timer;

namespace SoundSwitch.Framework.Audio.Lister
{
    public class CachedAudioDeviceLister
    {
        /// <inheritdoc />
        public IReadOnlyCollection<DeviceFullInfo> PlaybackDevices
        {
            get
            {
                lock (_lock)
                {
                    return _playbackDevices;
                }
            }
        }

        /// <inheritdoc />
        public IReadOnlyCollection<DeviceFullInfo> RecordingDevices
        {
            get
            {
                lock (_lock)
                {
                    return _recordingDevices;
                }
            }
        }

        private readonly DeviceState _state;
        private readonly DebounceDispatcher _dispatcher = new();
        private readonly object _lock = new();
        private IReadOnlyCollection<DeviceFullInfo> _playbackDevices = new List<DeviceFullInfo>();
        private IReadOnlyCollection<DeviceFullInfo> _recordingDevices = new List<DeviceFullInfo>();

        public CachedAudioDeviceLister(DeviceState state)
        {
            _state = state;
        }

        private void UpdatePlayback()
        {
            Log.Information("[{@State}] Refreshing playback", _state);
            using var enumerator = new MMDeviceEnumerator();
            _playbackDevices = CreateDeviceList(enumerator.EnumerateAudioEndPoints(DataFlow.Render, _state));
            Log.Information("[{@State}] Refreshed playbacks: {@Playbacks}", _state, _playbackDevices.Select(info => new { info.Name, info.Id }));
        }

        private void UpdateRecording()
        {
            Log.Information("[{@State}] Refreshing recording", _state);
            using var enumerator = new MMDeviceEnumerator();
            _recordingDevices = CreateDeviceList(enumerator.EnumerateAudioEndPoints(DataFlow.Capture, _state));
            Log.Information("[{@State}] Refreshed recordings: {@Recordings}", _state, _recordingDevices.Select(info => new { info.Name, info.Id }));
        }

        public void Refresh()
        {
            lock (_lock)
            {
                Log.Information("[{@State}] Refreshing all devices", _state);
                var threadPlayback = new Thread(UpdatePlayback)
                {
                    Name = $"Playback Refresh {_state}",
                    IsBackground = true
                };
                var threadRecording = new Thread(UpdateRecording)
                {
                    Name = $"Recording Refresh {_state}",
                    IsBackground = true
                };

                threadPlayback.Start();
                threadRecording.Start();

                threadPlayback.Join();
                threadRecording.Join();

                Log.Information("[{@State}] Refreshed all devices", _state);
            }
        }

        private static IReadOnlyCollection<DeviceFullInfo> CreateDeviceList(MMDeviceCollection collection)
        {
            var sortedDevices = new SortedList<string, DeviceFullInfo>();
            foreach (var device in collection)
            {
                try
                {
                    var deviceInfo = new DeviceFullInfo(device);
                    if (string.IsNullOrEmpty(deviceInfo.Name))
                    {
                        continue;
                    }

                    sortedDevices.Add(device.ID, deviceInfo);
                }
                catch (Exception)
                {
                    Log.Warning("Can't get name of device {device}", device.ID);
                }
            }

            return sortedDevices.Values.ToArray();
        }
    }
}