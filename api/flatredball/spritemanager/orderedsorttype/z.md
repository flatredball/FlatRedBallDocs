## Introduction

The default ordering mode for Sprites in FlatRedBall is SortType.Z. The definition is rather straight forward - objects which have a Z that positions them further away from the Camera (smaller Z in all but FlatRedBall MDX) will be drawn first. Since closer Sprites are drawn after (within the same frame) Sprites which are further, they will overlap appropriately.

## Same-Z Sprites

While it may be easy to image how Sprites with different Z values will draw, SortType.Z does not define how Sprites will be drawn when they have the same Z value. Of course, the engine doesn't use a random number generator to decide which should be drawn first - there is a method to it. Most articles which mention this topic encourage you to consider same-Z Sprites to have a random sorting order, but we'll cheat a little bit and explore. Internally FlatRedBall maintains a list of Sprites (as well as other ordered objects like Texts and IDrawableBatches). This list is sorted every frame just prior to drawing to guarantee proper ordering. It is very important that the sorting algorithm used is a "stable sorting algorithm". In other words, the sorting maintains the relative order of all same-Z Sprites. If this wasn't the case, then Sprites with the same Z value would shift positions every time the Sort method was called, causing them to flicker on screen. This means that if Sprite A is drawn on top of Sprite B, then it will \*always\* be drawn on top of B unless something in the program changes. ![SpriteOrderingComic.png](/media/migrated_media-SpriteOrderingComic.png) Therefore, you might be thinking, there must be **something** that is controlling which is drawn on top of which. There is: For same-Z Sprites, the order is whichever Sprite was added first. Let's look at two blocks of code and their results to see this in action. This block of code adds two Sprites. The one on the right is added last. Since it is added last, it appears later in the list. Since FlatRedBall renders from the front to back of lists, Sprites added later will be drawn in front:

    Sprite sprite1 = SpriteManager.AddSprite("redball.bmp");
    Sprite sprite2 = SpriteManager.AddSprite("redball.bmp");
    sprite2.X = 1;

![RightInFront.png](/media/migrated_media-RightInFront.png)

## Why depending on order is so bad

In the example above everything seems pretty clear and predictable - sprite2 is added after sprite1, so sprite2 will appear on top of sprite1 (assuming their Z values aren't changed). Of course, this code is far simpler than code you'll normally write when working with FlatRedBall. In many cases you won't be writing the code that actually creates Sprites. In the following cases the order of Sprite creation may be something you have no control over:

-   Loading Scenes - Scenes loaded from .scnx files often instantiate Sprites. The instantiation of these Sprites is done inside of FlatRedBall calls, so you do not control which Sprite is instantiated first. Furthermore, different tools may be written in different versions of FlatRedBall, so the way they sort Sprites may also differ.
-   SpiteGrids - SpriteGrids create and destroy Sprites if they are managed. This means that some Sprites in a SpriteGrid may be created at a much later time than other Sprites. It is possible to create situations where some Sprites in a SpriteGrid appear behind a large Sprite, while others appear in front when the SpriteGrid and the large Sprite all have the same Z.
-   Emitters - Emitters can continually create Sprites while they are alive. Since they are continually created you may not have control over their ordering relative to other Sprites with the same Z value.

## The moral of the story

You guessed it: Set your Z values. If you want to control how Sprites sort, then you should set Z values to prevent unexpected sorting.
