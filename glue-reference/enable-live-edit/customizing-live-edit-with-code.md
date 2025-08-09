# Customizing Live Edit with Code

## Introduction

When games run in Live Edit, they still run much of the same code that runs when the game is played normally. This means that custom code can be added to live edit to perform custom logic while the game is being edited. Common types of things that might be added to a game include:

* Adding labels, arrows, boxes, sprites, and other overlays to help provide information while editing
* Validating and displaying errors on screen, such as if a door does not have a proper exit point
* Displaying particles, animations, or other type of behavior that requires custom code
* Adding custom UI using Gum for things like scrollbars to move through a level, or buttons for common actions such as toggling the visibility of objects

The following image shows examples of how live edit can be customized to make it easier to work on your game.

1. A green rectangle showing the screen boundaries
2. The name of an enemy spawn along with a sprite displaying the enemy type
3. An icon next to a power-up container displaying what is revealed when the container is destroyed
4. The current camera Y position
5. A scroll bar for moving through the level quickly

<figure><img src="../../.gitbook/assets/09_14 20 01.png" alt=""><figcaption></figcaption></figure>

## CustomActivityEditMode

Every Screen and Component can add a CustomActivityEditMode method which can contain every-frame activity that runs only in edit mode. This is a partial method, so it is not added by default, but it can be added manually.

For example, consider an Entity called TestEntity with the following code:

<pre class="language-csharp"><code class="lang-csharp">public partial class TestEntity
{
    private void CustomInitialize()
    {


    }

    private void CustomActivity()
    {


    }

<strong>    partial void CustomActivityEditMode()
</strong><strong>    {
</strong><strong>        GlueControl.Editing.EditorVisuals.Text(
</strong><strong>            "Hello", Vector3.Zero);
</strong><strong>    }
</strong>
    private void CustomDestroy()
    {


    }

    private static void CustomLoadStaticContent(string contentManagerName)
    {


    }
}

</code></pre>

When the entity is selected in edit mode, it displays the text "Hello".

<figure><img src="../../.gitbook/assets/image (370).png" alt=""><figcaption><p>Hello text displayed in CustomActivityEditMode</p></figcaption></figure>

## Detecting Edit Mode

Functions like CustomInitialize, CustomDestroy, and CustomLoadStaticContent run in both normal and live edit mode. You can perform conditional logic in these methods in edit mode. You can check the state of the game using a number of variables, as shown in the following block of code:

```csharp
// checks if the entire game is in edit mode:
if(FlatRedBall.Screens.ScreenManager.IsInEditMode)
{
    // game is in edit mode
}
if(FlatRedBall.Screens.ScreenManager.CurrentScreen is 
    GlueControl.Screens.EntityViewingScreen entityViewingScreen)
{
    // game is viewing an entity
    var currentEntity = entityViewingScreen.CurrentEntity;

    if(currentEntity is Player)
    {
        // viewing the Player entity
    }
}
```

