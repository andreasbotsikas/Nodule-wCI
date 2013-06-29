using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Nodule_wCI.Worker.Helpers
{
    /// <summary>
    /// A simple dependency walker to discover the node module dependencies
    /// </summary>
    public static class DependencyWalker
    {

        // Logger helper
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        

        public class NodeModule
        {
            public string Name { get; set; }
            public List<KeyValuePair<string, object>> dependencies { get; set; }
            public List<KeyValuePair<string, object>> devDependencies { get; set; }
            public bool UsesNodeGyp { get; set; }
            public int References { get; set; }
        }

        /// <summary>
        /// Reads the package.json and traverses the node_module folder to discover dependencies
        /// </summary>
        /// <param name="directory">The root of a node module</param>
        /// <returns></returns>
        public static Dictionary<string, NodeModule> ProcessModule(DirectoryInfo directory)
        {
            var output = new Dictionary<string, NodeModule>();
            ProcessModuleRecursively(directory,output);
            return output;
        } 

        private static void ProcessModuleRecursively(DirectoryInfo directory,Dictionary<string, NodeModule> output)
        {
            var packageFiles = directory.GetFiles("package.json");
            if (packageFiles.Count() == 1)
            {
                var dynamicObject = Json.Decode(System.IO.File.ReadAllText(packageFiles[0].FullName));
                if (!output.ContainsKey(dynamicObject.name.ToLower()))
                {
                    output.Add(dynamicObject.name.ToLower(), new NodeModule()
                    {
                        Name = dynamicObject.name,
                        References = 1,
                        UsesNodeGyp = directory.GetFiles("binding.gyp").Count() == 1,
                        dependencies = new List<KeyValuePair<string, object>>(),
                        devDependencies = new List<KeyValuePair<string, object>>()
                    });
                    if (dynamicObject.dependencies != null)
                        foreach (KeyValuePair<string, object> item in dynamicObject.dependencies)
                        {
                            output[dynamicObject.name.ToLower()].dependencies.Add(item);
                        }
                    if (dynamicObject.devDependencies != null)
                        foreach (KeyValuePair<string, object> item in dynamicObject.devDependencies)
                        {
                            output[dynamicObject.name.ToLower()].devDependencies.Add(item);
                        }
                    var mods = directory.GetDirectories("node_modules");
                    if (mods.Count() == 1)
                    {
                        foreach (var dir in mods[0].GetDirectories())
                        {
                            ProcessModuleRecursively(dir, output);
                        }
                    }
                }
                else
                {
                    // If we already have the module skip processing it 
                    // and incement the number of references
                    output[dynamicObject.name.ToLower()].References++;
                }
            }
            else
            {
                Log.Warn("No package.json found @ {0}", directory.FullName);
            }
        }

    }
}
