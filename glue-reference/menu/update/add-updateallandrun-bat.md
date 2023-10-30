# Introduction

The **Add UpdateAllAndRun.bat** command adds a batch file to the project which will update FlatRedBall, build it, and run it. This is a convenient way to build and run FlatRedBall from source rather than relying on the prebuilt binaries.

![](../../../../../media/2022-04-img_624732ade314c.png)

When this command is executed a .bat file is created. The location of this bat file is shown in the output window so it can be inspected. For instance, the output window may display the following text:

```
11:12:39.4 - Added batch file to:
C:/Users/vchel/Downloads/Temp/frb-fail-RefreshLayoutInternal-GumExperiments/GumExperiments/UpdateAllAndRunFrb.bat
```

The contents of .bat may look like this:

```
:: Get the latest code for your project
git fetch
git pull
:: Get the latest Gum
cd ..\Gum
git fetch
git pull
:: Get the latest FlatRedBall
cd ..\FlatRedBall
git fetch
git pull
:: Build Glue with All solution
cd FRBDK\Glue
dotnet build ""Glue with All.sln""
:: Run the newly built Glue
cd Glue\bin\x86\Debug\netcoreapp3.0\
start GlueFormsCore.exe
```

This script assumes your current Glue project, FlatRedBal, and Gum are all in the same parent folder. To specify a different location for those source code folders, change the folders in the various **cd** commands. &#x20;
