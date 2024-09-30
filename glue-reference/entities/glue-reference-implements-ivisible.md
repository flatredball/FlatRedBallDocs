# Implements IVisible

### Introduction

The Implements IVisible property controls whether an entity implements the IVisible property. If true the following is performed by the FlatRedBall Editor:

* The Entity implements the IVisible interface
  * The Visible property is available in code
  * Children of the entity will be hidden if instances of the entity have their Visible property set to false
* The entity provides the Visible variable for tunneling and assignment per-instance

<figure><img src="../../.gitbook/assets/migrated_media-ImplementsIVisibleGeneralExample.png" alt=""><figcaption></figcaption></figure>

### What is "IVisible"?

IVisible is a code interface defined in FlatRedBall. This interface primarily provides a Visible property. For information on working with IVisible in code, see the [IVisible page](../../api/flatredball/graphics/ivisible/).

### Common Usage
