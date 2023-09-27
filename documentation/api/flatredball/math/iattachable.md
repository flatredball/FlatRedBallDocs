## Introduction

IAttachables provide properties and methods to control attachments.

## What are attachments?

An attachment is a relationship between two [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") in which one is identified as the parent object and one as the child object. The child object's absolute rotation and position values become read-only and its position and rotation are controlled by its parent's absolute position and rotation values as well as its own relative position and rotation values. The following examples highlight some of the uses of attachments:

-   Relatively positioned objects: There are certain objects which should always be positioned relative to another object, like wings on an airplane. It doesn't matter if the airplane is positioned at x = 0 or 50, nor does it matter if the plane is rotated. The wings should always appear in the same relative position to the airplane. Furthermore, we would like the wings to move with the airplane, so that we don't have to readjust their position every frame.

&nbsp;

-   Orbits: Attached [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") do not have to be touching for the attachment to be valid. We could easily have one object orbit around another by attaching the orbiting [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") to an invisible, spinning [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") positioned at the center of the orbit.

&nbsp;

-   Complex curved movements: Attachments can be multiple levels deep. Using multiple levels of relative coordinate systems, complex motion can be easily modeled. Although not very practical in game programming, the movement of objects on Earth relative to the Sun exemplifies such complex movement; objects on the Earth move around the center of the Earth as it rotates, but the Earth also orbits the Sun.

&nbsp;

-   Redefining a [PositionedObject's](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") rotational center: Some objects may need to be rotated, but their center is not at the center of the object. One example is a turret on a space ship. The barrel and round base may be one long [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"), however, it should rotate about its base rather than the center of the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"), which may be somewhere on the barrel. A joint [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") can be positioned at the desired rotational center, and the turret can be attached to the joint. Now, rotating the joint will rotate the gun along its base. The joint can also be attached to a ship, and behavior will be the same, assuming relative rotation is used rather than absolute rotation.

&nbsp;

-   Skeletons: The idea of having a jointed object can be extended to create large skeletal structures. That is, a hand could be attached to a joint, which is attached to the forearm, which is attached to an elbow joint, which is attached to the upper arm, which is attached to a shoulder joint, which is (finally!) attached to the body. Moving the body moves the entire arm. Rotating the shoulder joint rotates everything "below" in the hierarchical relationship.

## Relative Values

The relative values in an IAttachable are effective **only if an IAttachable has a parent**. Otherwise they sit idle and do nothing to the IAttachable.

## Creating Attachments

The following code creates two [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"). The larger [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") is the parent [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"). The smaller [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") is the child [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") which is attached to the parent [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"). Notice that attachments are created through the child and not the parent.

    // Replace your Initialize method with the following:
    protected override void Initialize()
    {
        FlatRedBallServices.InitializeFlatRedBall(this, this.graphics);

        Sprite parentSprite = SpriteManager.AddSprite("redball.bmp");
        parentSprite.ScaleX = 3;
        parentSprite.ScaleY = 3;

        parentSprite.CustomBehavior += PositionSpriteAtCursor;

        Sprite childSprite = SpriteManager.AddSprite("redball.bmp");
        // Set the absolute position before attaching childSprite to 
        // parentSprite.
        childSprite.X = 4;

        childSprite.AttachTo(parentSprite, true);

        base.Initialize();
    }

    // The following method is used to reposition the parent Sprite.
    void PositionSpriteAtCursor(Sprite sprite)
    {
       // Since our Sprites exist in a 3D world, the WorldXAt and 
       // WorldYAt methods require a Z value.
       sprite.X = InputManager.Mouse.WorldXAt(0);
       sprite.Y = InputManager.Mouse.WorldYAt(0);
    }

![ChildAndParentSprite.png](/media/migrated_media-ChildAndParentSprite.png)

## AttachTo Method

The AttachTo method creates a child-parent relationship between to IAttachables. The child IAttachable creates the relationship by calling AttachTo and passing the parent as the first argument. A parent can have any number of children, but a child can only have one parent. Calling AttachTo a second time breaks the first child-parent relationship and creates a new attachment between the calling instance and the instance passed as the first argument to the AttachTo method. The second argument determines whether relative values change, which also determines whether absolute values remain the same before and after the AttachTo call. For more information see the [AttachTo page](/frb/docs/index.php?title=FlatRedBall.Math.PositionedObject.AttachTo&action=edit&redlink=1.md "FlatRedBall.Math.PositionedObject.AttachTo (page does not exist)").

### Relative Positioning

All IAttachables have relative versions of position, velocity, acceleration, rotation, and rotational velocity. Relative properties are named the same as their absolute counterparts prefixed with the word "Relative". If the IAttachable is a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") as is the case with [Sprites](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite"), [Cameras](/frb/docs/index.php?title=FlatRedBall.Camera.md "FlatRedBall.Camera"), [Text objects](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text"), and [Emitters](/frb/docs/index.php?title=FlatRedBall.Graphics.Particle.Emitter.md "FlatRedBall.Graphics.Particle.Emitter"), then the following relationships hold:

|                     |                           |
|---------------------|---------------------------|
| "Absolute" Property | "Relative" Property       |
| X                   | RelativeX                 |
| Y                   | RelativeY                 |
| Z                   | RelativeZ                 |
| XVelocity           | RelativeXVelocity         |
| YVelocity           | RelativeYVelocity         |
| ZVelocity           | RelativeZVelocity         |
| XAcceleration       | RelativeXAcceleration     |
| YAcceleration       | RelativeYAcceleration     |
| ZAcceleration       | RelativeZAcceleration     |
| RotationX           | RelativeRotationX         |
| RotationY           | RelativeRotationY         |
| RotationZ           | RelativeRotationZ         |
| RotationXVelocity   | RelativeRotationXVelocity |
| RotationYVelocity   | RelativeRotationYVelocity |
| RotationZVelocity   | RelativeRotationZVelocity |

### Remember, child absolute values are read-only

As mentioned before, if a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") has a parent, then its absolute values are read only. For example, consider the X (or Position.X) value. If an object has a parent, then its X position (ignoring rotation) is:

    child.X = parent.X + object.RelativeX;

Therefore, if your code sets the X value, it will just get overwritten before rendering by the above code. This is the same for:

-   position
-   velocity
-   acceleration
-   rotation
-   rotational velocity.

### Child absolute velocity and acceleration

While absolute position and rotation values are read-only, velocity and acceleration values should not be used at all. Let's examine why velocity is not usable. As mentioned above, attachments result in the absolute position being set every frame according to the Parent's absolute position and the child's relative position. That means that the Position variable is reset every frame. But the Velocity variable also changes the variable every frame. That means that both attachments and Velocity will modify the absolute position of your object. So what happens if you have a non-zero Velocity? The Velocity will add itself (considering time) every frame, but just before drawing, attachments will set the Position property - overriding the changes that occurred earlier in the frame when Velocity was applied. Reading Velocity can also be misleading because velocity is not by default a "reactive" property. That means that if an object is moved by its Parent, the Velocity property will not automatically update itself according to the movement performed due to the attachment. However, making velocity reactive is possible using ["Real" values](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md#Real_Velocity_and_Acceleration "FlatRedBall.PositionedObject").

## "Changing the center" of a [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject")

By default all [PositionedObjects](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") are positioned at their center (the exception to this is the [Text object](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text")). This can be changed using attachments. First, let's look at the default center and points of rotation. We'll use a [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") to show how this works ([Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") inherits from [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") which implements IAttachable.

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.ScaleX = 5;
    sprite.ScaleY = 5;
    sprite.RotationZVelocity = 1;

![RotatingSprite.png](/media/migrated_media-RotatingSprite.png) As expected the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") rotates about its center. To change the point that the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") rotates about, we need to use an additional [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"). We'll add a simple [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject"), attach the [Sprite](/frb/docs/index.php?title=FlatRedBall.Sprite.md "FlatRedBall.Sprite") to it, then make the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") rotate. Notice that we must add the [PositionedObject](/frb/docs/index.php?title=FlatRedBall.PositionedObject.md "FlatRedBall.PositionedObject") to the [SpriteManager](/frb/docs/index.php?title=FlatRedBall.Sprite.mdManager "FlatRedBall.SpriteManager") or else the RotationZVelocity member will not apply automatically.

    PositionedObject anchor = new PositionedObject();
    SpriteManager.AddPositionedObject(anchor);
    // Position the anchor where we want the rotation point
    // This will put it at the top-left of the Sprite
    anchor.X = -5;
    anchor.Y = 5;
    anchor.RotationZVelocity = 1;

    Sprite sprite = SpriteManager.AddSprite("redball.bmp");
    sprite.ScaleX = 5;
    sprite.ScaleY = 5;
    // We no longer make the Sprite rotate - the parent rotates
    // We want to "change relative" so that the Sprite's absolute
    // values remain the same:
    bool changeRelative = true;
    sprite.AttachTo(anchor, changeRelative);

![NewRotationPoint.png](/media/migrated_media-NewRotationPoint.png)

**Stop right there!** The code shown above for attaching is as brief as possible and simply shows the raw syntax behind attachments. However, you may be using Glue, and if so you shouldn't be writing the code above. Instead, you will likely have the above situation mostly set up - the PositionedObject will be the Entity itself and the Sprite will be a Sprite (or Entire Scene) Object in Glue. Instead of doing this in code, you should simply offset the Sprite in the SpriteEditor. Then when the Entity rotates, the Sprite will rotate about an offset naturally.

## IAttachable Members

-   [FlatRedBall.Math.IAttachable.Detach](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.Detach.md "FlatRedBall.Math.IAttachable.Detach")
-   [FlatRedBall.Math.IAttachable.ParentRotationChangesPosition](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.ParentRotationChangesPosition.md "FlatRedBall.Math.IAttachable.ParentRotationChangesPosition")
-   [FlatRedBall.Math.IAttachable.ParentRotationChangesRotation](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.ParentRotationChangesRotation.md "FlatRedBall.Math.IAttachable.ParentRotationChangesRotation")
-   [FlatRedBall.Math.IAttachable.TopParent](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable.TopParent.md "FlatRedBall.Math.IAttachable.TopParent")

## Additional Information

-   [FlatRedBall.Math.IAttachable:Attachment Updates in the Engine](/frb/docs/index.php?title=FlatRedBall.Math.IAttachable:Attachment_Updates_in_the_Engine.md "FlatRedBall.Math.IAttachable:Attachment Updates in the Engine")
-   [Two-way relationships](/frb/docs/index.php?title=FlatRedBall.Math.AttachableList#Two_Way_Relationships.md "FlatRedBall.Math.AttachableList") - Explains how two-way relationships work between IAttachables and the lists they belong to.

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
