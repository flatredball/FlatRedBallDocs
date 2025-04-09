# CameraControllingEntity

### Introduction

The CameraControllingEntity is an object which provides convenient camera positioning and zooming functionality. It is included by default in the Top Down and Platformer projects when using the New Project Wizard.

Typically an instance of the CameraControllingEntity is created in the FRB Editor in GameScreen. For more information on working with the CameraControllingEntity in the FRB editor, see the [FRB Editor CameraControllingEntity page](../../../glue-reference/objects/object-types/cameracontrollingentity.md).

### Target

The Target property controls the desired location of the CameraControllingEntity. If a Target is assigned, the CameraControllingEntity changes its position to move towards the target according to the other properties assigned such as the Map and TargetApproachStyle.

Target can be assigned in code to change the desired position. The following code shows how to change between two targets by pressing the 1 and 2 keys on the keyboard:

```csharp
void CustomActivity(bool firstTimeCalled)
{
    var keyboard = InputManager.Keyboard;
    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D1))
    {
        CameraControllingEntityInstance.Target = TargetEntity1;
    }
    else if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D2))
    {
        CameraControllingEntityInstance.Target = TargetEntity2;
    }
}
```

<figure><img src="../../../.gitbook/assets/02_05 56 02.gif" alt=""><figcaption><p>Switching Targets with key presses</p></figcaption></figure>

Most games use a Target which is an Entity or Targets for multiple objects (as shown below). You can also create PositionedObjects to control the movement of the CameraControllingEntity as shown in the following code:

```csharp
// At class scope, such as in GameScreen
PositionedObject CameraTarget;

void CustomInitialize()
{
    CameraTarget = new PositionedObject();
    // If you want to have the CameraTarget apply velocity and acceleration, you 
    // can add it to the SpriteManager. If you do not need this, you can skip
    // adding it.
    SpriteManager.AddPositionedObject(CameraTarget);
    CameraControllingEntityInstance.Target = CameraTarget;
}

void CustomActivity()
{
    var cursor = GuiManager.Cursor;
    if(cursor.PrimaryClick)
    {
        // We are immediately setting the target to wherever the 
        // user clicks. For this implementation we wouldn't need to
        // add the CameraTarget to the SpriteManager.
        CameraTarget.X = cursor.WorldX;
        CameraTarget.Y = cursor.WorldY;
    }
}

void CustomDestroy()
{
    // If you added the CameraTarget to the SpriteManager, remove it too:
    SpriteManager.RemovePositionedObject(CameraTarget);
}
```

<figure><img src="../../../.gitbook/assets/06_11 45 40.gif" alt=""><figcaption></figcaption></figure>

### Targets

The Targets property (plural of Target) can be used to give the CameraControllingEntity multiple targets. This is typically used when the camera should follow a list of players in a mutiplayer game. The following code can be used to switch between following one of two targets individually or the list of targets. Notice that the CameraControllingEntity is positioned so that both targets are visible using their average X and Y values.

```csharp
void CustomActivity(bool firstTimeCalled)
{
    var keyboard = InputManager.Keyboard;
    if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D1))
    {
        CameraControllingEntityInstance.Target = TargetEntity1;
    }
    else if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D2))
    {
        CameraControllingEntityInstance.Target = TargetEntity2;
    }
    else if(keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.D3))
    {
        // TargetEntityList contains both TargetEntity1 and TargetEntity2
        CameraControllingEntityInstance.Targets = TargetEntityList;
    }
}

```

<figure><img src="../../../.gitbook/assets/02_08 01 01.gif" alt=""><figcaption><p>CameraControllingEntity moving between individual targets and the list</p></figcaption></figure>

### Moving Immediately to the Target

By default the CameraControllingEntity _interpolates_ from its current position to the target. This is normally desired as it can make the camera move smoothly. At times the Camera may need to be moved immediately to its target.

The following code results in the CameraControllingEntity moving immediately.

```csharp
var target = CameraControllingEntityInstance.GetTarget();
// If true, the camera controlling entity will interpolate to its target
// position. If false, the camera controlling entity sets its position immediately.
var lerpSmooth = false;
CameraControllingEntityInstance.ApplyTarget(target, lerpSmooth);
```

Keep in mind that setting the Camera.Main's position to the target location will not immediately move the camera to the target position. If using a CameraControllingEntity, then the Camera's position becomes _read only_, so any changes to the camera position must be done through the CameraControllingEntity.

Additionally, when calling ApplyTarget, the value that is passed in should be obtained from the GetTarget method. The GetTarget method considers the bounds of the Map and the Camera size. Setting a value explicitly (such as by defining a Vector2 with constant X and Y values) may result in the CameraControllingEntity temporarily showing a region that is outside of the Map bounds.

### Map

The Map object can be used to define the bounds for the CameraControllingEntity. If a Map is null, then the CameraControllingEntity does not stop on any bounds. If a Map is set, the CameraControllingEntity attempts to keep the Camera within the bounds. If the Target is set such that the Camera would view outside of the Map, the Camera moves smoothly to the edge of the bounds.

If the Map is smaller than the Camera's viewable area, the Camera centers itself within the Map.

A typical FlatRedBall game uses a LayeredTileMap (loaded from a TMX file) as its Map, but manual bounds can be set as well.

The following code shows how to manually create an AxisAlignedRectangle in code and use it as the Map to set bounds. Note that the following code only includes the relevant code to assign the Map property:

```csharp
AxisAlignedRectangle MapBounds;

void CustomInitialize()
{
    MapBounds = new AxisAlignedRectangle();
    MapBounds.Width = 800;
    MapBounds.Height = 700;

    CameraControllingEntityInstance.Map = MapBounds;
}
```

<figure><img src="../../../.gitbook/assets/07_05 34 04.gif" alt=""><figcaption><p>CameraControllingEntity instance with Map set</p></figcaption></figure>

### ShakeScreen

ShakeScreen applies an offset to the camera for screen shaking. The `radius` parameter specifies the maximum distance of the Camera's position from the CameraControllingEntity. The `durationInSeconds` parameter specifies how long screen shake should apply.

The following code shows how to shake the screen in the GameScreen when the cursor is clicked.

```csharp
if(Cursor.Main.PrimaryClick)
{
    CameraControllingEntityInstance.ShakeScreen(
        shakeRadius: 4, durationInSeconds: 1);
}
```

<figure><img src="../../../.gitbook/assets/09_17 50 34.gif" alt=""><figcaption><p>ScreenShake in response to cursor click</p></figcaption></figure>

