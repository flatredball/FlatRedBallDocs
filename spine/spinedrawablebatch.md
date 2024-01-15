# SpineDrawableBatch

### Introduction

The SpineDrawableBatch class is responsible for drawing Spine in your FlatRedBall game. If you have used Tiled in your FlatRedBall projects, you can think of the SpineDrawableBatch as being similar to a Tiled Layer. In other words, the SpineDrawableBatch has the following characteristics:

1. It can be positioned explicitly, although this is typically done through attachments in generated code
2. It has a Z value which controls its sorting
3. It produces a new render break (this may change in the future)

By contrast, normally Tiled maps are added to Screens; however, SpineDrawableBatches are typically added to Entities.&#x20;
