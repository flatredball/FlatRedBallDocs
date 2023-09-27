## Introduction

Most FlatRedBall files can be used to display something graphical in your game. For example Scene (.scnx) files can be used to display Sprites, Text, and SpriteFrames. However, for an object to be drawn it must be added to the FlatRedBall engine.

## Automatic adding of files to managers in Screens

In the simplest (and most common) cases, adding objects from files to your game is very simple. The simplest case is when a file (such as a .scnx file) is part of a Screen. In this case the file will automatically show up in your game and in GlueView with no additional changes needed. In other words, if you simply add a .scnx file to a Screen, it should show up automatically in your Screen and in your game.

## Adding of files to managers in Entities

Entities behave slightly differently from Screens. For a file which has been added to an Entity to appear, it must have an Object which references it. Most of the time Glue will ask you if you want to create an accompanying Object for new files - if you click the default Yes, then the file will automatically appear in your Entity.
