using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Nodule_wCI.Worker.Helpers
{
    /// <summary>
    /// Runs the npm install on the given pull request
    /// </summary>
    public class NpmInstaller
    {
        private const string NpmErrorOutput = "ERR!";   
        
        // Logger helper
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        
        public String Output { get; private set; }

        public bool ProcessEntrySync(string pullRequestUrl)
        {
            // Create temp path
            var workingDir = PathHelpers.GetTempFolder();
            try
            {
                var output = ExecuteNpmInstall(workingDir, pullRequestUrl);
                return output;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                // Delete temp path
                PathHelpers.DeleteRecursively(workingDir);
            }
        }

        private bool ExecuteNpmInstall(string workingDir, string pullRequestUrl)
        {
            // Initialize output
            Output = "";
            // We have to get the input from a file as gyp uses process start
            // Redirect STDERR too as npm writes there
            //http://technet.microsoft.com/en-us/library/bb490982.aspx
            var npmInstallProcess = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = workingDir,
                    FileName = "cmd.exe",
                    Arguments = String.Format("/c npm install {0} > Output.txt 2>&1", pullRequestUrl)
                }
            };

            //Fire up the process
            npmInstallProcess.Start();
            npmInstallProcess.WaitForExit();
            var exitCode = npmInstallProcess.ExitCode;
            npmInstallProcess.Close();

            Output = File.ReadAllText(Path.Combine(workingDir,"Output.txt"));
            if (exitCode != 0)
                return false;
            if (Output.Length == 0)
                return false;//Nothing ?
            else if (Output.Contains(NpmErrorOutput))
                return false;

            //Else everything seems fine
            return true;
        }

        
    }
}
