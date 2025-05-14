using FileManager.ConfigurationManager;
using FileManager.Interfaces;
using FileManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISDeploymentManager
{
    public static class FileDeploymentManager
    {
        public static void SFTPDeploy(string sourcePath, string destinationPath)
        {
            var sftpConfig = new SftpConfig
            {
                Host = "example.com",
                Port = 22,
                Username = "user",
                Password = "password"
            };
            IDeployer deployer = new SftpDeployer();
            //source @"C:\local\build"
            //destination @"C:\local\build\deploy"
            deployer.Deploy(sourcePath, destinationPath);
        }

        public static void Deploy(string sourcePath, string destinationPath)
        {
            IDeployer deployer = new LocalDeployer();
            deployer.Deploy(sourcePath, destinationPath);
        }
    }
}
