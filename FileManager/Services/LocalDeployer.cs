using FileManager.ConfigurationManager;
using FileManager.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace FileManager.Services
{
    public class LocalDeployer : IDeployer
    {
        public void Deploy(string sourcePath, string destinationPath, object? options = null)
        {
            Console.WriteLine($"[LOCAL] Deploying from {sourcePath} to {destinationPath}...");

            var config = options as LocalDeployConfig ?? new LocalDeployConfig();

            var files = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .Where(file =>
                                     !config.ExcludeFiles.Any(exclude =>
                                         file.EndsWith(exclude, StringComparison.OrdinalIgnoreCase)));

            foreach (var file in files)
            {
                var relativePath = Path.GetRelativePath(sourcePath, file);
                var targetFile = Path.Combine(destinationPath, relativePath);
                var targetDir = Path.GetDirectoryName(targetFile);

                if (!Directory.Exists(targetDir))
                    Directory.CreateDirectory(targetDir);

                File.Copy(file, targetFile, overwrite: config.Overwrite);
            }

            Console.WriteLine("Local deployment complete.");
        }
    }
}
