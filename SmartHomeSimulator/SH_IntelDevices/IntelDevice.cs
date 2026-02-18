using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.SH_IntelDevices
{
    public class IntelDevice
    {
        public string Name { get; private set; }
        public IntelDevice(string name)
        {
            Name = name;
        }
    }
}
