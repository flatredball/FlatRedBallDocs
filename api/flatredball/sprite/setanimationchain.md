# setanimationchain

### Introduction

The SetAnimationChain method sets the Sprite's current [AnimationChain](../../../../frb/docs/index.php).

### SetAnimationChain(AnimationChain chainToSet, double timeIntoAnimation)

This method can be used if the to set both the AnimationChain as well as how far into the AnimationChain the Sprite should set itself. The overload for SetAnimationChain which takes a double as a second argument sets how far into the argument chainToSet the Sprite beings animatingn after this call is made. For example, if the chainToSet has [AnimationFrames](../../../../frb/docs/index.php) of length .1, then passing a value of .25 will set the Sprite's CurrentFrameIndex to 2, and the [AnimationFrame](../../../../frb/docs/index.php) at index 2 will show for .05 seconds instead of the full .1 seconds. Setting a value of 0 will make the Sprite start the animation at the beginning. If a value of less than 0 is passed as the timeIntoAnimation, the SetAnimationChain method will throw an exception. If a value that is greater than the argument chainToSet's [TotalLength](../../../../frb/docs/index.php), the [TotalLength](../../../../frb/docs/index.php) of the chainToSet will be continually subtracted from timeIntoAnimation until the resulting value is less than the [TotalLength](../../../../frb/docs/index.php) value. Then the remainder will be applied. This simulates cycling the animation.
