# Parallaxx

### Introduction

MapDrawableBatches (map layers) support parallax by assigning the values in Tiled or in code. By default parallax has a value of 1, which means that the object will show no parallax. A value between 0 and 1 results in the layer behaving as if it is in the distance (not scrolling as quickly when the camera moves). A value greater than 1 results in the layer behaving as if it is in the foreground (scrolling more quickly when the camera moves).

### Example - Setting Parallax Factor in Tiled

To set parallax:

1. Open an existing map
2. Select a layer
3.  Change its Parallax Factor property to the desired value

    ![](../../.gitbook/assets/2022-08-img\_630bb51ae5135.png)
4. Tiled provides a preview of the parallax if you scroll the main view

<figure><img src="../../.gitbook/assets/2022-08-28_12-34-43.gif" alt=""><figcaption></figcaption></figure>

Once the file is saved, the parallax will automatically be applied at runtime in the game.

<figure><img src="../../.gitbook/assets/2022-08-28_12-36-06.gif" alt=""><figcaption></figcaption></figure>
