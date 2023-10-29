## Introduction

The CustomActivity function is a function which is called once per frame (unless the entity is paused). The CustomActivity method is a private method which cannot be directly called, but it is called by an entity's Activity function.

## Order of CustomActivity calls

Any Entity which is part of Glue, or part of a PositionedObjectList in Glue will (by default) have its CustomActivity called automatically. Entities will have their CustomActivity methods called in the order that they appear in Glue. So if the structure of Entities is:

-   A
-   B
-   C

Then the order will be first A, then B, then finally C. Entities in a PositionedObjectList will have their CustomActivity called in the order that they exist in the PositionedObjectList. CustomActivity on all contained Entities will be called before the container calls its CustomActivity. In other words, if a Screen contains an instance of an Entity, then the Entity will have its CustomActivity called first, then the Screen will call its CustomActivity.
