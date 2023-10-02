# tutorials-save-classes

### Introduction

If you've worked with FlatRedBall you may have come across "Save" classes. A Save class is a class that is designed to allow the user to save a runtime object to an XML file, as well as to load the XML and convert it back into a fully-functional runtime object. In other words, **Save classes are always serializable**. Save classes can be seen as the "middlemen" between runtime and XML. The Save class can be saved to XML by using simple .NET XML serialization or the serialization [offered by the FileManager](../../../frb/docs/index.php). FlatRedBall provides a number of Save classes which can be used to serialize common FlatRedBall types. The Save pattern can also be used to create your own custom file formats.

### Why have Save classes?

You may be wondering why Save classes are even needed. Why not simply save the runtime object (like an [Entity](../../../frb/docs/index.php) that you've created) directly to XML using an XML serializer. While that may be conceptually simpler (and from that point of view, superior) compared to using a Save class, there are a few significant problems related to simply serializing an object.

#### References are not preserved

References are very common relationships in games. For example, you may have a situation where you have one [Sprite](../../../frb/docs/index.php) attached to another [Sprite](../../../frb/docs/index.php). Or an even more common situation is where you have a [Sprite](../../../frb/docs/index.php) referencing a [texture](../../../frb/docs/index.php). References exist purely in RAM when it comes to runtime objects. As soon as you close your application, those references are no longer valid - even if you were to somehow get the memory address of the referenced objects and stuff them in your object. The Save class allows you to preserve relationships and re-establish them when objects are created. For example, the [SpriteSave](../../../frb/docs/index.php) class has the following member:

```
public string Parent;
```

When you create a [SpriteSave](../../../frb/docs/index.php) out of a [Sprite](../../../frb/docs/index.php) and the [Sprite](../../../frb/docs/index.php) has a parent, then the name of that parent is stored in the [SpriteSave's](../../../frb/docs/index.php) Parent member. When the engine loads a [Scene](../../../frb/docs/index.php), it can re-establish child/parent relationships between [Sprites](../../../frb/docs/index.php) by using this Parent member. Of course, this does require that all objects in a Scene have unique Names.

#### Some objects cannot be serialized

Consider a situation where you would like to serialize a group of [Sprites](../../../frb/docs/index.php). Each [Sprite](../../../frb/docs/index.php) has a [texture](../../../frb/docs/index.php)...but how should that [texture](../../../frb/docs/index.php) be serialized? Even if we could serialize it, it might not be a good idea. Many file formats use compression to keep their size down. Also, as mentioned before, multiple [Sprites](../../../frb/docs/index.php) might reference the same [texture](../../../frb/docs/index.php). You wouldn't want to serialize each reference, as the same data might be stored multiple times. In this case, a Save class would store the file name of any content that can be re-created from file. For example, the [SpriteSave](../../../frb/docs/index.php) class has the following member:

```
public string Texture;
```

The Texture member is used to store the file name of the texture referenced by the [Sprite](../../../frb/docs/index.php) that was used to make the [SpriteSave](../../../frb/docs/index.php).

#### Keeps things cross-platform

One of the coolest benefits of the Save pattern is that it can make your content cross-platform. When creating Save classes, we encourage you to not include platform-specific members. For example, instead of including a Vector3 in your SpriteSave class (a struct that may not be available in another library), you should store the individual X, Y, and Z components. The resulting XML will be far more cross-platform, which is an awesome benefit if you're considering porting your game to another platform at some time in the future.

### What goes in a Save class?

The Save class should provide ways to create a Save object from the runtime as well as a way to create the runtime object from the Save object. Optionally, you may want your Save class to save to XML and load from XML. Why is XML interfacing optional? The reason is because you may not intend for your Save class to be an object that can be directly saved, but rather an object that should be part of a larger Save object. For example, consider the [CircleSave](../../../frb/docs/index.php) class. We did not this class to be savable because saving a single [Circle](../../../frb/docs/index.php) to file does not seem like a very common activity. Therefore, the [CircleSave](../../../frb/docs/index.php) class has the following two methods:

```
public static CircleSave FromCircle(FlatRedBall.Math.Geometry.Circle circle)

public FlatRedBall.Math.Geometry.Circle ToCircle()
```

Notice that the FromCircle method is a static method. This method can be used to create a new instance of an object. This method is often also called "FromRuntime". On the other hand, some classes should directly interact with XML. The [ShapeCollectionSave](../../../frb/docs/index.php) class is an example. The ShapeCollection class has the following methods for interacting with XML:

```
public static ShapeCollectionSave FromFile(string fileName)

public void Save(string fileName)
```

The objects that the [ShapeCollectionSave](../../../frb/docs/index.php) has as members (such as [CircleSave](../../../frb/docs/index.php) and [PolygonSave](../../../frb/docs/index.php) ) are themselves Save classes, but they do not supply XML-interfacing methods.

### Creating your own Save class

The only requirements for a Save class, as mentioned above, is that the Save class can be created from a runtime object and can be used to create a runtime object. Interfacing with XML can be valuable, but it is not always needed. Remember, Save classes can contain other Save classes, and the ToRuntime method is usually fairly easy to write if your Save class contains other Save classes because all of the contained Save classes will themselves have a ToRuntime method. If you plan on including FlatRedBall objects in your runtime objects, then you will likely need to use FlatRedBall Save classes in your Save class. Nearly every object in FlatRedBall has an associating Save class. To find the appropriate Save class, look in the FlatRedBall.Content namespace.

### Content manager usage

Keep in mind that some objects may require a content manager to be properly instantiated. For example, the [SpriteSave](../../../frb/docs/index.php) creates [Sprites](../../../frb/docs/index.php) which likely have a [texture](../../../frb/docs/index.php). In this case, the Save class needs a content manager in its ToRuntime method. Even if your Save class doesn't necessarily use the content manager, you may still need a content manager argument to the ToRuntime if any other Save classes require it. For example, the [SpriteSave](../../../frb/docs/index.php) class has the following method:

```
public Sprite ToSprite(string contentManagerName)
```

If your Save object includes a [SpriteSave](../../../frb/docs/index.php), then your ToRuntime method will need to take a content manager argument.

### Additional Information

* [Custom Files and Content Pipelines](../../../frb/docs/index.php)
