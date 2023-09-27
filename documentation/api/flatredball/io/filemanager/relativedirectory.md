## Introduction

The FileManager's RelativeDirectory is a directory that is used as the directory that file loading is performed relative to.

For example, let's say the FileManager's RelativeDirectory is

    "C:\Projects\MyGame\bin\x86\debug\"

In this case any file-related FRB call will result in FlatRedBall looking in this directory for files. Therefore, we could create a Sprite as follows:

    SpriteManager.AddSprite("redball.bmp");

This would result in the engine looking for the following file:

     "C:\Projects\MyGame\bin\x86\debug\redball.bmp"

## RelativeDirectory and Glue

Generated Glue code assumes that the RelativeDirectory is the directory of the .exe file. Therefore, if your code ever changes the RelativeDirectory and you are using Glue, you should change the RelativeDirectory back to its old value. See below on an example of how to preserve RelativeDirectory.

## FlatRedBall calls use RelativeDirectory

Virtually any FlatRedBall call which access information off of the disk will use FileManager.RelativeDirectory. For example the following calls will use the RelativeDirectory when relative paths:

-   [FlatRedBall.FlatRedBallServices.Load](/frb/docs/index.php?title=FlatRedBall.FlatRedBallServices.Load "FlatRedBall.FlatRedBallServices.Load")
-   [FlatRedBall.IO.FileManager.XmlSerialize](/frb/docs/index.php?title=FlatRedBall.IO.FileManager.XmlSerialize "FlatRedBall.IO.FileManager.XmlSerialize")
-   [FlatRedBall.IO.FileManager.XmlDeserialize](/frb/docs/index.php?title=FlatRedBall.IO.FileManager.XmlDeserialize "FlatRedBall.IO.FileManager.XmlDeserialize")
-   [FlatRedBall.SpriteManager.AddSprite](/frb/docs/index.php?title=FlatRedBall.SpriteManager.AddSprite "FlatRedBall.SpriteManager.AddSprite")
-   Any FlatRedBall Save Class's FromFile and Save methods

## RelativeDirectory Default Value

The RelativeDirectory defaults to the directory of your executable if your application is running on the PC (as opposed to Silverlight or the Xbox 360). This file is determined when execution first starts. In other words, running your application in a different folder or on a different machine will result in a different RelativeDirectory at startup. This keeps file loading portable.

## Setting RelativeDirectory

In some cases you may want to change the FileManager's RelativeDirectory property; however, there are some restrictions when you do this:

-   The RelativeDirectory must always be an absolute path.
-   The RelativeDirectory should preferably be relative to the location of your executable.

These two requirements might seem contradictory - how can you guarantee that RelativeDirectory stays relative to your .exe, but at the same time achieve that by setting an absolute path?

The answer is to use the old RelativeDirectory value when setting a new RelativeDirectory.

### Setting RelativeDirectory Example

Let's say that you want to set the RelativeDirectory to your "Content" folder, as you plan on doing all loading from that folder. To do this, you'll simply want to append "Content\\" to your RelativeDirectory as follows:

    FileManager.RelativeDirectory = FileManager.RelativeDirectory + @"Content\";

This means that your program will use the "Content" folder for all of its loading logic; however, your file access code will remain relative.

**You should NOT do this:**

    FileManager.RelativeDirectory = @"C:\Projects\MyGame\bin\x86\debug\Content\";

If you do this then your game will break if you decide to move it to another computer, if you send it to a friend, or if you switch to a different platform like the Xbox 360 or Silverlight.

## Preserving the old RelativeDirectory value

Many file formats assume that contained references are relative to the file itself. For example, consider a [.scnx](/frb/docs/index.php?title=.scnx&action=edit&redlink=1 ".scnx (page does not exist)") file which references "redball.bmp". By default if you try to load "redball.bmp" your program will attempt to look for a redball.bmp file in the same folder as the .exe. If you are writing code which will load objects relative to another file, you may want to temporarily set the RelativeDirectory value, then change it back after you're finished.

For example, let's say that MySaveClass has a list of Sprites that it will load. The code to load this might be as follows:

    public SpriteList LoadSpritesFromFile(string fileName)
    {
        MySaveClass mySaveClass = FileManager.XmlDeserialize<MySaveClass>(fileName);

        // Save off the old RelativeDirectory before changing it
        string oldRelativeDirectory = FileManager.RelativeDirectory;

        FileManager.RelativeDirectory = FileManager.GetDirectory(fileName);

        SpriteList spriteList = new SpriteList();

        foreach(string spriteToLoad in mySaveClass.Sprites)
        {
            spriteList.Add(SpriteManager.AddSprite(spriteToLoad));
        }

        // Now set the RelativeDirectory back before exiting the function
        FileManager.RelativeDirectory = oldRelativeDirectory;
       
        return spriteList;
    }

## Using "../"

The FileManager supports the use of the "../" string which indicates to "move up one directory". You can change the RelativeDirectory by appending "../" at the end as follows:

    FileManager.RelativeDirectory += "../";

You can also use the backslash:

    FileManager.RelativeDirectory += @"..\";

This sill result in the RelativeDirectory moving up one directory. Keep in mind that RelativeDorectory must always be absolute, so the following is not valid:

    FileManager.RelativeDirectory = "../"; // Can't do this!

Also, it is not recommended that you use "../" to navigate up any higher than the starting RelativeDirectory as this will keep your application from being portable.

## Using "./"

The "./" string represents "this directory". This string should not be used when dealing with the RelativeDirectory property because it is a string that is reserved by FlatRedBall to indicate an absolute path on non-PC platforms.

The "./" can be used to indicate an absolute path if you would like to prevent the FileManager from making the file absolute. In other words, this operation would use the RelativeDirectory:

    SpriteManager.AddSprite("redball.bmp");

while on non-PC platforms, this is absolute:

    SpriteManager.AddSprite("./redball.bmp");

We strongly recommend not using absolute paths like this because they keep your application from being portable to the PC versions of FlatRedBall.
