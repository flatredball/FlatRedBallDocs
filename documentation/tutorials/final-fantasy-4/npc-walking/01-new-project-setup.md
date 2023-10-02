# 01-new-project-setup

### Introduction

This set of tutorials explores how to create NPC navigation similar to NPCs in Final Fantasy 4 (2 in the United States). NPCs in Final Fantasy 4 navigate a map by randomly selecting an adjacent tile which is unoccupied, then moving in that direction. This process repeats on a timer based which can differ based on the NPC - some move faster and some move slower. We will be creating a demo with NPCs navigating in a town following the rules mentioned above. The following video shows how NPCs navigate through the town. \[embed]https://youtu.be/QxodM4uWaC8?t=1374\[/embed] We'll start this tutorial with an empty project. Mine is called Ff2Npc.

### Glue Wizard

As usual we will run the Glue Wizard to prepare our project. We will leave most of the options to their default, but we will change the following:

#### GameScreen

* Uncheck **Add CloudCollision** - CloudCollision is only needed for platformers

#### Player Entity

* Uncheck **Add Player instance to list** - We won't have a player in this game, only NPCs

#### Levels

* Change **Number of levels to create** to 1 - We only need 1 level for this game

### Conclusion

We now have a project which is ready to be used. The next tutorial covers the creation of our map. &#x20;
