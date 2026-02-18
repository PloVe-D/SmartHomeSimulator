using System;
using SmartHomeSimulator.SH_IntelDevices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Automation
{
    public class AutomationRule
    {
        public Func<IntelDevice, bool> Condition { get; }
        public Action Action { get; }
        public AutomationRule(Func<IntelDevice, bool> condition, Action action)
        {
            Condition = condition;
            Action = action;
        }
        public void Evaluate(IntelDevice intelDevice)
        {
            if (Condition(intelDevice)) 
                Action();
        }
    }
}
