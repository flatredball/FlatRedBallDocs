# parentrotationchangesposition

### Introduction

The ParentRotationChangesPosition property controls whether a child IAttachable's absolute Position is modified by its Parent's rotation. By default this value is true, meaning that when an IAttachable's parent rotates, its absolute position will be calculated using its relative position as well as the parent's RelativeRotationMatrix.

### When to use ParentRotationChangesPosition

To understand when ParentRotationChangesPosition is a useful property, consider the following situation. A top-down tank game uses tanks which can rotate freely. Each tank should have a health bar shown above the tank. The health bar is attached to the tank for convenience; however when the tank rotates, the health bar moves around the tank. To keep the health bar above the tank regardless of the tank's orientation, the health bar's ParentRotationChangesPosition can be set to false. Also, setting the health bar's [ParentRotationChangesRotation](../../../../../frb/docs/index.php) is also probably needed in this situation.
