# 🖥️ Downloading FlatRedBall

### Prerequisites

#### 1 - Visual Studio 2022 or Newer

[https://visualstudio.microsoft.com/vs/community/](https://visualstudio.microsoft.com/vs/community/) Although it is possible to make games without Visual Studio or Rider, doing so requires advanced knowledge of MSBuild. We recommend downloading and installing Visual Studio Community which is free.

At a minimum you need to install **.NET desktop development**.

![](media/2021-08-img\_610caaac075b7.png)

#### 2. XNA 4.0 Redistributable

[https://www.microsoft.com/en-us/download/details.aspx?id=27598](https://www.microsoft.com/en-us/download/details.aspx?id=27598) Although this is not required to build and run FlatRedBall games, it is required to use Gum, which is the preferred FlatRedBall UI tool.

#### 3. .NET 6 SDK

[https://dotnet.microsoft.com/en-us/download/dotnet/6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

![](media/2023-03-img\_6415bcb385f79.png)

Newer Versions of Visual Studio (as of version 17.5.1) install .NET SDK 7.0 or newer which have a bug preventing projects from being loaded in the FlatRedBall Editor. Therefore, you need to manually install .NET 6 SDK.\
\
4\. .NET 8 SDK (Optional)

.NET 8 SDK is required if you intend to create FlatRedBall Web projects or FlatRedBall iOS or Android projects. [https://dotnet.microsoft.com/en-us/download/dotnet/8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Downloading FlatRedBall

The most common approach to making FlatRedBall games is to use the FlatRedBall Editor. The Editor can be downloaded from a pre-built .zip file, or it can be built from source. New users should download the pre-built .zip file.

### Downloading and Running FlatRedBall

1. Download the latest zip file from [https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/FRBDK.zip](https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/FRBDK.zip).&#x20;
   1. Alternatively, the FlatRedBall Editor (no additional tools) prebuilt can be downloaded from Github. This is not recommended for new users, but experienced users can replace the FlatRedball Glue folder with the contents from the built files: [https://github.com/vchelaru/FlatRedBall/actions](https://github.com/vchelaru/FlatRedBall/actions)
2.  Unzip the file after downloading

    <figure><img src=".gitbook/assets/image (5) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption></figcaption></figure>
3. Go to the folder where the .zip file unzipped to (by default called FRBDK)
4. Open the Run FlatRedBall.bat file (double click it)

![](media/2023-07-img\_64b932f820fb5.png)

If you see the **Windows protected your PC** dialog, click **More info** -> **Run Anyway**

![](media/2023-07-img\_64b938bddd912.png)

The FlatRedBall Editor should appear.

![](media/2022-12-img\_639d07e85b8d9.png)
