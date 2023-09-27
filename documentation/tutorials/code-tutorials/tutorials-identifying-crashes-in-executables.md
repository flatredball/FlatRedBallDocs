## Introduction

Visual Studio provides an excellent debugging environment. If your application throws an exception, Visual Studio will (in most cases) take you right to the line of code that is causing problems. You can investigate the state of variables, the call stack, and surrounding code. Unfortunately you may run into a situation where your game runs perfectly in Visual Studio, but crashes on another person's machine, or even on your machine when you run the application through the .exe. Not only is this apparent inconsistency frustrating, but an executable crash might not give you much useful information. ![ProgramStoppedWorking.png](/media/migrated_media-ProgramStoppedWorking.png) Of course, as you can see in the image above, you do have the option to attach a debugger to the process to see what the crash is, but what if the problem is happening on another person's computer? Worse yet, what if that person knows absolutely nothing about programming? Fortunately there is still a solution.

## Exceptions and WinForms to the rescue!

Whenever you experience a crash from running an executable, there are two things that you need to be able to properly resolve the issue:

1.  Information about the error needs to be collected by your program.
2.  The information needs to be displayed to the user (which may be you) to that it can be accessed and reacted to.

Fortunately both steps are fairly easy.

## Collecting the information

First, we need to get information about the crash. Fortunately, we can do this with a try/catch statement. You might be thinking "But where am I going to put the try/catch? I don't even know where my crash is happening." Actually, that's okay. One of the great things about try/catch statements is that they can be used to catch statements that happen both in the code that is within the try statement as well as any method called within the try statement. It doesn't just go one level deep either - any method called by any method in your try that throws an exception will also get caught, and so on - to an infinite level in the call stack. That means that we can do something very clever to our Program.cs file. This is normally a file that you probably never have touched (unless you've done this before). ![ProgramDotCs.png](/media/migrated_media-ProgramDotCs.png) The contents of the file are very simple:

    using System;
    namespace FlatRedBallXnaTestbed
    {
       static class Program
       {
           /// <summary>
           /// The main entry point for the application.
           /// </summary>
           static void Main(string[] args)
           {
               using (Game1 game = new Game1())
               {
                   game.Run();
               }
           }
       }
    }

All we have to do is wrap the game.Run(); call inside a try/catch:

    ...
               using (Game1 game = new Game1())
               {
                   try
                   {
                       game.Run();
                   }
                   catch (Exception e)
                   {
                   }
               }
    ...

That's it! Now any exception that isn't already being handled by your game or the FRB engine will make its way up to the catch statement we just wrote. The information that we need is stored in the Exception instance "e". Step 1 complete!

## Displaying the error information

Great, we got the information in "e". But how do we get it to the user? It's fairly easy, actually. First we'll focus on an immediate display of the error. If you are the one debugging the program, then this information may be sufficient. To do this, simply use a Windows MessageBox to show the error. In other words, change your code to look like this:

    ...
               using (Game1 game = new Game1())
               {
                   try
                   {
                       game.Run();
                   }
                   catch (Exception e)
                   {
                       string errorMessage = e.ToString();
                       System.Windows.Forms.MessageBox.Show(errorMessage);
                   }
               }
    ...

When adding the code above you may get an error similar to: **The type or namespace name 'Windows' does not exist in the namespace 'System' (are you missing an assembly reference?)** Visual Studio's got it spot on in this case. You are probably missing the System.Windows.Forms assembly. It's pretty easy to add:

1.  Right-click on your "References" folder
2.  Select "Add Reference..."
3.  Scroll down in the ".NET" tab which might already be selected for you and select System.Windows.Forms.

![SystemWindowsFormsReference.png](/media/migrated_media-SystemWindowsFormsReference.png)

That's all there is to it, at least for the first display. This may be sufficient in helping you catch your error if you're debugging on your machine, or if the user who is experiencing the error knows how to take a screen shot and can send you the image. Uh-oh. Someone forgot to include redball.bmp. ![ExceptionMessageBox.png](/media/migrated_media-ExceptionMessageBox.png) But if you want to make it easier on your user, there's more we can do...

## Saving the Error Information

Maybe the user you're working with doesn't know how to take a screen shot. If that's the case you can also easily save the information so that the user can send you the resulting text file. To do this, modify the catch statement to also export the contents of the information as follows: ...

               using (Game1 game = new Game1())
               {
                   try
                   {
                       game.Run();
                   }
                   catch (Exception e)
                   {
                       string errorMessage = e.ToString();
                       System.Windows.Forms.MessageBox.Show(errorMessage);
                       FlatRedBall.IO.FileManager.SaveText(
                           errorMessage,
                           FlatRedBall.IO.FileManager.MyDocuments + "error.txt");
                   }
               }

... Here we simply tell the FileManager to save the information contained in errorMessage to a file called error.txt in My Documents. Of course, you can change the file name if you'd like. This will now both spit out the error message to a message box as well as save the information in error.txt for simple transfer. ![SavedErrorText.png](/media/migrated_media-SavedErrorText.png) Happy debugging!
