## Introduction

Gum screens support animations which can be played through code. This article shows how to access a Gum animation and play it in your FlatRedBall project.

## Setup

To access a Gum screen in code you must first create an object in Glue for the Gum screen. For information on how to do this, see [this article](/documentation/tools/gum/gum-how-to-work-with-screens-in-code/.md "Gum:How To:Work with Screens in Code"). Animations can be defined in Gum or in code. To define an animation in Gum, see the [Gum Usage Guide](https://flatredball.gitbook.io/gum/animation-tutorials/creating-an-animation).

## Accessing animations in code

Animations added to Gum screens can be accessed in code. The Glue code generator will append the word "Animation" to animation names. For example, consider a Gum screen containing an animation called MoveToRight: ![MoveToRightAnimationInGum.PNG](/media/migrated_media-MoveToRightAnimationInGum.PNG) Then this animation can be accessed in code:

    // Assuming the object is called "GumScreen":
    GumScreen.MoveToRightAnimation.Play();

## Playing Animations on Component Instances

Similar to screens, components can also contain animations which can be played at runtime.  To play an animation on a component at runtime:

1.  Add an animation to a Gum component

2.  Obtain a reference to the component at runtime. For example, get a reference from a Gum screen in a Glue screen's Objects.

    ![](/media/2017-06-img_594c7ea4b26f7.png)

3.  Call the Play method on the desired animation within the component instance in code. For example, if the ButtonRuntime has an animation called FadeOutAnimation, the following code could be used to play the animation:

``` lang:c#
ButtonInstance.FadeOutAnimation.Play();
```

## GumAnimation Details

All animations are instances of the GumAnimation class, which provides useful variables, methods, and events.

### EndReached Event

The EndReached event is raised by the animation after the animation reaches its end (which is defined by its Length property). To use the EndReached event, you can add an Action to it, as follows:

``` lang:c#
void CustomInitialize()
{
    // Assign the event somewhere, like in CustomInitialize of a screen or entity:
    Button.FadeOutAnimation.EndReached += HandleEndReached;
}

// Implement the HandleEndReached method:
void HandleEndReached()
{
   // The animation ended, so do whatever, like play a sound
   BeepSound.Play();
}
```

   
