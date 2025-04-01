# Sorting

### Introduction

Top-down games usually require entities and environment to sort in a way that suggests depth. This page covers the various forms of sorting in a top down game.

### Sorting Basics

FlatRedBall sorts objects using cameras, layers, and positioning. Multiple cameras can be used to control draw order. Within a single camera multiple layers can be used to sort objects. This article assumes that all objects are on a single camera and on a single layer. Of course, if your game is using Gum for your game's HUD and UI then it is likely using multiple layers to keep Gum on top of your game. Note that the depth buffer can also be used to enforce sorting, but this article does not discuss this technique of sorting.

Entities and tile map layers use a combination of Z and Y values to control sorting.

### Sorting Entities vs Tiles

Entities are drawn relative to tile map layers according to their Z values.

By default, all entities have a Z value of 0. This means that they will draw above layers with a Z value that is less than 0, and will draw below layers with a Z value that is less than 0.

By convention FlatRedBall loads Tiled maps so that the GameplayLayer is at Z=0. Each layer above and below the GameplayLayer is separated by 1 Z value. For example, consider a map with the following layers and their Z values:

* AbovePlayer: Z=1
* GameplayLayer: Z=0
* GroundDecorations: Z=-1
* Ground: Z=-2

<figure><img src="../../.gitbook/assets/01_05 55 49.png" alt=""><figcaption><p>Layers in tiled</p></figcaption></figure>

In this map the AbovePlayer layer is positioned at Z = 1, so any tiles placed on this Layer draw on top of the Player.&#x20;

{% hint style="info" %}
The H hotkey in Tiled toggles highlighting the current layer. This feature can help visualize the current layer.

<img src="../../.gitbook/assets/01_05 58 06.gif" alt="" data-size="original">
{% endhint %}

If we want the player to overlap the pillar when below it, but be behind the pillar when above it, then the pillar must be broken up into two separate layers.&#x20;

<figure><img src="../../.gitbook/assets/01_06 10 31.gif" alt=""><figcaption><p>Pillar broken up into two layers</p></figcaption></figure>

If we run the game we can see the player moving above and below the pillar.

<figure><img src="../../.gitbook/assets/01_06 08 39.gif" alt=""><figcaption><p>Player moving above and below the pillar</p></figcaption></figure>

Of course this requires adjusting the player's collision to prevent it from moving too far up when below, or too far down when above. Otherwise, the player may overlap both layers at the same time.

<figure><img src="../../.gitbook/assets/01_06 13 25.png" alt=""><figcaption><p>Player overlapping both layers at the same time</p></figcaption></figure>

As mentioned above, the GameplayLayer is given a Z value of 0, equal to the default Z value for entities. Sorting between entities and the GameplayLayer should be considered arbitrary since it depends on the presence of other layers. FlatRedBall may choose to sort Tiled layers with a Z=0 above or below the player for performance reasons.

Most of the time this arbitrary sorting does not cause problems because the GameplayLayer is only made visible for debugging purposes, and is made invisible for final games. However, if you would like to force a particular sorting, you can shift your maps by a small amount in code.

For example, if only the GameplayLayer is visible, then entities will sort below the GameplayLayer.

<figure><img src="../../.gitbook/assets/01_06 18 17 (1).png" alt=""><figcaption><p>Player below the GameplayLayer</p></figcaption></figure>

We can shift our map slightly below the player by adding the following code to our GameScreen's CustomInitialize:

```csharp
private void CustomInitialize()
{
    // shift it down a very small amount so 
    // GameplayLayer sorts below the player
    Map.Z -= .01f;
}
```

Now all entities sort above the GameplayLayer.

<figure><img src="../../.gitbook/assets/01_06 22 19.png" alt=""><figcaption><p>Player above the GameplayLayer</p></figcaption></figure>

Keep in mind that this method of adjusting sorting is useful for keeping your entities above GameplayLayer, but it results in the player always above the GameplayLayer. If you would the player to sort above and below tiles according to its position, you must separate the tiles into different layers.

{% hint style="info" %}
The code above shifts the map by subtracting from its Z value rather than setting an explicit Z value. The Map's Z initially depends on the number of layers it contains, and it is shifted in generated code. By adding or subtracting from the Z value, the shift results in the desired sorting regardless of how many layers are in our map.
{% endhint %}
