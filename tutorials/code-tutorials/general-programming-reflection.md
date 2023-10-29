## Introduction

Reflection is a feature present in C# (and many other managed programming languages) which lets you inspect objects at runtime. For example, at runtime you would be able to look at an object (such as PositionedObject) and get a list of all of its fields, properties, methods, constructors, and so on. You could get information such as the names of these members, their types (or return values), and even which class defines them if they come from a base class. Not only that, but you can even set fields/properties and even call methods!

## Why do we need reflection?

Reflection is used for a variety of reasons but in general it is useful so that you can operate at a higher level than you normally would. Some common areas that use reflection are:

-   Serialization of data - If you are interested in saving data to the disk or sending it over the network, you can write general-purpose code that investigates the properties of an object, then serializes these properties. Since it dynamically determines what it needs to save depending on the object through reflection, then you can serialize any type of object with the same code!
-   UI generation - If you've ever used FlatRedBall's tools or the PropertyGrid that is provided in Winforms, then you've probably worked with UI that is generated through reflection. The PropertyGrid class in FlatRedBall creates the appropriate UI for the type of object you give it. If the object has a "float X" property, then it creates an UpDown window and a label that says "X" for that property. It uses reflection to read the current value of that property as well as to write to the object when the UI changes.
-   Syntax-based abstraction - There are times when you may have very similar syntax between objects, but the objects may not share a common base class. Therefore, you can't run both objects through the same code unless you use reflection. For example, you may have two objects that have a Weight property, but they don't share a common interface. Of course, if you can make them share a common interface this is better, but if this is not possible at all, then you may want to consider using reflection to set the X property on these objects.
-   Reduction in object bloat - There are some cases where you may want to create code that can operate on a particular object's member. You may not want to create a method for each member if the operations are similar, or you may not even know all of the objects that may be set. For example, Instructions in FlatRedBall set a field/property at a given time, but they are built to work with **any** property regardless of whether it is a FlatRedBall type or not. Reflection enables this.

## Learning about reflection

The following articles cover topics related to reflection in C#:

-   [Introduction to reflection](http://csharp.net-tutorials.com/reflection/introduction/)
-   [Setting and Getting Properties](http://odetocode.com/Articles/288.aspx)
