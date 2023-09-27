## Introduction

The SetByDerived property enables base screens/entities to define objects which will be assigned (instantiated) in derived screens/entities. Keep in mind that both the base and derived Object type must be the same. In other words, if the base screen/entity has a Sprite Object, then the Entity that derives from the base must also define the object as a Sprite.

## Why use SetByDerived

SetByDerived is usually set to true on objects which will ultimately come from a file in a derived class. The most common example in modern FlatRedBall games is the Map object in the GameScreen. By default, projects created with the Glue wizard contain a screen called GameScreen which contains a Map object.

![](/media/2021-09-img_614f297eaefcb.png)

In this case the GameScreen is defining that a Map object will exist, but it is not instantiating the Map object. Each derived level screen is responsible for instantiating the Map object. Typically this is done from a TMX file. In the following image, the Level1 Screen (which inherits from GameScreen) creates the Map using its Level1Map.tmx file.

![](/media/2021-09-img_614f2a5b045b5.png)

A general rule of thumb for SetByDerived is - set an object's SetByDerived to true if it will be assigned from a file in a derived class. In the case of the Map object, Glue should take care of this automatically. While other cases do exist, they are very rare in typical FlatRedBall development.

## SetByDerived makes an object "null"

If you set the SetByDerived property on an object to true, that means that Glue will not instantiate that object in the Screen or Entity that contains this Object in generated code. This Screen or Entity must be used as a base Screen or Entity to actually create an object. For example, consider an Entity called Character which contains a Sprite Object with **SetByDerived** set to **true**. The Sprite will not be created if you add an instance of Character to another Screen or Entity. The Character must be used as a base for another Entity (such as an Entity called "Monster").

## SetByDerived vs ExposedInDerived

These two properties may seem similar but each is used in a different scenario. SetByDerived is used if you want the derived screen/entity to control the *creation* of the object, such as assigning an object to the result of loading a file. ExposedInDerived is used if you want the derived screen/entity to have access to the object so that its properties can be changed, but the object is still ultimately instantiated in the base.

## Example

The following shows how to create an Entity (Base) which defines a Sprite Object which will get SetByDerived. The Derived then re-defines the Sprite.

### Creating a Base Entity

1.  Right-click on the  tree item

2.  Select ****Add Entity****

    ![](/media/2018-09-img_5b9683ae99d26.png)

3.  Name the entity **Base**

4.  Check the **Sprite** checkbox to add a Sprite to the Base entity

    ![](/media/2018-09-img_5b96841895b75.png)

5.  Click OK

### Creating a Derived Entity

1.  Right-click on the **Entities** tree item

2.  Select **Add Entity**

3.  Name the entity **Derived**

4.  Click **OK**

5.  Click the **Properties** tab on the newly-created **Derived** entity

6.  Set the **BaseEntity** property ****Entities\Base****

    ![](/media/2018-09-img_5b96850d87188.png)

**Base and Derived are bad names!** This example uses the names "Base" and "Derived" to clearly indicate the relationship between two Entities. In an actual game, avoid using names like **Base** and **Derived.** You should always name your Entities in a way to indicate what they are in the context of your game (such as Character or Enemy or PlayerShip). However, if you intend to use an Entity as a base type, it is a good idea to append "Base" at the end of the name (such as **EnemyBase**).

## Setting SetByDerived to True

1.  Expand the **Base** entity

2.  Select **SpriteInstance** (which was created earlier when the **Sprite** checkbox was checked)

3.  Select the **Properties** tab

4.  Set the SpriteObject's **SetByDerived** to ****True****

    ![](/media/2018-09-img_5b9685e153df0.png)

Glue will automatically add a SpriteInstance to the **Derived** entity.

![](/media/2018-09-img_5b96861f7c3c8.png)

Notice that objects which have their **SetByDerived** property to true appear blue in the tree view window, and objects which have their base implementation marked as **SetByDerived** appear yellow.

### Specifying Properties on Derived Sprite

At this point the Derived entity will automatically create a Sprite for you (since it is an object in Glue). You can select this Sprite and assign variables on it, just like any other Sprite.

![](/media/2018-09-img_5b96869b898a9.png)

## SetByDerived and Multiple Inheritance Levels

By default SetByDerived applies to only one level of inheritance, rather than cascading down through all levels of inheritance. For example, consider an example with three entities:

-   Base
-   Middle (which inherits from Base)
-   Derived (which inherits from Middle)

If Base defines SpriteInstance, and SpriteInstance has its SetByDerived to true, then the assignment to SpriteInstance will be done in Middle, and Derived will not be able to re-assign Sprite. Notice in the image above that SpriteInstance does not appear in the Derived entity.

![](/media/2021-08-img_612e3d6793be7.png)

However, the SetByDerived property can be set on the Middle SpriteInstance, and it will be assignable in Derived.

![](/media/2021-08-img_612e3e13aa857.png)
