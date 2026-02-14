using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Devices
{
    internal class Light: Device
    {
        public bool IsOn { get; private set; }
        public Light(string name) : base(name) { }
        public void TurnOn() => IsOn = true;
        public void TurnOff() => IsOn = false;
    }
}
