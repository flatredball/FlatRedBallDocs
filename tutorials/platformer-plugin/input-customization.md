# Input Customization

## Introduction

Platformer entities automatically implement keyboard and gamepad controls. We can customize these controls to support any combination of input. This page discusses the different types of input and shows how to customize it.

## Default Behavior

By default platformer entities use a gamepad if one is plugged in, otherwise keyboard is used. Platformer entities have the following input properties:

* HorizontalInput - controls horizontal movement (left and right)
  * Keyboard controls: A and D keys
  * Gamepad controls: Left/right on the left analog stick, left/right on the d-pad
* VerticalInput - controls climbing up and down, and dropping through cloud platforms
  * Keyboard controls: W and S
  * Gamepad controls: Up/down on the left analog stick, up/down on the d-pad
* JumpInput - controls when jumps are initiated
  * Keyboard controls: Space bar
  * Gamepad controls: A button

Note that these inputs have built-in functionality, but these can also be used in custom code for additional behavior, such as reading VerticalInput to allow the player to duck.

## Setting Input in GameScreen

The easiest way to assign input on your platformer entities is to assign it in your GameScreen's CustomInitialize. The GameScreen's CustomInitialize has access to all Players in the PlayerList, so you can perform any logic to change the input.

For example, the following code changes the player's jump input to use the gamepad's B button instead of A button:

<pre class="language-csharp"><code class="lang-csharp">public partial class GameScreen
{
    private void CustomInitialize()
    {
<strong>        Player1.JumpInput = 
</strong><strong>            InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.B);
</strong>    }
}
</code></pre>

## Using Multiple Input Devices

The Input properties described above can be built using a variety of methods provided by FlatRedBall. We can use simple methods for input such as Xbox360Gamead.GetButton or Keyboard.GetKey, or we can combine these to support reading from multiple devices at the same time.

For example, the following code shows how to jump when either the space bar or a gamepad's A button is pressed:

<pre class="language-csharp"><code class="lang-csharp">public partial class GameScreen
{
    private void CustomInitialize()
    {
<strong>        Player1.JumpInput = 
</strong><strong>            Keyboard.Main.GetKey(Microsoft.Xna.Framework.Input.Keys.Space)
</strong><strong>            .Or(InputManager.Xbox360GamePads[0].GetButton(Xbox360GamePad.Button.B))
</strong>    }
} 
</code></pre>

## Separating Input Device and Input Action Assignments

As mentioned above, the easiest way to assign input is to do so directly on the player's Input properties. This code combines two concepts into one:

* Deciding which input hardware to use
* Assigning the actions from the hardware

At times you may want to separate these to concepts. For example, you may want to allow users to pick whether to use the gamepad or keyboard. When an input device is selected, then the Input action properties should be re-assigned.

The assignment of which input hardware to use is typically performed in the GameScreen when it is initialized. The following code shows how to explicitly set the player to use the keyboard:

<pre class="language-csharp"><code class="lang-csharp">public partial class GameScreen
{
    private void CustomInitialize()
    {
<strong>        Player1.InitializePlatformerInput(Keyboard.Main);
</strong>    }
}
</code></pre>

Note that this code does not specify which keys to use on the keyboard for each action - only that the Keyboard hardware should be used. By default calling this method results in the keyboard being used with the default keys (as explained above).

We can react to this the input hardware being assigned by implementing the `CustomInitializePlatformerInput` method.

For example, the following code can be added to the Player.cs file to assign the left shift key as the jump input if using the keyboard, and the X button if using a gamepad:

```csharp
partial void CustomInitializePlatformerInput()
{
    var inputDevice = this.InputDevice;
    
    if(inputDevice is Keyboard keyboard)
    {
        JumpInput = keyboard.GetKey(
            Microsoft.Xna.Framework.Input.Keys.LeftShift);
    }
    else if(inputDevice is Xbox360GamePad gamePad)
    {
        JumpInput = gamePad.GetButton(Xbox360GamePad.Button.X);
    }
}
```
