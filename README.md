# PrintDemo
Print PDF using platform specific code. (Excluding Tyzen)
Credit for intial code goes to LanceMcCarthy's demo found here: https://github.com/LanceMcCarthy/CustomMauiExamples/tree/main/src/DocumentPrinting

I moved the code to platform specific classes and added an abstract PrintService with a CanPrint() method for additional validation. 
Tested on Windows and Android 12.1 ONLY, although code for mac and ios included.
