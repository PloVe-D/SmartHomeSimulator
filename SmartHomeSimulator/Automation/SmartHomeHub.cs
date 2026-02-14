using SmartHomeSimulator.Devices;
using SmartHomeSimulator.Sensors;
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