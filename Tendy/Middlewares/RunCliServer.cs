using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Tendy.Middlewares
{
    public static class RunCliServer
    {
        private static Process process;

        public static void Shell(this IApplicationBuilder app, string cmd)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    process = new Process
                    {
                        StartInfo = new ProcessStartInfo("cmd.exe", "/C " + cmd) { UseShellExecute = false }
                    };
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    //
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    //
                }

                process.Start();

                // Registers the application shutdown event.
                var applicationLifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
                applicationLifetime.ApplicationStopping.Register(OnShutDown);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private static void OnShutDown()
        {
            if (process != null)
            {
                try
                {
                    Debug.WriteLine($"Killing npm process ( {process.StartInfo.FileName} {process.StartInfo.Arguments} )");
                    process.Kill();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to kill npm process ( {process.StartInfo.FileName} {process.StartInfo.Arguments} )");
                    Debug.WriteLine($"Exception: {ex}");
                }
            }
        }
    }
}
