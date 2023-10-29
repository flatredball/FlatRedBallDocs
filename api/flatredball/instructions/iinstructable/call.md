# call

### Introduction

The "Call" function is a function which can be used to delay the execution of code. The Call function is conceptually similar to the [Set function](../../../../../frb/docs/index.php), but it is more flexible, allowing you to use lambda expressions, anonymous delegates, and regular functions. The Call function is a great way to perform delayed actions and "scripting". Internally the Call function creates a [DelegateInstruction](../../../../../frb/docs/index.php) and adds it to the calling IInstructable. Most IInstructable implementations, such as Sprites, shapes, and Entities have automatic code to execute their instructions. Therefore, simply calling the Call.After methods will result in these objects performing the desired action at the given time. Custom implementations of IInstructable need to call their own instructions every-frame for instructions added through Call.

**Note:** This is an extension method. To use this, you will need to add:

```
using FlatRedBall.Instructions;
```

### Code Example

The following code shows how to call Emit on an Emitter after 2 seconds:

```
emitterInstance.Call(emitterInstance.Emit).After(2);
```

&#x20; Since all Entities are IInstructables, you can also call custom methods on Emitters as follows:

```
this.Call(this.SomeCustomFunction).After(2);
```

&#x20; Entities can even destroy themselves after a certain amount of time:

```
this.Call(this.Destroy).After(4);
```

&#x20; You can also use lambda expressions inside Call:

```
this.Call( () => this.X = 4 ).After(2);
```

&#x20; Lambdas can be used to call methods which require parameters:

```lang:c#
this.Call( () => this.TakeDamage(AmountOfDamage) ).After(3);
```

&#x20;   You can use larger lambda statements:

```
this.Call( () => 
{
    this.X = 4;
    this.Y = 3;
    this.RotationX = 4;
    EvenCallSomeMethodHere();
} ).After(2);
```

&#x20; Screens are also IInstructables meaning you can use the Call function on Screens:

```
// To move another screen after 5 seconds, you could add the following in your Screen's
// CustomInitialize:
this.Call( () => MoveToScreen(typeof(ScreenToGoTo)) ).After(5);
```

### Example Usage

Call can be used to cascade actions. For example, consider an Entity which has a number of things which need to happen when it dies. The "Die" function may look like this:

```
public void PerformDieActions()
{
   this.Call(FlashRed).After(1);
   this.Call(PlayDieSound).After(1.2);
   this.Call(StartFadingOut).After(1.5);
   this.Call(Destroy).After(2);
}
```

Note that the functions used in the Call function are omitted to keep the example short. This example assumes that FlashRed, PlayDieSound, and StartFadingOut are functions with no parameters, and that they are defined in the same class as PerformDieActions. Destroy is defined for you by Glue in every Entity.

### Call and Glue

Entities and Screens both implement IInstructable automatically, meaning you don't have to do any modification to your code to be able to use the Call function. Keep in mind that since the Call function is an "extension method", you will need to use the "this" prefix to have access to the Call function if you intend to use Call on a Screen/Entity inside of its own custom code.

### Call creates Instructions

The Call function is a shorthand way to call a function through instructions. The Call function itself doesn't introduce any new functionality that isn't already available to the IInstructable interface; it just simplifies the syntax. Therefore, when you use the Call method, internally this creates an instruction. This can be verified:

```
// Assuming "this" is an IInstructable (like an Entity)
this.Instructions.Clear(); // Instruction count will now be 0
this.Call(SomeFunction).After(1);
if(this.Instructions.Count != 1)
{
    throw new Exception("This will not ever be hit");
}
```

### Instruction owner vs. called function owner

The simplest scenario for using Call is within an IInstructable-implementing object (such as an Entity). For example:

```
this.Call(Destroy).After(1);
```

In this case, the object containing the code (this) will hold the instruction, and the Destroy function will be called on "this" as well. However, you can call code that belongs to other objects. For example, if you have a list of Entities which should be destroyed in one second:

```
for(int i = 0; i < ListOfEntities; i++)
{
    var objectAtI = ListOfEntities[i];
    objectAtI.Call(objectAtI.Destroy).After(1);
}
```

In this case, the objectAtI is both the object that will contain the instruction, and it will also be the object that will be destroyed. If possible, it is recommended that the object that owns the function passed to Call should also be the object that is performing the call. In other words:

```
 This should be the same...
 |        as this                
 |              |
 V              V
 objectAtI.Call(objectAtI.Destroy).After(1);
```

Of course, this may not always be possible. For example, an Entity may contain an object which is not IInstructable. In that case, the Entity should "own" the instructions. In other words, this is okay:

```
// assuming "this" is an IInstructable, but someNonIInstructableObject is not
this.Call(someNonIInstructableObject.MethodToCall).After(1);
```
