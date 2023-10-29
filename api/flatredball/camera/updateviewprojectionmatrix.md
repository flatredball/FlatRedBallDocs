# Introduction

The UpdateViewProjectionMatrix updates the [View](../../../../frb/docs/index.php) and [Projection](../../../../frb/docs/index.php) properties according to the Camera's current state. This function is automatically called on all Cameras which are a part of FlatRedBall every frame prior to the frame being rendered, but if the [View](../../../../frb/docs/index.php) and [Projection](../../../../frb/docs/index.php) properties are needed after the Camera has been updated, then UpdateViewProjectionMatrix needs to be called.
