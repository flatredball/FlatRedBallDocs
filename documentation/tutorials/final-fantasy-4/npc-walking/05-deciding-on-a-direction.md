## Introduction

This tutorial will explore the logic for deciding which direction to move. We'll spend extra time considering how multiple Npc instances consider their movement, and we'll propose a solution called reserve-then-move.

## Deciding a Direction With SolidCollision

In Final Fantasy 4, NPCs can move in one of four directions. If an NPC has free space in all four directions, then the NPC may choose to move in any of the four directions. ![](/media/2021-03-img_60581cd3a7145.png)   If the NPC is standing next to solid collision, then the movement directions are reduced to the directions which do not have any solid collision. For example, if the NPC has a tree to its left, then it can only move up, right, and down.![](/media/2021-03-img_60581d541a1d4.png)   So far the logic is not too complicated, but it does get more complex when we consider that Final Fantasy 4 towns can have multiple NPCs walking around and bumping into each other. This means that NPCs must also avoid other NPCs. For example, if two NPCs are standing next to each other, the NPC on the left cannot walk to the right.

![](/media/2021-03-img_605821c339ac5.png)

 
