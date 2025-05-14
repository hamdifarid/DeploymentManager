using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Interfaces
{
    public interface IDeployer
    {
        void Deploy(string sourcePath, string destinationPath, object? options = null);

    }
}
