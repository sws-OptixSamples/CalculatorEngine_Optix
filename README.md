# CalculatorEngine_Optix

Application to demonstrate how a C++ program can be build into a NuGet package and used as a dependancy for an Optix application.  This Optix application utilizes a very simple calculator function within a NuGet package.    
  
Within the NuGet solution there is a wrapper project that will (eventually) allow for a Windows DLL or Linux SO package to be utilized based on the target device.  Currently, there is only the Windows version.  

The example image below illustrates the path from the cpp file to the Optix runtime.  
The supporting .NET solution for the NuGet build is named CalculatorEngine_NuGet

![runtimeExampleImage](ProjectFiles/runtimeExampleImage.png)

## Disclaimer
Rockwell Automation maintains these repositories as a convenience to you and other users. Although Rockwell Automation reserves the right at any time and for any reason to refuse access to edit or remove content from this Repository, you acknowledge and agree to accept sole responsibility and liability for any Repository content posted, transmitted, downloaded, or used by you. Rockwell Automation has no obligation to monitor or update Repository content

The examples provided are to be used as a reference for building your own application and should not be used in production as-is. It is recommended to adapt the example for the purpose and observing the highest safety standards.
