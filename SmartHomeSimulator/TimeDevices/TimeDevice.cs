using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.TimeDevices
{
    public abstract class TimeDevice
    {
        public abstract DateTime Now { get; }
        public string Name { get; private set; }
        protected TimeDevice(string name)
        {
            Name = name;
        }


        public virtual void PrintTime()
        {
            Console.WriteLine(Now.ToString("HH:mm:ss"));
        }
    }
}
