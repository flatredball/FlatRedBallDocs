# AddLayer

### Introduction

The AddLayer method allows the addition of Camera-specific [Layers](layer.md).

### Method Signatures

AddLayer() instantiates a new Layer and adds it to the Camera's internal list of Layers, at the end (to be drawn on top of all other contained Layers).&#x20;

`AddLayer(Layer layerToAdd)` adds an existing Layer instance to the calling Camera. The argument Layer should not already already be a part of any other Cameras or this method throws an exception.
