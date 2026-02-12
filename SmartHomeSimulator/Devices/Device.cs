using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Devices
{
    internal class Device
    {
        public string Name { get; set; }
        public Device(string name) { Name = name; }
    }
}
