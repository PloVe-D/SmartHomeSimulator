using SmartHomeSimulator.TimeDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Sensors
{
    public sealed class Clock : TimeDevice
    {
        private static readonly Lazy<Clock> _instance =         //private - лише в цьому класі, static - спільний для всіх екземплярів класу, _instance - ім'я змінної,
                     new Lazy<Clock>(() => new Clock());        //Lazy - відкладена ініціалізація, яка створює екземпляр класу лише при першому зверненні до нього
                                                                //readonly - ініціалізується лише один раз, 
                                                                //Lazy- відкладена ініціалізація, яка створює екземпляр класу лише при першому зверненні до нього
                                                                //нова функція Lazy, для класу Clock, не передає ніяких параметрів, повертає новий екземпляр класу Clock, який створюється за допомогою лямбда-виразу
                                                                //() => new Clock() - це лямбда-вираз, який створює новий екземпляр класу Clock, тобто він є функція без імені 
        
        public static Clock Instance => _instance.Value;
        private Clock() : base("Global Clock")
        {
        }

        public override DateTime Now => DateTime.Now;
    }
}
