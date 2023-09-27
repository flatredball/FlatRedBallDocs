## Introduction

Many platformers (exceptions include [Mega Man](http://en.wikipedia.org/wiki/Mega_Man) and [Contra](http://en.wikipedia.org/wiki/Contra_(video_game)) implement acceleration rather than an immediate application of velocity when the user presses a direction on the DPad or AnalogStick. In other words, the character will take time to speed up and slow down, rather than immediately moving fast and stopping. This article explains how to implement this.

## The concept of "desired" speed

When the user presses a particular direction on the control device (DPad or AnalogStick), this essentially is how the player tells the on-screen player how fast to move. This is a "desired" speed. However, the on-screen character may take some time to reach this speed. In a desired system, the control device does not directly control the movement of the on-screen character, but only its desired speed - the acceleration code will be used to modify the speed of the character.

## Calculating desired

The following code can be used to calculate the movement speed of your character. This code is meant to exemplify desired velocity, but not necessarily be the **only** solution. Feel free to modify coefficients and adapt the following code so it works in your particular game.

    // assuming gamePad is a valid Xbox360GamePad 
    const float speedCoefficient = 1; // increase this to move faster
    float desiredSpeed = gamePad.LeftAnalog.Position.X * speedCoefficient;

    float differenceFromDesired = desiredSpeed - character.XVelocity;
    const float epsilon = .1f; // this can be used to prevent "settling" bugs
    if(Math.Abs(differenceFromDesired) < epsilon)
    {
       character.XVelocity = desiredSpeed;
    }
    else
    {
       // This code can be modified considerably to give your game a different feel.  You may
       // consider snapping maximum accelerations, or perhaps adjusting this if the character is
       // trying to speed up vs. slow down.
       const float accelerationCoefficient = 1;
       character.XAcceleration = accelerationCoefficient * differenceFromDesired;
    }
