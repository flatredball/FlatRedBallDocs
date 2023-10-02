# glue-reference-setbyderived

### Introduction

SetByDerived is a variable that allows derived Entities to access variables defined in a base Entity. Once a variable is SetByDerived, any Entities that derive from the given Entity (that is, use it as its [BaseEntity](../../../../frb/docs/index.php)) can set the variable to a different value.

When using inheritance, the derived Entity in code inherits from the base Entity, therefore all variables are available in custom code. The SetByDerived is only useful for exposing the variable in Glue.

### Usage Example

Consider a situation where your game has three Entities: Enemy, Ghost, and Zombie: ![ThreeEntities.PNG](../../../../media/migrated\_media-ThreeEntities.PNG) In this situation the Enemy entity is the base for Ghost and Zombie: ![ZombieBase.PNG](../../../../media/migrated\_media-ZombieBase.PNG) Notice that by default the Enemy's MovementSpeed variable is not part of Zombie or Ghost: ![NotSetInDerived.PNG](../../../../media/migrated\_media-NotSetInDerived.PNG) If the MovementSpeed in Enemy has its SetByerived value set to True, the variables will automatically appear in the Ghost and Zombie Entities: ![SetByDerived.PNG](../../../../media/migrated\_media-SetByDerived.PNG)
