using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDemo
{
    /// <summary>
    /// Abstract Service that has platform specific code implemented
    /// </summary>
    public partial class PrintService
    {
        public partial bool CanPrint();

        public partial Task PrintFile(Stream fileStream, string fileName, object platformSpecificInput);
        

    }
}
