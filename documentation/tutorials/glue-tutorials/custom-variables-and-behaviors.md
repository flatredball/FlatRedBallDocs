## Introduction

Custom Variables are variables which can be added to a Screen or Entity to be used either in custom or generated code. There are three types of variables:

-   Exposed
-   Tunneled
-   New (custom)

Let's go through each type to show how they work. As a note for content creators, variables are the key to reusing your Entity instances, and very important when creating a user interface (UI).

## Exposed Variables

An exposed variable is actually not really a new variable, at least as far as programmers are concerned. Instead, exposed variables are simply a way to access variables which programmers already have access to. For example, all Entities can be positioned. This means they all have X, Y, and Z positions. In code, you simply have to change the X value of an Entity, and unless it is attached to another Entity, it will be repositioned.

You can expose the X, Y, and Z (among many other) variables in Glue so that you can modify entities.

### Why aren't all variables exposed by default?

You may be wondering why you have to go through the trouble of manually exposing variables like X, Y, and Z on an entity. There are a number of reasons for this:

1.  Exposing all variables would greatly increase clutter in Glue. Explicitly exposing variables keeps the Glue UI much cleaner than it normally would be. As you'll find later, a large variable set can make setting variables and creating States difficult.
2.  Exposed variables are always set by Glue whenever an instance is created or recycled. While adding a few variables will have an almost insignificant impact on performance, if every object set every exposed variable on creation and recycling, this may have an (unnecessary) impact on the performance of the game.
3.  Glue encourages "object oriented" design. One of the principles is encapsulation and providing as simple of an interface as possible. In other words, an Entity that only exposes the variables that should be modified is much easier to work with than an Entity that exposes every variable. This is the principle behind real-world interfaces too. Imagine if instead of just turning the key or pushing a button to start your car, it exposed all of the inner workings of how the car started, and it allowed you to modify it. While this may be useful for "power users" (such as mechanics), an over-exposed object usually just introduces the opportunity for error.

### Adding an Exposed Variable

To add an exposed variable:

1.  Expand your Character Entity.
2.  Right-click on the Variables tree item and select "Add Variable"![GlueAddVariable.png](/media/migrated_media-GlueAddVariable.png)
3.  Notice that the "Expose Existing" tab is selected by default.
4.  Use the drop-down to select the X variable![ExposeExistingX.png](/media/migrated_media-ExposeExistingX.png)
5.  Click the OK button

You should now have an X variable under your Character Entity, and it will have a default value of 0.![ExposedExistingXInList.png](/media/migrated_media-ExposedExistingXInList.png)

### Variables can have default and instance values

Whenever you create a variable in Glue, you can set a default value for it. This default value controls what all instances of a given Entity will have for that value. Of course, instances can overwrite their default value. In most cases you will want to overwrite the default value per-instance.

## Accessing a variable in an instance

Now that you've exposed an X variable in your Character Entity, you can modify the default X value as show in the image above, or you can modify the X variable on the instance in your Screen. To do this:

1.  Select your CharacterInstance object under your GameScreen
2.  Notice that it has an "X" property under the "Custom Variables" category![CustomVariableXInInstance.png](/media/migrated_media-CustomVariableXInInstance.png)
3.  This value is blank, meaning that it will use the default value. Enter a value such as 5 for the X value. If you ever want to revert to the default, simply right-click on the variable name and select "Set to Default"

If you run the game, you will now see that your object has moved 5 units to the right. Don't worry if your game looks different, I have removed the background from my Screen so we can focus on the Entity.

![InstanceVariableInGame.png](/media/migrated_media-InstanceVariableInGame.png)

## Tunneled Variables

Tunneled variables are similar to exposed variables, except they give you access to variables that belong to objects **inside** of a Screen or Entity. For example, in the previous section we showed how to move an Entity around. But what if we wanted to change the scale on the Sprite inside of the Entity. Entities themselves don't have size - at least until you add an object (such as a Sprite) which gives them size. That means that the size property is not a property of the Entity itself, but rather a property of the Sprite which belongs to the Entity.

This may seem confusing at first - if an Entity contains a Sprite, then isn't the size of the Sprite and the size of the Entity the same thing? Not quite. Imagine a situation where an Entity contains two Sprites (this is common). In that case, each Sprite would need to be independently sized - one size value wouldn't do because you may want to set the size of one Sprite to be larger than the other.

Let's look at an example of how to work with tunneled variables.

### Adding a tunneled variable

To add a tunneled variable:

