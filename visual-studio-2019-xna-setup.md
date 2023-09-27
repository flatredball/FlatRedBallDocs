## Introduction

This guide is a modified version of the guide available here: https://gist.github.com/roy-t/2f089414078bf7218350e8c847951255

1.  Download a modified version of **MXA Game Studio**, which is a set of installers for adding XNA to Visual Studio. [files.flatredball.com/content/XnaInstall/XnaForVS2019.zip](http://files.flatredball.com/content/XnaInstall/XnaForVS2019.zip) (right-click and save link as)
2.  After downloading, unzip the **XNAForVS2019.zip** file
3.  The unzipped folder contains 4 folders. Each one contains an executable. Run them in order:
    1.  DirectX\DXSETUP.exe
    2.  XNA Framework 4.0 Redistribution\XNA Framework 4.0 Redist.msi
    3.  XNA Game Studio 4.0 Platform Tools\XNA Game Studio Platform Tools.msi
    4.  XNA Game Studio 4.0 Shared\XNA Game Studio Shared.mxi
4.  Double-click **XNA Game Studio 4.0.vsix**.
    1.  Verify your version of Visual Studio is selected
    2.  If you get a message stating "The following extensions are not compatible with Visual Studio 2019", click **Yes** - the installation will still work.
5.  To make the XNA Game Studio files available to Visual Studio, you will either need to create a symbolic link or duplicate the files to Visual Studio's desired location. (Note that if you are using a different license version of Visual Studio, or your Visual Studio is installed in a different directory, you will need to adjust the destination of these files to the appropriate location. For example, for enterprise licenses of Visual Studio, copy the files to C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Microsoft\XNA Game Studio)
    -   To copy the files:
        1.  First create a new folder: C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\XNA Game Studio
        2.  Copy everything or create symbolic link from `C:\Program Files (x86)\MSBuild\Microsoft\XNA Game Studio` to `C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\XNA Game Studio`
    -   To create a symbolic link:
        1.  Load a command prompt with administrative privileges
        2.  Run the following command to create a symbolic link from the XNA Game Studio files to where Visual Studio will look for them: `mklink /D "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Microsoft\XNA Game Studio" "C:\Program Files (x86)\MSBuild\Microsoft\XNA Game Studio"`
6.  **Optional**: For TeamCity automated builds, also copy to C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Microsoft\XNA Game Studio

  Note that the bug is tracked here: <https://github.com/Microsoft/msbuild/issues/1831>  
