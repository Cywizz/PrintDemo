using Foundation;
using UIKit;

namespace PrintDemo
{
    public partial class PrintService
    {
        public partial bool CanPrint()
        {
            return true;
        }

        public partial Task PrintFile(Stream fileStream, string fileName,object platformSpecificInput)
        {
            var printInfo = UIPrintInfo.PrintInfo;
            printInfo.OutputType = UIPrintInfoOutputType.General;
            printInfo.JobName = "Print PDF";

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var library = Path.Combine(documents, "..", "Library");
            var filepath = Path.Combine(library, fileName);

            using var tempStream = new MemoryStream();

            fileStream.Position = 0;
            fileStream.CopyTo(tempStream);
            File.WriteAllBytes(filepath, tempStream.ToArray());

            var printer = UIPrintInteractionController.SharedPrintController;
            printInfo.OutputType = UIPrintInfoOutputType.General;

            printer.PrintingItem = NSUrl.FromFilename(filepath);
            printer.PrintInfo = printInfo;

#pragma warning disable CA1422
            printer.ShowsPageRange = true;
#pragma warning restore CA1422

            printer.Present(true, (handler, completed, err) => {
                if (!completed)
                {
                    Console.WriteLine("error");
                }
            });

           return Task.CompletedTask;
        }

    }
}