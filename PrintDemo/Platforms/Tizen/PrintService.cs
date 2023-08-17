using Foundation;
using System;
using UIKit;

namespace PrintDemo
{
    public partial class PrintService
    {
        public partial bool CanPrint()
        {
            return false;
        }

        public partial Task PrintFile(Stream fileStream, string fileName,object platformSpecificInput)
        {

            throw new NotImplementedException();
        }

    }
}