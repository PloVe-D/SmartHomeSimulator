using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Sensors
{
    public class Sensor
    {
        public string Name { get; private set; }
        public Sensor(string name) 
        { 
            Name = name; 
        }
        //public event Action OnTemperatureChanged;

        //public void OnTemperatureChanged(double value)
        //{
        //    // Подія для зміни температури
        //}
    }
}
