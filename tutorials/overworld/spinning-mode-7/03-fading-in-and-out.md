# Fading In and Out

### Introduction

The previous tutorial ended with the camera falling and rotating in a way similar to the falling sequence in ActRaiser. In this tutorial we'll be adding fading in and fading out using Gum.

### Adding a Gum Screen

We will be using Gum to fade our screen in and out by overlaying a black colored rectangle with animated alpha. As an alternative we could also fade the screen by creating an overlay Sprite in FlatRedBall. Gum will resolve a few problems for us automatically, such as not having to worry about positioning our overlay Sprite so it always sits in between the camera and world Sprite. To add Gum, click the **Add Gum Project** button in the **Quick Actions** tab.

![](../../../.gitbook/assets/2021-03-img\_60552fdf61f13.png)

Normally Gum screens will be created whenever adding a new Glue screen, but we already have an existing Glue screen that was created before adding the Gum project. We can add a Gum screen:

1. Expand the Screens folder
2. Right-click on the Mode7Screen
3. Click **Create New Gum Screen for Mode7Screen**

![](../../../.gitbook/assets/2021-03-img\_60553140f2f4b.png)

Now we can open the Gum project by clicking on the Gum icon in the toolbar.

![](../../../.gitbook/assets/2021-03-img\_605531c52bb05.png)

Our Gum project will have a Screen called Mode7ScreenGum.

![](../../../.gitbook/assets/2021-03-img\_605532074aee8.png)

### Adding Overlay Rectangle

To add an overlay ColoredRectangle:

1. Expand the **Standards** folder
2. Drag+drop the **ColoredRectangle** type onto the **Mode7ScreenGum**
3. Rename the newly-created ColoredRectangle to \*\*OverlayRectangle

<figure><img src="../../../.gitbook/assets/2021-03-2021_March_20_123824.gif" alt=""><figcaption></figcaption></figure>

\*\*

4.  Change the color of the rectangle to Black (Red, Green, and Blue values set to 0)

    ![](../../../.gitbook/assets/2021-03-img\_60563e6835b96.png)
5. Click the **Alignment** tab
6.  Change the Dock to fill

    ![](../../../.gitbook/assets/2021-03-img\_60563ed3c4915.png)

We now have a fully opaque black overlay in our game. If we run the game now, the black overlay will completely cover the spinning map.

![](../../../.gitbook/assets/2021-03-img\_60563f0c70776.png)

### Creating Opacity State Category

The fade-in and fade-out will be Gum animations. Since animations in Gum are created using states, so we must first create a state category and two states:

1. Right-click in the **States** list box
2.  Select **Add Category**

    ![](../../../.gitbook/assets/2021-03-img\_605642f083931.png)
3. Enter the category name **Opacity**. Avoid naming the category an existing name like **Alpha**
4.  Right-click on **Opacity** and select **Add State**

    ![](../../../.gitbook/assets/2021-03-img\_605642d75ab7c.png)
5. Enter the name **Opaque**
6.  Add another state and name it **Transparent**

    ![](../../../.gitbook/assets/2021-03-img\_6056431d4b313.png)

Notice that when a state is selected, Glue informs you that you are editing that particular state. Any change you make to the object when a state is selected will apply to the state, so be sure to only change properties that you want changed in the state. In our case, the only property we want to change in a state is the OverlayRectangle Alpha property:

1. Select the **Transparent** state
2. Verify **OverlayRectangle** is selected
3.  Change **Alpha** to 0

    ![](../../../.gitbook/assets/2021-03-img\_6056444888835.png)

The Opaque state automatically inherits the default value of 255, so no changes are needed on this state. We can see the two states by clicking on them and observing the change in the Editor window.

<figure><img src="../../../.gitbook/assets/2021-03-2021_March_20_124352.gif" alt=""><figcaption></figcaption></figure>

### Creating Gum Animations

The two states we created above (Opaque and Transparent) will be keyframes in our animations. We'll create our two animations next:

1.  Click **State Animation** -> **View Animations** to view/edit animations for Mode7ScreenGum

    ![](../../../.gitbook/assets/2021-03-img\_605645648f4c4.png)
2.  The Animations tab will appear in the bottom right tab view, so you may need to expand it to view animations

    ![](../../../.gitbook/assets/2021-03-img\_605645b4e1cd5.png)
3.  Click the **Add Animation** button

    ![](../../../.gitbook/assets/2021-03-img\_605645e4971e4.png)
