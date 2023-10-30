# camera

### Introduction

FlatRedBall Editor provides a Camera window which can be used to set the game's resolution and various Camera settings. This can be accessed through the camera icon in the toolbar.

![](../../../media/2023-08-img_64d2bcf75c1dc.png)

Keep in mind that when the game runs embedded in the FlatRedBall Editor, the Editor window may modify the resolution settings.

### Resolution

By default the resolution of the game is 800 pixels by 600 pixels.

![](../../../media/2021-10-img_6165964d3c8b5.png)

This means that the game will appear at this resolution when running on the desktop.

![](../../../media/2021-10-img_61658db25902c.png)

Notice that the resolution defines the _inner size_ of the game. On Windows, games with a title bar may be a little bit larger than the inner size. The resolution also controls how much of the _game world_ is visible. For example, if the game includes a grid of rectangles each sized 100x100, we can see that we can see 8 rectangles horizontally and 6 rectangles vertically.

![](../../../media/2021-10-img_61659544e130f.png)

This resolution can be changed in the editor by manually typing in a resolution value, or by using the dropdowns to select from a list of common resolution values.

![](../../../media/2021-10-img_616595823387f.png)

Changing the values to 400x300 (from 800x600) results in the game running as shown in the following image:

![](../../../media/2021-10-img_616595dd8ed5e.png)

Notice that the resolution impacts two things:

* The size of the window (when running on desktop)
* The visible area in game

### Fixed Aspect Ratio

The **Fixed Aspect Ratio checkbox** controls whether the game runs in a forced aspect ratio. By default this value is unchecked which means that the game will run in any aspect ratio rather than forcing a certain aspect ratio. If checked, then the game will [letterbox](https://en.wikipedia.org/wiki/Letterboxing_\(filming\)) or [pillarbox](https://en.wikipedia.org/wiki/Pillarbox) to maintain aspect ratio if the resolution does not match the aspect ratio. For example, the following images shows a game with resolution 800x600 running with a forced fixed aspect ratio of 16:9. Note the gray area displays the game area.

![](../../../media/2021-12-img_61ad4ae330bb6.png)

![](../../../media/2021-12-img_61ad4afa2ba58.png)

If the game's aspect ratio (default values) do not match the calculated aspect ratio from the resolution width and height (as is the case here), the editor will ask if the resolution width or height values should be preserved. In this case, the **Keep game coordinates height at 600** is selected, so the game will always display 600 units on the Y axis, and the width will be adjusted to maintain an aspect ratio. If the **Keep game coordinates width at 800** option is checked, then the game will always display 800 units wide, and will adjust the height to match the desired aspect ratio, as shown in the following images:

![](../../../media/2021-12-img_61ad4b906b200.png)

![](../../../media/2021-12-img_61ad4bee67b94.png)

Notice that if the game resolution and aspect ratio do not match, the window will match the resolution but the game area will match the aspect ratio. This behavior can be important for games which have logic written for a specific aspect ratio such as spawning enemies off-screen.

### Perspective

The Perspective option controls whether the game is using a 2D (Camera Orthogonal is set to true) or 3D (Camera Orthogonal is set to false) perspective. By default FlatRedBall runs in 2D mode.  In 2D, the play area matches the Resolution values. In 3D, the play area at Z=0 matches the Resolution values.

![](../../../media/2021-12-img_61ad4e7ec65bb.png)

Cameras with 3D perspective result in objects with positive Z values drawing larger and objects with negative Z values drawing smaller. For example, the following image shows three sprites with Z values of -100, 0, and 100 (positive).

![](../../../media/2021-12-img_61ad50a14039a.png)

### Texture Filter

Texture filtering modifies the way textures are rendered by Sprites. By default, FlatRedBall uses **Point** filtering. Linear filtering applies a blur effect when objects Sprites are drawn larger than the native resolution, or if the game is zoomed in. The following image shows the difference between Point and Linear filtering:

![](../../../media/2021-12-img_61ad525a252ff.png)

Note that Linear filtering also applies to tilemap rendering which can cause pixel colors to "bleed".

### Fullscreen

The Fullscreen checkbox controls whether the game runs in fullscreen or windowed mode. If the game runs in fullscreen on a monitor which does not match the desired game resolution, the game will be zoomed to maintain the same game area. For example, the following image shows a game running at 800x600 resolution on a monitor at 1920x1080:

![](../../../media/2021-12-img_61ad541cb742d.png)

If the same game runs in fullscreen mode, Glue will zoom the game as shown in the following image:

![](../../../media/2021-12-img_61ad543f63cc9.png)

Notice that the game still displays 6 squares tall, each representing 100 units in-game; however, these 6 are _zoomed_ to display over 1080 screen pixels. Also, note that the game now runs in 16:9 aspect ratio (the aspect ratio of the 1920x1080 resolution), so it displays more game area horizontally. To preserve the same game area vertically and horizontally, the aspect ratio can be forced to 4:3.

![](../../../media/2021-12-img_61ad551478ad6.png)

![](../../../media/2021-12-img_61ad5532cd486.png)

Notice that letterboxing is used to preserve the desired 4:3 resolution.

#### Fullscreen vs Borderless

If a game runs in fullscreen mode, it technically is running at the same resolution as the display in _borderless mode_. This enables a game to alt-tab quickly, and eliminates the need to reload textures when the graphics device is lost due to the game being minimized.

### Allow Window Resizing

If Allow Window Resizing is checked, the game window can be resized by the user when running in windowed mode. 

<figure><img src="../../../media/2021-10-05_17-20-27.gif" alt=""><figcaption></figcaption></figure>

 In the animation above the aspect ratio is not forced, so the game responds to resizes by keeping the height at 600 units (6 squares) while the width is adjusted to match the aspect ratio set from resizing the game. If the aspect ratio is forced then the game will add letterboxing and pillarboxing to maintain the forced aspect ratio as shown in the following animation: 

<figure><img src="../../../media/2021-10-05_17-22-23.gif" alt=""><figcaption></figcaption></figure>



### Scale

Scale controls the size of the window relative to its resolution. At **100%** scale (the default) the game window resolution matches the resolution **Resolution** values. The following image compares the same game with resolution 360x240 running at 50%, 100%, and 200% Scale:

![](../../../media/2021-12-img_61ad9b6b69943.png)

The scale value impacts only the size of the window (and the internal resolution of the game), but the game still has the same number of in-game units. Note that if fullscreen is set to true, scale values set in the editor are ignored.

### On Resize - Preserve vs Increase Visible Area

The **On Resize** option sets whether the amount of in-game units visible should change when the game resizes. By default this value is set to **Preserve (Stretch) Area** which means the in-game units will stretch to preserve the bounds. For example in the following example the height of the in-game area remains 400 units regardless of how the window is resized. 

<figure><img src="../../../media/2021-10-05_22_17_34.gif" alt=""><figcaption></figcaption></figure>

 Changing this value to **Increase Visible Area** enables more of the game world to be seen if the window is made larger. 

<figure><img src="../../../media/2021-10-05_22_19_04.gif" alt=""><figcaption></figcaption></figure>

 Note that this may result in unexpected behavior if your game expects the visible area to be of a constant size. &#x20;
