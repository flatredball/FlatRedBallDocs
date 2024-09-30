# DisplayText

### Introduction

The DisplayText property controls what a Text object will write to the Screen. The DisplayText property can be set to initially set what the Text will display, and it can be changed at any time. The DisplayText property should be used to change a Text's display instead of re-creating a new Text every frame or whenever the Text changes.

### Code Example

The following code shows how to display how much time has been running since the start of the game:

Add the following using statement:

```
using FlatRedBall.Graphics;
```

Add the following at class scope:

```
Text mText;
```

Add the following to Initialize after initializing FlatRedBall:

```
string initialDisplay = "0";
mText = TextManager.AddText(initialDisplay);
```

Add the following to Update:

```
mText.DisplayText = TimeManager.CurrentTime.ToString();
```

![TextDisplayText.png](../../../../.gitbook/assets/migrated\_media-TextDisplayText.png)
