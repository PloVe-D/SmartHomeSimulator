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
        private List<Device> devices = new List<Device>();
        private List<Sensor> sensors = new List<Sensor>();
        private List<AutomationRule> rules = new List<AutomationRule>();

        public void RegisterDevice(Device device)
        {
            devices.Add(device);
        }

        public void RegisterSensor(Sensor sensor)
        {
            sensors.Add(sensor);
            // Підписка на події сенсора
            sensor.OnTemperatureChanged += value => EvaluateRules(value);
        }

        public void AddRule(AutomationRule rule)
        {
            rules.Add(rule);
        }

        private void EvaluateRules(double value)
        {
            foreach (var rule in rules)
            {
                rule.Evaluate(value);
            }
        }
    }