1.  Expand your Character Entity.
2.  Right-click on the Variables tree item and select "Add Variable"
3.  Select the "Tunneling" tab![TunnelingTab.png](/media/migrated_media-TunnelingTab.png)
4.  Use the drop-down to select the Sprite object in your Entity![TunnelObjectSelection.png](/media/migrated_media-TunnelObjectSelection.png)
5.  Use the second drop-down to select the variable you want to change. We'll pick "ScaleX" (you will need to scroll through the list to find it)![TunnelingVariableSelection.png](/media/migrated_media-TunnelingVariableSelection.png)
6.  Glue will automatically name the variable for you. In this case, it will be named "VisibleRepresentationScaleX"
7.  Click the OK button

### Set proper defaults!

If you select the VisibleRepresentationScaleX variable that we just created, you'll notice that the default value is 0. This means that the Sprite in your Entity will be too small to see. Make sure to change the default to 1 (or some other valid value).

![TunnelingDefault.png](/media/migrated_media-TunnelingDefault.png)

### Changing the instance value

Now you can simply select your CharacterInstance inside of your GameScreen and you should see its "VisibleRepresentationScaleX" variable as an editable property. Change this value to 4.

![TunnelingOnInstance.png](/media/migrated_media-TunnelingOnInstance.png)

Now run the game and you should see your Character be much larger.

![TunnelingInGame.png](/media/migrated_media-TunnelingInGame.png)

### Why tunnel instead of changing the source content?

If you're familiar with the SpriteEditor, then you probably know that you can also change the scale of a Sprite there as well instead of through Glue. We also mentioned before that you want to do as much in content as possible, so why would you want to change the value in Glue instead of in the SpriteEditor?

The answer is because changes to source content (the .scnx in this case) apply to every instance of your Entity. But if you make changes to tunneled variables on the instance itself as we did in this demo, it will only impact this particular instance.

So in this particular case, changing the ScaleX on the CharacterInstance didn't make a lot of sense because it could have been done in the .scnx file, but consider a situation where you create a Button Entity which has a SpriteFrame and Text object. With tunneling you could change the size of the button and what the text says on an instance-by-instance basis...all through Glue. And with exposed position values, you could position, size, and set the text on buttons all in Glue. This approach is **very common** when building UI screens in Glue.

## New "custom" variables

The last category of variables is "new" variables. New variables are variables which do not exist as part of an Entity, Screen, or object inside an Entity or Screen. These are variables which make sense only in the context of your game, and which will need custom code to have any sort of impact on your game. In other words, these variables provide a way for Glue users to tune values used by the game's custom code.

If you are not a programmer, you will need to work with your programming team to hook up new variables. First we'll show how to create new variables in Glue, then we'll show how to use them in code.

### Creating a new variable

The process of creating new variables is almost the same as for creating exposed and tunneled variables. To create a new variable:

1.  Right-click on the Variables item
2.  Select the "Create New" tab![CreateNewTab.png](/media/migrated_media-CreateNewTab.png)
3.  Select a type for your variable. "float" represents a number with a decimal (such as 3.2), and it is selected by default. Set the name of the variable, such as "WalkSpeed". Spaces are not allowed, and capitalization is recommended.![NewVariableName.png](/media/migrated_media-NewVariableName.png)
4.  Press OK. Your variable will appear in the Variables list. You can edit it the same as any other variable.![NewVariableInList.png](/media/migrated_media-NewVariableInList.png)

## Using a new variable in code

When a new variable is added, a new field is added to the Screen or Entity class. You can use this variable in code just like you would any other variable. In fact, you can add a variable in Glue, then switch back to Visual Studio and you will immediately have access to the variable - even with auto-complete!

![IntellisenseAndNewVariables.png](/media/migrated_media-IntellisenseAndNewVariables.png)

If you ever find yourself creating coefficients for behavior in code, consider where that should be promoted to a variable in Glue. It gives you freedom as a programmer to be able to worry about the system while allowing the designers to tune behaviors without any conflict or possibility of them writing bad code.

## Don't over-define your Glue Elements

Since Glue allows you to create variables which are essentially identical to fields you would create in your class, you may be tempted to define all of your variables in Glue. We strongly recommend not doing this. As mentioned above, keep in mind that Glue is intended to provide a higher-level interface to your objects. Therefore, you should not add variables excessively to Glue to avoid defining them in code. You should add a variable to Glue:

-   If it makes sense that a designer would want to tweak this variable to change the behavior of an object
-   If the variable is used to define the object and not just as a temporary or logic-only variable. In other words, MaxHealth would be a proper variable to add to Glue, but CurrentHealth would definitely not be.

[To the next tutorial -\>](/frb/docs/index.php?title=Glue:Tutorials:Entity_Inheritance "Glue:Tutorials:Entity Inheritance")
