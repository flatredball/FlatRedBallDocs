# addtomanagers

### Introduction

The AddToManagers method adds all contained elements in the calling Scene to their appropriate managers. Since a Scene can contain [Sprites](../../../../frb/docs/index.php), [Text objects](../../../../frb/docs/index.php), and [PositionedModels](../../../../frb/docs/index.php), this method can add objects to more than one manager. This method is most often called after a Scene is loaded through [FlatRedBallServices](../../../../frb/docs/index.php).

### Method Signatures

#### public void AddToManagers()

Adds the contained elements to their respective managers so they draw in the regular non-layered space.

#### public void AddToManagers(Layer layer)

Adds the contained elements to their respective managers for management and to the argument [Layer](../../../../frb/docs/index.php) for drawing.
