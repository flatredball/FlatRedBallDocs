## Introduction

Variable naming is something which may seem like a very simple topic; however, the variable names you choose for your object can be very important. There are three types of variables in Glue:

1.  Exposed
2.  Tunneled
3.  Custom (under the "Create New" tab)

## Exposed Variables

The Exposed category of variables is simply the exposing of an existing variable. Because of this, the name of the variable is already set. In other words, there's not much point in discussing variable naming regarding Exposed variables because Exposed variable names can't be changed.

## Custom Variables

Custom variables are brand new variables which have no impact on an Entity or Screen, at least as far as Glue is concerned. The purpose of these variables is to "escalate access" of variables that are used in custom code. Usually the naming of these variables is fairly straight-forward. It's best to name these variables according to what they do. For example, if a variable is used to control how fast a character walks in game, then "Speed" or "WalkSpeed" are perfectly appropriate names.

## Tunneled Variables

Tunnled variables are the variables which deserve the most discussion about naming. The reason is because it may not be immediately obvious what the name of a variable should be. Let's consider a situation where you are creating an Entity called Button, and this Button uses a graphical object (such as a SpriteFrame) to display itself. You may want to allow each instance of Button to change its size independently, so you decide to tunnel in to the SpriteFrame's ScaleX and ScaleY properties. If you tunnel in to ScaleX and leave the default name, then the variable name will be the name of the SpriteFrame with "ScaleX" at the end. For example, if your SpriteFrame Object is named "SpriteFrameInstance" then the variable will be "SpriteFrameInstanceScaleX". What a long name! Length isn't the only problem with the variable "SpriteFrameInstanceScaleX". In this particular case, the variable is unnecessarily specific. That is, if your Button Entity only contains a SpriteFrame object and nothing else which can be scaled, then there's no need to name the variable "SpriteFrameInstanceScaleX"; the name "ScaleX" is sufficient. Of course, in a situation where you have multiple objects which you want to tunnel in to, it may be a good idea to keep the default name the same. For example, if you are creating a character that has a Sword and a Shield Object and you want to control the ScaleX of each individually, then SwordScaleX and ShieldScaleX are perfectly acceptable variable names. Since Glue doesn't understand the purpose of Entities or what objects you intend to add and tunnel in to, it can't predict whether it should prepend the name of the Object that is being tunneled into. Therefore it makes the safest assumption and suggests the more-specific name. It's up to you to click the "Advanced \>\>" button and change the name to be less specific if appropriate.
