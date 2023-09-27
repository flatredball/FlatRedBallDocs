## Implementing FRB in a form

This tutorial will explain how to implement FRB on a windows form (also known as WinForms). There are a few noticeable differences between the normal FRB template and using FRB in a form.

The requirements for this example are:

-   A form with 1 panel control
-   A class inheriting from Microsoft.Xna.Framework.Game
-   PeekMessage API call.

## Known issues

There are currently a few known issues regarding using FRB in a windows form.

-   Mouse position also updates outside the form.
-   Method [FlatRedBall.Input.Mouse](/frb/docs/index.php?title=FlatRedBall.Input.Mouse.md "FlatRedBall.Input.Mouse").IsInGameWindow() can incorrectly return true whilst the cursor is outside the window.

## Creating a new Project

The first step is to create a new Windows Forms Application project. To do this:

-   Open Visual Studio
-   Go to File-\>New Project...
-   Select "Windows Forms Application" under Visual Studio installed templates. You may need to select the "C#" category as "XNA Game Studio VERSION NUMBER" might be selected by default.
-   Enter a Name and press OK.

## Adding FlatRedBall

FlatRedBall needs to be added to the project. To do this:

-   Right-click on your project
-   Select Add-\>New Folder
-   Rename the new folder "Libraries"
-   Locate the FlatRedBall.dll file. If you downloaded the template, then it'll be located inside the .zipped template file on your computer. On Windows Vista, it's probably:

&nbsp;

    C:\Users\<YOUR NAME>\Documents\Visual Studio 2008\Templates\ProjectTemplates

If you're not sure, you can always re-run the installer and see the folder location where it's saved.

-   You'll probably need to unzip the template to get access to the .dll. Remember, you'll still need the .zipped folder in the same location if you decide to make a FRB application at a later time. Remember to unzip the XNA template.
-   Once you've unipped the folder, navigate to its Libraries directory.
-   Drag the FlatRedBall.dll file from the unzipped Libraries folder into the Libraries folder in your project in the Solution Explorer.
-   For Intellisense support, drag the FlatRedBall.XML file into your project's Libraries folder. Right-click it and select "Exclude From Project".
-   Right-click on the References item under your project and select "Add Reference...".
-   Select the Browse tab.
-   Navigate to your Libraries folder.
-   Select FlatRedBall.dll and click OK.

## Adding XNA

Just like FlatRedBall, your project needs to reference XNA. To add the necessary references:

-   Right-click on your project's References item and select "Add Reference...".
-   Click on the .NET tab.
-   Scroll down and select Microsoft.Xna.Framework.
-   Click "OK"
-   Repeat the above steps to add "Microsoft.Xna.Framework.Game" to your project as well.

## PeekMessage API

To implement this feature we'll need a piece of code that is familiar to those that worked with the MDX version of FRB.

We'll implement this in a new class called NativeMethods. To do this:

-   Right-click on your project in the Solution Explorer
-   Select Add-\>Class...
-   Name your class NativeMethods
-   Add the following code:

Add the following using statement:

    using System;
    using System.Runtime.InteropServices;
    using System.Security;

Copy the following code as your class:

       public static class NativeMethods
       {
           [StructLayout(LayoutKind.Sequential)]
           public struct Message
           {
               public IntPtr hWnd;
               public UInt32 msg;
               public IntPtr wParam;
               public IntPtr lParam;
               public UInt32 time;
               public System.Drawing.Point p;
           }

           [SuppressUnmanagedCodeSecurity] // We won't use this maliciously
           [DllImport("User32.dll", CharSet = CharSet.Auto)]
           public static extern bool PeekMessage(out Message msg, IntPtr hWnd,
            uint messageFilterMin, uint messageFilterMax, uint flags);

       }

## Game code

Next we'll create our Game class. Basically this class can be copied from the template and modified; For this example however I'll discuss all the necessary bits and pieces that we need to add to get a working application.

To create a game class:

-   Right-click on your project
-   Select Add-\>Class...
-   Name your class RenderClass
-   Add the code to your class as follows:

Add the following using statement:

    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using FlatRedBall;

Create the class:

       public class RenderClass : Game
       {
           public GraphicsDeviceManager graphics;
           public ContentManager content;
           
       }

Here start the differences with the normal template code. We apply a small hack to force XNA to recreate the device context. Also note that the constructor ends with the Initialize() method due to the form being the messagepump parser.

Create the following method:

           public RenderClass() : base()
           {
               graphics = new GraphicsDeviceManager(this);
               content = new ContentManager(Services);

               IGraphicsDeviceManager graphicsDeviceManager =
                this.Services.GetService(typeof(IGraphicsDeviceManager)) as 
                IGraphicsDeviceManager;
     
               // Check if the graphicsDeviceManager has been initialised before continuing.
               if (graphicsDeviceManager != null) 
               {
                   graphicsDeviceManager.CreateDevice();
                   // base BeginDraw relies on this next line; see MS Feedback item 277959
                   this.GetType().BaseType.GetField("graphicsDeviceManager", 
                    System.Reflection.BindingFlags.Instance | 
                    System.Reflection.BindingFlags.NonPublic).SetValue(this, graphicsDeviceManager);
               }

               Initialize();
           }

Next on the list is the Initialize() method. Here as well we are applying a small hack to let XNA get into the right execution context.

