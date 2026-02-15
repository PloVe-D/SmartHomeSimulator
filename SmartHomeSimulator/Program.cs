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

            //створити правило: якщо температура >20 та <25, увімкнути cвітло
            hub.AddRule(new AutomationRule
                (
                    condition: temp => temp > 20 && temp < 25,
                    action: () => light.TurnOn()
                ));
            hub.AddRule(new AutomationRule
                (
                    condition: temp => temp <= 20 || temp >= 25,
                    action: () => light.TurnOff()
                ));

            //задати температуру та вивести стан світла/температури
            tempSensor.SetTemperature(19);
            StatusCheck(tempSensor, light, clock);
            Thread.Sleep(2000);
            //змінити температуру -> спрацює правило -> вивести оновлений стан світла/температури
            tempSensor.SetTemperature(22);
            StatusCheck(tempSensor, light, clock);
            Thread.Sleep(2000);
            tempSensor.SetTemperature(30);
            StatusCheck(tempSensor, light, clock);

        }

        public static void StatusCheck(TemperatureSensor tempSensor, Light light, ControlledClock clock)
        {
            //Console.WriteLine($"Temperature: {tempSensor.Temperature}°C, Light state: {(light.IsOn ? "On" : "Off")} and it's {Clock.Instance.Now.ToString("HH:mm")} О'clock");
            Console.WriteLine($"Temperature: {tempSensor.Temperature}°C, Light state: {(light.IsOn ? "On" : "Off")} and it's {clock.Now.ToString("HH:mm")} О'clock");
        }
    }
}
