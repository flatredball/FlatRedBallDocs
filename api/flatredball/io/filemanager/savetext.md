# SaveText

### Introduction

The SaveText function is a function that can be used to easily save the contents of a string to a .txt file. This function will overwrite previously-created .txt files if an existing file name is passed, so be careful calling this method.

### Code Example

The following code creates a string, saves it to a .txt file, then opens that file.

```
System.Text.StringBuilder builder = new System.Text.StringBuilder();

builder.AppendLine("Why is FlatRedBall so great?  Let me count the reasons...");

// Stop at 100 to prevent an infinite loop :)
for (int i = 1; i < 100; i++)
{
    builder.AppendLine(i.ToString());
}

string fileToSave = FileManager.UserApplicationData + @"\temp.txt";

FileManager.SaveText(builder.ToString(), fileToSave);

System.Diagnostics.Process.Start(fileToSave);
```

![SaveText.png](../../../../.gitbook/assets/migrated\_media-SaveText.png)
