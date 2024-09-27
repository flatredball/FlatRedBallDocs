# PositionedObjectList

### Introduction

PositionedObjectLists (also referred to as lists) in the FlatRedBall Editor hold lists of objects which inherit from the PositionedObject type. Positioned objects include:

* Any Entity (the most common types of lists)
* Circles
* AxisAlignedRectangles
* Texts
* Sprites

In code all of the objects mentioned above inherit from the [FlatRedBall.PositionedObject](../../../api/flatredball/positionedobject/) class.

The most common place for lists is in GameScreen, although lists can exist in any screen and even in other entities.&#x20;

### Entity List Behavior

As shown below, when an entity is created, the FlatRedBall suggests creating a list in GameScreen as well as adding a factory for the list. This configuration enables the following common and useful behaviors and relationships:

* Entity lists automatically associated themselves with factories, so that creating a new instance through a factory in code results in the instance being added to the list.
* Entity lists call Activity on all contained instances, keeping activity behavior consistent whether the instance is created in the FRB editor or at runtime (such as through a factory)
* Entity lists automatically destroy all instances when the screen ends, making screen cleanup easy
*

### Default Functionality - Automatically Created Lists in GameScreen

By default the FRB Editor creates lists for newly-created entities if the default options are left unchanged. For example, the following animation shows the creation of an entity called Enemy which also results in an EnemyList added to GameScreen.

<figure><img src="../../../.gitbook/assets/04_10 15 42.gif" alt=""><figcaption><p>Creating an Enemy entity automatically creates an EnemyList in GameScreen</p></figcaption></figure>

### Creating a PositionedObjectList Manually

The FlatRedBall Editor provides a number of ways to create new lists.

#### Option 1 - Add List to GameScreen Quick Action

If your game has a GameScreen, and if your GameScreen does not already contain a list for an entity, then the Quick Actions tab shows a button to add a list to the GameScreen. Clicking this button creates a new list in the GameScreen.

<figure><img src="../../../.gitbook/assets/04_10 18 01.gif" alt=""><figcaption><p>The Quick Actions tab includes a button to add lists to the GameScreen</p></figcaption></figure>

#### Option 2 - Right-Click Drag+Drop

Entity lists can be created by right-click drag+dropping an entity into a screen. This is useful if you are adding lists of entities to screens other than the GameScreen.

<figure><img src="../../../.gitbook/assets/04_10 20 33.gif" alt=""><figcaption><p>Right-click drag+drop to add a new list to a screen</p></figcaption></figure>

#### Option 3 - Right-click Add Object Menu

PositionedObjectLists can also be created through the regular right-click menu in an screen or entity's **Objects** node:

1. Right-click on **Objects**
2. Select **Add Object**
3. Make sure **FlatRedBall or Custom Type** is selected
4. Select **PositionedObjectList\<T>**
5. Select the type of list to create using the dropdown
6.  Enter the name of the list

    ![New Object window for adding a new list to a screen](<../../../.gitbook/assets/04\_10 22 25.png>)

### Adding to a List

Once a list has been created, instances of the list's type can be added through the FRB Editor using a number of methods.

Option 1 - Drag+drop onto Screen, Objects folder or List

If a list contains a screen, it becomes the _default container_ for newly-created instances that are added by drag+drop. For example, the following shows enemies being added to the EnemyList by drag+dropping an enemy on Level1, Level1's Objects folder, and directly on the EnemyList.

<figure><img src="../../../.gitbook/assets/04_10 25 07.gif" alt=""><figcaption><p>Enemies being added through drag+drop in Level1</p></figcaption></figure>

Option 2 - Right-click, Add Object

Objects can be directly added to the list by right-clicking on the list. Notice that the Add Object window restricts the types of entities which can be added to the types that are supported by the list. For example, the following animation shows how to add an Enemy to an Enemy list with the right-click menu.

<figure><img src="../../../.gitbook/assets/04_10 27 35.gif" alt=""><figcaption><p>Lists provide a right-click option to add entity instances</p></figcaption></figure>

If the list is of a base type, then the right-click option provides all available options for the list. For example, the following is a screenshot from a game which has multiple entity types inheriting from Enemy:

<figure><img src="../../../.gitbook/assets/image (4) (1).png" alt=""><figcaption><p>New Object window also includes all derived entity types</p></figcaption></figure>



### CallActivity

The CallActivity property controls whether the FRB Editor should generate Activity calls for a PositionedObjectList. By default this value is set to true. For example, the following shows a BulletList inside a screen which has its CallActivity set to true:

<figure><img src="../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>CallActivity set to true on a BulletList</p></figcaption></figure>

If this value is changed to false, then the Bullet instances inside of BulletList would not have their Activity (and CustomActivity) methods called automatically in generated code.

The most common reason to set this value to false is when dealing with derived entity lists. For example, consider a game which has a base Enemy entity as well as Skeleton entity which inherits from Enemy (Skeleton is an Enemy variant). If the game needs to perform custom logic on Skeleton instances then it may need both an EnemyList and SkeletonList in GameScreen.

<figure><img src="../../../.gitbook/assets/image (2) (1) (1) (1).png" alt=""><figcaption><p>SkeletonList with CallActivity set to false</p></figcaption></figure>

In this case, Skeletons which are created through the Skeleton factory would be added to both the EnemyList and the SkeletonList. If both EnemyList and SkeletonList called Activity, then Skeleton instances would have activity called twice per frame. This can result in unexpected behavior such as movement logic being applied twice per frame.

If a derived entity type list is added to a screen through the quick action button, FlatRedBall automatically sets CallActivity to false.

<figure><img src="../../../.gitbook/assets/image (3) (1) (1).png" alt=""><figcaption><p>Quick action button to add a SkeletonList to GameScreen</p></figcaption></figure>

If an entity list is added through the right-click option on a screen, FlatRedBall provides suggestions about whether to call Activity.

<figure><img src="../../../.gitbook/assets/image (4) (1) (1).png" alt=""><figcaption><p>FlatRedBall providing the suggestion to set CallActivity as false (unchecked)</p></figcaption></figure>
