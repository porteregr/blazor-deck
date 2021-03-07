using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BlazorDeck.Server.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BlazorDeck.Server.SystemControl
{
    public class WindowManagement
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public event EventHandler<string> WindowChanged;

        private readonly Task windowListener;
        private readonly TimeSpan pullDelay = TimeSpan.FromMilliseconds(250);

        public WindowManagement()
        {
            windowListener = Task.Run(PollForActiveWindow);
        }

        private async Task PollForActiveWindow()
        {
            var previousWindow = "";
            while (true)
            {
                var currentWindow = GetActiveWindow();
                if (currentWindow != previousWindow)
                {

                    WindowChanged.Invoke(this, currentWindow);
                    previousWindow = currentWindow;
                }

                await Task.Delay(pullDelay);
            }
        }

        public string GetActiveWindow()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }



        
    }
}
