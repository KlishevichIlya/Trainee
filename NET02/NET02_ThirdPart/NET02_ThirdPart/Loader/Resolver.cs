using System;
using System.Reflection;

namespace NET02_ThirdPart.Loader
{
    public static class Resolver
    {
        private static volatile bool _loaded;

        public static void RegisterDependencyResolver()
        {
            if (!_loaded)
            {
                AppDomain.CurrentDomain.AssemblyResolve += OnResolve;
                _loaded = true;
            }
        }

        private static Assembly OnResolve(object sender, ResolveEventArgs args)
        {
            var execAssembly = Assembly.GetExecutingAssembly();
            var resourceName = String.Format("{0}.{1}.dll",
                execAssembly.GetName().Name,
                new AssemblyName(args.Name).Name);

            using (var stream = execAssembly.GetManifestResourceStream(resourceName))
            {
                int read = 0, toRead = (int)stream.Length;
                var data = new byte[toRead];

                do
                {
                    var n = stream.Read(data, read, data.Length - read);
                    toRead -= n;
                    read += n;
                } while (toRead > 0);

                return Assembly.Load(data);
            }
        }
    }
}
