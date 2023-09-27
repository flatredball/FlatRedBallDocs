## Introduction

FieldOfView represents the Y angle of view from the bottom of the screen to the top. The default value for FieldOfView is:

    FieldOfView = (float)System.Math.PI / 4.0f;

The following diagram shows a side-view of how FieldOfView changes what is shown on screen. ![FieldOfView.png](/media/migrated_media-FieldOfView.png) A smaller field of view makes the view more narrow. This narrower view results in the appearance of "zooming in". Tools such as binoculars or telescopes provide a zoomed-in view by creating a very narrow field of view. The FieldOfView property is only effective if the Camera's [Orthogonal](/frb/docs/index.php?title=FlatRedBall.Camera.Orthogonal.md "FlatRedBall.Camera.Orthogonal") property is false (the default value).
