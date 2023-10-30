# glue-reference-exposedinderived

### Introduction

The ExposedInDerived property on an object allows an object to be accessible in a derived Entity. This is useful if a base Entity defines that an object must exist (such as an AxisAlignedRectangle in a collidable entity), but the entity modifies its values (such as a derived enemy entity modifying the size of its collision). Objects which are ExposedInDerived will appear as normal white entities in the tree view, and objects which are created as a result of setting ExposedInDerived to true appear as green in derived entities. The following image shows an AxisAlignedRectangleInstance in BaseEntity which has its ExposedInDerived set to true. The AxisAlignedRectangleInstance in DerivedEntity is green to indicate that it is created in the base entity.

![](../../../../media/2021-05-img_60aa8c9f21571.png)

### Object Access

Providing proper access to your objects can be a little complex at first, but it is the key to "scalability" (the property of being able to continually grow the size of your game while minimizing complexity). In short, there are three "levels" of access you can provide in Glue:

* No access in derived elements (default)
* ExposedInDerived set to true
* SetByDerived set to true

If no access is given, then an Entity's objects will be hidden from derived Entities. This allows derived entities to simply inherit a "closed" object. It is rare to have a base entity that does not provide access to any of its contained objects to a derived entity, but this option exists in case you want to limit access to some. ExposedInDerived allows you to access and modify an existing Object in a derived Entity, but you do not have access to set it to something different. This is common for Entities which include lists that are to be populated by derived Entities. You can also do things like change properties on ExposedInDeived objects. SetByDerived allows you to completely change an Object in an derived Entity. In this case, the base entity simply defines that an object _can exist_ but the derived entity is responsible for actually defining this object. This can be used if the derived entity will create the object conditionally, or based on some other file (such as obtaining a collision object from a Gum component). &#x20;
