## Introduction

Attachments are a feature in FlatRedBall which provides a convenient way of moving or rotating one object (called the child) relative to another object (called a parent). The interface for attachments is provided by the IAttachable interface. Objects which implement the IAttachable interface usually provide properties for position or rotation, although they don't have to. However, in most cases you will never need to worry about implementing the IAttachable interface yourself, so we won't cover how to do that in this tutorial.

The most common type of IAttachable is the [PositionedObject](/frb/docs/index.php?title=PositionedObject.md "PositionedObject") class. The [PositionedObject](/frb/docs/index.php?title=PositionedObject.md "PositionedObject") class is the base class for many common FlatRedBall objects including [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite"), [Camera](/frb/docs/index.php?title=Camera.md "Camera"), [Texts](/frb/docs/index.php?title=Text.md "Text"), and the [Entities](/frb/docs/index.php?title=Entity.md "Entity") pattern. If you've been working through the tutorials so far, then you've worked with [PositionedObjects](/frb/docs/index.php?title=PositionedObject.md "PositionedObject") already.

## Creating Attachments

Attachments are very easy to create. The following code creates two [Sprites](/frb/docs/index.php?title=Sprite.md "Sprite"). The larger [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite") is the parent and the smaller one (which is attached to the larger one) is the child.

    Sprite parent = SpriteManager.AddSprite("redball.bmp");
    parent.ScaleX = 4;
    parent.ScaleY = 4;
    // Start spinning this Sprite so the attachment can be seen
    parent.RotationZVelocity = 1;

    Sprite child = SpriteManager.AddSprite("redball.bmp");
    child.X = 6;
    bool keepSamePosition = true;
    child.AttachTo(parent, keepSamePosition);

![RotateAndAttachment.png](/media/migrated_media-RotateAndAttachment.png)

The child [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite") is attached to the parent Sprite. This means that if the parent rotates or moves, the child follows, always preserving the same relative position and rotation. To show this we've made the parent rotate and shown that the child is automatically updating its position.

## Absolute and relative

The absolute modifier in "absolute position" and "absolute rotation" means the position or rotation of an object in "world coordinates". When you think of position or rotation, you are likely thinking of absolute coordinates. Actually, absolute values are actually relative, but they're relative to the "origin" and "world coordinate system" - two frames of reference which never change.

The parent object's absolute position is at (0,0,0) - the default. Its Z rotation is continually changing due to its RotationZVelocity.

As far as the parent object goes, its relative values currently have no meaning - it isn't attached to anything so its relative values have no impact. In fact, you can change any relative value of the parent and so long as it isn't attached to another [PositionedObject](/frb/docs/index.php?title=PositionedObject.md "PositionedObject"), these changes won't have any impact.

Next, let's look at the child.

The child also has an absolute position and rotation - and both of these are changing every frame. We never wrote any code to explicitly change these; however, they change because the parent is rotating, and the parent's rotation movement impacts the absolute position and rotation of the child.

The phrase "relative to" can also be thought of as "from the point of view of". For example, if I asked you to "hold your arm out straight to the right", you can do this without considering where you are. It doesn't matter if you're on the ground, or in an airplane, or in a swimming pool (hopefully not while reading this), or even upside-down. This command is understood regardless of your position or orientation because it's **relative to you**. This example isn't just an easy way of understanding relative values - it's also an example of why relative values are so valuable.

To return to the "hold your arm out straight to the right" example, consider if I had to give this command using absolute coordinates. Well, in the real world this is difficult to do because there really isn't an absolute frame of reference. Some measurements use the earth as a frame of reference (longitude and latitude), some use the ocean (distance above sea level), and some might even use other arbitrary measurements (23 minutes west of New York City).

But let's say we were to use altitude and longitude/latitude to give you the command of holding your arm out straight to the right. To do this I might have to give you the coordinates of where your arm should be using these three coordinates...but that's very difficult to do because the command becomes very complex. That is, I'd have to take in so many considerations like what you're standing/sitting on, the altitude of where you are, which direction you're facing, and so on. And if you're somewhere that's moving (like a car or airplane), then the command becomes essentially impossible because I'd have to update the command continually! Doesn't "hold your arm out straight to the right" seem so much easier?

Similarly, relative positions can be just as useful. If you want to have a health bar display above a character, you can simply attach it and set its RelativeY - you don't have to worry about where the character is in the world, or whether he's running or falling - you simply perform the attachment and it's valid until you actively remove it.

## Setting child absolute values before attachment

A very common mistake in FlatRedBall is forgetting which properties are active in which situation. This all depends on whether your object has an attachment or not.

As mentioned before, the parent [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite") has no attachment. Therefore, if we change the position of the parent, it will update fine. That is, if we write:

    parent.X = -2;

then the parent will be 2 units further to the left. But what about the child?

In the case of the child, it depends. First consider the keepSamePosition argument that we're passing to AttachTo. This is the second argument of AttachTo which controls whether the object that is being attached to its parent should have its relative values changed when the attachment occurs. If this value is true, the child remains in the same absolute position and has the same absolute rotation after the attachment as before.

If this value is false, then the absolute position of the child is ignored, and its relative positions is used. The default relative values of the child are (0,0,0) for position and 0 for rotation (unrotated). Let's change the keepSamePosition value to false to see what happens:

    Sprite parent = SpriteManager.AddSprite("redball.bmp");
    parent.ScaleX = 4;
    parent.ScaleY = 4;
    // Start spinning this Sprite so the attachment can be seen
    parent.RotationZVelocity = 1;

    Sprite child = SpriteManager.AddSprite("redball.bmp");
    child.X = 6; //<-------- This no longer matters at all!!
    bool keepSamePosition = false; //<------- This changed
    child.AttachTo(parent, keepSamePosition);

![AttachmentWithoutPreservingAbsolute.png](/media/migrated_media-AttachmentWithoutPreservingAbsolute.png)

Now the child [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite") is centered on the parent. Of course, the parent's rotation still impacts the rotation of the child, and if the parent were to move, the child would also move with it. As mentioned in the comments above, **the setting of the position of the child before the attachment has no impact on the child after the attachment.** Its **absolute position is ignored** and **overwritten** according to the absolute position of the parent and the child's relative values. You can try changing the setting of X = 6 to any other value and you'll see that it has no impact on the position of the child.

So to sum up what we've just looked at:

**A child's absolute values before attachment are considered only if the second argument to AttachTo is true.**

So, you may be asking, when should the second argument be true? In practice attachments occur in one of two situations - when an object is created or due to some behavior at some point after the object is created.

If the attachment occurs when the object is created, usually the second argument should be false. For example, if you are creating a character who is going to always wear a hat, then you may first create the character [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite"), then the hat [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite"), then you'll want to attach the hat to the character. In this case, you'll probably want to simply set the relative value of the hat, and the absolute position of the hat before attachment doesn't really matter.

If the attachment occurs at some point during runtime, you may want to have the second argument be true. For example, consider a game like [Katamari Damacy](http://en.wikipedia.org/wiki/Katamari_Damacy). This game is played by controlling a ball around an environment, picking up objects to grow the ball. As soon as an object is touched by the ball, it sticks to the ball and continues to rotate with the ball. This is a perfect example of where attachments would be used and the second argument would be true. Any object that touches the ball should immediately stick to it, but at the moment when the "sticking" occurs, the object should stay in the same position and orientation. After the "sticking", the object is then subject to the movement and rotation of the parent ball.

## Setting child relative values before attachment

We've looked at what happens to a child's absolute values when an attachment occurs and have seen that it depends on the second argument to AttachTo. But what about relative values before attachment? Are those considered? As hinted above, whether a child's relative values are considered during attachment depends on the second argument to AttachTo. In fact, only relative or absolute values can be considered. If absolute values are considered, then relative values are ignored and overwritten. If the second argument is false, then absolute values are ignored and overwritten.

In short, **the second argument to AttachTo controls whether the relative or absolute values should be used during the AttachTo call**. It's very important to remember that this argument controls whether absolute or relative are used **only during the AttachTo call, not after!**. Once the attachment occurs, **absolute values become read-only.**

The next section explains in more details.

## Absolute position after attachment

Once the AttachTo method has finished, absolute positions become read only. Let's test this:

    Sprite parent = SpriteManager.AddSprite("redball.bmp");
    parent.ScaleX = 4;
    parent.ScaleY = 4;
    // Spinning has been removed

    Sprite child = SpriteManager.AddSprite("redball.bmp");
    bool keepSamePosition = false;
    child.AttachTo(parent, keepSamePosition);
    // The child is now attached.  Absolute is read-only
    child.X = 10;

**Notice:** I removed the spinning and the setting of child.X = 6 to simplify the code.

In the code above I first perform an attachment, then after the attachment occurs I set the child's X to 10. But does the child's X remain at 10? No, as the image shows, the child's X stays at 0.

![AttachmentWithoutPreservingAbsolute.png](/media/migrated_media-AttachmentWithoutPreservingAbsolute.png)

This isn't just for X; any absolute property (Y, Z, Velocity, Acceleration, RotationZ) is ignored.

That means that if you want to change any absolute value of a child, you have to do it "through the parent". In other words, you have to change its relative values:

    Sprite parent = SpriteManager.AddSprite("redball.bmp");
    parent.ScaleX = 4;
    parent.ScaleY = 4;
    // Spinning has been removed

    Sprite child = SpriteManager.AddSprite("redball.bmp");
    bool keepSamePosition = false;
    child.AttachTo(parent, keepSamePosition);
    // Better use Relative values if you want them to actually be used after attachment:
    child.RelativeX = 10;

![RelativeValuesInAction.png](/media/migrated_media-RelativeValuesInAction.png)

## Attachments and [Entities](/frb/docs/index.php?title=Entity.md "Entity")

If you continue reading our FlatRedBall tutorials, or if you check the forums, you're bound to come across the term [Entity](/frb/docs/index.php?title=Entity.md "Entity") sooner or later. While this tutorial won't cover how to create one, we will mention them at a high level because they are a very common pattern in FlatRedBall game development.

As you create your game, you'll likely want to create an object which will have some kind of graphical representation (like a [Sprite](/frb/docs/index.php?title=Sprite.md "Sprite")) and will also need some type of collision (we cover collision in the next tutorial). FlatRedBall provides classes for both of these behaviors, but they aren't the same. This is where the [Entity](/frb/docs/index.php?title=Entity.md "Entity") pattern shines.

The [Entity](/frb/docs/index.php?title=Entity.md "Entity") pattern is an object which inherits from the [PositionedObject](/frb/docs/index.php?title=PositionedObject.md "PositionedObject") class and has a visible representation object and a collision object. In FlatRedBall all classes which can be used as visible representations inherit from the [PositionedObject](/frb/docs/index.php?title=PositionedObject.md "PositionedObject") class. Similarly, all objects which are used for collision also inherit from the [PositionedObject](/frb/docs/index.php?title=PositionedObject.md "PositionedObject") class. Since the [Entity](/frb/docs/index.php?title=Entity.md "Entity") does as well, then the collision and visible representation can be attached to the entity. This means that you don't have to worry about the individual components when controlling your [Entity](/frb/docs/index.php?title=Entity.md "Entity"). In other words, you can simply position and rotate your [Entity](/frb/docs/index.php?title=Entity.md "Entity") and its attached visible representation and collision will move with it automatically.

This is just a brief explanation of how [Entities](/frb/docs/index.php?title=Entity.md "Entity") work, but keep it in mind as you read about them later on.
