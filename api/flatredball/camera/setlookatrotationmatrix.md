The SetLookAtRotationMatrix method can be used to orient a camera so it is facing an object. This method of setting the rotation matrix can be easier to work with than calculating a rotation matrix yourself to accomplish a look-at.

## Code Example

The following code can be used to have a Camera look at a moving object called myEntity. This code assumes that myEntity is a valid Entity with a Position property.

    Camera cameraToUse = SpriteManager.Camera;
    Vector3 positionToLookAt = myEntity.Position;
    cameraToUse.SetLookAtRotationMatrix(positionToLookAt);
