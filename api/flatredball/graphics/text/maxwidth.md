# MaxWidth

### Introduction

The MaxWidth value controls the available area that the Text object can render text inside. The Text object will either wrap or clamp text according to its [MaxWidthBehavior](../../../../frb/docs/index.php).

### Code Example

```
 Text text = TextManager.AddText("");
 text.DisplayText = "Hello, I am some really long text that will wrap";
 text.MaxWidth = 60;
 text.MaxWidthBehavior = MaxWidthBehavior.Wrap;
```

![WrappingText.PNG](../../../../.gitbook/assets/migrated\_media-WrappingText.PNG)
