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
        private const string NpmConcurrencyErrorOutput = "npm ERR! Error: EPERM";
        private const string NpmNetworkErrorOutput = "fatal: unable to connect to";   
        
        // Logger helper
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        
        public String Output { get; private set; }

        public bool ProcessEntrySync(string workingDir, string pullRequestUrl)
        {
            try
            {
                var output = ExecuteNpmInstall(workingDir, pullRequestUrl);
                return output;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private bool ExecuteNpmInstall(string workingDir, string pullRequestUrl)
        {
            // Initialize output
            var outputBuilder = new StringBuilder();
            // We have to get the input from a file as gyp uses process start
            // Redirect STDERR too as npm writes there
            //http://technet.microsoft.com/en-us/library/bb490982.aspx
            var npmInstallProcess = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = workingDir,
                    FileName = "cmd.exe",
                    Arguments = String.Format("/c npm install {0} --cache=\"{1}\"> Output.txt 2>&1", pullRequestUrl, Path.Combine(workingDir,"cache"))
                }
            };
            // Use a local cache in order to avoid concurrent builds locking

            outputBuilder.AppendLine("Performing the following command");
            outputBuilder.AppendLine(npmInstallProcess.StartInfo.Arguments.Substring(3));

            //Fire up the process
            npmInstallProcess.Start();
            npmInstallProcess.WaitForExit();
            var exitCode = npmInstallProcess.ExitCode;
            npmInstallProcess.Close();
            
            // Gather the output
            outputBuilder.AppendLine("--- Console output ---");
            outputBuilder.AppendLine(File.ReadAllText(Path.Combine(workingDir,"Output.txt")));

            if (File.Exists(Path.Combine(workingDir, "npm-debug.log")))
            {
                outputBuilder.AppendLine("--- NPM DEBUG LOG ---");
                outputBuilder.AppendLine(File.ReadAllText(Path.Combine(workingDir, "npm-debug.log")));
            }

            Output = outputBuilder.ToString();

            if (exitCode != 0)
                return false;
            if (Output.Length == 0) // Not going to happen, but still
                throw new ApplicationException(string.Format("Empty output on npm {0}", pullRequestUrl));
            else if (Output.Contains(NpmConcurrencyErrorOutput))// If EPERM error occures then it's most likely a failure to get the lock file (TODO: make a proper regex)
                throw new ApplicationException(string.Format("NPM can't acquire lock : {0}", Output));
            else if (Output.Contains(NpmNetworkErrorOutput))// If "unable to connect" apprears, then it's a network issue
                throw new ApplicationException(string.Format("NPM has network issues : {0}", Output));
            else if (Output.Contains(NpmErrorOutput))
                return false;

            //Else everything seems fine
            return true;
        }

        
    }
}
