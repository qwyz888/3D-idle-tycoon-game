using System;
using System.Collections.Generic;

namespace _Scripts.Infrastracture
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            var type = typeof(T);
            services[type] = service;
        }

        public static T Get<T>()
        {
            var type = typeof(T);
            if (services.TryGetValue(type, out var service))
            {
                return (T)service;
            }
            throw new Exception($"Service of type {type} not found in ServiceLocator");
        }

        public static IEnumerable<object> GetAllServices()
        {
            return services.Values;
        }

        public static void Clear() => services.Clear();
    }
}