Create the following method:

           protected override void Initialize()
           {
               base.Initialize();
               this.BeginRun();
            
               FlatRedBall.FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);
               FlatRedBall.FlatRedBallServices.IsWindowsCursorVisible = true;

               // Fetch the GameTime class. We will require this for the first update call.
               GameTime gt = this.GetType().BaseType.GetField("gameTime",
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic).GetValue(this) as GameTime;

               this.Update(gt);

               this.GetType().BaseType.GetField("doneFirstUpdate", 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic).SetValue(this, true);
               
               // From this point you can add your own initialisation code.
               Sprite sprite = FlatRedBall.SpriteManager.AddSprite("redball.bmp");
               FlatRedBall.SpriteManager.AddSprite(sprite);

           }

Next are the usual methods that you'll also find in the FRB template with one exception. The dispose() override.

Create the following methods:

           protected override void Update(GameTime gameTime)
           {
               FlatRedBall.FlatRedBallServices.Update(gameTime);
               base.Update(gameTime);
           }

           protected override void Draw(GameTime gameTime)
           {
               FlatRedBall.FlatRedBallServices.Draw();
               base.Draw(gameTime);
           }

           protected override void Dispose(bool disposing)
           {
               this.EndRun();
               base.Dispose(disposing);
           }

Once those are pasted into your class, you can declare the game class in the form code.

## What about a graphic?

Most samples on the FlatRedBall website use the redball.bmp image. If you made a new project then it likely doesn't have this file. So, be sure to add the redball.bmp graphic to the project as follows:

-   Save the redball.bmp image somewhere on your computer: ![Redball.bmp](/media/migrated_media-Redball.png)
-   Navigate to this location on your computer.
-   Drag the redball.bmp image into your Project.
-   Select the redball.bmp item and press F4 to bring up the properties window.
-   Select the "Build Action" as "None" and the "Copy to Output Directory" to "Copy if newer".

## Form code

In this application, your form is the primary window. Usually in XNA applications the Game class window is the primary window. We need to make a few modifications to the form to ensure proper execution. To do this:

-   Right-click on your Form1.cs item in the Solution Explorer.
-   Select "View Code"
-   Make the following modifications:

Add the following using statement:

    using System;
    using System.Windows.Forms;
    using System.Security;
    using System.Runtime.InteropServices;
    using FlatRedBall;

Start off by adding the XNA Game class to the top of the form.

Add the following to class scope::

           private RenderClass mGame;

To prepare for using the game class, add the following methods to perform the messageloop for the game. These methods mimic the messagepump and only render if there are no messages in the queue for the window to handle.

Add the following methods to your Form1 Class:

           void Application_Idle(object sender, EventArgs e)
           {
               while (AppStillIdle())
               {
                   mGame.Tick();
               }
           }

           private bool AppStillIdle()
           {
               NativeMethods.Message msg;
               return !NativeMethods.PeekMessage(out msg, Handle, 0, 0, 0);
           }

Since the game code can't maintain its own disposal, an override method in the form is required to dispose the game window when the application exits. It's possible you will get an error regarding Dispose() which that it already exists. If so; delete the Dispose() from the \<formname\>.Designer.cs file.

Create the following method:

           protected override void Dispose(bool disposing)
           {
               Application.Idle -= Application_Idle;
               mGame.Dispose();
               if (disposing && (components != null))
               {
                   components.Dispose();
               }
               base.Dispose(disposing);
           }

Normally when Visual Studio creates a form for you, the constructor will only contain a call to the components initialisation. For example, yours probably looks like:

           public Form1()
           {
               InitializeComponent();
           }

We'll need to modify the constructor, but before we do we need to add a panel. To do so:

-   Double-click your Form1.cs item in the Solution Explorer. This will take you to the Design View.
-   Open the Toolbox and select a "Panel". This can be found under the "Containers" category or the "All Windows Forms" category.
-   Click and drag to draw the new Panel on your form.
-   Name the panel "Viewport".

![Frb windows form panel.jpg](/media/migrated_media-Frb_windows_form_panel.jpg)

Modify the constructor method:

           public MyExampleForm() : base()
           {
               SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
               UpdateStyles();

               InitializeComponent();

               // Create the instance.
               mGame = new RenderClass();

               // We fetch the Form object from the game handle.
               Form form = Form.FromHandle(mGame.Window.Handle) as Form;

               // We disable the border, make it dock and set its parent.
               // And... we add it as a child to the Panel object.
               form.FormBorderStyle = FormBorderStyle.None;
               form.Dock = DockStyle.Fill;
               form.TopLevel = false;
               form.Parent = Viewport;
               Viewport.Controls.Add(form);

               form.Visible = true;
               Application.Idle += Application_Idle;

               // For some reason the client size can be reported incorrectly to FlatRedBall
               // when FlatRedBallServices is initialized.  Therefore, force the graphics device
               // to match the form's height/width.
               FlatRedBallServices.GraphicsOptions.SuspendDeviceReset();
               {
                   FlatRedBallServices.GraphicsOptions.ResolutionHeight = form.Height;
                   FlatRedBallServices.GraphicsOptions.ResolutionWidth = form.Width;
               }
               FlatRedBallServices.GraphicsOptions.ResumeDeviceReset();
               FlatRedBallServices.GraphicsOptions.ResetDevice();
           }

And you are done. Press F5 and if FRB initialised the panel will now be black with the red ball in the middle.

![InWinform.png](/media/migrated_media-InWinform.png)

In case you wish to resize your form, please add the following to the ResizeEnd event of the form. This enforces FRB to use the new ClientSize.

           FlatRedBall.FlatRedBallServices.ForceClientSizeUpdates();

Congratulations. You just implemented FRB on a windows form.

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum/.md) for a rapid response.
