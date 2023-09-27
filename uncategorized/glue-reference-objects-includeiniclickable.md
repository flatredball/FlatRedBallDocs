## Introduction

If an Entity is IClickable that means that it has a HasCursorOver method which can be used to detect if the cursor (or user's finger on touch screens) is over the Entity. This property tests against all contained objects. If you want certain objects to be excluded from this test, then their IncludeInIClickable property can be set to false.

![IncludeInIClickable.PNG](/media/migrated_media-IncludeInIClickable.PNG)

**IncludeInIClickable also impacts IWindow behavior:** If an Entity uses IWindow then it internally uses HasCursorOver to fire user action-based events. Making an object be not included in IClickable will also remove the object from IWindow logic.
