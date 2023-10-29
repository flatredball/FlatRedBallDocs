# Introduction

The IsSpriteInView method reports whether the argument Sprite is in view given the Camera's position, the Sprite's position, and the [CameraCullMode](../../../../frb/docs/index.php). If the [CameraCullMode](../../../../frb/docs/index.php) is set to CameraCullMode.None then this value will always return true. If the [CameraCullMode](../../../../frb/docs/index.php) is set to CameraCullMode.UnrotatedDownZ then this will calculate whether the Sprite is in view or not. This function is intended to be used for culling, and it favors optimization over perfect accuracy.
