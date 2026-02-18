using System;
using SmartHomeSimulator.SH_IntelDevices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Sensors
{
    public class TemperatureSensor : Sensor
    {
        public double Temperature { get; private set; }
        public event Action<IntelDevice> OnTemperatureChanged;
        public TemperatureSensor(string name) : base(name) { }
        public void SetTemperature(double temp, IntelDevice device)
        {
            Temperature = temp;
            OnTemperatureChanged?.Invoke(device);
        }
    }
}
