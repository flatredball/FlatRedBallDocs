## Introduction

The TextRenderingMode property controls the approach that the RenderingLibrary uses to render Text objects internally. The following two approaches are supported:

-   TextRenderingMode.RenderTarget
-   TextRenderingMode.CharacterByCharacter

By default the RenderingLibrary sets the TextRenderingMode to CharacterByCharacter.

## CharacterByCharacter

TextRenderingMode.CharacterByCharacter renders each character separately, similar to a situation where each character in a Text object is a separate Sprite object. This approach has a number of benefits:

-   There is no practical limit to the number of characters in a single Text object, nor is there a practical limit to the maximum dimensions of the Text character.
-   If the Font uses the same texture as other Gum graphics, the RenderingLibrary will not introduce new state changes (RenderBreaks) when rendering text and non-text objects.

CharacterByCharacter offers the most flexibility to rendering, and can greatly improve performance when a game includes a large number of Text objects, such as list boxes  or a large number of buttons.

## RenderTarget

TextRenderingMode.RenderTarget renders each character separately to an intermediary RenderTarget, and then renders that render target directly to the screen. This approach has the following benefit:

-   Very large Text objects which do not change often will render more quickly, as the engine only has to process one large sprite rather than hundreds or even thousands of individual sprites (letters) each frame.

While this approach can be useful for large text blocks (such as multiple paragraphs of text or scrolling credits), it will reduce performance in many situations because it requires switching render states for each text object.

## Setting TextRenderingMode

TextRenderingMode is a static property which applies to all Text objects. It can be set and changed at any time, as shown in the following code:

``` lang:c#
RenderingLibrary.Graphics.Text.TextRenderingMode = 
    RenderingLibrary.Graphics.TextRenderingMode.CharacterByCharacter;
```

## When to Change TextRenderingMode

No set guidelines exist for when to use one rendering mode vs. another; however, in general if you have a large number of individual text objects, it is likely you will want to place the font in the same texture as the rest of your UI and use the TextRenderingMode.CharacterByCharacter. This is especially important on mobile apps. If you suspect that your game is suffering from performance due to rendering each character individually, you can swap the TextRenderingMode and compare your game's frame rate - the most important thing is to set your game up early to use the same texture for fonts and the rest of the UI.    
