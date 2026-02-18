using SmartHomeSimulator.SH_IntelDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Sensors
{
    public class Sensor : IntelDevice
    {
        protected Sensor(string name):
            base(name) { }    
    }
}