4.  Enter the name **FadeIn** (no spaces) and click **OK**

    ![](../../../.gitbook/assets/2021-03-img\_6056460579189.png)
5.  Click the **Add State** button to add a keyframe to the animation

    ![](../../../.gitbook/assets/2021-03-img\_6056463c45c8e.png)
6.  FadeIn animation will begin Opaque and animate to Transparent, so select the **Opacity/Opaque** state first and click **OK**

    ![](../../../.gitbook/assets/2021-03-img\_60564680874fc.png)
7. The Opaque state will be added at time 0.00
8. Repeat the steps above to add the Transparent state

Gum adds the second keyframe at time 1.00, and we can use the play button to view the animation in the editor window.

<figure><img src="../../../.gitbook/assets/2021-03-2021_March_20_135102.gif" alt=""><figcaption></figcaption></figure>

Repeat the steps above to add a **FadeOut** animation. The first state should be **Opacity/Transparent**, and the second should be **Opacity/Opaque**.

![](../../../.gitbook/assets/2021-03-img\_605647cc4a7bf.png)

By default both of our animations are 1 second in length. The fade in and fade out in ActRaiser are much shorter, around .3 seconds. We can speed the animations up by changing the Time variable on the second state in both **FadeIn** and **FadeOut**.

<figure><img src="../../../.gitbook/assets/2021-03-2021_March_20_133208.gif" alt=""><figcaption></figcaption></figure>

### Playing Animation in Code

Now that our animations are defined in Gum, we can play them in code. The logic we will be implementing will perform the following:

* Begin playing the FadeIn animation. The camera should not be moving yet.
* Once the FadeIn animation finishes, the camera should begin falling and spinning.
* When the camera is close to the ground, the FadeOut animation should play.

We want the FadeOut animation to finish right when the camera reaches the ground. We will be using the length of the animations to decide when to start falling and when to start playing the FadeOut animation. We could either use await Task.Delay or we could use the built-in FlatRedBall method Call to delay the falling and fade out animation playing. We use Task.Delay for simplicity, but keep in mind that this approach will not respect slow-motion settings in Glue or changes to TimeManager.TimeFactor. Modify the Mode7Screen so it contains the following code:

```
public partial class Mode7Screen
{
    float fallingSeconds = 8.0f;

    async void CustomInitialize()
    {
        Camera.Main.Orthogonal = false;
        // default is 1000, increase this so the map doesn't clip when we move far away
        Camera.Main.FarClipPlane = 10000;
        // This is roughly the starting distance which mimics the real game
        Camera.Main.Z = 750;

        // The screen takes a little bit to load so let's wait a second before starting anything
        await Task.Delay(1000);

        Mode7ScreenGum.FadeInAnimation.Play();

        // The animation length is in seconds, so we need to multiply by 1000 to get milliseconds
        await Task.Delay((int)(Mode7ScreenGum.FadeInAnimation.Length * 1000));

        BeginCameraFalling();

        var secondsToWaitBeforeFadeOut = fallingSeconds - Mode7ScreenGum.FadeOutAnimation.Length;

        await Task.Delay((int)(secondsToWaitBeforeFadeOut * 1000));

        Mode7ScreenGum.FadeOutAnimation.Play();
    }

    private void BeginCameraFalling()
    {
        var secondsPerRotation = 5.0f;

        Camera.Main.Z = 750;
        Camera.Main.RotationZ = 0;
        Camera.Main.ZVelocity = -(Camera.Main.Z / fallingSeconds);
        Camera.Main.RotationZVelocity = MathHelper.TwoPi / secondsPerRotation;
    }

    void CustomActivity(bool firstTimeCalled)
    {
        Camera.Main.UpVector = Camera.Main.RotationMatrix.Up;
        if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Space))
        {
            BeginCameraFalling();
        }
    }

    // ...
```

Now when we run the game, it begins with a black screen which fades in, the camera falls, and before it hits the ground it fades back to black.

<figure><img src="../../../.gitbook/assets/2021-03-2021_April_06_181021.gif" alt=""><figcaption></figcaption></figure>

### Conclusion

While it may seem like we spent a lot of time creating simple fade-in and fade-out animations, becoming fluent with using Gum is worthwhile since it is so commonly in FlatRedBall development. Now that the animation is done, we're finished. Congratulations, you have created a screen similar to the ActRaiser falling animation scene!
