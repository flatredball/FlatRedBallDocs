## Introduction

Thanks for visiting the PolygonEditor wiki. This is the first in a series of tutorials discussing what the PolygonEditor is used for and how to use it. Before we get into doing things with the PolygonEditor, let's answer a few common questions about the PolygonEditor.

## What is the PolygonEditor used for?

The PolygonEditor is used to create and edit collections of 2D and 3D shapes. These collections are most commonly used to define areas and volumes used for collision detection and reaction.

The most common object created in the PolygonEditor is what is called a "collision map". Collision maps can define areas in a level which cannot be passed through. Although collision maps often define "solid" areas, they can also be used to define triggers for level behavior as well as areas that should have specific behaviors on the player, such as slowing him down or dealing damage over time.

The PolygonEditor supports loading scenes (.scnx files) so that collision maps can be easily and accurately created.

## What kind of files can the PolygonEditor edit and save?

The PolygonEditor is used to create and manipulate the following two types of files:

-   **plylstx** - The plylstx file extension stands for a Polygon List XML. This file format can contain a list of polygons. Keep in mind, this list can save **only polygons**. If you want to save any other types of files, use the shcx file format.
-   **shcx** - The shcx file extension stands for Shape Collection XML. This file format can contain every type of shape (Rectangles, Circles, Polygons, and so on). Use this file format if you are planning on using any of these shapes.

## Why does the PolygonEditor save both plylstx and shcx files?

There are two answers to this. The first is due to backwards compatibility. Initially, the only type of shape supported by FlatRedBall was the polygon. The plylstx file was the standard for saving polygons. Later, other shapes were added, and instead of making a special kind of list for each type, the shape collection save file was created to store all shapes including shapes that were to be added later.

The second is to give the user a choice on how data is to be constructed. Polygons can be less efficient than circles and rectangles; however, a list of polygons can be easier to manage than a list of mixed types.
