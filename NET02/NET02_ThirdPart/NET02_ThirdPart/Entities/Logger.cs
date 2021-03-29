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
        private static readonly List<IObserver> _listeners = new List<IObserver>();
        private static readonly StartupLoggerConfigSection _loggers;

        static Logger()
        {
            _loggers = (StartupLoggerConfigSection)ConfigurationManager.GetSection("CustomLogger");
            var targets = (StartupTargetsConfigSection)ConfigurationManager.GetSection("CustomTargets");

            for (var i = 0; i < targets.TargetsItems.Count; i++)
            {
                var name = targets.TargetsItems[i][i].Name;
                var value = targets.TargetsItems[i][i].Value;

                var asm = Assembly.LoadFrom($"{targets.TargetsItems[i].Type.Split(',')[1]}.dll");
                var type = asm.GetType(
                    $"{targets.TargetsItems[i].Type.Split('.')[0]}.{targets.TargetsItems[i].Type.Split('.')[1].Split(',')[0]}",
                    true,
                    true);
                var item = (IObserver)Activator.CreateInstance(type);
                _listeners.Add(item);
            }
        }

        public void Trace(string message)
        {
            Record(message, 1, false);
        }

        public void Debug(string message)
        {
            Record(message, 2, false);
        }

        public void Info(string message)
        {
            Record(message, 3, false);
        }

        public void Warn(string message)
        {
            Record(message, 4, false);
        }

        public void Error(string message)
        {
            Record(message, 5, false);
        }

        public void Fatal(string message)
        {
            Record(message, 6, false);
        }

        public void Track(object o)
        {
            var typeObject = o.GetType();
            var entityAttr = typeObject.GetCustomAttribute(typeof(TrackingEntityAttribute));
            if (entityAttr == null) return;
            foreach (var property in typeObject.GetProperties())
            {
                if (property.GetCustomAttribute(typeof(TrackingPropertyAttribute)) == null) continue;
                foreach (var namedAttr in property.GetCustomAttributesData())
                {
                    Record(
                        namedAttr.NamedArguments?.Count == 0
                            ? $"{property.Name} -- {property.GetValue(o)}"
                            : $"{namedAttr.NamedArguments?[0].TypedValue.Value} -- {property.GetValue(o)}", 1, true);
                }
            }

            foreach (var field in typeObject.GetFields())
            {
                if (field.GetCustomAttribute(typeof(TrackingPropertyAttribute)) == null) continue;
                foreach (var namedAttr in field.GetCustomAttributesData())
                {
                    Record(
                        namedAttr.NamedArguments.Count == 0
                            ? $"{field.Name} -- {field.GetValue(o)}"
                            : $"{namedAttr.NamedArguments[0].TypedValue.Value} -- {field.GetValue(o)}", 1, true);
                }
            }
        }

        private void Record(string message, int level, bool isTrack)
        {
            var valueMinLevel = (int)Enum.Parse(typeof(Level), _loggers.LoggerItems[0].MinLevel);
            if (level < valueMinLevel && isTrack == false) return;
            var name = (Level)level;
            foreach (var listener in _listeners)
            {
                listener.Update(message, name.ToString());
            }
        }
    }
}
