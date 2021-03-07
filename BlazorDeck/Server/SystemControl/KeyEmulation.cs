using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace BlazorDeck.Server.SystemControl
{
    public class KeyEmulation
    {
        private InputSimulator inputSimulator = new InputSimulator();
        public void PressKey(VirtualKeyCode keyCode)
        {
            inputSimulator.Keyboard.KeyPress(keyCode);
        }
        public void PressChord(IEnumerable<VirtualKeyCode> keyCodes)
        {
            inputSimulator.Keyboard.ModifiedKeyStroke(keyCodes.Take(keyCodes.Count() - 1), keyCodes.Last());
        }
    }
}
