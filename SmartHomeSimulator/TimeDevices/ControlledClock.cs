using SmartHomeSimulator.Sensors;
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

        private ControlledClock() : base("Controlled Clock")
        {
            _time = DateTime.Today.AddHours(14).AddMinutes(30);
        }

        public override DateTime Now => _time;

        // Керуємо часом вручну (для симуляції / тестів)
        public void SetTime(DateTime time)
        {
            _time = time;
        }
    }
}
