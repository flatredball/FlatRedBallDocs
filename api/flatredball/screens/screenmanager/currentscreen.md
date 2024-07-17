# CurrentScreen

### Introduction

The CurrentScreen property references the ScreenManager's current Screen. Only one Screen can be active at one time.

This property is set automatically by the ScreenManager when a new Screen is created. This can occur through:

* The [FlatRedBall.Screens.ScreenManager.Start](start.md) method
* The [FlatRedBall.Screens.Screen.MoveToScreen](../screen/movetoscreen.md) method
* The [FlatRedBall.Screens.Screen.IsActivityFinished](../screen/screen-isactivityfinished.md) property

The CurrentScreen property cannot be set directly. For more information on when the CurrentScreen is initially see the [FlatRedBall.Screens.ScreenManager.Start](start.md) method.

### When is CurrentScreen set?

Initially CurrentScreen is usually set in generated code by the FlatRedBall Editor according to the startup screen. After initial setting, any of the calls mentioned above can be used to change the CurrentScreen.

CurrentScreen is set internally by the ScreenManager after the Screen has been instantiated but before CustomInitialize has been called. Therefore, the CurrentScreen will always equal "this" in the CustomInitialize call.

The CurrentScreen will remain the same throughout a Screen's life, persisting through the CustomActivity and CustomDestroy calls.

Since the Screen has not yet been initialized, the CurrentScreen will not be set when a Screen's CustomLoadStaticContent method is called.
