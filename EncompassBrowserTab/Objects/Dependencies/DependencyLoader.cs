using CefSharp;
using CefSharp.WinForms;
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EncompassBrowserTab.Objects.Dependencies
{

    public static class DependencyLoader
    {

        public static string DependencyPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        private static List<Dependency> dependencies;

        public static void LoadDependencies()
        {

            // add the dependencies to the list
            dependencies = new List<Dependency>();
            dependencies.Add(new Dependency
            {
                Name = "CefSharp",
                FileExtension = "zip",
                Version = ""
            });

            try
            {

                foreach (var dependency in dependencies)
                {

                    // Check if there is a matching verison already on disk
                    if (File.Exists(DependencyPath + dependency.Filename))
                    {
                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(DependencyPath + dependency.Filename);
                        if (versionInfo.FileVersion != null && versionInfo.FileVersion != dependency.Version)
                        {
                            SaveDependency(dependency);
                        }
                    }
                    else
                    {
                        SaveDependency(dependency);
                    }

                }

            }
            catch (Exception ex)
            {

            }

            if (dependencies.Any(a => a.Name.Contains("CefSharp")))
            {
                InitializeCef();
            }
        }


        private static void SaveDependency(Dependency dependency)
        {
            byte[] dependencyBytes = EncompassApplication.Session.DataExchange.GetCustomDataObject(dependency.Filename).Data;

            if (dependencyBytes != null)
            {
                System.IO.Directory.CreateDirectory(DependencyPath);
                File.WriteAllBytes(DependencyPath + dependency.Filename, dependencyBytes);

                if (dependency.FileExtension == "zip")
                {
                    unzipDependencies(DependencyPath + dependency.Filename);
                }
                else
                {
                    File.WriteAllBytes(DependencyPath + dependency.Filename, dependencyBytes);
                }
            }
            else
            {
                // TODO: Need to log that the dependency was not found in the Encompass customdataobjects
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void InitializeCef()
        {

            var settings = new CefSettings();

            settings.LogFile = Path.Combine(DependencyPath, "Debug.log"); //You can customise this path
	        settings.LogSeverity = LogSeverity.Verbose; // You can change the log level
            //settings.DisableGpuAcceleration();
            //settings.CefCommandLineArgs.Add("disable-gpu");
            //settings.CefCommandLineArgs.Add("disable-gpu-compositing");

            // Set BrowserSubProcessPath based on app bitness at runtime
            // settings.BrowserSubprocessPath = Path.Combine(DependencyPath, "CefSharp.BrowserSubprocess.exe");

            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

        }

        private static void unzipDependencies(string zipFile)
        {

            ZipFile.ExtractToDirectory(zipFile, DependencyPath);

        }

    }
}
