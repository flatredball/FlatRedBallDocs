## Introduction

CustomActivity is a function which is part of every Screen and Entity. This is where you can place code that you would like to run every-frame. Examples of common logic in CustomActivity include:

-   Collision
-   Input
-   Checking for non-UI events such as a timer ending a level

CustomActivity is called by default by generated code, so it should never be called in custom code.

## Order of CustomActivity

A Screen's CustomActivity will always be called last relative to the Objects inside of it. More generally speaking, the children Objects of a Screen or Entity will have their CustomActivity called before the parent container. Objects in a Screen or Entity will have their CustomActivity called in the order in which they appear in Glue. In this example, the order of CustomActivity will be as follows:

1.  SubEntityInstance
2.  SubEntityInstance2
3.  SubEntityInstance3
4.  TestEntity
5.  Whatever contains TestEntity (like a Screen)

![SampleHierarchy.PNG](/media/migrated_media-SampleHierarchy.PNG)
