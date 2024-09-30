# CallActivity

### Introduction

The CallActivity property on an object determines if the object will have its CustomActivity (custom code) and Activity (generated code) methods called. This value defaults to true, which means that objects will have their Activity (and CustomActivity) called automatically.

![](../../.gitbook/assets/2023-08-img\_64f11cb0a4cda.png)

### CallActivity as False

CallActivity can be set to false to prevent generated code from automatically calling Activity on an object. This might be useful in a number of situations:

* If a Screen has multiple lists of the same type (such as EnemyList), and if instances may exist in both lists. The primary list should have CallActivity set to true, while other lists should have this value set to false to prevent Activity from being called twice per frame.
* If activity is never needed on an entity, and a large number of entities exist. Omitting activity calls may provide a small performance boost.
* If entity activity is optional. This scenario is considered advanced, and is not recommended for most games. However, the flexibility exists.

### CallsActivity and Lists (PositionedObjectList)

PositionedObjectLists which are contained in Screens and Entities will call Activity on all contained instances. Setting CallActivity to false will disable this functionality.
