using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestRunner
{
    public class AssemblyLoader
    {
        public static IEnumerable<Assembly> Load()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var files = Directory
                .GetFiles(currentDirectory)
                .Where(f => f.EndsWith(".Tests.dll"))
                .Select(f => Assembly.LoadFile(f));
            return files;
        }
    }
}
