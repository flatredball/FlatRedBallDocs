# addlayer

### Introduction

The AddLayer method allows the addition of Camera-specific [Layers](../../../../frb/docs/index.php). For more information on how [Layers](../../../../frb/docs/index.php) sort, see the [Object Sorting](../../../../frb/docs/index.php) wiki entry.

### Method Signatures

AddLayer() instantiates a new Layer and adds it to the Camera's internal list of Layers, at the end (to be drawn on top of all other contained Layers). AddLayer(Layer layerToAdd) adds an existing Layer instance to the calling Camera. This Layer cannot be part of any other Cameras or this method will throw an exception.
