using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.ConfigurationManager
{
    public class LocalDeployConfig
    {
        public string[] ExcludeFiles { get; set; } = new[] { "appsettings.json", "web.config" };
        public bool Overwrite { get; set; } = true;
    }
}
