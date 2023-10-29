# resizing-the-game-window-for-tools

### Introduction

When creating a tool using FlatRedBall XNA, the tool must react to window resizing events. By default when the Game Window is resized, the [Camera](../../../../frb/docs/index.php) only changes its DestinationRectangle and AspectRatio. Therefore, if a Sprite takes up the entire screen horizontally, it will take up the entire screen horizontally after the resize, as shown by the following images:

**Before Resize**![BeforeResizeNoCameraModification.png](../../../../media/migrated\_media-BeforeResizeNoCameraModification.png) **After Resize**![AfterResizeNoCameraModification.png](../../../../media/migrated\_media-AfterResizeNoCameraModification.png)

Tools users will not anticipate this behavior. Rather, they will expect that objects will take up the same amount of total space on their monitors before and after the resize as shown by the following images:

**After Resize Expected Behavior**![AfterResize.png](../../../../media/migrated\_media-AfterResize.png)

### Code Example

The following code modifies the Camera whenever the window resizes. It assumes that the game uses the default [FieldOfView](../../../../frb/docs/index.php) of PI/4 when starting at 600 pixels tall.

Add the following to Initialize after initializing FlatRedBall:

```
this.Window.AllowUserResizing = true;
// Using render targets and resizing makes the engine unstable
FlatRedBall.Graphics.Renderer.UseRenderTargets = false;
FlatRedBallServices.CornerGrabbingResize += ReactToResizing;
```

Add the following method at class scope:

```
 void ReactToResizing(object sender, EventArgs e)
 {
     // Get the new client bounds (the area where things will be drawn)
     Microsoft.Xna.Framework.Rectangle displayRectangle = 
         FlatRedBallServices.Game.Window.ClientBounds;

     // This tests if the user has minimized the window
     if (displayRectangle.Width == 0 || displayRectangle.Height == 0)
     {
         // The user has minimized the window.  Don't do anything in this case
         return;
     }

     // Do we need to update things?
     bool hasWindowChanged =
             SpriteManager.Cameras[0].DestinationRectangle.Height != displayRectangle.Height;

     if (hasWindowChanged)
     {
         // Resize the destination rectangle so the camera renders to the full screen
         // You may need to change this code if using a split screen view.
         SpriteManager.Cameras[0].DestinationRectangle = new Microsoft.Xna.Framework.Rectangle(
             0, 0, displayRectangle.Width, displayRectangle.Height);

         #region Fix the Orthogonal values

         double unitPerPixel = SpriteManager.Camera.OrthogonalHeight / 
             SpriteManager.Cameras[0].DestinationRectangle.Height;

         SpriteManager.Camera.OrthogonalHeight = (float)(displayRectangle.Height * unitPerPixel);
         SpriteManager.Camera.OrthogonalWidth = (float)(displayRectangle.Width * unitPerPixel);

         #endregion

         #region Fix the 3D (FieldOfView and AspectRatio) values

         // These values represent the field of view at 600 pixels.
         // Increase the values (decrease the number that PI is divided by) to
         // make the view wider (and make things appear smaller)
         double yAt600 = Math.Sin(Math.PI / 8.0);
         double xAt600 = Math.Cos(Math.PI / 8.0);
         double desiredYAt600 = yAt600 * (double)displayRectangle.Height / 600.0;
         float desiredAngle = (float)Math.Atan2(desiredYAt600, xAt600);
         SpriteManager.Cameras[0].FieldOfView = 2 * desiredAngle;

         SpriteManager.Cameras[0].FixAspectRatioYConstant();

         #endregion
     }
 }
```
