# SecondsSince

### Introduction

The SecondsSince method can be used to detect how many seconds have passed since a given time. This method is often used in combination with the CurrentTime property.

Note that SecondsSince assumes that the value passed is in game time (using `TimeManager.CurrentTime` ) and not screen time ( `TimeManager.CurrentScreenTime` ). This method is rarely used. It is only needed if the amount of in-game time that has passed is greater than some value which may span mulitple screens.&#x20;

### Example - Using SecondsSince for Ability Cooldown

Note that this operation assumes that ability cooldown should persist between screens. If your game has abilities which cool down, but which reset when a screen changes (such as the player re-starting a level), then CurrentScreenSecondsSince should be used. However, if you would like cooldown to persist between multiple screens, you can use SecondsSince as shown in the following code:

```csharp
var isCooldownAvailable = TimeManager.SecondsSince(LastAbilityUsed);

if(isCooldownAvailable && AbilityInput.WasPressed)
{
  // Perform ability
  
  // Use CurrentTime, not CurrentScreenTime
  LastAbilityUsed = TimeManager.CurrentTime;
}
```
