using IISDeploymentManager;
using System;

class Program
{
    static void Main(string[] args)
    {
        string appPoolName = "YourAppPoolName";  
        string sourceDirectory = @"C:\Path\To\Your\Source\Directory";  
        string targetDirectory = @"C:\Path\To\Your\Target\Directory";  

        try
        {
            BeginDeployment(appPoolName, sourceDirectory, targetDirectory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void BeginDeployment(string appPoolName, string sourceDirectory, string targetDirectory)
    {
        IISAppPoolManager.StopAppPool(appPoolName);

        FileDeploymentManager.Deploy(sourceDirectory, targetDirectory);

        IISAppPoolManager.StartAppPool(appPoolName);

        Console.WriteLine("Deployment completed successfully!");
    }
}
