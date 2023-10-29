# qualifying-types

### Introduction

Have you ever read a tutorial on FlatRedBall which references a type, but the tutorial doesn't include the required "using" statement for qualifying that type? Or perhaps you've written code which referenced a type, but you couldn't remember what the entire namespace for that type was. Fortunately the Visual Studio team has thought of this problem.

### Example

Let's say you are programming and have decided to use the [InputManager](../../../frb/docs/index.php). Notice that if the class doesn't include a proper "using" statement, Visual Studio will complain: ![UnknownInputManager.png](../../../media/migrated\_media-UnknownInputManager.png) Notice that under the "r" of "InputManager" there is a small dark-red rectangle. This indicates that Visual Studio recognizes the type, but that it is not qualified. At this point, you can either move the mouse over the red rectangle, or press CTRL + . (that's CTRL and the period key): If clicked with mouse: ![MouseClickQualify.png](../../../media/migrated\_media-MouseClickQualify.png) If CTRL+.: ![ShiftF10Qualify.png](../../../media/migrated\_media-ShiftF10Qualify.png) If you select the first option (using FlatRedBall.Input;), then that "using" statement will automatically be added for you. If you select the second, then the namespace will be placed in front of your object. I generally prefer simply adding the using statement so I don't have to worry about any further qualifications for that type. ![QualifiedInputManager.png](../../../media/migrated\_media-QualifiedInputManager.png) Your class name will change color indicating that Visual Studio now recognizes the type.
