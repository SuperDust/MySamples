using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExtensionsInject
{
    public static class ServiceInjectExtensions
    {
        public static void AddTransientList(this IServiceCollection services, System.Reflection.Assembly assembly)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            foreach (Type item in assembly.GetTypes())
            {
                if (item.GetCustomAttributes(typeof(Transient)).Count() > 0)
                {
                    if (!item.IsInterface)
                    {
                        services.AddTransient(item.GetInterfaces()[0], item);
                    }
                }
            }
        }

        public static void AddScopedList(this IServiceCollection services, System.Reflection.Assembly assembly)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            foreach (Type item in assembly.GetTypes())
            {
                if (item.GetCustomAttributes(typeof(Scoped)).Count() > 0)
                {
                    if (!item.IsInterface)
                    {
                        services.AddTransient(item.GetInterfaces()[0], item);
                    }
                }
            }
        }

        public static void AddSingletonList(this IServiceCollection services, System.Reflection.Assembly assembly)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            foreach (Type item in assembly.GetTypes())
            {
                if (item.GetCustomAttributes(typeof(Singleton)).Count() > 0)
                {
                    if (!item.IsInterface)
                    {
                        services.AddTransient(item.GetInterfaces()[0], item);
                    }
                }
            }
        }
    }
}