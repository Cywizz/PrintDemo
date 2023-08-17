

using Android.Content;
using Android.Print;
using AndroidX.Print;

namespace PrintDemo
{
    public partial class PrintService
    {
        public partial bool CanPrint()
        {
            return true;
        }


        public partial Task PrintFile(Stream fileStream, string fileName, object platformSpecificInput)
        {

            if (fileStream.CanSeek)
                //Reset the position of PDF document stream to be printed
                fileStream.Position = 0;
            //Create a new file in the Personal folder with the given name
            string createdFilePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
            //Save the stream to the created file
            using (var dest = System.IO.File.OpenWrite(createdFilePath))
                fileStream.CopyTo(dest);
            string filePath = createdFilePath;
            var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
            PrintManager printManager = (PrintManager)activity.GetSystemService(Context.PrintService);

            PrintUtility utility = new PrintUtility(fileName);

            //Print with null PrintAttributes
            printManager.Print(fileName, utility, null);

            return Task.CompletedTask;

        }

    }
}
