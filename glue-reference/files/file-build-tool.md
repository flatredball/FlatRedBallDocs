# File Build Tool

### Introduction

The File Build Tools window allows adding command-line build tools for your files for converting from one file format to another. Conceptually file build tools are similar to the MonoGame or XNA Content Pipeline, but they are run through the command line as a separate process for each file.

File build tools can be used to convert from a custom or app-specific file format to a file format which is understood by FlatRedBall or an external library.

FlatRedBall provides a number of integrations for file build tools, and additional tools can be added to support any file format you would like to use.

### Viewing File Build Tools

To view the file build tools window, select **Settings** -> **File Build Tools** in FRB. A window should appear displaying the existing file build tools.

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>File build tool window</p></figcaption></figure>

This window displays the existing file build tool assications. The list box on the left displays the file types that can be used as input (such as .odf files), the tool that is being used to conver the file (such as soffice.exe), and the output file format (such as .csv).

### Adding New Build Tools

To add a new build tool, click the **Add new build tool** button. A new entry is added to the list box on the left which can be customized. As you fill in the properties for the new build tool, the Example text below is updated to show FlatRedBall will call the build tool for a built file.

### Using a Build Tool

If you add a file to your FlatRedBall project which has an associated build tool, then a popup is shown allowing you to select which build tool to use. For example, if you add an .ods file to your project, you will see a window similar to the following image:

<figure><img src="../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>File build tool selection popup</p></figcaption></figure>

You can leave the default, or use the dropdown to select a different builder. If you do not want to use a builder for this particular file, you can change the dropdown to \<None>.

<figure><img src="../../.gitbook/assets/image (2) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Selecting &#x3C;None> in the file build tool selection popup</p></figcaption></figure>

If a file has an associated file build tool, then the destination file is displayed in the FRB Editor. For example, if an .ods file is added, the destination file type (csv) shows. At runtime the source file is completely ignored and only the destination file is loaded.

<figure><img src="../../.gitbook/assets/image (5) (1).png" alt=""><figcaption><p>CSV file</p></figcaption></figure>

Once a file has been added you can change its BuildTool property in its Properties window.

<figure><img src="../../.gitbook/assets/image (3) (1) (1) (1).png" alt=""><figcaption><p>BuildTool Property</p></figcaption></figure>

### Using the Build Tool

Any time the source file changes on disk (such as an .ods file), FRB detects this change and automatically performs a build. The command is displayed in the Output window.

<figure><img src="../../.gitbook/assets/image (85).png" alt=""><figcaption><p>Build tool command shown in the output window</p></figcaption></figure>
