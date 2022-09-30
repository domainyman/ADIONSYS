using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.StartLoading
{
    public static class Constants
    {
        //The folder name which contains the plugin DLLs
        public const string FolderName = "Plugins";
    }

    public class PluginLoader
    {
        public static List<IPlugin>? Plugins { get; set; }

        public void LoadPlugins()
        {
            Plugins = new List<IPlugin>();

            //Load the DLLs from the Plugins directory
            if (Directory.Exists(Constants.FolderName))
            {
                string[] files = Directory.GetFiles(Constants.FolderName);
                foreach (string file in files)
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(Path.GetFullPath(file));
                        Console.WriteLine(file);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(Constants.FolderName);
                string[] files = Directory.GetFiles(Constants.FolderName);
                foreach (string file in files)
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(Path.GetFullPath(file));
                        Console.WriteLine(file);
                    }
                }
            }

            Type interfaceType = typeof(IPlugin);
            //Fetch all types that implement the interface IPlugin and are a class
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();
            //Console.WriteLine(types);
            foreach (Type type in types)
            {
                if (type is not null)
                {
                    Plugins.Add((IPlugin)Activator.CreateInstance(type));
                }
                //Create a new instance of all found types
            }
        }
    }
    //private void PlugFolder()
    //private static Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();

    //    PlugFolder();
    //    LoadingPlugs();
    //        foreach (var key in Plugins.Keys)
    //        {
    //            Plugins[key].run();
    //}
    //{
    //    string PathBase = AppDomain.CurrentDomain.BaseDirectory;
    //    string path = Path.Combine(PathBase, "Plugin");
    //    bool directoryExists = Directory.Exists(path);
    //    if (directoryExists)
    //    {

    //    }
    //    else
    //    {
    //        Directory.CreateDirectory(path);
    //    }
    //}

    //private void PluginDictionary()
    //{
    //    foreach (var key in Plugins.Keys)
    //    {
    //        Plugins[key].run();
    //    }
    //}

    //private static void LoadingPlugs()
    //{
    //    string PathBase = AppDomain.CurrentDomain.BaseDirectory;
    //    string path = Path.Combine(PathBase, "Plugin");
    //    foreach (var dll in Directory.GetFiles(path,"*.dll"))
    //    {
    //        AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(dll);
    //        Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
    //        IPlugin plugin = Activator.CreateInstance(assembly.GetTypes()[0]) as IPlugin;
    //        Console.WriteLine(assembly.GetTypes()[0]);
    //        MessageBox.Show(dll, "Message", MessageBoxButtons.OK);
    //        Plugins.Add(Path.GetFileNameWithoutExtension(dll), plugin);
    //    }
    //}
}
