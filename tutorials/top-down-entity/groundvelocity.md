# GroundVelocity

### Introduction

The GroundVelocity property is used to simulate the ground moving under the player. By default GroundVelocity is a 0-length vector which means the player is not standing on moving ground.&#x20;

GroundVelocity can be set for the following reasons:

* Simulating standing on moving ground such as a treadmill or moving walkway
* Standing on a moving platform such as log floating on a river
* Being pushed by the environment such as standing in blowing wind or flowing water

{% hint style="warning" %}
GroundVelocity is a Vector3 for convenience when applying velocity, but only the X and Y values should be assigned. Setting the Z value results in the entity's Z value changing which can affect ordering or even move the entity out of the camera's minimum and maximum Z values.

In other words, be sure to keep GroundVelocity.Z set to 0.
{% endhint %}

### Code Example - Setting Ground Velocity

GroundVelocity can be set per instance. For example, the following code sets the GroundVelocity on Player1 when the Space bar is held down.

```csharp
if(Keyboard.Main.KeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
{
    Player1.GroundVelocity = new Vector3(32, 0, 0);
    EditorVisuals.Text("Space is held", Camera.Main.Position.AtZ(0));
}
else
{
    Player1.GroundVelocity = new Vector3(0, 0, 0);
}
```

<figure><img src="../../.gitbook/assets/14_13 37 53.gif" alt=""><figcaption><p>Player1 moving when space is held.</p></figcaption></figure>

### GroundVelocity Affects Movement

Top down entity movement is performed relative to GroundVelocity. If GroundVelocity is assigned to a non-zero vector, then all movement is performed relative to that new value. For example, if GroundVelocity is set to have an X value of 32, then the entity can move 32 pixels faster on the X axis when moving to the right, and 32 pixels slower when moving to the left.

<figure><img src="../../.gitbook/assets/14_13 43 24.gif" alt=""><figcaption><p>Player moving around with a GroundVelocity.X value set to 32</p></figcaption></figure>

