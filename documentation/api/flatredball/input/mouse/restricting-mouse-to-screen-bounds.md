## Introduction

Some games benefit from keeping the mouse within the screen bounds. The two common scenarios for keeping the mouse within the screen bounds are:

1.  A first person shooter uses the mouse to move around. The mouse should be invisible and not move outside of the window when the window has focus.
2.  Real time strategy games often implement "edge scrolling" (scrolling the camera when the mouse reaches the edge of the screen).

## Keeping the mouse a the center of the screen

If the mouse is invisible then the easiest way to keep the mouse in screen is to continually reset its position every frame:

``` lang:c#
if(FlatRedBallServices.Game.IsActive)
{
   var centerX = FlatRedBallServices.Game.Window.ClientBounds.Width/2;
   var centerY = FlatRedBallServices.Game.Window.ClientBounds.Height/2;

   Microsoft.Xna.Framework.Input.Mouse.SetPosition(centerOfWindowX, centerOfWindowY);
}
```

## Keeping the mouse bound to the window

The mouse can be bound to the window as shown in the following code:

``` lang:c#
[DllImport("user32.dll")]
static extern void ClipCursor(ref Rectangle rect);


protected override void Update(GameTime gameTime)
{
  if (IsActive)
  {
    Rectangle rect = Window.ClientBounds;
    rect.Width += rect.X;
    rect.Height += rect.Y;
    
    ClipCursor(ref rect);
  }
  
  base.Update(gameTime);
}
```

Code obtained from <http://xboxforums.create.msdn.com/forums/p/3553/18372.aspx>  
