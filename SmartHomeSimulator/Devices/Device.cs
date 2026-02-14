using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Devices
{
    public class Device
    {
        // Базовий клас для пристроїв
        public string Name { get; private set; } 
        public Device(string name)
        {
            Name = name; 
        }
    }
}
