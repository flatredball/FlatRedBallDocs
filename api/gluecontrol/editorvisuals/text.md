# Text

### Introduction

The Text method draws text usign the argument string at the argument position.

### Code Example: Drawing the Current Screen Time

```csharp
EditorVisuals.Text(
    $"Time since screen started: {TimeManager.CurrentScreenTime:0.00}", Vector3.Zero);
```

<figure><img src="../../../.gitbook/assets/04_19 21 11.png" alt=""><figcaption><p>Text method rendering text to the screen</p></figcaption></figure>
