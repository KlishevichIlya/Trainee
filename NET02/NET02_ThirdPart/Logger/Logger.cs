using Interfaces;
using Interfaces.Enums;
using Logger.Attributes;
using Logger.CustomConfig;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;


namespace Logger
{
    public class Logger
    {
        private static readonly List<IObserver> _listeners = new List<IObserver>();
        private static readonly StartupLoggerConfigSection _loggers;

        static Logger()
        {
            _loggers = (StartupLoggerConfigSection)ConfigurationManager.GetSection("CustomLogger");
            var targets = (StartupTargetsConfigSection)ConfigurationManager.GetSection("CustomTargets");
            if (_loggers == null || targets == null)
                throw new ArgumentException("Invalid section");

            for (var i = 0; i < targets.TargetsItems.Count; i++)
            {
                var asm = Assembly.Load(targets.TargetsItems[i].Type.Split(',')[1]);
                var type = asm.GetType(
                    $"{targets.TargetsItems[i].Type.Split('.')[0]}.{targets.TargetsItems[i].Type.Split('.')[1].Split(',')[0]}",
                    true,
                    true);
                var item = (IObserver)Activator.CreateInstance(type);
                for (var j = 0; j < targets.TargetsItems[i].Count; j++)
                {
                    item.NameList.Add(targets.TargetsItems[i][j].Name);
                    item.ValueList.Add(targets.TargetsItems[i][j].Value);
                }

                _listeners.Add(item);
            }
        }

        public void Trace(string message)
        {
            Record(message, "Trace");
        }

        public void Debug(string message)
        {
            Record(message, "Debug");
        }

        public void Info(string message)
        {
            Record(message, "Info");
        }

        public void Warn(string message)
        {
            Record(message, "Warn");
        }

        public void Error(string message)
        {
            Record(message, "Error");
        }

        public void Fatal(string message)
        {
            Record(message, "Fatal");
        }

        public void Track(object o)
        {
            var typeObject = o.GetType();
            var entityAttr = typeObject.GetCustomAttribute(typeof(TrackingEntityAttribute));
            if (entityAttr == null) return;
            foreach (var property in typeObject.GetProperties())
            {
                var attr = property.GetCustomAttribute(typeof(TrackingPropertyAttribute));
                if (attr == null) continue;
                Record(
                    (attr as TrackingPropertyAttribute).Name == null
                        ? $"{property.Name} -- {property.GetValue(o)}"
                        : $"{(attr as TrackingPropertyAttribute).Name} -- {property.GetValue(o)}", "Trace");
            }

            foreach (var field in typeObject.GetFields())
            {
                var attr = field.GetCustomAttribute(typeof(TrackingPropertyAttribute));
                if (attr == null) continue;
                Record(
                    (attr as TrackingPropertyAttribute).Name == null
                        ? $"{field.Name} -- {field.GetValue(o)}"
                        : $"{(attr as TrackingPropertyAttribute).Name} -- {field.GetValue(o)}", "Trace");
            }
        }

        private void Record(string message, string levelName)
        {
            var valueMinLevel = (int)Enum.Parse(typeof(Level), _loggers.LoggerItems[0].MinLevel);
            var currentLevel = (int)Enum.Parse(typeof(Level), levelName);
            if (currentLevel < valueMinLevel) return;
            foreach (var listener in _listeners)
            {
                listener.Update(message, levelName);
            }
        }
    }
}
