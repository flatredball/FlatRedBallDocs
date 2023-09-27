FlatRedBall is now making a big upgrade to .NET and MonoGame 3.8.1. This means the FlatRedBall Editor (aka Glue) and new game projects are on .NET 6. This upgrade brings along a lot of changes to FlatRedBall, so let's dive in! Note that some of the changes below require creating a new .NET 6 project or manually upgrading your project to use .NET 6.

## .NET 6 Performance Boosts

.NET 6 introduces lots of performance improvements for all C# applications. FlatRedBall games benefit from these improvements. For information, see the [.NET 6 blog about performance improvements](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/).

## CSharp 8, 9, and 10

Games can now take advantage of the latest C# syntactical improvements. For more information see the following blogs:

-   [What's new in C# 8](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8)
-   [What's new in C# 9](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)
-   [What's new in C# 10](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10)

## New Controller Support

(Requires .NET 6 project) Previous versions of FlatRedBall supported only Xbox controllers (Xbox 360 and Xbox One). Now, FlatRedBall supports virtually all PC USB controllers including:

-   Nintendo Switch Pro Controllers
-   Nintendo Gamecube-style (aka Smash Bros) controllers
-   "Retro" controllers, such as NES and SNES-style controllers
-   Playstation 4 and 5 controllers
-   General PC controllers

These controllers will appear in the InputManager.Xbox360GamePads list. Buttons such as X, Y, A, B will match the face buttons so be aware that they will not be positioned physically in the same spot across Xbox and Switch controllers.

![](/media/2022-10-img_6346d2dd50f8f.png)

## Live Edit Improvements

Live edit continues to be an important feature which is being used internally and continually improved. The latest version addresses more edge cases and helps catch left-over processes. Live edit also does a better job of reporting game crashes in the output window.

![](/media/2022-10-img_6346d3c08605e.png)

## ICollidable ItemsCollidedAgainst and LastFrameItemsCollidedAgainst

ICollidable objects (including all generated entities) now have an ItemsCollidedAgainst and LastFrameItemsCollidedAgainst. This allows for custom code to check for collisions rather than performing code in events. This is primarily useful when multiple collision relationships control a single variable. Additionally, Platformer objects also have a GroundCollidedAgainst property which similarly records the items that the player has collided with. For example, a Player may perform logic if on ice. Being on ice may require checking multiple collision relationships as shown in the following snippet:

    public bool IsOnIce => 
       GroundCollidedAgainst.Contains(nameof(GameScreen.IceCollision)) || 
       GroundCollidedAgainst.Contains(nameof(GameScreen.IceCloudCollision));

## Collision Relationship Improvements

Collision Relationship physics can now be defined in the FRB Editor, but the application of the physics can be controlled manually. This is important if the application of physics is conditional. For example, consider a ghost enemy which may be able to pass through walls depending on its current state. In this case, the physics could be defined in the FRB Editor, but not automatically applied:

![](/media/2022-10-img_6346d69b1b42a.png)

CollisionRelationships now have a **DoCollisionPhysics** method which can be called to apply physics, typically performed conditionally in a collision event.

## Factory Performance Improvements

Entity lists are often sorted to improve partitioning. The new version of FRB will automatically insert items sorted, rather than at the end of the list to be sorted. For large lists, this can create significant improvements in performance.

![](/media/2022-10-img_6346db23dc281.png)

## ... and lots more!

This version also includes dozens of small bug fixes and enhancements. It's available now, so head on over to the [Downloads page](/download/.md) and give it a shot.
