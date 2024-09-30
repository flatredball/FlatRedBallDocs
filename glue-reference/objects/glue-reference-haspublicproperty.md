# HasPublicProperty

### Introduction

The HasPublicProperty variable on an Object controls whether the object can be accessed by code outside of an instance of the containing Entity. In other words, it controls whether the property created for an object is private or public. This value is false by default, but can be set to public if necessary. ![HasPublicProperty.PNG](../../.gitbook/assets/migrated\_media-HasPublicProperty.PNG)

### When to set HasPublicProperty to true

The HasPublicProperty is by default false. It is usually set to true when dealing with objects which must expose certain objects to the Screen that contains them. Most commonly, objects need to expose their collision members so that the Screen that contains instances or lists of collidable objects can perform collision logic. If your code attempts to access an object from outside of an Entity but the object's HasPublicProperty is set to false, then you will see a compile error like:

```
<ObjectName> is inaccessible due to its protection level
```

### Base objects define HasPublicProperty

The HasPublicProperty is only available on objects in their base definition. If an object is available in a derived Entity, but defined in the base Entity, the HasPublicProperty value can only be set in the base and not derived.
