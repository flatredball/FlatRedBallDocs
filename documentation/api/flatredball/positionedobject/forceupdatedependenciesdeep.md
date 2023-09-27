## Introduction

ForceUpdateDependenciesDeep is a method which calls ForceUpdateDisependencies on all contained children. This method recursively calls itself on all contained Children, so it will update all children, grandchildren, etc. This method is not typically called in games and is only needed in rare cases.

## A note about performance

Just like [FlatRedBall.PositionedObject.ForceUpdateDependencies](/frb/docs/index.php?title=FlatRedBall.PositionedObject.ForceUpdateDependencies.md "FlatRedBall.PositionedObject.ForceUpdateDependencies") this method does not check if dependencies have already been updated already. Therefore this method can result in unnecessary calls to ForceUpdateDependencies.
