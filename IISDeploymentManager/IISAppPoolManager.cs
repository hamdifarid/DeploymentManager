using Microsoft.Web.Administration;
using System;

public static class IISAppPoolManager
{
    public static void StopAppPool(string appPoolName)
    {
        using (var serverManager = new ServerManager())
        {
            var appPool = serverManager.ApplicationPools[appPoolName];
            if (appPool != null && appPool.State == ObjectState.Started)
            {
                Console.WriteLine($"Stopping App Pool: {appPoolName}");
                appPool.Stop();
            }
            else
            {
                Console.WriteLine($"App Pool {appPoolName} is already stopped or doesn't exist.");
            }
        }
    }

    public static void StartAppPool(string appPoolName)
    {
        using (var serverManager = new ServerManager())
        {
            var appPool = serverManager.ApplicationPools[appPoolName];
            if (appPool != null && appPool.State == ObjectState.Stopped)
            {
                Console.WriteLine($"Starting App Pool: {appPoolName}");
                appPool.Start();
            }
            else
            {
                Console.WriteLine($"App Pool {appPoolName} is already started or doesn't exist.");
            }
        }
    }
}
