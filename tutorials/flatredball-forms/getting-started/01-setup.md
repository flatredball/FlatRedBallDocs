## Introduction

FlatRedBall.Forms is an easy-to-use UI library for games. This tutorial will walk you through setup of a game project including FlatRedBall.Forms.

## Creating a Glue Project

First we'll create a Glue project. If you already have a Glue project you can skip this section. To create a new project:

1.  Open Glue

2.  Select **File** -\> ****New Project****

    ![](/media/2023-03-img_6426482be48bd.png)

3.  Enter your project name and click **Create Project!**

    ![](/media/2023-03-img_64264855799bc.png)

4.  On the wizard, pick Standard Platformer, Standard Top Down, or Ui - any of those three will add FlatRedBall.Forms to your project.

    ![](/media/2023-03-img_6426489f8f6a0.png)

Now we have a project that is ready to go. Note that if you already have an existing FlatRedBall project, you can continue on the next step.

## Adding a Gum Project

If your project does not have Gum (such as if you skipped the wizard), you can it at any point. To do so:

1.  Click the Gum icon in Glue to add a new Gum project

    ![](/media/2023-03-img_6426496266e6b.png) Note that if you already have a Gum project, this icon will open the file in Gum

2.  Click the option to include forms

    ![](/media/2023-03-img_6426498fd5846.png)

## Adding a Button

If you either created your project through the wizard, then all FlatRedBall Screens have an associated Gum screen. In other words, you can start adding FlatRedBall.Forms to any existing screen. You can verify that your FlatRedBall Screens have an associated Gum screen by checking the Files folder and finding a file with the .gusx extension. For example, the GameScreen has an associated Gum screen in the following image.

![](/media/2023-03-img_64264a7009ae3.png)

If you open Gum, it will have a GameScreenGum screen. ![](/media/2018-03-img_5aadbd276a91c.png) To add a Button to your GameScreen:

1.  Expand the **Components** -\> **Controls **folder

2.  Drag+drop the **ButtonStandard** component onto the ****GameScreenGum**** or ****MainMenuGum**** (depending on which project type you created) ********

    ![](/media/2023-08-img_64d80cd2ef344.png)

The Button should now appear in the Gum.

![](/media/2023-08-img_64d80cf03468c.png)

Running the game will also show a fully-functional button. [![](/media/2017-11-12_16-52-55.gif)](/media/2017-11-12_16-52-55.gif)

## Gum vs Forms

If you have used Gum before (or if you have read the Gum tutorials), you may be wondering about the difference between Gum and Forms. A deep dive into this topic would be too long for this tutorial, but we will briefly look compare Gum and Forms using the project we just created earlier in this tutorial. As mentioned earlier, FlatRedBall.Forms is a UI library which provides common UI logic. For example, notice that our button instance automatically reacts to a moue hover and click. We didn't have to write any code to tell it to change its appearance. Technically FlatRedBall.Forms is a collection of classes which can modify Gum objects in response to a variety of interactions such as mouse hover, keyboard actions, an clicks. Gum components may or may not be represented as Forms objects at runtime depending on their behaviors as defined in Gum. All Forms objects have a backing Gum object, which is stored in their Visual property. By contrast, not all Gum objects are wrapped by Forms objects.

### Gum and Forms Buttons

To help understand the difference, let's take a look at the Gum button components. The default Gum project contains multiple Controls which begin with the word "Button".

![](/media/2023-08-img_64d8d16c133d1.png)

If any of these components are added as instances to a screen, they will be represented by the Button forms type. We can see this by adding an instance of each to our Screen and running the game. For example, consider the following screen:

![](/media/2023-08-img_64d8d1f013852.png)

Each instance in this screen is a different component type: ButtonClose, ButtonConfirm, and so on. However, if we access these buttons at runtime through the Forms property, they are all of type Button.

![](/media/2023-08-img_64d8d3074255c.png)

We can even go to the definition of our Forms object and see that all Buttons are of the same type.

![](/media/2023-08-img_64d8d33d39c49.png)

### Non-Forms Gum Components

Not all Gum components are represented as Forms controls. For example, the default Gum project contains a component named Icon which can be used to display one of a collection of standard icons in games.

![](/media/2023-08-img_64d8d45f87ad0.png)

If we add an instance of our Icon to GameScreen, we can see that the Forms object does not contain a property for IconInstance.

![](/media/2023-08-img_64d8d49d888ee.png)

Note that Visual Studio's auto complete does not provide a suggestion for IconInstance (but it does provide a suggestion for ButtonIconInstance, which is an instance of a Button).

![](/media/2023-08-img_64d8d4cee60a6.png)

We can still access the icon through the GumScreen property, which provides typed access to all Gum instances whether they are forms or not.

![](/media/2023-08-img_64d8d4f817666.png)

Ultimately, FlatRedBall decides whether a component should be in Forms or not depending on the Behaviors that the component implements. For example, all of our Button components implement the Button behavior.

![](/media/2023-08-img_64d8d5b3d8fff.png)

The presence of this behavior is all that is needed to mark a component as a Forms object. You can browse other components such as TextBox and ListBox to see the behaviors they implement as well. If you would like to create custom components which should be treated as Forms objects, you can add these behaviors to your controls as well.
