## Introduction

The AdjustPositionForPixelPerfectDrawing method tells the FlatRedBall Engine to attempt to offset Text objects so that they do not render in-between pixels. This value defaults to true, and in most cases you do not need to adjust it.

## When to adjust AdjustPositionForPixelPerfectDrawing

AdjustPositionForPixelPerfectDrawing should be turned off if FlatRedBall is not properly adjusting your Text objects to be pixel perfect. One common scenario for this is if a Text object is on a camera other than the default Camera.

## Code Example

The following assumes that "TextInstance" is a valid Text object:

    TextInstance.AdjustPositionForPixelPerfectDrawing = false;
