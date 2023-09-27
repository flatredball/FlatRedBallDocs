## Introduction

The InterpolateToState method allows Entities and Screens to smoothly interpolate (also known as "tweening") from one state to another over time. For example, you could set up two States for a Button Entity like "OffScreen" and "OnScreen", where each State set the X variable of the Entity. Interpolating between States allows for easily making the button slide on and off screen.

If you are working with an Entity or Screen that has multiple States, then Glue has already gneerated an InterpolateToState for you.

See [this page](/frb/docs/index.php?title=Glue:Reference:States:InterpolateToState_vs_InterpolateBetween.md "Glue:Reference:States:InterpolateToState vs InterpolateBetween") to discuss the difference between InterpolateToState and InterpolateBetween.

## Example

-   [GlueVault Download](http://www.gluevault.com/entity/30-interpolating-entity)

For this example we'll create a simple Entity that contains a Circle. We'll create some Variables and States to modify the Entity and show how they work in code.

First, let's create the Entity:

-   Right-click on your Entities item and select "Add Entity"
-   Name the Entity "InterpolatingEntity" and click OK
-   Right click on your newly-created Entity's Objects and select "Add Object"
-   Enter the name "Circle" and click OK
-   Select your newly-created object and change its SourceType to "FlatRedBallType"
-   Change SourceClassType to "Circle"

Next we'll create some Variables that we'll use in our States:

-   Right-click on the Variables item and select "Add Variable"
-   Under the "Expose Existing" tab, select "X" and click OK
-   Right-click (again) on the Variables item and select "Add Variable"
-   Under the "Tunneling" tab, select "Circle" as the Object, and select "Radius" as the Variable and click OK
-   Set the default value of the newly-created CircleRadius variable to 1

Now that we have our Variables, let's create States for them:

-   Right-click on the States item and select "Add State"
-   Enter the name "Left"
-   Create a second state called "Right"
-   Create a third state called "Big"
-   Create a fourth state called "Small"

**Note:**In this example we created four states which are all uncategorized. In an actual project you would probably want to categorize these under state categories. You would likely want to set these state categories' [SharesVariablesWithOtherCategories](/frb/docs/index.php?title=Glue:Reference:States:State_Categories.md "Glue:Reference:States:State Categories") value to false as well.

These states need to have variables assigned to them:

-   Select "Left" and set the X value to -3
-   Select "Right" and set the X value to 3
-   Select "Big" and set the CircleRadius value to 6
-   Select "Small" and set the CircleRadius to 2

Finally we'll want to make sure that there is an instance of our InterpolatingEntity that we can see in the game

-   Right-click on the "Screens" item and select "Add Screen"
-   Name the Screen "TestScreen" and click OK
-   Click+drag the InterpolatingEntity onto TestScreen
-   A notification will appear asking you if you want to create a new Object in TestScreen. Click Yes.

At this point we have four states. They've been intentionally created so that they can be interpolated between each other. This is done by having each pair of states (Left/Right and Big/Small) modify the same values. That is, both Left and Right modify the X value. Since they set the same value then they can be interpolated between.

If you created another state called "Up" which modified the Y value, you would not be able to interpolate between the "Up" and "Left" states. Technically, you could still call InterpolateToState, but you wouldn't see anything happen. Usually when you intend to use InterpolateToState, you will create two (or more) states which modify the same variables.

## InterpolateToState and State Categories

Glue will generate an InterpolateToState method for each category which has its SharesVariablesWithOtherCategories value set to false as well as an InterpolateToState method for uncategorized states.

## Interpolation in code

Now that we have our Entity and states set up, let's create the code. Open up the InterpolatingEntity.cs file and add the following code to your CustomActivity method:

    double interpolationTime = 1;

    if (InputManager.Keyboard.KeyPushed(Keys.Up))
    {
        InterpolateToState(VariableState.Big, interpolationTime);
    }

    if (InputManager.Keyboard.KeyPushed(Keys.Down))
    {
        InterpolateToState(VariableState.Small, interpolationTime);
    }

    if (InputManager.Keyboard.KeyPushed(Keys.Left))
    {
        InterpolateToState(VariableState.Left, interpolationTime);
    }

    if (InputManager.Keyboard.KeyPushed(Keys.Right))
    {
        InterpolateToState(VariableState.Right, interpolationTime);
    }

![InterpolateBig.PNG](/media/migrated_media-InterpolateBig.PNG)
