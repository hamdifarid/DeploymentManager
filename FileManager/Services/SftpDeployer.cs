using FileManager.ConfigurationManager;
using FileManager.Interfaces;
using Renci.SshNet;
using System;
using System.IO;

namespace FileManager.Services
{
    public class SftpDeployer : IDeployer
    {
        public void Deploy(string sourcePath, string destinationPath, object? options = null)
        {
            if (options is not SftpConfig config)
                throw new ArgumentException("SftpConfig must be provided as the options parameter.");

            using var client = new SftpClient(config.Host, config.Port, config.Username, config.Password);

            client.Connect();
            Console.WriteLine("Connected to SFTP.");

            foreach (var file in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(sourcePath, file);
                var remotePath = Path.Combine(destinationPath, relativePath).Replace("\\", "/");

                using var fileStream = File.OpenRead(file);

                var remoteDir = Path.GetDirectoryName(remotePath).Replace("\\", "/");
                CreateRemoteDirectory(client, remoteDir);

                Console.WriteLine($"Uploading: {remotePath}");
                client.UploadFile(fileStream, remotePath, true);
            }

            client.Disconnect();
            Console.WriteLine("SFTP Deployment completed.");
        }

        private void CreateRemoteDirectory(SftpClient client, string path)
        {
            var segments = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var currentPath = "";

            foreach (var segment in segments)
            {
                currentPath += "/" + segment;
                if (!client.Exists(currentPath))
                    client.CreateDirectory(currentPath);
            }
        }
    }
}
