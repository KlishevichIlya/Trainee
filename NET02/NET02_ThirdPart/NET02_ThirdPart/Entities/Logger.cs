using Interfaces;
using NET02_ThirdPart.Attributes;
using NET02_ThirdPart.CustomConfig;
using NET02_ThirdPart.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace NET02_ThirdPart.Entities
{
    public class Logger
    {
        private readonly List<IObserver> _listeners = new List<IObserver>();
        private readonly StartupLoggerConfigSection _loggers;

        public Logger()
        {
            _loggers = (StartupLoggerConfigSection)ConfigurationManager.GetSection("CustomLogger");
            var targets = (StartupTargetsConfigSection)ConfigurationManager.GetSection("CustomTargets");

            for (var i = 0; i < targets.TargetsItems.Count; i++)
            {
                var asm = Assembly.LoadFrom(targets.TargetsItems[i].Assembly);
                var type = asm.GetType($"{targets.TargetsItems[i].Namespace}.{targets.TargetsItems[i].Class}", true,
                    true);
                var item = (IObserver)Activator.CreateInstance(type);
                _listeners.Add(item);
            }
        }

        public void Record(string message)
        {
            var valueMinLevel = (int)Enum.Parse(typeof(Level), _loggers.LoggerItems[0].MinLevel);

            foreach (var item in (int[])Enum.GetValues(typeof(Level)))
            {
                if (item < valueMinLevel) continue;
                var name = (Level)item;
                foreach (var listener in _listeners)
                {
                    listener.Update(message, name.ToString());
                }
            }
        }

        public void Track(object o)
        {
            var typeObject = o.GetType();

            var attrs = typeObject.GetCustomAttributes(false);
            var fields = typeObject.GetProperties();

            foreach (var listener in _listeners)
            {
                foreach (var classAttr in attrs)
                {
                    if (!(classAttr is TrackingEntityAttribute)) continue;
                    foreach (var field in fields)
                    {
                        foreach (var attrField in field.CustomAttributes)
                        {
                            if (attrField.AttributeType.Name != "TrackingPropertyAttribute") continue;
                            listener.Update(
                                attrField.NamedArguments.Count == 0
                                    ? $"{field.Name} -- {field.GetValue(o)}"
                                    : $"{attrField.NamedArguments[0].TypedValue.Value} -- {field.GetValue(o)}",
                                "Trace");
                        }
                    }
                }
            }
        }
    }
}
