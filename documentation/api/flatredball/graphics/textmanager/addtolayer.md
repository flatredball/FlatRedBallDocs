## Code Example

The following code creates a [Text](/frb/docs/index.php?title=FlatRedBall.Graphics.Text.md "FlatRedBall.Graphics.Text") object and adds it to a layer.

    Layer layer = SpriteManager.AddLayer();

    Text text = TextManager.AddText("Hello", layer);

Alternatively the Text can be added to a Layer after AddText is called. The following code can also be used:

    Layer layer = SpriteManager.AddLayer();

    Text text = TextManager.AddText("Hello");
    TextManager.AddToLayer(text, layer);
