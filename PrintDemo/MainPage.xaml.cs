namespace PrintDemo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		//get your pdf stream from somewhere...for this demo it is embedded as a MAUI asset under resources-raw
        using var stream = await FileSystem.OpenAppPackageFileAsync("pdfTestFile.pdf");
      
		PrintService printService = new PrintService();

		//Added this method to add additional checks before you can start printing
		if (printService.CanPrint())
		{

#if WINDOWS
           await printService.PrintFile(stream, "pdfTestFile.pdf", this.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window);

#elif __IOS__ || MACCATALYST || ANDROID
			await printService.PrintFile(stream, "pdfTestFile.pdf", null);

#endif
		}

    }
}

