using System.Reflection;

namespace ShoppingBlazor.Infrastructure.Extensions;

public static class AssemblyExtension
{
    public static Assembly[] GetProjectAssemblies()
    {
        IList<Assembly> assemblies = [];

        var baseDir = AppDomain.CurrentDomain.BaseDirectory;

        var dllPaths = Directory.GetFiles(baseDir, "ShoppingBlazor.*.dll");

        foreach (var dllPath in dllPaths)
        { 
            assemblies.Add(Assembly.LoadFile(dllPath));
        }

        return assemblies.ToArray();
    }
}