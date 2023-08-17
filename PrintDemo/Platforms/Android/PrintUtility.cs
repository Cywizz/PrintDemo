using Android.OS;
using Android.Print;
using Java.IO;
using FileNotFoundException = Java.IO.FileNotFoundException;
using IOException = Java.IO.IOException;

namespace PrintDemo
{
    public class PrintUtility : PrintDocumentAdapter
    {
        public string PrintFileName { get; set; }
        public PrintUtility(string printFileName) 
        {
            PrintFileName = printFileName;
        }


        public override void OnLayout(PrintAttributes oldAttributes, PrintAttributes newAttributes, CancellationSignal cancellationSignal, LayoutResultCallback callback, Bundle extras)
        {
            if (cancellationSignal.IsCanceled)
            {
                callback.OnLayoutCancelled();
                return;
            }

            var pdi = new PrintDocumentInfo.Builder(PrintFileName).SetContentType(PrintContentType.Document).Build();

            callback.OnLayoutFinished(pdi, true);
        }

        public override void OnWrite(PageRange[] pages, ParcelFileDescriptor destination, CancellationSignal cancellationSignal, WriteResultCallback callback)
        {
            InputStream input = null;
            OutputStream output = null;

            try
            {
                input = new FileInputStream(PrintFileName);
                output = new FileOutputStream(destination.FileDescriptor);

                var buf = new byte[1024];
                int bytesRead;

                while ((bytesRead = input.Read(buf)) > 0)
                {
                    output.Write(buf, 0, bytesRead);
                }

                callback.OnWriteFinished(new[] { PageRange.AllPages });

            }
            catch (FileNotFoundException ee)
            {
                //Catch
            }
            catch (Exception e)
            {
                //Catch
            }
            finally
            {
                try
                {
                    input?.Close();
                    output?.Close();
                }
                catch (IOException e)
                {
                    e.PrintStackTrace();
                }
            }
        }
    }
}
