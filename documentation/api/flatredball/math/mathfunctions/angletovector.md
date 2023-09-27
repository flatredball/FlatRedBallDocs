## Introduction

AngleToVector converts a Radian value and returns a Vector3 pointing in the direction of that direction. Since a value of 0 points to the right, then AngleToVector will return a Vector of (1,0,0). As the angle increases the returned Vector3 will rotate clockwise.

The value returned from AngleToVector will equal a PositionedObject's RotationMatrix.Right given the same RotationZ.
