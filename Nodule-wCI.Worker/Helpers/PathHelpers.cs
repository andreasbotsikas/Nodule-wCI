using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodule_wCI.Worker.Helpers
{
    internal static class PathHelpers
    {

        /// <summary>
        /// Create a temp folder and returns the path
        /// </summary>
        /// <returns></returns>
        public static string GetTempFolder()
        {
            var path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(path);
            return path;
        }

        /// <summary>
        /// Deletes a folder removing files too
        /// </summary>
        /// <param name="extractPath"></param>
        public static void DeleteRecursively(string extractPath)
        {
            string[] files = Directory.GetFiles(extractPath);
            string[] dirs = Directory.GetDirectories(extractPath);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteRecursively(dir);
            }

            Directory.Delete(extractPath, false);

        }

    }
}
