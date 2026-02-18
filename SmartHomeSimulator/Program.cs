using SmartHomeSimulator.Automation;
using SmartHomeSimulator.Devices;
using SmartHomeSimulator.Sensors;
using SmartHomeSimulator.TimeDevices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartHomeSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ініціалізація хаба, пристроїв, сенсорів
            Light light = new Light("Living Room Light");
            TemperatureSensor tempSensor = new TemperatureSensor("Living Room Temp Sensor");
            SmartHomeHub hub = new SmartHomeHub();
            //Clock clock = Clock.Instance;
            ControlledClock clock = ControlledClock.Instance;

            //зареєструвати пристрої та сенсори в хабі
            hub.RegisterSensor(tempSensor);
            hub.RegisterDevice(light);
            hub.RegisterTDevice(clock);

            //створити правило: якщо температура >20 та <25, увімкнути cвітло
            //hub.AddRule(new AutomationRule
            //    (
            //        condition: temp => temp > 20 && temp < 25,          //bool
            //        action: () => light.TurnOn()                        //what to do if yes
            //    ));
            //hub.AddRule(new AutomationRule
            //    (
            //        condition: temp => temp <= 20 || temp >= 25,
            //        action: () => light.TurnOff()
            //    ));
            //var hour = clock.Now.Hour;
            hub.AddRule(new AutomationRule
                (
                    condition: hour => hour >= 16 && hour <= 24 || hour >= 5 && hour < 6,
                    action: () => light.TurnOn()
                ));
            hub.AddRule(new AutomationRule
                (
                    condition: hour => hour < 16 && hour >= 6 || hour >= 24 || hour < 5,
                    action: () => light.TurnOff()
                ));

            clock.SetTime(DateTime.Today.AddHours(12).AddMinutes(00));
            StatusCheck(light, clock);
            Thread.Sleep(2000);
            clock.SetTime(DateTime.Today.AddHours(22).AddMinutes(00));
            StatusCheck(light, clock);
            Thread.Sleep(2000);
            clock.SetTime(DateTime.Today.AddHours(03).AddMinutes(00));
            StatusCheck(light, clock);
            Thread.Sleep(2000);
            clock.SetTime(DateTime.Today.AddHours(05).AddMinutes(00));
            StatusCheck(light, clock);
            Thread.Sleep(2000);
            //int hour = clock.Now.Hour;
            //Console.WriteLine($"Current time: {hour.ToString()}");

            ////задати температуру та вивести стан світла/температури
            //tempSensor.SetTemperature(19);
            //StatusCheck(tempSensor, light, clock);
            //Thread.Sleep(2000);
            ////змінити температуру -> спрацює правило -> вивести оновлений стан світла/температури
            //tempSensor.SetTemperature(22);
            //StatusCheck(tempSensor, light, clock);
            //Thread.Sleep(2000);
            //tempSensor.SetTemperature(30);
            //StatusCheck(tempSensor, light, clock);

        }

        public static void StatusCheck(TemperatureSensor tempSensor, Light light, ControlledClock clock)
        {
            //Console.WriteLine($"Temperature: {tempSensor.Temperature}°C, Light state: {(light.IsOn ? "On" : "Off")} and it's {Clock.Instance.Now.ToString("HH:mm")} О'clock");
            Console.WriteLine($"Temperature: {tempSensor.Temperature}°C, Light state: {(light.IsOn ? "On" : "Off")} and it's {clock.Now.ToString("HH:mm")} О'clock");
        }
        public static void StatusCheck( Light light, ControlledClock clock)
        {
            //Console.WriteLine($"Temperature: {tempSensor.Temperature}°C, Light state: {(light.IsOn ? "On" : "Off")} and it's {Clock.Instance.Now.ToString("HH:mm")} О'clock");
            Console.WriteLine($"Light state: {(light.IsOn ? "On" : "Off")} and it's {clock.Now.ToString("HH:mm")} О'clock");
        }
    }
}
