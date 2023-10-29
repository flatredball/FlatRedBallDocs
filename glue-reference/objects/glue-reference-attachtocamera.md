## Introduction

The AttachToCamera property controls whether an object is attached to the Camera. HUD and UI elements are often attached to the Camera so that they stay in the same screen position when the Camera moves.

## Usage

To attach an instance of an object to the Camera:

1.  Select the instance under the "Object" tree item in a given Screen
2.  Set the AttachToCamera property to true:![AttachToCamera.PNG](/media/migrated_media-AttachToCamera.PNG)

## AttachToCamera only available in Screens

The AttachToCamera property is only available on objects which are contained in Screens. Objects which are contained in Entities do not have this property, and functionally AttachToCamera will always be false on objects in Entities. The reason for this is because even though this is something which is supported by the underlying FlatRedBall engine, it can result in confusing and difficult-to-debug behavior. Keeping all attachments to Camera at the Screen level makes it much easier to identify why an object is not behaving as you might expect.
