## Introduction

The Camera class has a UpVector which is used to orient the Camera so that it is always tilted a particular way. UpVectors are very common in 3D games as they can help the player feel oriented. By default, the Camera's UpVector value is set to be the unit Y vector (0,1,0). The UpVector must be changed if you want the "up" direction to change. The most common situation this is needed is if the Camera needs to rotate on the Z axis (to change its RotationZ or RelativeRotationZ).

## Why does UpVector exist?

If you are working with the Camera class and expect modifying the Camera to rotate when you change its RotationMatrix or RotationZ, you may have been surprised to see that these properties do not modify the rotation of the Camera. As mentioned above, the reason for this is because the UpVector takes priority over the Camera's RotationMatrix. The reason for this is because in 3D games, the Camera may often end up with a rather complex RotationMatrix, and in many cases the expected behavior is to keep the Camera oriented so that it is not tilted. Simply setting the UpVector allows you to always guarantee that you will have a proper up vector without having to perform complex matrix math. In other words, if FlatRedBall were to not include an UpVector on the Camera, applying this functionality could be somewhat difficult. On the other hand, eliminating the UpVector functionality is very easy:

    ApplySomeRotationTo(Camera.Main);
    Camera.Main.UpVector = Camera.Main.RotationMatrix.Up;
