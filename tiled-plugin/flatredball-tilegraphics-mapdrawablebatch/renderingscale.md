# RenderingScale

### Introduction

RenderingScale can be used to draw a MapDrawableBatch at a larger size. By default this value is set to 1 which means the MapDrawableBatch draws at its original size. Note that increasing the RenderingScale is not recommended for "zooming" the game in or out - it's best to use the FlatRedBall Camera. Increasing the RenderingScale can be used to make layers in-game appear larger or smaller.

### Code Example - Increasing RenderingScale with the Keyboard

The following code finds a layer called CloudLayer and increases the RenderingScale gradually as the user holds either the up arrow or down arrow on the keyboard.

```csharp
void CustomActivity(bool firstTimeCalled)
{
    var cloudLayer = Map.MapLayers.FindByName("CloudLayer");
    var keyboard = InputManager.Keyboard;
    if(keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
    {
        cloudLayer.RenderingScale *= 1.02f;
    }
    else if(keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
    {
        cloudLayer.RenderingScale /= 1.02f;
    }
}
```

<figure><img src="../../.gitbook/assets/06_09 48 37.gif" alt=""><figcaption><p>CloudLayer scaling up/down in response to the up and down key pressed</p></figcaption></figure>
