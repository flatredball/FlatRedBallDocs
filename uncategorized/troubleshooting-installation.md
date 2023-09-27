## GlueWithAll.exe (FlatRedBall Editor) Does Not Open

If the FlatRedBall Editor closes immediately, you may be able to get diagnostic information through the Event Viewer.

1.  Open the Event Viewer

    ![](/media/2023-03-img_640c7681570d3.png)

2.  Select Windows Logs -\> Application

    ![](/media/2023-03-img_640c76d232eef.png)

3.  Search for a recent Error

4.  Select one that has a Source of .NET Runtime. You may want to re-run GlueWithAll.exe to get a recent error.

    ![](/media/2023-03-img_640c774bda3ab.png)

5.  Look at the error in the bottom half of the Event Viewer

The resulting error may give clues about why it is not opening. Please paste the entire message (callstack) in the FlatRedBall Help chat.

## 

## Error loading pipeline assembly "C:\\...\FlatRedBallXna4Template\Libraries\Xna4Pc\FlatRedBall.dll".

If you are experiencing this or any other problem with assemblies loaded in the Content project:

-   Navigate to the Libraries folder where the .dlls that your project links are located
-   Right-click on the .dll that is causing problems
-   Select "Properties"
-   At the bottom of the properties window, look for a "Unblock" button. Click it.
-   Click OK to apply changes
-   Rebuild (not just build, but rebuild) your project.

## c:\PROJECT PATH : error : Could not load type 'Microsoft.Build.Framework.IProjectElement' from assembly 'Microsoft.Build.Framework, Version=15.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.

The global assembly cache is not finding Microsoft.Build.Framework. Instructions for fixing it can be found here: https://developercommunity.visualstudio.com/content/problem/94979/cannot-open-any-projects-in-solution-after-install.html

## Error: Invalid static method invocation syntax: "\[Microsoft.Build.Utilities.ToolLocationHelper\]::GetPathToStandardLibraries($(TargetFrameworkIdentifier), $(TargetFrameworkVersion), $(TargetFrameworkProfile), $(PlatformTarget), $(TargetFrameworkRootPath), $(TargetFrameworkFallbackSearchPaths))". Method 'Microsoft.Build.Utilities.ToolLocationHelper.GetPathToStandardLibraries' not found. Static method invocation should be of the form: $(\[FullTypeName\]::Method()), e.g. $(\[System.IO.Path\]::Combine(\`a\`, `b`)). C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\Microsoft.Common.CurrentVersion.targets

See this post: https://developercommunity.visualstudio.com/content/problem/311632/error-after-updating-to-1580-invalid-static-method.html
