using System;
using SmartHomeSimulator.SH_IntelDevices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.TimeDevices
{
    public abstract class TimeDevice : IntelDevice
    {
        public abstract DateTime Now { get; }
        
        protected TimeDevice(string name) : 
            base(name){}


        public virtual void PrintTime()
        {
            Console.WriteLine(Now.ToString("HH:mm:ss"));
        }
    }
}
