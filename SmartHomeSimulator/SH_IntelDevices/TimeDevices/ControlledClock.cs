using SmartHomeSimulator.Sensors;
using SmartHomeSimulator.SH_IntelDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.TimeDevices
{
    public sealed class ControlledClock : TimeDevice
    {
        private static readonly Lazy<ControlledClock> _instance =
            new Lazy<ControlledClock>(() => new ControlledClock());

        public static ControlledClock Instance => _instance.Value;

        private DateTime _time;
        public event Action<IntelDevice> OnTimeChanged;

        private ControlledClock() : base("Controlled Clock")
        {
            
        }

        public override DateTime Now => _time;

        // Керуємо часом вручну (для симуляції / тестів)
        public void SetTime(DateTime time, IntelDevice device)
        {
            _time = time;
            OnTimeChanged?.Invoke(device);
        }
    }
}
