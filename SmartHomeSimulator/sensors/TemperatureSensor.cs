using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Sensors
{
    public class TemperatureSensor : Sensor
    {
        public double Temperature { get; private set; }
        public event Action<double> OnTemperatureChanged;
        public TemperatureSensor(string name) : base(name) { }
        public void SetTemperature(double temp)
        {
            Temperature = temp;
            OnTemperatureChanged?.Invoke(temp);
        }
    }
}
