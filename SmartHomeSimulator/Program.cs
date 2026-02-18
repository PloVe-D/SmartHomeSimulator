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
            TemperatureSensor tempSensor = new TemperatureSensor("Living Room");
            SmartHomeHub hub = new SmartHomeHub();
            Heater heater = new Heater("Living Room Heater");
            //Clock clock = Clock.Instance;
            ControlledClock clock = ControlledClock.Instance;

            //зареєструвати пристрої та сенсори в хабі
            hub.RegisterSensor(tempSensor);          
            hub.RegisterTDevice(clock);
            hub.RegisterDevice(light);
            hub.RegisterDevice(heater);

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
                    //condition: temp => temp >= 17,
                    condition: sensor => sensor is TemperatureSensor && tempSensor.Temperature >= 17,
                    action: () => heater.TurnOff()
                ));
            //hub.AddRule(new AutomationRule
            //    (
            //        condition: temp => temp < 17,
            //        action: () => heater.TurnOn()
            //    ));
            //hub.AddRule(new AutomationRule
            //    (
            //        condition: hour => hour >= 16 && hour <= 24 || hour >= 5 && hour < 6,
            //        action: () => light.TurnOn()
            //    ));
            //hub.AddRule(new AutomationRule
            //    (
            //        condition: hour => hour < 16 && hour >= 6 || hour >= 24 || hour < 5,
            //        action: () => light.TurnOff()
            //    ));

            BlockOfProgram(heater, tempSensor, clock, light, 12, 0, 20);
            Thread.Sleep(2000);
            BlockOfProgram(heater, tempSensor, clock, light, 12, 0, 20);
            Thread.Sleep(2000);
            BlockOfProgram(heater, tempSensor, clock, light, 16, 33, 17);
            Thread.Sleep(2000);
            BlockOfProgram(heater, tempSensor, clock, light, 24, 0, 15);
            Thread.Sleep(2000);
            BlockOfProgram(heater, tempSensor, clock, light, 3, 15, 5);
            Thread.Sleep(2000);
            BlockOfProgram(heater, tempSensor, clock, light, 5, 15, 10);
            Thread.Sleep(2000);
            BlockOfProgram(heater, tempSensor, clock, light, 9, 10, 16);
            Thread.Sleep(2000);

        }

        public static void StatusCheck(TemperatureSensor tempSensor, Heater heater, Light light, ControlledClock clock)
        {
            Console.WriteLine(
                $"{tempSensor.Name}: {tempSensor.Temperature}°C, {heater.Name} state: {(heater.IsOn ? "On":"Off")} \n" +
                $"It's {clock.Now:HH:mm} and the {light.Name} state: {(light.IsOn ? "On" : "Off")}\n"
                );
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
        public static void BlockOfProgram(Heater heater, TemperatureSensor tempSensor, ControlledClock clock,  Light light, int h, int min, int temp) {
            clock.SetTime(DateTime.Today.AddHours(h).AddMinutes(min));
            tempSensor.SetTemperature(temp); //problem
            StatusCheck(tempSensor, heater, light, clock);
        }
    }
}
