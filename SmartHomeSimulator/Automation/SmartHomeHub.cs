using SmartHomeSimulator.Devices;
using SmartHomeSimulator.Sensors;
using SmartHomeSimulator.TimeDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Automation
{
    public class SmartHomeHub
    {
        // Зберігання пристроїв, сенсорів та правил
        private List<Device> devices = new List<Device>();
        private List<Sensor> sensors = new List<Sensor>();
        private List<AutomationRule> rules = new List<AutomationRule>();
        private List<TimeDevice> tDevices = new List<TimeDevice>();

        // Реєстрація пристроїв 
        public void RegisterDevice(Device device)
        {
            devices.Add(device);
        }
        // Реєстрація сенсорів
        public void RegisterSensor(Sensor sensor)
        {
            sensors.Add(sensor);

            // Підписка на події temperature сенсора
            if (sensor is TemperatureSensor tempSensor)
            {
                tempSensor.OnTemperatureChanged += value => EvaluateRules(value);
            }
            
        }
        public void RegisterTDevice( TimeDevice timeDevice)
        {
            tDevices.Add(timeDevice);
            // Підписка на події temperature сенсора
           
            if (timeDevice is ControlledClock clock)
            {
                clock.OnTimeChanged += value => EvaluateRules(value);
            }
        }

        // Додавання правил автоматизації
        public void AddRule(AutomationRule rule)
        {
            rules.Add(rule);
        }
        // Оцінка правил при зміні температури
        private void EvaluateRules(double value)
        {
            foreach (var rule in rules)
            {
                rule.Evaluate(value);
            }
        }
    }
}