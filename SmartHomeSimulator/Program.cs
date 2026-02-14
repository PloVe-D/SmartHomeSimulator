using SmartHomeSimulator.Automation;
using SmartHomeSimulator.Devices;
using SmartHomeSimulator.Sensors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
            StatusCheck(tempSensor, light);
           
            //змінити температуру -> спрацює правило -> вивести оновлений стан світла/температури
            tempSensor.SetTemperature(22);
            StatusCheck(tempSensor, light);

            tempSensor.SetTemperature(30);
            StatusCheck(tempSensor, light);

        }

        public static void StatusCheck(TemperatureSensor tempSensor, Light light)
        {
            Console.WriteLine($"Temperature: {tempSensor.Temperature}°C, Light state: {(light.IsOn ? "On" : "Off")}");
        }
    }
}
