## Introduction

The Clone method can be used to create a copy of a given Polygon. A cloned polygon will be identical to the original polygon. Cloned polygons can be used if you are loading Polygons from a file and want to create multiple instances of a given Polygon. For example, you may create a Polygon (which we'll call attack Polygon) in the PolygonEditor. Whenever your character attacks, you may want to clone the attack Polygon and add the newly-created Polygon to a list of polygons in your Screen, which can be used to test collision against enemies.
