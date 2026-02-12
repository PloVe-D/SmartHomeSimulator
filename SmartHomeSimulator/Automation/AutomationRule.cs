using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSimulator.Automation
{
    public class AutomationRule
    {
        public Func<double, bool> Condition { get; }
        public Action Action { get; }
        public AutomationRule(Func<double, bool> condition, Action action)
        {
            Condition = condition;
            Action = action;
        }
        public void Evaluate(double value)
        {
            if (Condition(value)) Action();
        }
    }
}
