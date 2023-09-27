## Introduction

The ForceUpdateDependencies forces the calling PositionedObject and all of its parents to update absolute values according to relative values. This method can be called if an update is needed immediately (instead of waiting for the next Draw call). For more information on attachments, check the [IAttachable page](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.md "FlatRedBall.Math.IAttachable").

## Common Usage

In many cases, if you have a parent object and a child object, you will not need to manually manage this attachment by calling ForceUpdateDependencies. However, calling ForceUpdateDependencies may be necessary in certain cases. As explained in [this article](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.md:Attachment_Updates_in_the_Engine "FlatRedBall.Math.IAttachable:Attachment Updates in the Engine"), setting the relative value of a child object **does not immediately change its absolute value**. Similarly, changing the absolute value of a parent also does not immediately update the absolute value of a child. These updates occur right before drawing occurs. Therefore, if you have created a new attachment or modified the values involved in an attachment and would like to see these updates immediately impact the absolute value of all children, then you need to call ForceUpdateDependencies.

## Code Example - Modifying child relative values

The following created two [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text") objects. Both are attached to a PositionedObject, but only one calls ForceUpdateDependencies. Then the DisplayText is set to show each [Text's](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text") absolute Y value. Notice only the one which called ForceUpdateDependencies has a non-zero Y value. Add the following using statements:

    using FlatRedBall.Graphics;

Add the following to Initialize after initializing FlatRedBall:

     Text firstText = TextManager.AddText("");
     Text secondText = TextManager.AddText("");

     PositionedObject parent = new PositionedObject();

     firstText.AttachTo(parent, false);
     secondText.AttachTo(parent, false);

     firstText.RelativeY = 2;
     secondText.RelativeY = -2;
     // At this point the relative values have not
     // yet been applied to change absolute values.
     // Calling ForceUpdateDependencies forces an update
     // resulting in the absolute Y value changing.
     firstText.ForceUpdateDependencies();

     // Now set the DisplayText to show if they've been changed
     firstText.DisplayText = "My Y in Initialize is: " + firstText.Y;
     secondText.DisplayText = "My Y in Initialize is: " + secondText.Y;

![ForceUpdateDependencies.png](/media/migrated_media-ForceUpdateDependencies.png)

## Code Example - Modifying parent absolute values

The example above showed a situation where a child's relative values were read out immediately after an attachment was created. This example shows a similar situation - where the parent object is moved. You can comment and uncomment out the ForceUpdateDependencies call to see the difference. Add the following using statements:

    using FlatRedBall.Graphics;

Add the following to Initialize after initializing FlatRedBall:

     Sprite parent = SpriteManager.AddSprite("redball.bmp");

     Sprite child = SpriteManager.AddSprite("redball.bmp");
     child.AttachTo(parent, false);

     // At this point, both child and parent have a position of (0,0,0)
     // Let's move the parent:
     parent.X = 5;
     parent.Y = 3;
     // At this point the parent is at (5,3,0), but the child hasn't had
     // it's dependencies updated yet, so it's still at (0,0,0)
     Vector3 positionBeforeUpdate = child.Position;
     child.ForceUpdateDependencies();
     Vector3 positionAfterUpdate = child.Position;

     // Now let's output this to the screen so we can see it:
     string stringToOutput =
         "Position before: " + positionBeforeUpdate + "\n" +
         "Position after: " + positionAfterUpdate;

     Text text = TextManager.AddText(stringToOutput);

![ForceUpdateDependenciesParentReposition.png](/media/migrated_media-ForceUpdateDependenciesParentReposition.png)
