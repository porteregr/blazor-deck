using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BlazorDeck.Server.SystemControl
{
    public class VolumeControl
    {
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public void Mute()
        {
            SendMessageW(IntPtr.Zero, WM_APPCOMMAND, IntPtr.Zero,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        //private void btnDecVol_Click(object sender, EventArgs e)
        //{
        //    SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
        //        (IntPtr)APPCOMMAND_VOLUME_DOWN);
        //}

        //private void btnIncVol_Click(object sender, EventArgs e)
        //{
        //    SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
        //        (IntPtr)APPCOMMAND_VOLUME_UP);
        //}
    }
}
