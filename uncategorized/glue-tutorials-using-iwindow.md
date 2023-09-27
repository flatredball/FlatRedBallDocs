## Introduction

If you've been reading the tutorials in order, then you have just finished the [tutorial on IClickable](/frb/docs/index.php?title=Glue:Tutorials:Using_IClickable.md "Glue:Tutorials:Using IClickable"). IClickable can be used to tell you if a Cursor is over an Entity, which is the basis for creating GUIs in games that use a mouse or touch screen. However, while the IClickable gets us a lot of functionality, there are a number of problems which must still be solved in custom code when writing a UI system. For more advanced UI systems, Glue offers the IWindow interface. IWindow extends the IClickable interface by adding events for common UI input actions such as an object being clicked or the cursor moving over an object.

## What problems can IWindow solve?

There are a number of benefits to using the IWindow interface:

-   Addition of Events which are automatically called by the [GuiManager](/frb/docs/index.php?title=FlatRedBall.Gui.GuiManager.md "FlatRedBall.Gui.GuiManager")
-   Support for preventing "click-throughs" (a click registering on two objects at once, such as overlapping buttons)

In short, the IWindow interface can give your Entities the functionality and ease of use you'd get from using the non-customizable FRB GUI system, or even Windows Forms, but with all of the customization and code generation you get from Glue.

## Making an entity implement IWindow

Implementing IWindow on an Entity is essentially the same as implementing IClickable - simply change the "Implements IWindow" property to true:

![](/media/2016-11-img_581f9c05be9ab.png)

**Got a popup about IVisible?** You may get a popup about implementing IVisible as follows:

![](/media/2016-11-img_581f9be988634.png)

This tutorial specifies that IWindows must also implement the IVisible interface. The IVisible interface simply means that the object has a Visible property. Don't worry, if you get this it just means Glue is going to automatically make a Visible property for your Entity.

## IWindow has the HasCursorOver method

Once you tell Glue to implement the IWindow interface, it will automatically generate an implementation of the HasCursorOver method for you. Therefore, if you like the pattern of checking whether the cursor is over an object in custom code, you can still do that with IWindow. But as we'll show in the next sections, you won't even have to run checks yourself - just use events.

## IWindow events

Once an Entity implements IWindow, Glue will automatically generate a number of fully-functional events. In this tutorial we'll use the Click event, which is perhaps the most commonly used event in PC GUIs. To use the Click event:

1.  Expand the Entity that implements IWindow
2.  Right-click on Events
3.  Select "Add Event"
4.  Select the "Expose" option
5.  Use the drop-down to select "Click" ![ExposeClickEvent.png](/media/migrated_media-ExposeClickEvent.png)

Glue will add an implementation for the Click event. You can access this in one of two ways:

-   Go to Visual Studio and open the Event file for your Entity. If your Entity is called "Button" then you will have a file named "Button.Event.cs". This file may be embedded under Button.cs, so you will have to expand the Button.cs node in the Solution Explorer.

--or--

-   Expand the Events item under Glue and select the newly-created event. Glue will provide a code window for you to add implementation for your button.

Both methods will ultimately result in the code being added to the same place, so which you choose is simply a matter of convenience and preference. You can implement code as follows: The OnClick method will automatically be created for you in Glue - you just have to fill it in:

    void OnClick(IWindow button)
    {
        // Just adding this to give the Button some kind of behavior.  You'll want to put something more
        // appropriate here.
        this.X += 1;
    }

## Events are available per instance

The example above shows how to add an event to an Entity inside the Entity's own code. Every event created by Glue when implementing IWindow is public, meaning you can implement these events per instance instead on the Entity itself. In other words, if you had an instance called ButtonInstance in a Screen, you could add the following code in the Screen's CustomInitialize:

    ButtonInstance.Click += OnClickInScreen;

You can also tunnel in to the Button's Click event through the Add Event menu option.

## Preventing click-throughs

Next we'll look at how to prevent click-throughs. If you're not sure what a click-through is, consider the following. Assume you are making a game where clicking on the world map causes the main character to move to that location (like Diablo or Titan Quest). Your code may look like this:

    Cursor cursor = GuiManager.Cursor;
    if(cursor.PrimaryClick)
    {
       CharacterInstance.MoveTo(
           cursor.WorldXAt(0),
           cursor.WorldYAt(0));
    }

In your game you also have a "Menu" button which the user can click on to go to the menu. However, when you click on the Menu button, the game logic detects that you have clicked and tells the main character to move. Of course, you could check to see whether the Menu button HasCursorOver, but this is not a very good solution. This code will need to be modified whenever you add a new button, and you would need to remember to check every button's HasCursorOver wherever your game checks for clicking. Instead, you can simply see if the Cursor is over any Windows:

    if(cursor.PrimaryClick && cursor.WindowOver == null)
    {
       CharacterInstance.MoveTo(
           cursor.WorldXAt(0),
           cursor.WorldYAt(0));
    }

The WindowOver property will return any Entity that the cursor is over. Using this can prevent your game from clicking through GUI and causing unintended consequences.

## Enabled Property

IWindows have an Enabled property which you can set to true/false. It is set to true by default meaning that your IWindow-implementing Entity will respond to UI actions by raising events. If you set this to false, your Entity will not raise events like Click.

## That's it!

That's all you need to know to begin using IWindows.
