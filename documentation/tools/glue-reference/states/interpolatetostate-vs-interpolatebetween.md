## Introduction

Glue automatically provides two methods for any Screen or Entity which includes multiple states: InterpolateToState and InterpolateBetween. Although both of these methods use similar concepts (interpolation using states) they have slightly different functionality. InterpolateToState is a function which requires only a single state argument and a time value. InterpolateToState is a function which continues to apply itself over time as specified by the time argument. InterpolateBetween is a one-time call which combines two states using a given interpolation value (which is between 0 and 1). It requires two states so that it can create an "in between" state.

## When to use InterpolateToState

InterpolateToState uses a "linear interpolation" which means that the values are changed at a constant rate. For example, if one state sets an object's X to 0 and another state sets it to 10, and you interpolate over the course of 1 second, then the object's X will change at 10 units per second for the entire second. InterpolateToState is useful if you want to perform some type of automatic state change over time. For example, you may tint a player Entity's Sprite to red when it gets hit, then interpolate back to the regular (non-tinted) color after being hit.

## When to use InterpolateBetween

InterpolateBetween is generally used in two situations. The first is if your states represent a range of values which your Entity or Screen can occupy, and which should persist until explicitly changed. The InterpolateBetween article gives an example of creating a health bar. The user's health bar should remain at a set value until the player either collects health items, or until the player is hit by an enemy. InterpolateBetween can also be used to perform advanced interpolation over time. This requires continually calling InterpolateBetween every frame, but passing a constantly changing value. This allows for the implementation of custom (non-linear) interpolation. InterpolateBetween also allows for the setting of values outside of the 0-1 range, which may or may not be desirable depending on the type of interpolation you are performing.
