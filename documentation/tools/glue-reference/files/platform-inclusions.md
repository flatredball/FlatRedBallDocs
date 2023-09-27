## Introduction

By default, files added to Glue will automatically be added to all associated Visual Studio projects. Some files, however, are only needed on some platforms. Files can be excluded from certain projects through the Platform Inclusions tab. Note that this tab will only appear when a file is selected in Glue project which has more than one code solution (added through [Project Sync](/documentation/tools/glue-reference/menu/glue-reference-menu-file-new-synced-project/.md)). ![PlatformInclusion](/media/2016-02-PlatformInclusion.png)

## Inclusions Details

Excluding a file from a project will exclude the project from the Visual Studio .csproj or .contentproj, but the code generation currently does not consider whether the file has been excluded. This means that code generation may throw a file not found exception (or equivalent) when the project executes on a platform from which the file has been excluded. For this reason, files should only be excluded when [LoadedAtRuntime](/documentation/tools/glue-reference/files/glue-reference-files-loadedatruntime/.md) is set to false.
