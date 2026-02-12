using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Sensors
{
    internal class Sensor
    {
        public string Name { get; set; }
        public Sensor(string name) { Name = name; }
    }
}
