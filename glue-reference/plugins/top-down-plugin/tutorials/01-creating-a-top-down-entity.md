# 01-creating-a-top-down-entity

### Introduction

This tutorial shows how to create an entity which can be used as a top down entity. It requires understanding the basics of working with Glue including:

* Creating a Screen
* Creating an ntity
* Adding an Entity instance to a Screen
* Running a Glue project

### Creating an Entity

For this project we'll begin with a project with a single screen:

![](../../../../../../media/2020-02-img\_5e38eaf107295.png)

First we'll add an entity:

1. Right-click on entities
2. Select Add Entity
3. Give the entity a name like **TopDownEntity**
4. Check the **Circle** checkbox
5.  Check the **Is Top Down Entity** checkbox

    ![](../../../../../../media/2020-02-img\_5e38eb9ac7ae1.png)

Even though a Circle object is not necessary, we're going to add one to this Entity so we can see the Entity, and so we can add collision later.   Once your Entity is created:

1. Select the entity
2.  Click the Top Down tab

    ![](../../../../../../media/2020-02-img\_5e38ebec22283.png)

Notice that the entity already has a set of movement values called **Default**. These values can be used to modify the entity movement behavior.

### Adding an Entity to GameScreen

Now that our Entity is created and is a Top Down entity, we can add an instance to our \*\*GameScreen \*\*by drag+dropping the entity on the GameScreen item in Glue: 

<figure><img src="../../../../../../media/2020-02-2020\_February\_03\_213300.gif" alt=""><figcaption></figcaption></figure>

 If we run the game, the entity is in our game and can move around. If you have a game controller plugged in, then the analog and dpad move the entity. Otherwise, the W,A,S,D keys on the keyboard move the entity. 

<figure><img src="../../../../../../media/2020-02-2020\_February\_03\_213503.gif" alt=""><figcaption></figcaption></figure>


